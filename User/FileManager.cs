using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Data;

#nullable disable
namespace User {

    interface IInput {
        bool LookupAccount(string username, string password);
        string? LookupGlobalAttribute(string attributeName);
        (bool, TicketData) LookupTicket(string username);
        ClientData GetClientData(string username);
        List<TicketData> GetAllArchivedTickets(string username);
    }

    interface IOutput {
        bool ModifyAccountPassword(string username, string currentPassword, string newPassword);
        void CreateTicket(TicketData data);
        void ChangeTicketAttribute(string clientName, string attribute, string newValue);
        void UpdateDataAttributeForAccount(string attribute_name, string username, int to);
    }

    public sealed class FileManager : IInput, IOutput {
        
        private static string[] GetLinesFromFile(string targetFile) {
            string dataFolder = Constants.dataFolder;
            // da li postoji /Data folder
            if (Directory.Exists(dataFolder)) {
                string[] files = Directory.GetFiles(dataFolder);

                // provjera svakog fajla u /Data
                foreach (string file in files) {
                    string currentFile = new DirectoryInfo(file).Name;
                    // ako je fajl koji prelazimo u trenutnoj iteraciji petlje jednak trazenom
                    if (currentFile == targetFile) {
                        string[] lines = File.ReadAllLines(file);
                        return lines;
                    }
                }
            }
            return null;
        }

        private static bool CheckForAccountInFile(string clampedCreds, string username, string password) {
            string[] parts = clampedCreds.Split(":");

            return parts[0] == username && parts[1] == password;
        }
        
        private static string? GetAttributeName(string attributeString) {
            string[] parts = attributeString.Split("=");

            // npr. ulaz "ATTRIBUTE_NAME=Attribute_Value" vraca "ATTRIBUTE_NAME"
            return parts.Length != 2 ? null : parts[0];
        }

        private static string? GetAttributeValue(string attributeString) {
            string[] parts = attributeString.Split("=");

            // npr. ulaz "ATTRIBUTE_NAME=Attribute_Value" vraca "Attribute_Value"
            return parts.Length != 2 ? null : parts[1];
        }

        // IInput
        public bool LookupAccount(string username, string password) {
            string targetFile = Constants.clientAccountsFile;
            string[] lines = GetLinesFromFile(targetFile);

            if (lines != null)
                foreach (var line in lines)
                    if (CheckForAccountInFile(line, username, password))
                        return true;
            return false;
        }

        public string? LookupGlobalAttribute(string attributeName) {
            string targetFile = Constants.globalDataFile;
            string[] lines = GetLinesFromFile(targetFile);

            if (lines != null)
                foreach (var line in lines)
                    if (GetAttributeName(line) == attributeName)
                        return GetAttributeValue(line);
            return null;
        }

        public (bool, TicketData) LookupTicket(string username) {
            // ticketsFile
            string targetFile = Constants.ticketsFile;
            string key = Constants.commonAttributeLiterals["name"] + username;

            // default povratne vrijednosti
            (bool, TicketData) returnTuple = (false, Constants.ticketDataPlaceholder);

            string[] lines = GetLinesFromFile(targetFile);
            int linesSize = lines.Length;
            int linesToRead = Constants.ticketDataEntryLength;
            string[] relevantLines = new string[linesToRead];

            for (int i = 0; i < linesSize; i++) {
                string line = lines[i];
                // ako smo nasli trazenu liniju, citamo narednih N sa ostalim sadrzajem
                if (line == key) {
                    returnTuple.Item1 = true;
                    for (int j = 0; j < linesToRead; j++) {
                        string relevantLine = lines[i + j];
                        relevantLines[j] = GetAttributeValue(relevantLine);
                    }
                }
            }

            TicketData ticketData = new TicketData {
                ClientName = relevantLines[0],
                Title = relevantLines[1],
                Content = relevantLines[2],
                AssignedOperatorName = relevantLines[3],
                Status = relevantLines[4],
                OperatorResponse = relevantLines[5],
            };

            if (returnTuple.Item1)
                returnTuple.Item2 = ticketData;

            return returnTuple;
        }

        public ClientData GetClientData(string username) {
            string targetFile = Constants.clientDataFile;
            string[] lines = GetLinesFromFile(targetFile);
            string[] relevantLines = new string[Constants.clientDataEntryLength];

            for (int i = 0; i < lines.Length; i++) {
                string currentLine = lines[i];
                if (currentLine == Constants.commonAttributeLiterals["name"] + username) 
                    for (int j = 0; j < Constants.clientDataEntryLength; j++)
                        relevantLines[j] = GetAttributeValue(lines[i + j]);
            }

            return new ClientData {
                ClientName = relevantLines[0],
                FirstLogin = relevantLines[1],
                ConsentGiven = relevantLines[2],
            };
        }

        public List<TicketData> GetAllArchivedTickets(string username) {
            List<TicketData> res = new();

            string key = Constants.commonAttributeLiterals["name"] + username;
            string[] lines = GetLinesFromFile(Constants.archivedTicketsFile);
            for (int i = 0; i < lines.Length; i++) {
                if (lines[i] == key) {
                    TicketData currentTicketData = new();
                    string[] relevantLines = new string[Constants.ticketDataEntryLength];
                    for (int j = 0; j < Constants.ticketDataEntryLength; j++)
                        relevantLines[j] = GetAttributeValue(lines[i + j]);

                    currentTicketData.ClientName = relevantLines[0];
                    currentTicketData.Title = relevantLines[1];
                    currentTicketData.Content = relevantLines[2];
                    currentTicketData.AssignedOperatorName = relevantLines[3];
                    currentTicketData.Status = relevantLines[4];
                    currentTicketData.OperatorResponse = relevantLines[5];

                    res.Add(currentTicketData);
                }

            }

            return res;
        }
        // #IInput

        // IOutput
        public bool ModifyAccountPassword(string username, string currentPassword, string newPassword) {
            string dataFolder = Constants.dataFolder;
            string targetFile = Constants.clientAccountsFile;
            string writePath = Path.Combine(dataFolder, targetFile);
            string[] lines = GetLinesFromFile(targetFile);

            for (int i = 0; i < lines.Length; i++) {
                string currentLine = lines[i];
                if (currentLine == username + ":" + currentPassword) {
                    string newLine = username + ":" + newPassword;
                    lines[i] = newLine;
                    File.WriteAllLines(writePath, lines);
                    LoginForm.loggedInAccountPassword = newPassword;

                    return true;
                }
            }
            return false;
        }

        public void CreateTicket(TicketData data) {
            string dataFolder = Constants.dataFolder;
            string targetFile = Path.Combine(dataFolder,  Constants.ticketsFile);

            File.AppendAllText(targetFile, Constants.commonAttributeLiterals["name"]
                + data.ClientName + "\n");

            File.AppendAllText(targetFile, Constants.commonAttributeLiterals["title"] 
                + data.Title + "\n");

            File.AppendAllText(targetFile, Constants.commonAttributeLiterals["content"]
                + data.Content + "\n");

            File.AppendAllText(targetFile, Constants.commonAttributeLiterals["operator"] 
                + data.AssignedOperatorName + "\n");

            File.AppendAllText(targetFile, Constants.commonAttributeLiterals["status"]
                + data.Status + "\n");

            File.AppendAllText(targetFile, Constants.commonAttributeLiterals["response"] + 
                data.OperatorResponse + "\n\n");
        }

        public void ChangeTicketAttribute(string clientName, string attribute, string newValue) {
            string dataFolder = Constants.dataFolder;
            string targetFile = Constants.ticketsFile;
            string writePath = Path.Combine(dataFolder, targetFile);

            string[] lines = GetLinesFromFile(targetFile);
            string targetLine = Constants.commonAttributeLiterals["name"] + clientName;
            for (int i = 0; i < lines.Length; i++) {
                string line = lines[i];
                if (line == targetLine) {
                    for (int j = 0; j < Constants.ticketDataEntryLength; j++) {
                        string offsetLine = lines[i + j];
                        if (GetAttributeName(offsetLine) == attribute) {
                            lines[i + j] = attribute + "=" + newValue;
                            goto END;
                        }

                    }
                }
            }
        END:
            File.WriteAllLines(writePath, lines);
        }

        public void UpdateDataAttributeForAccount(string attributeName, string username, int to) {
            string dataFolder = Constants.dataFolder;
            string targetFile = Constants.clientDataFile;
            string writePath = Path.Combine(dataFolder, targetFile);
            string[] lines = GetLinesFromFile(targetFile);

            Debug.WriteLine("[{0}] calling update on {1} to {2}", username, attributeName, to);

            for (int i = 0; i < lines.Length; i++) {
                string line = lines[i];
                if (line == Constants.commonAttributeLiterals["name"] + username) {
                    for (int j = 0; j < Constants.clientDataEntryLength; j++) {
                        Debug.WriteLine("comparing: {0} <-> {1}", attributeName, GetAttributeName(lines[i + j]));
                        if (attributeName == GetAttributeName(lines[i + j])) {
                            Debug.WriteLine("FOUND!");
                            lines[i + j] = attributeName + "=" + to.ToString();
                            goto End;
                        }
                    }
                }
            }

        End:
            File.WriteAllLines(writePath, lines);
        }
        // #IOutput
    }
}
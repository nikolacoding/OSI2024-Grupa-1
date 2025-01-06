using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

#nullable disable
namespace User {

    interface IInput {
        bool LookupAccount(string username, string password);
        string? LookupAttribute(string targetFile, string attributeName);
        (bool, TicketData) LookupTicket(string targetFile, string username);
    }

    interface IOutput {
        bool ModifyAccountPassword(string username, string currentPassword, string newPassword);
        void CreateTicket(TicketData data);
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
            string targetFile = Constants.accountsFile;
            string[] lines = GetLinesFromFile(targetFile);

            if (lines != null)
                foreach (var line in lines)
                    if (CheckForAccountInFile(line, username, password))
                        return true;
            return false;
        }

        public string? LookupAttribute(string targetFile, string attributeName) {
            string[] lines = GetLinesFromFile(targetFile);

            if (lines != null)
                foreach (var line in lines)
                    if (GetAttributeName(line) == attributeName)
                        return GetAttributeValue(line);
            return null;
        }

        public (bool, TicketData) LookupTicket(string targetFile, string username) {
            // ticketsFile
            string dataFolder = Constants.dataFolder;
            string key = "CLIENT=" + username;

            // default povratne vrijednosti
            (bool, TicketData) returnTuple = (false, Constants.ticketDataPlaceholder);

            string[] lines = GetLinesFromFile(targetFile);
            int linesSize = lines.Length;
            int linesToRead = 5;
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
            };

            if (returnTuple.Item1)
                returnTuple.Item2 = ticketData;

            return returnTuple;
        }
        // #IInput

        // IOutput
        public bool ModifyAccountPassword(string username, string currentPassword, string newPassword) {
            string dataFolder = Constants.dataFolder;
            string targetFolder = Constants.accountsFile;
            string[] lines = GetLinesFromFile(targetFolder);

            for (int i = 0; i < lines.Length; i++) {
                string currentLine = lines[i];
                if (currentLine == username + ":" + currentPassword) {
                    string newLine = username + ":" + newPassword;
                    lines[i] = newLine;
                    string file = Path.Combine(dataFolder, targetFolder);
                    File.WriteAllLines(file, lines);

                    return true;
                }
            }
            return false;
        }

        public void CreateTicket(TicketData data) {
            string dataFolder = Constants.dataFolder;
            string targetFile = Path.Combine(dataFolder,  Constants.ticketsFile);

            Debug.WriteLine(targetFile);

            File.AppendAllText(targetFile, "CLIENT=" + data.ClientName + "\n");
            File.AppendAllText(targetFile, "TITLE=" + data.Title + "\n");
            File.AppendAllText(targetFile, "CONTENT=" + data.Content + "\n");
            File.AppendAllText(targetFile, "ASSIGNED_OPERATOR=" + data.AssignedOperatorName + "\n");
            File.AppendAllText(targetFile, "STATUS=" + data.Status + "\n\n");
        }
        // #IOutput
    }
}
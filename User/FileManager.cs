﻿using System;
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
    }

    interface IOutput {
        bool ModifyAccountPassword(string username, string currentPassword, string newPassword);
        void CreateTicket(TicketData data);
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
            string targetFile = Constants.globaldataFile;
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
            string key = Constants.clientDataAttributeLiterals["name"] + username;

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

        public ClientData GetClientData(string username) {
            string targetFile = Constants.clientDataFile;
            string[] lines = GetLinesFromFile(targetFile);
            string[] relevantLines = new string[Constants.clientDataEntryLength];

            for (int i = 0; i < lines.Length; i++) {
                string currentLine = lines[i];
                if (currentLine == Constants.clientDataAttributeLiterals["name"] + username) 
                    for (int j = 0; j < Constants.clientDataEntryLength; j++)
                        relevantLines[j] = GetAttributeValue(lines[i + j]);
            }

            return new ClientData {
                ClientName = relevantLines[0],
                FirstLogin = relevantLines[1],
                ConsentGiven = relevantLines[2],
            };
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

            Debug.WriteLine(targetFile);

            File.AppendAllText(targetFile, "CLIENT=" + data.ClientName + "\n");
            File.AppendAllText(targetFile, "TITLE=" + data.Title + "\n");
            File.AppendAllText(targetFile, "CONTENT=" + data.Content + "\n");
            File.AppendAllText(targetFile, "ASSIGNED_OPERATOR=" + data.AssignedOperatorName + "\n");
            File.AppendAllText(targetFile, "STATUS=" + data.Status + "\n\n");
        }

        public void UpdateDataAttributeForAccount(string attributeName, string username, int to) {
            string dataFolder = Constants.dataFolder;
            string targetFile = Constants.clientDataFile;
            string writePath = Path.Combine(dataFolder, targetFile);
            string[] lines = GetLinesFromFile(targetFile);

            Debug.WriteLine("[{0}] calling update on {1} to {2}", username, attributeName, to);

            for (int i = 0; i < lines.Length; i++) {
                string line = lines[i];
                if (line == Constants.clientDataAttributeLiterals["name"] + username) {
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
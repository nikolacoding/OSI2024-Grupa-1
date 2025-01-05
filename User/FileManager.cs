﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;
#nullable disable
namespace User {

    interface IInput {
        bool LookupAccount(string username, string password);
        string? LookupAttribute(string attributeName);
        (bool, TicketData) LookupTicket(string username);
    }

    interface IOutput {
        bool ModifyAccountPassword(string username, string currentPassword, string newPassword);
    }

    public sealed class FileManager : IInput, IOutput {
        public bool LookupAccount(string username, string password) {
            string targetFile = Constants.accountsFile;
            string dataFolder = Constants.dataFolder;

            // da li postoji /Data folder
            if (Directory.Exists(dataFolder)) {
                string[] files = Directory.GetFiles(dataFolder);

                // provjera svakog fajla u /Data
                foreach (string file in files) {
                    string currentFile = new DirectoryInfo(file).Name;
                    Debug.WriteLine(currentFile);

                    // ako je fajl koji prelazimo u trenutnoj iteraciji petlje jednak trazenom
                    if (currentFile == targetFile) {
                        string[] lines = File.ReadAllLines(file);

                        // provjeravamo svaku njegovu liniju i trazimo unesene kredencijale
                        foreach (var line in lines)
                            if (CheckForAccountInFile(line, username, password))
                                return true;
                    }
                }
            }
            return false;
        }
        
        public string? LookupAttribute(string attributeName) {
            string dataFolder = Constants.dataFolder;

            // otvara svaki fajl u Data folderu i trazi atribut naziva 'attributeName'
            if (Directory.Exists(dataFolder)) {
                string[] files = Directory.GetFiles(dataFolder);
                foreach (var file in files) {
                    string[] lines = File.ReadAllLines(file);
                    foreach (var line in lines) {
                        if (GetAttributeName(line) == attributeName)
                            return GetAttributeValue(line);
                    }
                }
                return null;
            }
            else {
                Debug.WriteLine("Data folder not found.");
                return null;
            }
        }

        public (bool, TicketData) LookupTicket(string username) {
            string dataFolder = Constants.dataFolder;
            string targetFile = Constants.ticketsFile;
            string key = "CLIENT=" + username;

            // default povratne vrijednosti
            (bool, TicketData) returnTuple = (false, Constants.ticketDataPlaceholder);

            // da li postoji /Data folder
            if (Directory.Exists(dataFolder)) {
                string[] files = Directory.GetFiles(dataFolder);

                // provjera svakog fajla u /Data
                foreach (string file in files) {
                    string currentFile = new DirectoryInfo(file).Name;
                    Debug.WriteLine(currentFile);

                    // ako je fajl koji prelazimo u trenutnoj iteraciji petlje jednak trazenom
                    if (currentFile == targetFile) {
                        string[] lines = File.ReadAllLines(file);
                        int linesSize = lines.Length;
                        int linesToRead = 5;

                        string[] relevantLines = new string[linesToRead];
                        // provjeravamo svaku njegovu liniju i trazimo kljuc
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
                    }
                }
            }
            return returnTuple;
        }

        public static bool CheckForAccountInFile(string clampedCreds, string username, string password) {
            string[] parts = clampedCreds.Split(":");

            return parts[0] == username && parts[1] == password;
        }
        
        public static string? GetAttributeName(string attributeString) {
            string[] parts = attributeString.Split("=");

            // npr. ulaz "ATTRIBUTE_NAME=Attribute_Value" vraca "ATTRIBUTE_NAME"
            return parts.Length != 2 ? null : parts[0];
        }

        public static string? GetAttributeValue(string attributeString) {
            string[] parts = attributeString.Split("=");

            // npr. ulaz "ATTRIBUTE_NAME=Attribute_Value" vraca "Attribute_Value"
            return parts.Length != 2 ? null : parts[1];
        }

        public bool ModifyAccountPassword(string username, string currentPassword, string newPassword) {
            string dataFolder = Constants.dataFolder;

            Debug.WriteLine("username: " + username + "; " +
                            "currentpassword: " + currentPassword + "; " +
                            "newpassword: " + newPassword);

            // otvara svaki fajl u Data folderu i trazi dati username
            if (Directory.Exists(dataFolder)) {
                string[] files = Directory.GetFiles(dataFolder);
                foreach (var file in files) {
                    string[] lines = File.ReadAllLines(file);
                    for (int i = 0; i < lines.Length; i++) {
                        string currentLine = lines[i];
                        if (currentLine == username + ":" + currentPassword) {
                            Debug.WriteLine("found: " + currentLine);
                            string newLine = username + ":" + newPassword;
                            lines[i] = newLine;
                            File.WriteAllLines(file, lines);
                            return true;
                        }
                    }
                }
            }
            else {
                Debug.WriteLine("Data folder not found.");
            }

            return false;
        }
    }
}

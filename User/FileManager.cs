using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User {

    interface IInput {
        bool LookupAccount(string username, string password);
        string? LookupAttribute(string attributeName);
    }

    interface IOutput { 

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
    }
}

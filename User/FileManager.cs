using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User {

    interface IInput {
        string? LookupAttribute(string attributeName);
    }

    interface IOutput { 

    }

    interface IAttributeParser {
        public string? GetAttributeName(string attributeString);
        public string? GetAttributeValue(string attributeString);
    }

    public sealed class FileManager : IInput, IOutput, IAttributeParser {
        public string? LookupAttribute(string attributeName) {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string projFolder = Path.GetFullPath(Path.Combine(baseDir, @"..\..\"));
            string dataFolder = Path.Combine(projFolder, "Data");

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
        
        public string? GetAttributeName(string attributeString) {
            string[] parts = attributeString.Split("=");

            // npr. ulaz "ATTRIBUTE_NAME=Attribute_Value" vraca "ATTRIBUTE_NAME"
            return parts.Length != 2 ? null : parts[0];
        }

        public string? GetAttributeValue(string attributeString) {
            string[] parts = attributeString.Split("=");

            // npr. ulaz "ATTRIBUTE_NAME=Attribute_Value" vraca "Attribute_Value"
            return parts.Length != 2 ? null : parts[1];
        }
    }
}

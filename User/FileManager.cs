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

    public sealed class FileManager : IInput, IOutput {
        public string? LookupAttribute(string attributeName) {
            string dataFolder = Constants.dataFolder;
            Debug.WriteLine(Constants.dataFolder);

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

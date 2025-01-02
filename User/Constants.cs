using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User {
    public sealed class Constants {
        private readonly FileManager fm = new();

        private static readonly string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string pathPrefix = @"..\..\..\..\";
        private static readonly string projFolder = Path.GetFullPath(Path.Combine(baseDir, pathPrefix));
        
        public static readonly string dataFolder = Path.Combine(projFolder, "Data");

        private readonly string consentTextPlaceholder = "Prije upotrebe korisničke " +
            "podrške za {0}, ja (korisnik) garantujem sljedeće:\r\n\r\n" +
            "1. Strpljenje\r\n" +
            "2. Opšte poštovanje i uljudnost prema operaterima\r\n" +
            "3. Razumijevanje politike privatnosti i gdje idu moji podaci\r\n" +
            "4. Razumijevanje vlastitih prava na žalbe i pohvale\r\n" +
            "5. Opšti razum";

        private readonly string mainFormTitlePlaceholder = "Korisnička podrška [{0}]";
        
        // Generalizovati ovo
        public string GetConsentText(string firmNameAttribute) {
            string? firmName = fm.LookupAttribute(firmNameAttribute);
            if (firmName == null) 
                return consentTextPlaceholder;
            else
                return string.Format(consentTextPlaceholder, firmName);
        }

        public string GetMainFormTitle(string firmNameAttribute) {
            string? firmName = fm.LookupAttribute(firmNameAttribute);
            if (firmName == null)
                return mainFormTitlePlaceholder;
            else
                return string.Format(mainFormTitlePlaceholder, firmName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User {
    public class Constants {
        private readonly FileManager fm = new();

        private readonly string consentText = "Prije upotrebe korisničke " +
            "podrške za {0}, ja (korisnik) garantujem sljedeće:\r\n\r\n" +
            "1. Strpljenje\r\n" +
            "2. Opšte poštovanje i uljudnost prema operaterima\r\n" +
            "3. Razumijevanje politike privatnosti i gdje idu moji podaci\r\n" +
            "4. Razumijevanje vlastitih prava na žalbe i pohvale\r\n" +
            "5. Opšti razum";

        private readonly string mainFormTitle = "Korisnička podrška [{0}]";
          
        public string GetConsentText(string firmNameAttribute) {
            string? firmName = fm.LookupAttribute(firmNameAttribute);
            if (firmName == null) 
                return consentText;
            else
                return string.Format(consentText, firmName);
        }

        public string GetMainFormTitle(string firmNameAttribute) {
            string? firmName = fm.LookupAttribute(firmNameAttribute);
            if (firmName == null)
                return mainFormTitle;
            else
                return string.Format(mainFormTitle, firmName);
        }
    }
}

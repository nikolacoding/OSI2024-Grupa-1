using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User {
    // mozda konvertovati u struct kasnije
    public sealed class Constants {
        private readonly FileManager fm = new();

        private static readonly string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string pathPrefix = @"..\..\..\..\";
        private static readonly string projFolder = Path.GetFullPath(Path.Combine(baseDir, pathPrefix));
        
        public static readonly string dataFolder = Path.Combine(projFolder, "Data");
        public static readonly string accountsFile = "UserAccounts.txt";
        public static readonly string globaldataFile = "GlobalData.txt";
        public static readonly string ticketsFile = "Tickets.txt";

        public static readonly int ticketTitleMaxChars = 30;
        public static readonly int ticketContentMaxChars = 250;

        private static readonly string consentTextPlaceholder = "Prije upotrebe korisničke " +
            "podrške za {0}, ja, {1}, garantujem sljedeće:\r\n\r\n" +
            "1. Strpljenje\r\n" +
            "2. Opšte poštovanje i uljudnost prema operaterima\r\n" +
            "3. Razumijevanje politike privatnosti i gdje idu moji podaci\r\n" +
            "4. Razumijevanje vlastitih prava na žalbe i pohvale\r\n" +
            "5. Opšti razum";

        private static readonly string windowTitlePlaceholder = "Korisnička podrška - {0}";

        public static readonly TicketData ticketDataPlaceholder = new TicketData {
            ClientName = "",
            Title = "Nema",
            Content = "",
            Status = "-",
            AssignedOperatorName = "-"
        };

        // Generalizovati ovo
        public string GetConsentText(string firmNameAttribute) {
            string? firmName = fm.LookupAttribute(globaldataFile, firmNameAttribute);
            if (firmName == null) 
                return consentTextPlaceholder;
            else
                return string.Format(consentTextPlaceholder, firmName, LoginForm.loggedInAccountUsername);
        }

        public string GetFormWindowTitle(string firmNameAttribute) {
            string? firmName = fm.LookupAttribute(globaldataFile, firmNameAttribute);
            if (firmName == null)
                return windowTitlePlaceholder;
            else
                return string.Format(windowTitlePlaceholder, firmName);
        }
    }
}

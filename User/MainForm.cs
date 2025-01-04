using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms.Design;
using System.Windows.Forms.VisualStyles;
using User;

using Data;
#nullable disable

namespace User {
    public sealed partial class MainForm : Form, Interfaces.IInitializable {
        // debug parametri za preskakanje prva dva prozora;
        // ocekuje se da ce finalna verzija zahtijevati (barem) prijavu pri svakom pokretanju
        private static bool consentGiven = true;
        private static bool isLoggedIn = false;

        // da li postoji aktivni tiket; potencijalno kreirati posebnu strukturu za dati tiket
        public static bool activeTicketExists = false;

        private readonly Constants constants = new();
        private readonly FileManager fm = new();

        // IInitializable
        public void SetDefaultWindowSettings() {
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void FillStaticConstants() {
            Text = constants.GetFormWindowTitle("FIRMNAME");
        }

        public void SetDefaultStates() {
            createTicketButton.Enabled = !activeTicketExists;
            respondButton.Enabled = false;
            archivedTicketsButton.Enabled = true;
            refreshButton.Enabled = true;
            accountNameLabel.Text = "Nalog: " + LoginForm.loggedInAccountUsername;
            DisplayTicketData();
        }
        // #IInitializable

        private void FailedLoginCloseOnStart(object sender, EventArgs e) => Close();

        private void DisplayTicketData() {
            (bool, TicketData) result = fm.LookupTicket(LoginForm.loggedInAccountUsername);
            TicketData ticketData = result.Item2;

            if (result.Item1) {
                ticketTitleLabel.Text = ticketData.Title;
                ticketContentLabel.Text = ticketData.Content;
                ticketStateLabel.Text = ticketData.Status;
            }
        }

        public MainForm() {
            // ako korisnik nije vec prijavljen, prikazati formu za prijavu
            if (!isLoggedIn)
                new LoginForm().ShowDialog();
            else
                LoginForm.loginSuccessful = true;
            // ^ else je za debug, koristi placeholdere za ime naloga

            // ako je korisnik neuspjesno prijavljen (najcesce forma za prijavu zatvorena na X),
            // dodati funkciju za zatvaranje koja se poziva po zavrsetku konstruktora
            if (!LoginForm.loginSuccessful)
                Load += FailedLoginCloseOnStart;
            else {
                // inace prikazati formu za saglasnost; ovo funkcionise na ovaj nacin jer, kao sto
                // sam naveo u komentaru iznad, konstrukcija se vrsi do kraja, a (ja mislim da)
                // instanca ConsentForm-a komunicira sa MainForm nakon sto se pozove lista funkcija
                // obuhvacena u Load, tako da ConsentForm pokusava da pristupi dealociranoj instanci
                // MainForm-a
                if (!consentGiven)
                    new ConsentForm().ShowDialog();
            }

            InitializeComponent();
            SetDefaultWindowSettings();
            FillStaticConstants();
            SetDefaultStates();

            accountNameLabel.Text = "Nalog: " + LoginForm.loggedInAccountUsername;
        }

        // "Napravi tiket" dugme
        private void createTicket_click(object sender, EventArgs e) {

        }

        // "Odgovori" dugme
        private void respondButton_Click(object sender, EventArgs e) {

        }

        // "Arhivirani tiketi" dugme
        private void archivedTicketsButton_Click(object sender, EventArgs e) {
            
        }

        // "Refresh" dugme
        private void refreshButton_Click(object sender, EventArgs e) {
            DisplayTicketData();
        }

        private void label2_Click(object sender, EventArgs e) { }
    }
}

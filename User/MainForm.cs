using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms.Design;
using System.Windows.Forms.VisualStyles;
using User;

using Data;
#nullable disable

namespace User {
    public sealed partial class MainForm : Form, Interfaces.IInitializable {

        private static bool firstLogin = false;
        private static bool consentGiven = true;

        // da li postoji aktivni tiket; potencijalno kreirati posebnu strukturu za dati tiket
        public static bool activeTicketExists = false;

        private readonly Constants constants = new();
        private readonly FileManager fm = new();

        private readonly Dictionary<string, System.Timers.Timer> activeTimers = new();

        private enum TicketStates {
            NO_TICKETS,
            TICKET_OPEN,
            TICKET_ASSIGNED,
            TICKET_RETURNED,
        };

        // IInitializable
        public void SetDefaultWindowSettings() {
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void FillStaticConstants() {
            Text = constants.GetFormWindowTitle();
        }

        public void SetDefaultStates() {
            DisplayTicketData();
            archivedTicketsButton.Enabled = 
                fm.GetAllArchivedTickets(LoginForm.loggedInAccountUsername).Count > 0;

            refreshButton.Enabled = true;
            accountNameLabel.Text = "Nalog: " + LoginForm.loggedInAccountUsername;
            autoRefreshCheckBox.Checked = true;
            refreshButton.Enabled = !autoRefreshCheckBox.Checked;
        }
        // #IInitializable

        public MainForm() {
            Login();

            InitializeComponent();
            SetDefaultWindowSettings();
            FillStaticConstants();
            SetDefaultStates();

            accountNameLabel.Text = "Nalog: " + LoginForm.loggedInAccountUsername;
        }

        private static void SetClientData(ClientData data) {
            try {
                bool fl = int.Parse(data.FirstLogin) == 1;
                bool cg = int.Parse(data.ConsentGiven) == 1;

                firstLogin = fl;
                consentGiven = cg;
            }
            catch {
                Debug.WriteLine("Izlaz prije inicijalizacije.");
            }
        }

        private void UpdateButtonStates(TicketStates state) {
            switch (state) {
                case TicketStates.TICKET_OPEN: // "Otvoren"
                    createTicketButton.Enabled = false;
                    respondButton.Enabled = false;

                    ticketTitleLabel.ForeColor = Color.Black;
                    ticketStatusLabel.ForeColor = Color.Green;
                    break;
                case TicketStates.TICKET_ASSIGNED: // "Dodijeljen operateru"
                    UpdateButtonStates(TicketStates.TICKET_OPEN);
                    // ^ isto ponasanje kao za TICKET_OPEN, samo druga boja
                    ticketStatusLabel.ForeColor = Color.Blue;
                    break;
                case TicketStates.TICKET_RETURNED: // "Vracen"
                    createTicketButton.Enabled = false;
                    respondButton.Enabled = true;

                    ticketTitleLabel.ForeColor = Color.Black;
                    ticketStatusLabel.ForeColor = Color.Orange;
                    break;
                case TicketStates.NO_TICKETS: // "Nema"
                    createTicketButton.Enabled = true;
                    respondButton.Enabled = false;

                    ticketTitleLabel.ForeColor = Color.Red;
                    ticketStatusLabel.ForeColor = Color.Black;
                    break;
                default:
                    Debug.WriteLine("Undefined UpdateButtonStates() call.");
                    break;
            }
        }

        private void FailedLoginCloseOnStart(object sender, EventArgs e) => Close();

        private void StartTimedAction(string key, Action action, float seconds, bool periodic) {
            // nastaje "curenje tajmera" ako dozvolimo duplikate jer se gubi referenca na jednog
            if (activeTimers.ContainsKey(key)) return;

            var timer = new System.Timers.Timer(seconds * 1000);
            timer.Elapsed += (s, args) => {
                try {
                    Invoke(new Action(action));
                }
                catch { }
                // periodic == true -> akcija se izvrsava jednom
                // periodic == false -> akcija se izvrsava periodicno do Application.Exit()
                if (!periodic) {
                    timer.Stop();
                    timer.Dispose();
                }
            };
            timer.Start();

            // dodajemo tajmer u mapu kako bismo ga mogli kasnije adresirati za gasenje
            activeTimers[key] = timer;
        }

        private void StopTimedAction(string key) {
            // trazimo tajmer po kljucu i vracamo ga po referenci iz argumenta funkcije ispod
            if (activeTimers.TryGetValue(key, out var timer)) {
                timer.Stop();
                timer.Dispose();
                activeTimers.Remove(key);
            }
        }

        private void DisplayTicketData() {
            (bool, TicketData) lookupResult = 
                fm.LookupTicket(LoginForm.loggedInAccountUsername);

            TicketData ticketData = lookupResult.Item2;

            if (lookupResult.Item1) {
                if (ticketData.Status == Constants.ticketStatusLiterals["returned"])
                    UpdateButtonStates(TicketStates.TICKET_RETURNED);
                else if (ticketData.Status == Constants.ticketStatusLiterals["opened"])
                    UpdateButtonStates(TicketStates.TICKET_OPEN);
                else if (ticketData.Status == Constants.ticketStatusLiterals["assigned"])
                    UpdateButtonStates(TicketStates.TICKET_ASSIGNED);

                activeTicketExists = true;
            }
            else {
                UpdateButtonStates(TicketStates.NO_TICKETS);
                activeTicketExists = false;
                ticketData = Constants.ticketDataPlaceholder;
            }

            ticketTitleLabel.Text = ticketData.Title;
            ticketContentLabel.Text = ticketData.Content;
            ticketStatusLabel.Text = ticketData.Status;
            ticketOperatorLabel.Text = ticketData.AssignedOperatorName;
        }

        private void Login() {
            new LoginForm().ShowDialog();
            SetClientData(LoginForm.loggedInAccountData);

            // ako je korisnik neuspjesno prijavljen (najcesce forma za prijavu zatvorena na X),
            // u Load se dodaje funkcija/akcija za zatvaranje koja se poziva po zavrsetku konstruktora
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

                if (firstLogin)
                    new AccountSettingsForm(true).ShowDialog();
            }

            // pocetak periodicnog azuriranja statusa tiketa i naziva firme svaki sekund
            StartTimedAction("ticketAutoRefresh", () => {
                Text = constants.GetFormWindowTitle();
                DisplayTicketData();

                archivedTicketsButton.Enabled =
                    fm.GetAllArchivedTickets(LoginForm.loggedInAccountUsername).Count > 0;

            }, 0.5f, true);
        }

        // "Napravi tiket" dugme
        private void createTicket_click(object sender, EventArgs e) {
            new CreateTicketForm().ShowDialog();
            DisplayTicketData();
        }

        // "Odgovori" dugme
        private void respondButton_Click(object sender, EventArgs e) {
            new RespondTicketForm().Show();
        }

        // "Arhivirani tiketi" dugme
        private void archivedTicketsButton_Click(object sender, EventArgs e) {
            new ArchivedTicketList().Show();
        }

        // "Refresh" dugme
        private void refreshButton_Click(object sender, EventArgs e) {
            DisplayTicketData();
        }

        private void autoRefreshCheckBox_CheckedChanged(object sender, EventArgs e) {
            refreshButton.Enabled = !autoRefreshCheckBox.Checked;

            if (!autoRefreshCheckBox.Checked)
                StopTimedAction("ticketAutoRefresh");
            else
                StartTimedAction("ticketAutoRefresh", DisplayTicketData, 0.5f, true);
        }

        private static bool firstPress = true;
        private void logoutExitButton_Click(object sender, EventArgs e) {
            // dvostruka potvrda pritisnutog dugmeta
            if (firstPress) {
                firstPress = false;
                logoutExitButton.ForeColor = Color.Red;

                activeTimers.Remove("logoutConfirmation");
                // ukoliko prodje sekund bez drugog (potvrdnog) klika, stanje se resetuje
                StartTimedAction("logoutConfirmation", () => {
                    firstPress = true;
                    logoutExitButton.ForeColor = Color.Black;
                }, 0.5f, false);
            }
            else {
                Close();
                Application.Exit();
            }
        }

        private void accountSettingsButton_Click(object sender, EventArgs e) {
            new AccountSettingsForm(false).ShowDialog();
        }

        // pri zatvaranju forme ugasiti svaki tajmer jer po nekad dolazi do greske ako
        // zatvorimo aplikaciju u trenutku kada se poziva periodicni tajmer
        protected override void OnFormClosed(FormClosedEventArgs e) {
            base.OnFormClosed(e);
            foreach (var timer in activeTimers.Values) {
                timer.Stop();
                timer.Dispose();
            }
            activeTimers.Clear();
        }

        private void label2_Click(object sender, EventArgs e) { }

        private void ticketStatusLabel_Click(object sender, EventArgs e) {

        }

        private void ticketOperatorLabel_Click(object sender, EventArgs e) {

        }
    }
}

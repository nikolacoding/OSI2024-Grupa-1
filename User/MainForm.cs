using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;
using User;

namespace User {
    public sealed partial class MainForm : Form, Interfaces.IInitializable {
        public static bool consentGiven = false;
        public static bool activeTicketExists = false;

        private readonly ConsentForm cf = new();
        private readonly Constants constants = new();
        private readonly FileManager fm = new();

        public void SetDefaultWindowSettings() {
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void FillStaticConstants() {
            Text = constants.GetMainFormTitle("FIRMNAME");
        }

        public void SetDefaultStates() {
            createTicketButton.Enabled = !activeTicketExists;
            respondButton.Enabled = false;
            archivedTicketsButton.Enabled = true;
            refreshButton.Enabled = true;
        }

        public MainForm() {
            InitializeComponent();
            SetDefaultWindowSettings();
            FillStaticConstants();
            SetDefaultStates();

            if (!consentGiven)
                cf.ShowDialog();
        }

        private void createTicket_click(object sender, EventArgs e) {

        }

        private void respondButton_Click(object sender, EventArgs e) {

        }

        private void archivedTicketsButton_Click(object sender, EventArgs e) {

        }

        private void refreshButton_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) { }
    }
}

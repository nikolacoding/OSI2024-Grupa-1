using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User {
    public partial class RespondTicketForm : Form, Interfaces.IInitializable {
        private readonly FileManager fm = new();
        private readonly TicketData currentTicket;

        public RespondTicketForm() {
            currentTicket = fm.LookupTicket(LoginForm.loggedInAccountUsername).Item2;
            InitializeComponent();
            SetDefaultWindowSettings();
            FillStaticConstants();
            SetDefaultStates();
        }

        public void SetDefaultWindowSettings() {
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void FillStaticConstants() {
            clientNameTextBox.Text = LoginForm.loggedInAccountUsername;
            clientNameTextBox.Enabled = false;

            titleTextBox.Text = currentTicket.Title;
            titleTextBox.Enabled = false;
        }

        public void SetDefaultStates() {
            statusLabel.Text = "";
            statusLabel.ForeColor = Color.Red;

            operatorResponseTextBox.Enabled = false;
            operatorResponseTextBox.Text = currentTicket.OperatorResponse;
        }

        private void respondButton_Click(object sender, EventArgs e) {
            int contentLen = contentTextBox.Text.Length, maxContentLen = Constants.ticketContentMaxChars;

            if (contentLen > maxContentLen) {
                SoundEngine.failSound.Play();
                statusLabel.Text = "Naslov i/ili sadržaj su previše dugački.";
            }
            else if (contentLen <= 0) {
                SoundEngine.failSound.Play();
                statusLabel.Text = "Naslov i/ili sadržaj su prazni.";
            }
            else {
                SoundEngine.successSound.Play();

                fm.ChangeTicketAttribute(clientNameTextBox.Text, "CONTENT", contentTextBox.Text);
                fm.ChangeTicketAttribute(clientNameTextBox.Text, "STATUS", Constants.ticketStatusLiterals["assigned"]);
                fm.ChangeTicketAttribute(clientNameTextBox.Text, "OPERATOR_RESPONSE", "");
                Close();
            }
        }

        private void contentTextBox_TextChanged_1(object sender, EventArgs e) {
            int charCount = contentTextBox.Text.Length;
            int maxChars = Constants.ticketContentMaxChars;

            contentCharCounter.Text = charCount + "/" + maxChars;
            contentCharCounter.ForeColor = (charCount > maxChars) ? Color.Red : Color.Black;
        }
    }
}

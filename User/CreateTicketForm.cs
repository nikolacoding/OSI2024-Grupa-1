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
    public partial class CreateTicketForm : Form, Interfaces.IInitializable {

        FileManager fm = new();

        // IInitializable
        public void SetDefaultWindowSettings() {
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void FillStaticConstants() {
            clientNameTextBox.Text = LoginForm.loggedInAccountUsername;
            clientNameTextBox.Enabled = false;
        }

        public void SetDefaultStates() {
            statusLabel.Text = "";
            statusLabel.ForeColor = Color.Red;
        }
        // #IInitializable

        public CreateTicketForm() {
            InitializeComponent();

            SetDefaultStates();
            FillStaticConstants();
            SetDefaultStates();
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e) {
            int charCount = titleTextBox.Text.Length;
            int maxChars = Constants.ticketTitleMaxChars;
            titleCharCounter.Text = charCount + "/" + maxChars;
            titleCharCounter.ForeColor = (charCount > maxChars) ? Color.Red : Color.Black;
        }

        private void contentTextBox_TextChanged(object sender, EventArgs e) {
            int charCount = contentTextBox.Text.Length;
            int maxChars = Constants.ticketContentMaxChars;

            contentCharCounter.Text = charCount + "/" + maxChars;
            contentCharCounter.ForeColor = (charCount > maxChars) ? Color.Red : Color.Black;
        }

        private void createButton_Click(object sender, EventArgs e) {
            int titleLen = titleTextBox.Text.Length, maxTitleLen = Constants.ticketTitleMaxChars;
            int contentLen = contentTextBox.Text.Length, maxContentLen = Constants.ticketContentMaxChars;

            if (titleLen > maxTitleLen || contentLen > maxContentLen) {
                SoundEngine.failSound.Play();
                statusLabel.Text = "Naslov i/ili sadržaj su previše dugački.";
            }
            else {
                TicketData data = new TicketData {
                    ClientName = LoginForm.loggedInAccountUsername,
                    Title = titleTextBox.Text,
                    Content = contentTextBox.Text,
                    AssignedOperatorName = "",
                    Status = "Otvoren",
                };

                fm.CreateTicket(data);
                SoundEngine.successSound.Play();
                Close();
            }
        }
    }
}

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
    public partial class AccountSettingsForm : Form, Interfaces.IInitializable {
        private readonly FileManager fm = new();
        public AccountSettingsForm() {
            InitializeComponent();
            SetDefaultStates();
            FillStaticConstants();
            SetDefaultWindowSettings();
        }

        // IInitializable
        public void SetDefaultWindowSettings() {
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void FillStaticConstants() {
            currentUsernameLabel.Text = LoginForm.loggedInAccountUsername;
        }

        public void SetDefaultStates() {
            currentPasswordTextbox.PasswordChar = '*';
            newPasswordTextbox.PasswordChar = '*';
            statusLabel.ForeColor = Color.Red;
            statusLabel.Text = "";
        }
        // #IInitializable

        private void confirmPasswordChangeButton_Click(object sender, EventArgs e) {
            if (fm.ModifyAccountPassword(LoginForm.loggedInAccountUsername,
                currentPasswordTextbox.Text, newPasswordTextbox.Text)) {
                // ^ uspjesna modifikacija

                SoundEngine.successSound.Play();
                Close();
            }
            else {
                statusLabel.Text = "Pogrešna lozinka.";
                SoundEngine.failSound.Play();
            }
        }

        private void currentPasswordTextbox_TextChanged(object sender, EventArgs e) { }
    }
}

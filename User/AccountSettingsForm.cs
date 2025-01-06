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
        private readonly bool g_required;

        public AccountSettingsForm(bool required) {
            g_required = required;

            InitializeComponent();
            SetDefaultStates();
            FillStaticConstants();
            SetDefaultWindowSettings();
        }

        // moze ovo i bolje i ljepse
        private void ChangePassword() {
            // lozinka prekratka (prazna), vazi uslov i za required i non-required promjene lozinke
            if (newPasswordTextbox.Text.Length <= 0)
                goto FAIL_TOOSHORT;

            if (!g_required) {
                // ako nije forsirana promjena, korisnik unosi staru lozinku
                if (fm.ModifyAccountPassword(LoginForm.loggedInAccountUsername,
                    currentPasswordTextbox.Text, newPasswordTextbox.Text)) {
                    goto SUCCESS;
                }
                else
                    goto FAIL_WRONGPASSWORD;
                //  ^ ako je unesena stara lozinka netacna
            }
            else {
                fm.ModifyAccountPassword(LoginForm.loggedInAccountUsername,
                    LoginForm.loggedInAccountPassword, newPasswordTextbox.Text);
                goto SUCCESS;
            }
        // ^ else blok pokriva situacije gdje je promjena lozinke forsirana; u tom slucaju korisnik
        // ne unosi staru lozinku vec samo novu, te nema potrebe za provjerom validnosti, samo upisom;
        // provjera duzine je vec izvrsena na vrhu

        SUCCESS:
            SoundEngine.successSound.Play();
            if (g_required)
                fm.UpdateDataAttributeForAccount("FIRST_LOGIN", LoginForm.loggedInAccountUsername, 0);
            // ^ FIRST_LOGIN stavljamo na false kako vise korisnik ne bi morao mijenjati lozinke pri
            // prijavi
            Close();
            return;

        FAIL_WRONGPASSWORD:
            SoundEngine.failSound.Play();
            statusLabel.Text = "Pogrešna lozinka.";
            return;

        FAIL_TOOSHORT:
            SoundEngine.failSound.Play();
            statusLabel.Text = "Nova lozinka je prazna.";
            return;
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

            if (g_required) {
                currentPasswordTextbox.Enabled = false;
                currentPasswordTextbox.PasswordChar = '\0';
                currentPasswordTextbox.Text = LoginForm.loggedInAccountPassword;
                titleLabel.ForeColor = Color.Red;
                titleLabel.Font = new Font("Segoe UI", 10);
                titleLabel.Text = "Promjena lozinke je obavezna pri prvoj prijavi!";
                ControlBox = false;
            }
        }
        // #IInitializable

        private void confirmPasswordChangeButton_Click(object sender, EventArgs e) => ChangePassword();

        private void currentPasswordTextbox_TextChanged(object sender, EventArgs e) { }
    }
}

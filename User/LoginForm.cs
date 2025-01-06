using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User {
    public partial class LoginForm : Form, Interfaces.IInitializable {
        
        // staticke promjenljive za komunikaciju sa ostalim formama; ovaj pristup je dovoljan
        // s obzirom da moze biti samo jedan ulogovan korisnik i on mora da se uloguje svaki
        // put kada pokrece aplikaciju
        public static string loggedInAccountUsername = "{username}";
        public static string loggedInAccountPassword = "{password}";
        public static bool loginSuccessful = false;

        public LoginForm() {
            InitializeComponent();

            SetDefaultWindowSettings();
            FillStaticConstants();
            SetDefaultStates();
        }

        // IInitializable
        public void SetDefaultWindowSettings() {
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void FillStaticConstants() {
            Text = constants.GetFormWindowTitle("FIRMNAME");
            loginStatusLabel.Text = "";
        }

        public void SetDefaultStates() {
            passwordBox.PasswordChar = '*';
        }
        // #IInitializable

        private readonly FileManager fm = new();
        private readonly Constants constants = new();

        private void loginButton_Click(object sender, EventArgs e) {
            if (fm.LookupAccount(usernameBox.Text, passwordBox.Text)) {
                // setujemo staticke promjenljive za cuvanje imena i lozinke koje zive bez obzira
                // da li imamo aktivnu LoginForm instancu ili ne i omogucava nam da iz svake
                // ostale forme i konteksta pokupimo username trenutno prijavljenog korisnika;
                loggedInAccountUsername = usernameBox.Text;
                loggedInAccountPassword = passwordBox.Text;
                loginSuccessful = true;
                SoundEngine.successSound.Play();
                Close();
            }
            else {
                loginStatusLabel.Text = "Neispravno ime ili lozinka.";
                SoundEngine.failSound.Play();
            }
        }

        public void usernameBox_TextChanged(object sender, EventArgs e) { }
        public void passwordBox_TextChanged(Object sender, EventArgs e) { }
    }
}

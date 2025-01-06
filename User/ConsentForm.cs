using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User {
    public partial class ConsentForm : Form, Interfaces.IInitializable {
        readonly private Constants constants = new();
        readonly private FileManager fm = new();

        // IInitializable
        public void SetDefaultWindowSettings() {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ControlBox = false;
        }

        public void FillStaticConstants() {
            label1.Text = constants.GetConsentText("FIRMNAME");
        }

        public void SetDefaultStates() {
            consentCheckBox.Checked = false;
            consentButton.Enabled = consentCheckBox.Checked;
        }
        // #IInitializable

        public ConsentForm() {
            InitializeComponent();
            if (!LoginForm.loginSuccessful)
                Close();

            SetDefaultWindowSettings();
            FillStaticConstants();
            SetDefaultStates();
        }

        // "Razumijem" checkbox
        private void consentCheckBox_CheckedChanged(object sender, EventArgs e) =>
            consentButton.Enabled = consentCheckBox.Checked;

        // "Nastavi" dugme
        private void consentButton_click(object sender, EventArgs e) {
            fm.UpdateDataAttributeForAccount("CONSENT_GIVEN", LoginForm.loggedInAccountUsername, 1);
            Close();
        }

        private void label1_Click(object sender, EventArgs e) { }
    }
}
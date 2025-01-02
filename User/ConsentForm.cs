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
    public partial class ConsentForm : Form {
        readonly private FileManager fm = new();
        readonly private Constants constants = new();

        public ConsentForm() {
            InitializeComponent();
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            
            button1.Enabled = false;

            label1.Text = constants.GetConsentText("FIRMNAME");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if (checkBox1.Checked) 
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            MainForm.consentGiven = true;
            Close();
        }
    }
}
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace User {
    public sealed partial class MainForm : Form {
        public static bool consentGiven = false;
        readonly private ConsentForm cf = new();
        readonly private Constants constants = new();
        readonly private FileManager fm = new();

        public MainForm() {
            // inicijalizovati konstante preko datoteka
            InitializeComponent();
            cf.ShowDialog();
            Text = constants.GetMainFormTitle("FIRMNAME");
        }

        private void button1_Click(object sender, EventArgs e) {

        }
    }
}

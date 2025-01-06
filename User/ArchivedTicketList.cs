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
    public sealed partial class ArchivedTicketList : Form, Interfaces.IInitializable {
        public ArchivedTicketList() {
            InitializeComponent();
        }

        // IInitializable
        public void SetDefaultWindowSettings() {
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void FillStaticConstants() {

        }

        public void SetDefaultStates() {

        }
        // #IInitializable
    }
}

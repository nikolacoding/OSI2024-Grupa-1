using Data;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User {
    public sealed partial class ArchivedTicketList : Form, Interfaces.IInitializable {
        private readonly List<TicketData> allTickets;
        private int currentlyDisplayedTicketIndex = 0;

        public ArchivedTicketList() {
            InitializeComponent();
            SetDefaultWindowSettings();
            FillStaticConstants();
            SetDefaultStates();

            FileManager fm = new();
            allTickets = fm.GetAllArchivedTickets(LoginForm.loggedInAccountUsername);
            DisplayTicket(0);
        }

        // IInitializable
        public void SetDefaultWindowSettings() {
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void FillStaticConstants() {
            ticketStatusLabel.Text = "Zatvoren";
        }

        public void SetDefaultStates() {
            ticketStatusLabel.ForeColor = Color.Red;
        }
        // #IInitializable

        private void DisplayTicket(int index) {
            if (index >= allTickets.Count || index < 0)
                return;

            TicketData ticket = allTickets[index];

            ticketTitleLabel.Text = ticket.Title;
            ticketContentLabel.Text = ticket.Content;
            ticketOperatorLabel.Text = ticket.AssignedOperatorName;
            ticketMessageLabel.Text = ticket.OperatorResponse;

            ticketNumLabel.Text = string.Format("{0}/{1}", index + 1, allTickets.Count);
            currentlyDisplayedTicketIndex = index;
        }

        private void nextTicketButton_Click(object sender, EventArgs e) 
            => DisplayTicket(currentlyDisplayedTicketIndex + 1);

        private void prevTicketButton_Click(object sender, EventArgs e)
             => DisplayTicket(currentlyDisplayedTicketIndex - 1);
    }
}

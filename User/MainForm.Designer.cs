namespace User {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            createTicketButton = new Button();
            label1 = new Label();
            ticketTitleLabel = new Label();
            ticketContentLabel = new Label();
            respondButton = new Button();
            archivedTicketsButton = new Button();
            label4 = new Label();
            ticketStateLabel = new Label();
            refreshButton = new Button();
            accountSettingsButton = new Button();
            accountNameLabel = new Label();
            SuspendLayout();
            // 
            // createTicketButton
            // 
            createTicketButton.Location = new Point(12, 71);
            createTicketButton.Name = "createTicketButton";
            createTicketButton.Size = new Size(108, 23);
            createTicketButton.TabIndex = 0;
            createTicketButton.Text = "Napravi tiket";
            createTicketButton.UseVisualStyleBackColor = true;
            createTicketButton.Click += createTicket_click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 155);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 1;
            label1.Text = "Aktivni tiket:";
            // 
            // ticketTitleLabel
            // 
            ticketTitleLabel.AutoSize = true;
            ticketTitleLabel.Location = new Point(91, 155);
            ticketTitleLabel.Name = "ticketTitleLabel";
            ticketTitleLabel.Size = new Size(166, 15);
            ticketTitleLabel.TabIndex = 2;
            ticketTitleLabel.Text = "TicketTitleTicketTitleTicketTitle";
            ticketTitleLabel.Click += label2_Click;
            // 
            // ticketContentLabel
            // 
            ticketContentLabel.AutoSize = true;
            ticketContentLabel.Location = new Point(12, 186);
            ticketContentLabel.Name = "ticketContentLabel";
            ticketContentLabel.Size = new Size(592, 135);
            ticketContentLabel.TabIndex = 3;
            ticketContentLabel.Text = resources.GetString("ticketContentLabel.Text");
            // 
            // respondButton
            // 
            respondButton.Location = new Point(12, 100);
            respondButton.Name = "respondButton";
            respondButton.Size = new Size(108, 23);
            respondButton.TabIndex = 4;
            respondButton.Text = "Odgovori";
            respondButton.UseVisualStyleBackColor = true;
            respondButton.Click += respondButton_Click;
            // 
            // archivedTicketsButton
            // 
            archivedTicketsButton.Location = new Point(496, 8);
            archivedTicketsButton.Name = "archivedTicketsButton";
            archivedTicketsButton.Size = new Size(108, 23);
            archivedTicketsButton.TabIndex = 5;
            archivedTicketsButton.Text = "Arhivirani tiketi";
            archivedTicketsButton.UseVisualStyleBackColor = true;
            archivedTicketsButton.Click += archivedTicketsButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(291, 155);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 6;
            label4.Text = "Status: ";
            // 
            // ticketStateLabel
            // 
            ticketStateLabel.AutoSize = true;
            ticketStateLabel.Location = new Point(342, 155);
            ticketStateLabel.Name = "ticketStateLabel";
            ticketStateLabel.Size = new Size(50, 15);
            ticketStateLabel.TabIndex = 7;
            ticketStateLabel.Text = "Otvoren";
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(496, 151);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(108, 23);
            refreshButton.TabIndex = 8;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // accountSettingsButton
            // 
            accountSettingsButton.Location = new Point(12, 30);
            accountSettingsButton.Name = "accountSettingsButton";
            accountSettingsButton.Size = new Size(108, 23);
            accountSettingsButton.TabIndex = 9;
            accountSettingsButton.Text = "Postavke naloga";
            accountSettingsButton.UseVisualStyleBackColor = true;
            // 
            // accountNameLabel
            // 
            accountNameLabel.AutoSize = true;
            accountNameLabel.Location = new Point(12, 12);
            accountNameLabel.Name = "accountNameLabel";
            accountNameLabel.Size = new Size(128, 15);
            accountNameLabel.TabIndex = 10;
            accountNameLabel.Text = "Nalog: markomarkovic";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(615, 330);
            Controls.Add(accountNameLabel);
            Controls.Add(accountSettingsButton);
            Controls.Add(refreshButton);
            Controls.Add(ticketStateLabel);
            Controls.Add(label4);
            Controls.Add(archivedTicketsButton);
            Controls.Add(respondButton);
            Controls.Add(ticketContentLabel);
            Controls.Add(ticketTitleLabel);
            Controls.Add(label1);
            Controls.Add(createTicketButton);
            Name = "MainForm";
            Text = "Korisnička podrška";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button createTicketButton;
        private Label label1;
        private Label ticketTitleLabel;
        private Label ticketContentLabel;
        private Button respondButton;
        private Button archivedTicketsButton;
        private Label label4;
        private Label ticketStateLabel;
        private Button refreshButton;
        private Button accountSettingsButton;
        private Label accountNameLabel;
    }
}

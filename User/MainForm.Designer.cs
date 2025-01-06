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
            ticketStatusLabel = new Label();
            refreshButton = new Button();
            accountSettingsButton = new Button();
            accountNameLabel = new Label();
            logoutExitButton = new Button();
            autoRefreshCheckBox = new CheckBox();
            label2 = new Label();
            ticketOperatorLabel = new Label();
            SuspendLayout();
            // 
            // createTicketButton
            // 
            createTicketButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createTicketButton.Location = new Point(12, 138);
            createTicketButton.Name = "createTicketButton";
            createTicketButton.Size = new Size(124, 33);
            createTicketButton.TabIndex = 0;
            createTicketButton.Text = "Napravi tiket";
            createTicketButton.UseVisualStyleBackColor = true;
            createTicketButton.Click += createTicket_click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 191);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 1;
            label1.Text = "Aktivni tiket:";
            // 
            // ticketTitleLabel
            // 
            ticketTitleLabel.AutoSize = true;
            ticketTitleLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ticketTitleLabel.Location = new Point(113, 191);
            ticketTitleLabel.Name = "ticketTitleLabel";
            ticketTitleLabel.Size = new Size(213, 20);
            ticketTitleLabel.TabIndex = 2;
            ticketTitleLabel.Text = "TicketTitleTicketTitleTicketTitle";
            ticketTitleLabel.Click += label2_Click;
            // 
            // ticketContentLabel
            // 
            ticketContentLabel.BorderStyle = BorderStyle.FixedSingle;
            ticketContentLabel.FlatStyle = FlatStyle.Flat;
            ticketContentLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ticketContentLabel.Location = new Point(354, 198);
            ticketContentLabel.MaximumSize = new Size(600, 135);
            ticketContentLabel.Name = "ticketContentLabel";
            ticketContentLabel.Size = new Size(314, 123);
            ticketContentLabel.TabIndex = 3;
            ticketContentLabel.Text = resources.GetString("ticketContentLabel.Text");
            // 
            // respondButton
            // 
            respondButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            respondButton.Location = new Point(540, 153);
            respondButton.Name = "respondButton";
            respondButton.Size = new Size(128, 33);
            respondButton.TabIndex = 4;
            respondButton.Text = "Odgovori";
            respondButton.UseVisualStyleBackColor = true;
            respondButton.Click += respondButton_Click;
            // 
            // archivedTicketsButton
            // 
            archivedTicketsButton.Enabled = false;
            archivedTicketsButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            archivedTicketsButton.Location = new Point(540, 12);
            archivedTicketsButton.Name = "archivedTicketsButton";
            archivedTicketsButton.Size = new Size(128, 33);
            archivedTicketsButton.TabIndex = 5;
            archivedTicketsButton.Text = "Arhivirani tiketi";
            archivedTicketsButton.UseVisualStyleBackColor = true;
            archivedTicketsButton.Click += archivedTicketsButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 219);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 6;
            label4.Text = "Status: ";
            // 
            // ticketStatusLabel
            // 
            ticketStatusLabel.AutoSize = true;
            ticketStatusLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ticketStatusLabel.Location = new Point(113, 219);
            ticketStatusLabel.Name = "ticketStatusLabel";
            ticketStatusLabel.Size = new Size(62, 20);
            ticketStatusLabel.TabIndex = 7;
            ticketStatusLabel.Text = "Otvoren";
            ticketStatusLabel.Click += ticketStatusLabel_Click;
            // 
            // refreshButton
            // 
            refreshButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            refreshButton.Location = new Point(12, 285);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(124, 33);
            refreshButton.TabIndex = 8;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // accountSettingsButton
            // 
            accountSettingsButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            accountSettingsButton.Location = new Point(12, 69);
            accountSettingsButton.Name = "accountSettingsButton";
            accountSettingsButton.Size = new Size(128, 33);
            accountSettingsButton.TabIndex = 9;
            accountSettingsButton.Text = "Postavke naloga";
            accountSettingsButton.UseVisualStyleBackColor = true;
            accountSettingsButton.Click += accountSettingsButton_Click;
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
            // logoutExitButton
            // 
            logoutExitButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logoutExitButton.Location = new Point(12, 30);
            logoutExitButton.Name = "logoutExitButton";
            logoutExitButton.Size = new Size(128, 33);
            logoutExitButton.TabIndex = 11;
            logoutExitButton.Text = "Odjava i izlaz";
            logoutExitButton.UseVisualStyleBackColor = true;
            logoutExitButton.Click += logoutExitButton_Click;
            // 
            // autoRefreshCheckBox
            // 
            autoRefreshCheckBox.Checked = true;
            autoRefreshCheckBox.CheckState = CheckState.Checked;
            autoRefreshCheckBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            autoRefreshCheckBox.Location = new Point(148, 290);
            autoRefreshCheckBox.Name = "autoRefreshCheckBox";
            autoRefreshCheckBox.Size = new Size(123, 24);
            autoRefreshCheckBox.TabIndex = 12;
            autoRefreshCheckBox.Text = "auto-refresh";
            autoRefreshCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            autoRefreshCheckBox.UseVisualStyleBackColor = true;
            autoRefreshCheckBox.CheckedChanged += autoRefreshCheckBox_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 248);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 13;
            label2.Text = "Operater:";
            // 
            // ticketOperatorLabel
            // 
            ticketOperatorLabel.AutoSize = true;
            ticketOperatorLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ticketOperatorLabel.Location = new Point(113, 248);
            ticketOperatorLabel.Name = "ticketOperatorLabel";
            ticketOperatorLabel.Size = new Size(90, 20);
            ticketOperatorLabel.TabIndex = 14;
            ticketOperatorLabel.Text = "ivanivanovic";
            ticketOperatorLabel.Click += ticketOperatorLabel_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 330);
            Controls.Add(ticketOperatorLabel);
            Controls.Add(label2);
            Controls.Add(autoRefreshCheckBox);
            Controls.Add(logoutExitButton);
            Controls.Add(accountNameLabel);
            Controls.Add(accountSettingsButton);
            Controls.Add(refreshButton);
            Controls.Add(ticketStatusLabel);
            Controls.Add(label4);
            Controls.Add(archivedTicketsButton);
            Controls.Add(respondButton);
            Controls.Add(ticketContentLabel);
            Controls.Add(ticketTitleLabel);
            Controls.Add(label1);
            Controls.Add(createTicketButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private Label ticketStatusLabel;
        private Button refreshButton;
        private Button accountSettingsButton;
        private Label accountNameLabel;
        private Button logoutExitButton;
        private CheckBox autoRefreshCheckBox;
        private Label label2;
        private Label ticketOperatorLabel;
    }
}

namespace User {
    partial class ArchivedTicketList {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchivedTicketList));
            ticketOperatorLabel = new Label();
            label2 = new Label();
            ticketStatusLabel = new Label();
            label4 = new Label();
            ticketContentLabel = new Label();
            ticketTitleLabel = new Label();
            label3 = new Label();
            nextTicketButton = new Button();
            prevTicketButton = new Button();
            label1 = new Label();
            ticketMessageLabel = new Label();
            ticketNumLabel = new Label();
            SuspendLayout();
            // 
            // ticketOperatorLabel
            // 
            ticketOperatorLabel.AutoSize = true;
            ticketOperatorLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ticketOperatorLabel.Location = new Point(113, 66);
            ticketOperatorLabel.Name = "ticketOperatorLabel";
            ticketOperatorLabel.Size = new Size(90, 20);
            ticketOperatorLabel.TabIndex = 21;
            ticketOperatorLabel.Text = "ivanivanovic";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 66);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 20;
            label2.Text = "Operater:";
            // 
            // ticketStatusLabel
            // 
            ticketStatusLabel.AutoSize = true;
            ticketStatusLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ticketStatusLabel.ForeColor = Color.Red;
            ticketStatusLabel.Location = new Point(113, 37);
            ticketStatusLabel.Name = "ticketStatusLabel";
            ticketStatusLabel.Size = new Size(68, 20);
            ticketStatusLabel.TabIndex = 19;
            ticketStatusLabel.Text = "Zatvoren";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 37);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 18;
            label4.Text = "Status: ";
            // 
            // ticketContentLabel
            // 
            ticketContentLabel.BorderStyle = BorderStyle.FixedSingle;
            ticketContentLabel.FlatStyle = FlatStyle.Flat;
            ticketContentLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ticketContentLabel.Location = new Point(12, 99);
            ticketContentLabel.MaximumSize = new Size(600, 135);
            ticketContentLabel.Name = "ticketContentLabel";
            ticketContentLabel.Size = new Size(314, 123);
            ticketContentLabel.TabIndex = 17;
            ticketContentLabel.Text = resources.GetString("ticketContentLabel.Text");
            // 
            // ticketTitleLabel
            // 
            ticketTitleLabel.AutoSize = true;
            ticketTitleLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ticketTitleLabel.Location = new Point(113, 9);
            ticketTitleLabel.Name = "ticketTitleLabel";
            ticketTitleLabel.Size = new Size(213, 20);
            ticketTitleLabel.TabIndex = 16;
            ticketTitleLabel.Text = "TicketTitleTicketTitleTicketTitle";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 15;
            label3.Text = "Naslov:";
            // 
            // nextTicketButton
            // 
            nextTicketButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nextTicketButton.Location = new Point(56, 303);
            nextTicketButton.Name = "nextTicketButton";
            nextTicketButton.Size = new Size(38, 30);
            nextTicketButton.TabIndex = 22;
            nextTicketButton.Text = ">";
            nextTicketButton.UseVisualStyleBackColor = true;
            nextTicketButton.Click += nextTicketButton_Click;
            // 
            // prevTicketButton
            // 
            prevTicketButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            prevTicketButton.Location = new Point(12, 303);
            prevTicketButton.Name = "prevTicketButton";
            prevTicketButton.Size = new Size(38, 30);
            prevTicketButton.TabIndex = 23;
            prevTicketButton.Text = "<";
            prevTicketButton.UseVisualStyleBackColor = true;
            prevTicketButton.Click += prevTicketButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 234);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 24;
            label1.Text = "Poruka:";
            // 
            // ticketMessageLabel
            // 
            ticketMessageLabel.AutoSize = true;
            ticketMessageLabel.BorderStyle = BorderStyle.FixedSingle;
            ticketMessageLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ticketMessageLabel.Location = new Point(12, 260);
            ticketMessageLabel.Name = "ticketMessageLabel";
            ticketMessageLabel.Size = new Size(202, 22);
            ticketMessageLabel.TabIndex = 25;
            ticketMessageLabel.Text = "Zatvoren zbog a, b, c, d, e, f...";
            // 
            // ticketNumLabel
            // 
            ticketNumLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ticketNumLabel.Location = new Point(275, 313);
            ticketNumLabel.Name = "ticketNumLabel";
            ticketNumLabel.Size = new Size(68, 23);
            ticketNumLabel.TabIndex = 26;
            ticketNumLabel.Text = "1/5";
            ticketNumLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ArchivedTicketList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 345);
            Controls.Add(ticketNumLabel);
            Controls.Add(ticketMessageLabel);
            Controls.Add(label1);
            Controls.Add(prevTicketButton);
            Controls.Add(nextTicketButton);
            Controls.Add(ticketOperatorLabel);
            Controls.Add(label2);
            Controls.Add(ticketStatusLabel);
            Controls.Add(label4);
            Controls.Add(ticketContentLabel);
            Controls.Add(ticketTitleLabel);
            Controls.Add(label3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ArchivedTicketList";
            Text = "Arhivirani tiketi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ticketOperatorLabel;
        private Label label2;
        private Label ticketStatusLabel;
        private Label label4;
        private Label ticketContentLabel;
        private Label ticketTitleLabel;
        private Label label3;
        private Button nextTicketButton;
        private Button prevTicketButton;
        private Label label1;
        private Label ticketMessageLabel;
        private Label ticketNumLabel;
    }
}
namespace User {
    partial class CreateTicketForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTicketForm));
            clientNameTextBox = new TextBox();
            titleTextBox = new TextBox();
            contentTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            createButton = new Button();
            statusLabel = new Label();
            titleCharCounter = new Label();
            contentCharCounter = new Label();
            SuspendLayout();
            // 
            // clientNameTextBox
            // 
            clientNameTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clientNameTextBox.Location = new Point(12, 72);
            clientNameTextBox.Name = "clientNameTextBox";
            clientNameTextBox.Size = new Size(115, 27);
            clientNameTextBox.TabIndex = 0;
            clientNameTextBox.Text = "{clientName}";
            // 
            // titleTextBox
            // 
            titleTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleTextBox.Location = new Point(148, 72);
            titleTextBox.MaxLength = 40;
            titleTextBox.Name = "titleTextBox";
            titleTextBox.PlaceholderText = "Ne radi mi...";
            titleTextBox.Size = new Size(250, 27);
            titleTextBox.TabIndex = 1;
            titleTextBox.TextChanged += titleTextBox_TextChanged;
            // 
            // contentTextBox
            // 
            contentTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contentTextBox.Location = new Point(12, 153);
            contentTextBox.MaximumSize = new Size(300, 0);
            contentTextBox.MaxLength = 300;
            contentTextBox.Multiline = true;
            contentTextBox.Name = "contentTextBox";
            contentTextBox.PlaceholderText = "Nemam ovu uslugu vec 2 dana...";
            contentTextBox.Size = new Size(283, 149);
            contentTextBox.TabIndex = 2;
            contentTextBox.TextChanged += contentTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(148, 49);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 3;
            label1.Text = "Naslov:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 130);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 4;
            label2.Text = "Sadržaj:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 49);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 5;
            label3.Text = "Klijent:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 9);
            label4.Name = "label4";
            label4.Size = new Size(112, 25);
            label4.TabIndex = 6;
            label4.Text = "Kreiraj tiket:";
            // 
            // createButton
            // 
            createButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createButton.Location = new Point(312, 270);
            createButton.Name = "createButton";
            createButton.Size = new Size(86, 32);
            createButton.TabIndex = 7;
            createButton.Text = "Kreiraj";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(12, 311);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(166, 15);
            statusLabel.TabIndex = 8;
            statusLabel.Text = "Sadržaj mora biti do 250 slova.";
            // 
            // titleCharCounter
            // 
            titleCharCounter.Location = new Point(362, 54);
            titleCharCounter.Name = "titleCharCounter";
            titleCharCounter.Size = new Size(36, 15);
            titleCharCounter.TabIndex = 9;
            titleCharCounter.Text = "0/30";
            titleCharCounter.TextAlign = ContentAlignment.MiddleRight;
            // 
            // contentCharCounter
            // 
            contentCharCounter.Location = new Point(246, 135);
            contentCharCounter.Name = "contentCharCounter";
            contentCharCounter.Size = new Size(49, 15);
            contentCharCounter.TabIndex = 10;
            contentCharCounter.Text = "0/250";
            contentCharCounter.TextAlign = ContentAlignment.MiddleRight;
            // 
            // CreateTicketForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 335);
            Controls.Add(contentCharCounter);
            Controls.Add(titleCharCounter);
            Controls.Add(statusLabel);
            Controls.Add(createButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(contentTextBox);
            Controls.Add(titleTextBox);
            Controls.Add(clientNameTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateTicketForm";
            Text = "Kreiraj tiket";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox clientNameTextBox;
        private TextBox titleTextBox;
        private TextBox contentTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button createButton;
        private Label statusLabel;
        private Label titleCharCounter;
        private Label contentCharCounter;
    }
}
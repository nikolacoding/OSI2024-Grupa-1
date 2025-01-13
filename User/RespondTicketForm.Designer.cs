namespace User {
    partial class RespondTicketForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RespondTicketForm));
            contentCharCounter = new Label();
            statusLabel = new Label();
            respondButton = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            contentTextBox = new TextBox();
            titleTextBox = new TextBox();
            clientNameTextBox = new TextBox();
            operatorResponseTextBox = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // contentCharCounter
            // 
            contentCharCounter.Location = new Point(246, 339);
            contentCharCounter.Name = "contentCharCounter";
            contentCharCounter.Size = new Size(49, 15);
            contentCharCounter.TabIndex = 21;
            contentCharCounter.Text = "0/250";
            contentCharCounter.TextAlign = ContentAlignment.MiddleRight;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(12, 514);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(166, 15);
            statusLabel.TabIndex = 19;
            statusLabel.Text = "Sadržaj mora biti do 250 slova.";
            // 
            // respondButton
            // 
            respondButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            respondButton.Location = new Point(301, 479);
            respondButton.Name = "respondButton";
            respondButton.Size = new Size(86, 32);
            respondButton.TabIndex = 18;
            respondButton.Text = "Odgovori";
            respondButton.UseVisualStyleBackColor = true;
            respondButton.Click += respondButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 13);
            label4.Name = "label4";
            label4.Size = new Size(223, 25);
            label4.TabIndex = 17;
            label4.Text = "Odgovori na vraćen tiket:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 53);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 16;
            label3.Text = "Klijent:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 339);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 15;
            label2.Text = "Vaš odgovor:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(148, 53);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 14;
            label1.Text = "Naslov:";
            // 
            // contentTextBox
            // 
            contentTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contentTextBox.Location = new Point(12, 362);
            contentTextBox.MaximumSize = new Size(300, 0);
            contentTextBox.MaxLength = 300;
            contentTextBox.Multiline = true;
            contentTextBox.Name = "contentTextBox";
            contentTextBox.PlaceholderText = "Mislio sam na...";
            contentTextBox.Size = new Size(283, 149);
            contentTextBox.TabIndex = 13;
            contentTextBox.TextChanged += contentTextBox_TextChanged_1;
            // 
            // titleTextBox
            // 
            titleTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleTextBox.Location = new Point(148, 76);
            titleTextBox.MaxLength = 40;
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(250, 27);
            titleTextBox.TabIndex = 12;
            // 
            // clientNameTextBox
            // 
            clientNameTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clientNameTextBox.Location = new Point(12, 76);
            clientNameTextBox.Name = "clientNameTextBox";
            clientNameTextBox.Size = new Size(115, 27);
            clientNameTextBox.TabIndex = 11;
            clientNameTextBox.Text = "{clientName}";
            // 
            // operatorResponseTextBox
            // 
            operatorResponseTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            operatorResponseTextBox.Location = new Point(12, 164);
            operatorResponseTextBox.MaximumSize = new Size(300, 0);
            operatorResponseTextBox.MaxLength = 300;
            operatorResponseTextBox.Multiline = true;
            operatorResponseTextBox.Name = "operatorResponseTextBox";
            operatorResponseTextBox.Size = new Size(283, 149);
            operatorResponseTextBox.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 141);
            label5.Name = "label5";
            label5.Size = new Size(140, 20);
            label5.TabIndex = 23;
            label5.Text = "Odgovor operatera:";
            // 
            // RespondTicketForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 542);
            Controls.Add(label5);
            Controls.Add(operatorResponseTextBox);
            Controls.Add(contentCharCounter);
            Controls.Add(statusLabel);
            Controls.Add(respondButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(contentTextBox);
            Controls.Add(titleTextBox);
            Controls.Add(clientNameTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RespondTicketForm";
            Text = "Odgovori";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label contentCharCounter;
        private Label statusLabel;
        private Button respondButton;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox contentTextBox;
        private TextBox titleTextBox;
        private TextBox clientNameTextBox;
        private TextBox operatorResponseTextBox;
        private Label label5;
    }
}
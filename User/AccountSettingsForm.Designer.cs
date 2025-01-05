namespace User {
    partial class AccountSettingsForm {
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
            label5 = new Label();
            label7 = new Label();
            newPasswordTextbox = new TextBox();
            label10 = new Label();
            label11 = new Label();
            currentPasswordTextbox = new TextBox();
            confirmPasswordChangeButton = new Button();
            currentUsernameLabel = new Label();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(90, 9);
            label5.Name = "label5";
            label5.Size = new Size(116, 20);
            label5.TabIndex = 6;
            label5.Text = "Postavke naloga";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(16, 68);
            label7.Name = "label7";
            label7.Size = new Size(126, 20);
            label7.TabIndex = 14;
            label7.Text = "Promjena lozinke:";
            // 
            // newPasswordTextbox
            // 
            newPasswordTextbox.Location = new Point(164, 129);
            newPasswordTextbox.Name = "newPasswordTextbox";
            newPasswordTextbox.Size = new Size(120, 23);
            newPasswordTextbox.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(55, 103);
            label10.Name = "label10";
            label10.Size = new Size(96, 15);
            label10.TabIndex = 10;
            label10.Text = "Trenutna lozinka:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(73, 133);
            label11.Name = "label11";
            label11.Size = new Size(78, 15);
            label11.TabIndex = 9;
            label11.Text = "Nova lozinka:";
            // 
            // currentPasswordTextbox
            // 
            currentPasswordTextbox.Location = new Point(164, 100);
            currentPasswordTextbox.Name = "currentPasswordTextbox";
            currentPasswordTextbox.Size = new Size(120, 23);
            currentPasswordTextbox.TabIndex = 8;
            // 
            // confirmPasswordChangeButton
            // 
            confirmPasswordChangeButton.Location = new Point(209, 162);
            confirmPasswordChangeButton.Name = "confirmPasswordChangeButton";
            confirmPasswordChangeButton.Size = new Size(75, 23);
            confirmPasswordChangeButton.TabIndex = 15;
            confirmPasswordChangeButton.Text = "Potvrdi";
            confirmPasswordChangeButton.UseVisualStyleBackColor = true;
            confirmPasswordChangeButton.Click += confirmPasswordChangeButton_Click;
            // 
            // currentUsernameLabel
            // 
            currentUsernameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentUsernameLabel.Location = new Point(90, 29);
            currentUsernameLabel.Name = "currentUsernameLabel";
            currentUsernameLabel.Size = new Size(116, 20);
            currentUsernameLabel.TabIndex = 16;
            currentUsernameLabel.Text = "username";
            currentUsernameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AccountSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(287, 195);
            Controls.Add(currentUsernameLabel);
            Controls.Add(confirmPasswordChangeButton);
            Controls.Add(label7);
            Controls.Add(newPasswordTextbox);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(currentPasswordTextbox);
            Controls.Add(label5);
            Name = "AccountSettingsForm";
            Text = "Postavke naloga";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private Label label7;
        private TextBox newPasswordTextbox;
        private Label label10;
        private Label label11;
        private TextBox currentPasswordTextbox;
        private Button confirmPasswordChangeButton;
        private Label currentUsernameLabel;
    }
}
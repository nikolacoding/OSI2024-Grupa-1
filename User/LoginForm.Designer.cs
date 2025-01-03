namespace User {
    partial class LoginForm {
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
            usernameBox = new TextBox();
            label1 = new Label();
            passwordBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            loginButton = new Button();
            loginStatusLabel = new Label();
            SuspendLayout();
            // 
            // usernameBox
            // 
            usernameBox.Location = new Point(104, 70);
            usernameBox.Name = "usernameBox";
            usernameBox.Size = new Size(154, 23);
            usernameBox.TabIndex = 0;
            usernameBox.TextChanged += usernameBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(131, 24);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 1;
            label1.Text = "Prijava na nalog";
            // 
            // passwordBox
            // 
            passwordBox.Location = new Point(104, 99);
            passwordBox.Name = "passwordBox";
            passwordBox.Size = new Size(154, 23);
            passwordBox.TabIndex = 2;
            passwordBox.TextChanged += passwordBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 3;
            label2.Text = "Korisničko ime";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 102);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 4;
            label3.Text = "Lozinka";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(131, 142);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(75, 23);
            loginButton.TabIndex = 5;
            loginButton.Text = "Prijava";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // loginStatusLabel
            // 
            loginStatusLabel.AutoSize = true;
            loginStatusLabel.ForeColor = Color.Red;
            loginStatusLabel.Location = new Point(108, 45);
            loginStatusLabel.Name = "loginStatusLabel";
            loginStatusLabel.Size = new Size(145, 15);
            loginStatusLabel.TabIndex = 6;
            loginStatusLabel.Text = "Neispravno ime ili lozinka.";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 177);
            Controls.Add(loginStatusLabel);
            Controls.Add(loginButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(passwordBox);
            Controls.Add(label1);
            Controls.Add(usernameBox);
            Name = "LoginForm";
            Text = "{firmname} - Korisnička podrška";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameBox;
        private Label label1;
        private TextBox passwordBox;
        private Label label2;
        private Label label3;
        private Button loginButton;
        private Label loginStatusLabel;
    }
}
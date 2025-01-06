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
            usernameBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameBox.Location = new Point(136, 70);
            usernameBox.Name = "usernameBox";
            usernameBox.Size = new Size(173, 27);
            usernameBox.TabIndex = 0;
            usernameBox.TextChanged += usernameBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(119, 17);
            label1.Name = "label1";
            label1.Size = new Size(115, 20);
            label1.TabIndex = 1;
            label1.Text = "Prijava na nalog";
            // 
            // passwordBox
            // 
            passwordBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordBox.Location = new Point(136, 112);
            passwordBox.Name = "passwordBox";
            passwordBox.Size = new Size(173, 27);
            passwordBox.TabIndex = 2;
            passwordBox.TextChanged += passwordBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 3;
            label2.Text = "Korisničko ime";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(59, 119);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 4;
            label3.Text = "Lozinka";
            // 
            // loginButton
            // 
            loginButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginButton.Location = new Point(171, 158);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(93, 30);
            loginButton.TabIndex = 5;
            loginButton.Text = "Prijava";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // loginStatusLabel
            // 
            loginStatusLabel.AutoSize = true;
            loginStatusLabel.ForeColor = Color.Red;
            loginStatusLabel.Location = new Point(106, 37);
            loginStatusLabel.Name = "loginStatusLabel";
            loginStatusLabel.Size = new Size(145, 15);
            loginStatusLabel.TabIndex = 6;
            loginStatusLabel.Text = "Neispravno ime ili lozinka.";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 200);
            Controls.Add(loginStatusLabel);
            Controls.Add(loginButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(passwordBox);
            Controls.Add(label1);
            Controls.Add(usernameBox);
            Name = "LoginForm";
            Text = "Korisnička podrška - {firmname}";
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
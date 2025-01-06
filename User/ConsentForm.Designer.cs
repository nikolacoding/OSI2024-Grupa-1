namespace User {
    partial class ConsentForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsentForm));
            label1 = new Label();
            consentCheckBox = new CheckBox();
            consentButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(7, 9);
            label1.Name = "label1";
            label1.Size = new Size(453, 119);
            label1.TabIndex = 0;
            label1.Text = resources.GetString("label1.Text");
            label1.Click += label1_Click;
            // 
            // consentCheckBox
            // 
            consentCheckBox.AutoSize = true;
            consentCheckBox.Location = new Point(12, 161);
            consentCheckBox.Name = "consentCheckBox";
            consentCheckBox.Size = new Size(85, 19);
            consentCheckBox.TabIndex = 1;
            consentCheckBox.Text = "Razumijem";
            consentCheckBox.UseVisualStyleBackColor = true;
            consentCheckBox.CheckedChanged += consentCheckBox_CheckedChanged;
            // 
            // consentButton
            // 
            consentButton.Location = new Point(469, 161);
            consentButton.Name = "consentButton";
            consentButton.Size = new Size(75, 23);
            consentButton.TabIndex = 2;
            consentButton.Text = "Nastavi";
            consentButton.UseVisualStyleBackColor = true;
            consentButton.Click += consentButton_click;
            // 
            // ConsentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 188);
            Controls.Add(consentButton);
            Controls.Add(consentCheckBox);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ConsentForm";
            Text = "Uslovi korišćenja";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CheckBox consentCheckBox;
        private Button consentButton;
    }
}
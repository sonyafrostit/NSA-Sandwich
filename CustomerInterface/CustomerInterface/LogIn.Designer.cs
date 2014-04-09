namespace CustomerInterface
{
    partial class LogInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.accountNumberBox = new System.Windows.Forms.TextBox();
            this.enterInfoLabel = new System.Windows.Forms.Label();
            this.signInBut = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accountNumberBox
            // 
            this.accountNumberBox.Location = new System.Drawing.Point(16, 39);
            this.accountNumberBox.Name = "accountNumberBox";
            this.accountNumberBox.Size = new System.Drawing.Size(291, 20);
            this.accountNumberBox.TabIndex = 0;
            // 
            // enterInfoLabel
            // 
            this.enterInfoLabel.AutoSize = true;
            this.enterInfoLabel.Location = new System.Drawing.Point(13, 13);
            this.enterInfoLabel.Name = "enterInfoLabel";
            this.enterInfoLabel.Size = new System.Drawing.Size(149, 13);
            this.enterInfoLabel.TabIndex = 1;
            this.enterInfoLabel.Text = "Enter in your account number:";
            // 
            // signInBut
            // 
            this.signInBut.Location = new System.Drawing.Point(107, 85);
            this.signInBut.Name = "signInBut";
            this.signInBut.Size = new System.Drawing.Size(94, 31);
            this.signInBut.TabIndex = 2;
            this.signInBut.Text = "Sign in";
            this.signInBut.UseVisualStyleBackColor = true;
            this.signInBut.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(13, 62);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 3;
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 128);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.signInBut);
            this.Controls.Add(this.enterInfoLabel);
            this.Controls.Add(this.accountNumberBox);
            this.Name = "LogInForm";
            this.Text = "Loyalty Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox accountNumberBox;
        private System.Windows.Forms.Label enterInfoLabel;
        private System.Windows.Forms.Button signInBut;
        private System.Windows.Forms.Label errorLabel;
    }
}
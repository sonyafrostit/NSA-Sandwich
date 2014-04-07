namespace CustomerInterface
{
    partial class LogInOrGuest
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
            this.signInButton = new System.Windows.Forms.Button();
            this.guestButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // signInButton
            // 
            this.signInButton.Location = new System.Drawing.Point(36, 28);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(208, 125);
            this.signInButton.TabIndex = 2;
            this.signInButton.Text = "Sign into loyalty account";
            this.signInButton.UseVisualStyleBackColor = true;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // guestButton
            // 
            this.guestButton.Location = new System.Drawing.Point(276, 28);
            this.guestButton.Name = "guestButton";
            this.guestButton.Size = new System.Drawing.Size(208, 125);
            this.guestButton.TabIndex = 3;
            this.guestButton.Text = "Continue as Guest";
            this.guestButton.UseVisualStyleBackColor = true;
            this.guestButton.Click += new System.EventHandler(this.guestButton_Click);
            // 
            // LogInOrGuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 189);
            this.Controls.Add(this.guestButton);
            this.Controls.Add(this.signInButton);
            this.Name = "LogInOrGuest";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.Button guestButton;
    }
}
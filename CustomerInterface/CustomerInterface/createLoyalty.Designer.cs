namespace CustomerInterface
{
    partial class createLoyalty
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.createLoyaltyBut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.emailAddressLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 63);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(321, 20);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(12, 121);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(321, 20);
            this.emailTextBox.TabIndex = 1;
            this.emailTextBox.TextChanged += new System.EventHandler(this.emailTextBox_TextChanged);
            // 
            // createLoyaltyBut
            // 
            this.createLoyaltyBut.Location = new System.Drawing.Point(124, 169);
            this.createLoyaltyBut.Name = "createLoyaltyBut";
            this.createLoyaltyBut.Size = new System.Drawing.Size(107, 40);
            this.createLoyaltyBut.TabIndex = 2;
            this.createLoyaltyBut.Text = "Create loyalty account";
            this.createLoyaltyBut.UseVisualStyleBackColor = true;
            this.createLoyaltyBut.Click += new System.EventHandler(this.createLoyaltyBut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // emailAddressLabel
            // 
            this.emailAddressLabel.AutoSize = true;
            this.emailAddressLabel.Location = new System.Drawing.Point(9, 105);
            this.emailAddressLabel.Name = "emailAddressLabel";
            this.emailAddressLabel.Size = new System.Drawing.Size(76, 13);
            this.emailAddressLabel.TabIndex = 4;
            this.emailAddressLabel.Text = "Email Address:";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(9, 20);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(112, 13);
            this.infoLabel.TabIndex = 5;
            this.infoLabel.Text = "Enter your information:";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(13, 195);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 6;
            // 
            // createLoyalty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 221);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.emailAddressLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createLoyaltyBut);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Name = "createLoyalty";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button createLoyaltyBut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label emailAddressLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label errorLabel;
    }
}
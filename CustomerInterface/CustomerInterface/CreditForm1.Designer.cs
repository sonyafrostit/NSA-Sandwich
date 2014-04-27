namespace CustomerInterface
{
    partial class CreditForm1
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
            this.label1 = new System.Windows.Forms.Label();
            this.CCBox = new System.Windows.Forms.TextBox();
            this.promptLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.emailReceiptCheck = new System.Windows.Forms.CheckBox();
            this.emailAddressText = new System.Windows.Forms.TextBox();
            this.emailAddressLabel = new System.Windows.Forms.Label();
            this.checkLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "NSA RESTAURANT";
            // 
            // CCBox
            // 
            this.CCBox.Location = new System.Drawing.Point(12, 62);
            this.CCBox.Multiline = true;
            this.CCBox.Name = "CCBox";
            this.CCBox.Size = new System.Drawing.Size(272, 20);
            this.CCBox.TabIndex = 1;
            this.CCBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // promptLabel
            // 
            this.promptLabel.AutoSize = true;
            this.promptLabel.Location = new System.Drawing.Point(12, 46);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(149, 13);
            this.promptLabel.TabIndex = 0;
            this.promptLabel.Text = "Enter your credit card number:";
            this.promptLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // emailReceiptCheck
            // 
            this.emailReceiptCheck.AutoSize = true;
            this.emailReceiptCheck.Location = new System.Drawing.Point(14, 88);
            this.emailReceiptCheck.Name = "emailReceiptCheck";
            this.emailReceiptCheck.Size = new System.Drawing.Size(97, 17);
            this.emailReceiptCheck.TabIndex = 11;
            this.emailReceiptCheck.Text = "Email Receipt?";
            this.emailReceiptCheck.UseVisualStyleBackColor = true;
            this.emailReceiptCheck.CheckedChanged += new System.EventHandler(this.emailReceiptCheck_CheckedChanged);
            // 
            // emailAddressText
            // 
            this.emailAddressText.Location = new System.Drawing.Point(94, 105);
            this.emailAddressText.Name = "emailAddressText";
            this.emailAddressText.Size = new System.Drawing.Size(154, 20);
            this.emailAddressText.TabIndex = 15;
            this.emailAddressText.Visible = false;
            // 
            // emailAddressLabel
            // 
            this.emailAddressLabel.AutoSize = true;
            this.emailAddressLabel.Location = new System.Drawing.Point(12, 108);
            this.emailAddressLabel.Name = "emailAddressLabel";
            this.emailAddressLabel.Size = new System.Drawing.Size(76, 13);
            this.emailAddressLabel.TabIndex = 14;
            this.emailAddressLabel.Text = "Email Address:";
            this.emailAddressLabel.Visible = false;
            // 
            // checkLabel
            // 
            this.checkLabel.AutoSize = true;
            this.checkLabel.ForeColor = System.Drawing.Color.Red;
            this.checkLabel.Location = new System.Drawing.Point(12, 131);
            this.checkLabel.Name = "checkLabel";
            this.checkLabel.Size = new System.Drawing.Size(0, 13);
            this.checkLabel.TabIndex = 16;
            // 
            // CreditForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 163);
            this.Controls.Add(this.checkLabel);
            this.Controls.Add(this.emailAddressText);
            this.Controls.Add(this.emailAddressLabel);
            this.Controls.Add(this.emailReceiptCheck);
            this.Controls.Add(this.promptLabel);
            this.Controls.Add(this.CCBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "CreditForm1";
            this.Text = "Credit Payment";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox CCBox;
        private System.Windows.Forms.Label promptLabel;
        private System.Windows.Forms.CheckBox emailReceiptCheck;
        private System.Windows.Forms.TextBox emailAddressText;
        private System.Windows.Forms.Label emailAddressLabel;
        private System.Windows.Forms.Label checkLabel;
    }
}


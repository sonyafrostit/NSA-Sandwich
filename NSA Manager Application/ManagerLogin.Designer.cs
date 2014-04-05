namespace NSA_Manager
{
    partial class ManagerLogin_Form
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
            this.Title_Form = new System.Windows.Forms.Label();
            this.Username_Textbox = new System.Windows.Forms.TextBox();
            this.Password_Textbox = new System.Windows.Forms.TextBox();
            this.Username_Label = new System.Windows.Forms.Label();
            this.Password_Label = new System.Windows.Forms.Label();
            this.Login_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title_Form
            // 
            this.Title_Form.AutoSize = true;
            this.Title_Form.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Title_Form.Location = new System.Drawing.Point(124, 9);
            this.Title_Form.Name = "Title_Form";
            this.Title_Form.Size = new System.Drawing.Size(137, 24);
            this.Title_Form.TabIndex = 0;
            this.Title_Form.Text = "NSA Sandwich";
            // 
            // Username_Textbox
            // 
            this.Username_Textbox.Location = new System.Drawing.Point(165, 71);
            this.Username_Textbox.Name = "Username_Textbox";
            this.Username_Textbox.Size = new System.Drawing.Size(133, 20);
            this.Username_Textbox.TabIndex = 1;
            // 
            // Password_Textbox
            // 
            this.Password_Textbox.Location = new System.Drawing.Point(165, 97);
            this.Password_Textbox.Name = "Password_Textbox";
            this.Password_Textbox.PasswordChar = '*';
            this.Password_Textbox.Size = new System.Drawing.Size(133, 20);
            this.Password_Textbox.TabIndex = 2;
            // 
            // Username_Label
            // 
            this.Username_Label.AutoSize = true;
            this.Username_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Username_Label.Location = new System.Drawing.Point(82, 71);
            this.Username_Label.Name = "Username_Label";
            this.Username_Label.Size = new System.Drawing.Size(77, 17);
            this.Username_Label.TabIndex = 3;
            this.Username_Label.Text = "Username:";
            // 
            // Password_Label
            // 
            this.Password_Label.AutoSize = true;
            this.Password_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Password_Label.Location = new System.Drawing.Point(86, 97);
            this.Password_Label.Name = "Password_Label";
            this.Password_Label.Size = new System.Drawing.Size(73, 17);
            this.Password_Label.TabIndex = 4;
            this.Password_Label.Text = "Password:";
            // 
            // Login_Button
            // 
            this.Login_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Login_Button.Location = new System.Drawing.Point(128, 146);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(133, 39);
            this.Login_Button.TabIndex = 5;
            this.Login_Button.Text = "Login";
            this.Login_Button.UseVisualStyleBackColor = true;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // ManagerLogin_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.Password_Label);
            this.Controls.Add(this.Username_Label);
            this.Controls.Add(this.Password_Textbox);
            this.Controls.Add(this.Username_Textbox);
            this.Controls.Add(this.Title_Form);
            this.Name = "ManagerLogin_Form";
            this.Text = "Manager Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title_Form;
        private System.Windows.Forms.TextBox Username_Textbox;
        private System.Windows.Forms.TextBox Password_Textbox;
        private System.Windows.Forms.Label Username_Label;
        private System.Windows.Forms.Label Password_Label;
        private System.Windows.Forms.Button Login_Button;
    }
}
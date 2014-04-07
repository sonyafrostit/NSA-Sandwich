namespace CustomerInterface
{
    partial class CustomizeForm
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BreadList = new System.Windows.Forms.ListView();
            this.OtherListBox = new System.Windows.Forms.CheckedListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.BreadPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.BreadPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(924, 597);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(135, 47);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BreadPanel);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.OtherListBox);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 578);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button4.Location = new System.Drawing.Point(7, 506);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 68);
            this.button4.TabIndex = 7;
            this.button4.Text = "q";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button3.Location = new System.Drawing.Point(7, 210);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 68);
            this.button3.TabIndex = 6;
            this.button3.Text = "p";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button2.Location = new System.Drawing.Point(0, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 138);
            this.button2.TabIndex = 5;
            this.button2.Text = "t";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button1.Location = new System.Drawing.Point(976, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 138);
            this.button1.TabIndex = 4;
            this.button1.Text = "u";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bread:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Other:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // BreadList
            // 
            this.BreadList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.BreadList.Location = new System.Drawing.Point(58, 34);
            this.BreadList.Name = "BreadList";
            this.BreadList.Size = new System.Drawing.Size(912, 139);
            this.BreadList.TabIndex = 1;
            this.BreadList.UseCompatibleStateImageBehavior = false;
            this.BreadList.SelectedIndexChanged += new System.EventHandler(this.BreadList_SelectedIndexChanged);
            // 
            // OtherListBox
            // 
            this.OtherListBox.CheckOnClick = true;
            this.OtherListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherListBox.FormattingEnabled = true;
            this.OtherListBox.Location = new System.Drawing.Point(65, 210);
            this.OtherListBox.Name = "OtherListBox";
            this.OtherListBox.Size = new System.Drawing.Size(978, 342);
            this.OtherListBox.TabIndex = 0;
            this.OtherListBox.SelectedIndexChanged += new System.EventHandler(this.OtherListBox_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(783, 597);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(135, 47);
            this.button5.TabIndex = 2;
            this.button5.Text = "Finish";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // BreadPanel
            // 
            this.BreadPanel.Controls.Add(this.button2);
            this.BreadPanel.Controls.Add(this.button1);
            this.BreadPanel.Controls.Add(this.BreadList);
            this.BreadPanel.Controls.Add(this.label2);
            this.BreadPanel.Location = new System.Drawing.Point(10, 8);
            this.BreadPanel.Name = "BreadPanel";
            this.BreadPanel.Size = new System.Drawing.Size(1036, 172);
            this.BreadPanel.TabIndex = 8;
            this.BreadPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BreadPanel_Paint);
            // 
            // CustomizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 656);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomizeForm";
            this.Text = "CustomizeForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.BreadPanel.ResumeLayout(false);
            this.BreadPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView BreadList;
        private System.Windows.Forms.CheckedListBox OtherListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel BreadPanel;
    }
}
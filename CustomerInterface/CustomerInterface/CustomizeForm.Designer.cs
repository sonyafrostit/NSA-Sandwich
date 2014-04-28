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
            this.BreadPanel = new System.Windows.Forms.Panel();
            this.BreadList = new System.Windows.Forms.ListView();
            this.breadLabel = new System.Windows.Forms.Label();
            this.otherLabel = new System.Windows.Forms.Label();
            this.OtherListBox = new System.Windows.Forms.CheckedListBox();
            this.button5 = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.otherLabel);
            this.panel1.Controls.Add(this.OtherListBox);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 578);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BreadPanel
            // 
            this.BreadPanel.Controls.Add(this.BreadList);
            this.BreadPanel.Controls.Add(this.breadLabel);
            this.BreadPanel.Location = new System.Drawing.Point(10, 8);
            this.BreadPanel.Name = "BreadPanel";
            this.BreadPanel.Size = new System.Drawing.Size(1036, 172);
            this.BreadPanel.TabIndex = 8;
            this.BreadPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BreadPanel_Paint);
            // 
            // BreadList
            // 
            this.BreadList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.BreadList.HideSelection = false;
            this.BreadList.Location = new System.Drawing.Point(7, 34);
            this.BreadList.Name = "BreadList";
            this.BreadList.Size = new System.Drawing.Size(1026, 139);
            this.BreadList.TabIndex = 1;
            this.BreadList.UseCompatibleStateImageBehavior = false;
            this.BreadList.SelectedIndexChanged += new System.EventHandler(this.BreadList_SelectedIndexChanged);
            // 
            // breadLabel
            // 
            this.breadLabel.AutoSize = true;
            this.breadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breadLabel.Location = new System.Drawing.Point(3, 7);
            this.breadLabel.Name = "breadLabel";
            this.breadLabel.Size = new System.Drawing.Size(60, 24);
            this.breadLabel.TabIndex = 3;
            this.breadLabel.Text = "Bread";
            // 
            // otherLabel
            // 
            this.otherLabel.AutoSize = true;
            this.otherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otherLabel.Location = new System.Drawing.Point(3, 183);
            this.otherLabel.Name = "otherLabel";
            this.otherLabel.Size = new System.Drawing.Size(57, 24);
            this.otherLabel.TabIndex = 2;
            this.otherLabel.Text = "Other";
            this.otherLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // OtherListBox
            // 
            this.OtherListBox.CheckOnClick = true;
            this.OtherListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherListBox.FormattingEnabled = true;
            this.OtherListBox.Location = new System.Drawing.Point(10, 210);
            this.OtherListBox.Name = "OtherListBox";
            this.OtherListBox.Size = new System.Drawing.Size(1033, 342);
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
        private System.Windows.Forms.Label otherLabel;
        private System.Windows.Forms.Label breadLabel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel BreadPanel;
    }
}
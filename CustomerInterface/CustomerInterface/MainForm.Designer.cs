namespace CustomerInterface
{
    partial class KioskWindow
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
            this.KioskTabs = new System.Windows.Forms.TabControl();
            this.MenuTab = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuListView = new System.Windows.Forms.ListView();
            this.LoyaltyTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label5 = new System.Windows.Forms.Label();
            this.HistoryView = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AccNumberLaber = new System.Windows.Forms.Label();
            this.AccNumberTagLabel = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.LanguageTab = new System.Windows.Forms.TabPage();
            this.KioskTabs.SuspendLayout();
            this.MenuTab.SuspendLayout();
            this.LoyaltyTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // KioskTabs
            // 
            this.KioskTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KioskTabs.Controls.Add(this.MenuTab);
            this.KioskTabs.Controls.Add(this.LoyaltyTab);
            this.KioskTabs.Controls.Add(this.LanguageTab);
            this.KioskTabs.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KioskTabs.ItemSize = new System.Drawing.Size(42, 18);
            this.KioskTabs.Location = new System.Drawing.Point(13, 12);
            this.KioskTabs.Multiline = true;
            this.KioskTabs.Name = "KioskTabs";
            this.KioskTabs.SelectedIndex = 0;
            this.KioskTabs.Size = new System.Drawing.Size(766, 593);
            this.KioskTabs.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.KioskTabs.TabIndex = 0;
            // 
            // MenuTab
            // 
            this.MenuTab.Controls.Add(this.button4);
            this.MenuTab.Controls.Add(this.button5);
            this.MenuTab.Controls.Add(this.menuListView);
            this.MenuTab.Location = new System.Drawing.Point(4, 22);
            this.MenuTab.Name = "MenuTab";
            this.MenuTab.Padding = new System.Windows.Forms.Padding(3);
            this.MenuTab.Size = new System.Drawing.Size(758, 567);
            this.MenuTab.TabIndex = 0;
            this.MenuTab.Text = "Menu";
            this.MenuTab.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Wingdings 3", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button4.Location = new System.Drawing.Point(3, 456);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 65);
            this.button4.TabIndex = 5;
            this.button4.Text = "q";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Wingdings 3", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button5.Location = new System.Drawing.Point(3, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(66, 65);
            this.button5.TabIndex = 4;
            this.button5.Text = "p";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(959, 569);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Finish Order";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // menuListView
            // 
            this.menuListView.Location = new System.Drawing.Point(75, 6);
            this.menuListView.Name = "menuListView";
            this.menuListView.Size = new System.Drawing.Size(677, 515);
            this.menuListView.TabIndex = 0;
            this.menuListView.UseCompatibleStateImageBehavior = false;
            this.menuListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // LoyaltyTab
            // 
            this.LoyaltyTab.Controls.Add(this.panel1);
            this.LoyaltyTab.Controls.Add(this.panel2);
            this.LoyaltyTab.Controls.Add(this.textBox2);
            this.LoyaltyTab.Controls.Add(this.label3);
            this.LoyaltyTab.Controls.Add(this.textBox1);
            this.LoyaltyTab.Controls.Add(this.label2);
            this.LoyaltyTab.Controls.Add(this.label1);
            this.LoyaltyTab.Controls.Add(this.AccNumberLaber);
            this.LoyaltyTab.Controls.Add(this.AccNumberTagLabel);
            this.LoyaltyTab.Location = new System.Drawing.Point(4, 22);
            this.LoyaltyTab.Name = "LoyaltyTab";
            this.LoyaltyTab.Padding = new System.Windows.Forms.Padding(3);
            this.LoyaltyTab.Size = new System.Drawing.Size(758, 567);
            this.LoyaltyTab.TabIndex = 2;
            this.LoyaltyTab.Text = "Loyalty Account";
            this.LoyaltyTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.HistoryView);
            this.panel1.Location = new System.Drawing.Point(6, 187);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 184);
            this.panel1.TabIndex = 3;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(3, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(743, 3);
            this.splitter2.TabIndex = 11;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 184);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            // 
            // HistoryView
            // 
            this.HistoryView.Location = new System.Drawing.Point(0, 39);
            this.HistoryView.Name = "HistoryView";
            this.HistoryView.Size = new System.Drawing.Size(743, 145);
            this.HistoryView.TabIndex = 8;
            this.HistoryView.UseCompatibleStateImageBehavior = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.splitter3);
            this.panel2.Location = new System.Drawing.Point(6, 377);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(746, 184);
            this.panel2.TabIndex = 2;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(3, 34);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(740, 145);
            this.listView2.TabIndex = 12;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "label6";
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(746, 3);
            this.splitter3.TabIndex = 0;
            this.splitter3.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(86, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(414, 33);
            this.textBox2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(414, 33);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "4 more orders to free sandwich";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email:";
            // 
            // AccNumberLaber
            // 
            this.AccNumberLaber.AutoSize = true;
            this.AccNumberLaber.Location = new System.Drawing.Point(184, 11);
            this.AccNumberLaber.Name = "AccNumberLaber";
            this.AccNumberLaber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AccNumberLaber.Size = new System.Drawing.Size(133, 25);
            this.AccNumberLaber.TabIndex = 1;
            this.AccNumberLaber.Text = "29038470298";
            // 
            // AccNumberTagLabel
            // 
            this.AccNumberTagLabel.AutoSize = true;
            this.AccNumberTagLabel.Location = new System.Drawing.Point(10, 11);
            this.AccNumberTagLabel.Name = "AccNumberTagLabel";
            this.AccNumberTagLabel.Size = new System.Drawing.Size(176, 25);
            this.AccNumberTagLabel.TabIndex = 0;
            this.AccNumberTagLabel.Text = "Account Number:";
            this.AccNumberTagLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(786, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(282, 524);
            this.listBox1.TabIndex = 1;
            // 
            // LanguageTab
            // 
            this.LanguageTab.Location = new System.Drawing.Point(4, 22);
            this.LanguageTab.Name = "LanguageTab";
            this.LanguageTab.Padding = new System.Windows.Forms.Padding(3);
            this.LanguageTab.Size = new System.Drawing.Size(758, 567);
            this.LanguageTab.TabIndex = 3;
            this.LanguageTab.Text = "Language";
            this.LanguageTab.UseVisualStyleBackColor = true;
            // 
            // KioskWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 617);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.KioskTabs);
            this.Name = "KioskWindow";
            this.Text = "Customer Kiosk";
            this.KioskTabs.ResumeLayout(false);
            this.MenuTab.ResumeLayout(false);
            this.LoyaltyTab.ResumeLayout(false);
            this.LoyaltyTab.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage MenuTab;
        private System.Windows.Forms.ListView menuListView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabPage LoyaltyTab;
        private System.Windows.Forms.Label AccNumberTagLabel;
        private System.Windows.Forms.Label AccNumberLaber;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView HistoryView;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.TabPage LanguageTab;
        private System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.TabControl KioskTabs;
    }
}


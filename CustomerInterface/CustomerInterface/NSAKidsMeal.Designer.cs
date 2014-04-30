namespace CustomerInterface
{
    partial class NSAKidsMeal
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kidsNum = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ErrorPrint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NSA Restaurant";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "HURRAY!! FREE KIDS MEAL DAY.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of kids:";
            // 
            // kidsNum
            // 
            this.kidsNum.Location = new System.Drawing.Point(215, 105);
            this.kidsNum.Multiline = true;
            this.kidsNum.Name = "kidsNum";
            this.kidsNum.Size = new System.Drawing.Size(73, 20);
            this.kidsNum.TabIndex = 3;
            this.kidsNum.TextChanged += new System.EventHandler(this.kidsNum_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(361, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start Your Order";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ErrorPrint
            // 
            this.ErrorPrint.AutoSize = true;
            this.ErrorPrint.Location = new System.Drawing.Point(215, 142);
            this.ErrorPrint.Name = "ErrorPrint";
            this.ErrorPrint.Size = new System.Drawing.Size(0, 13);
            this.ErrorPrint.TabIndex = 5;
            // 
            // NSAKidsMeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 334);
            this.Controls.Add(this.ErrorPrint);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.kidsNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NSAKidsMeal";
            this.Text = "NSAKidsMeal";
            this.Load += new System.EventHandler(this.NSAKidsMeal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox kidsNum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ErrorPrint;
    }
}
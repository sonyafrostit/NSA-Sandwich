namespace CustomerInterface
{
    partial class CashForm1
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
            this.cash_received = new System.Windows.Forms.Label();
            this.Due = new System.Windows.Forms.Label();
            this.change = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.due_amount = new System.Windows.Forms.Label();
            this.received_amount = new System.Windows.Forms.Label();
            this.change_amount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NSA RESTAURANT";
            // 
            // cash_received
            // 
            this.cash_received.AutoSize = true;
            this.cash_received.Location = new System.Drawing.Point(50, 89);
            this.cash_received.Name = "cash_received";
            this.cash_received.Size = new System.Drawing.Size(113, 13);
            this.cash_received.TabIndex = 1;
            this.cash_received.Text = "Total Cash Received: ";
            // 
            // Due
            // 
            this.Due.AutoSize = true;
            this.Due.Location = new System.Drawing.Point(50, 58);
            this.Due.Name = "Due";
            this.Due.Size = new System.Drawing.Size(57, 13);
            this.Due.TabIndex = 2;
            this.Due.Text = "Total Due:";
            // 
            // change
            // 
            this.change.AutoSize = true;
            this.change.Location = new System.Drawing.Point(50, 119);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(50, 13);
            this.change.TabIndex = 3;
            this.change.Text = "Change: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // due_amount
            // 
            this.due_amount.AutoSize = true;
            this.due_amount.Location = new System.Drawing.Point(186, 57);
            this.due_amount.Name = "due_amount";
            this.due_amount.Size = new System.Drawing.Size(0, 13);
            this.due_amount.TabIndex = 5;
            this.due_amount.Click += new System.EventHandler(this.due_amount_Click);
            // 
            // received_amount
            // 
            this.received_amount.AutoSize = true;
            this.received_amount.Location = new System.Drawing.Point(189, 89);
            this.received_amount.Name = "received_amount";
            this.received_amount.Size = new System.Drawing.Size(0, 13);
            this.received_amount.TabIndex = 6;
            // 
            // change_amount
            // 
            this.change_amount.AutoSize = true;
            this.change_amount.Location = new System.Drawing.Point(192, 119);
            this.change_amount.Name = "change_amount";
            this.change_amount.Size = new System.Drawing.Size(0, 13);
            this.change_amount.TabIndex = 7;
            // 
            // CashForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 272);
            this.Controls.Add(this.change_amount);
            this.Controls.Add(this.received_amount);
            this.Controls.Add(this.due_amount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.change);
            this.Controls.Add(this.Due);
            this.Controls.Add(this.cash_received);
            this.Controls.Add(this.label1);
            this.Name = "CashForm1";
            this.Text = "Cash Payment";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label cash_received;
        private System.Windows.Forms.Label Due;
        private System.Windows.Forms.Label change;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label due_amount;
        private System.Windows.Forms.Label received_amount;
        private System.Windows.Forms.Label change_amount;
    }
}


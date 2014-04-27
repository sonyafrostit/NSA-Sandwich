namespace CustomerInterface
{
    partial class receiptFinal
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
            this.receiptText = new System.Windows.Forms.Label();
            this.finishButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // receiptText
            // 
            this.receiptText.AutoSize = true;
            this.receiptText.Location = new System.Drawing.Point(13, 13);
            this.receiptText.Name = "receiptText";
            this.receiptText.Size = new System.Drawing.Size(35, 13);
            this.receiptText.TabIndex = 0;
            this.receiptText.Text = "label1";
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(159, 308);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 23);
            this.finishButton.TabIndex = 1;
            this.finishButton.Text = "Finish";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // receiptFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 343);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.receiptText);
            this.Name = "receiptFinal";
            this.Text = "Receipt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label receiptText;
        private System.Windows.Forms.Button finishButton;
    }
}
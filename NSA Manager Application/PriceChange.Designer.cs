namespace NSA_Manager
{
    partial class PriceChange
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
            this.NewPrice_Textbox = new System.Windows.Forms.TextBox();
            this.SavePrice_Button = new System.Windows.Forms.Button();
            this.NewPrice_Label = new System.Windows.Forms.Label();
            this.OldPrice_Label = new System.Windows.Forms.Label();
            this.Price_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NewPrice_Textbox
            // 
            this.NewPrice_Textbox.Location = new System.Drawing.Point(106, 78);
            this.NewPrice_Textbox.Name = "NewPrice_Textbox";
            this.NewPrice_Textbox.Size = new System.Drawing.Size(100, 20);
            this.NewPrice_Textbox.TabIndex = 0;
            // 
            // SavePrice_Button
            // 
            this.SavePrice_Button.Location = new System.Drawing.Point(106, 104);
            this.SavePrice_Button.Name = "SavePrice_Button";
            this.SavePrice_Button.Size = new System.Drawing.Size(75, 23);
            this.SavePrice_Button.TabIndex = 1;
            this.SavePrice_Button.Text = "Save Price";
            this.SavePrice_Button.UseVisualStyleBackColor = true;
            this.SavePrice_Button.Click += new System.EventHandler(this.SavePrice_Button_Click);
            // 
            // NewPrice_Label
            // 
            this.NewPrice_Label.AutoSize = true;
            this.NewPrice_Label.Location = new System.Drawing.Point(41, 81);
            this.NewPrice_Label.Name = "NewPrice_Label";
            this.NewPrice_Label.Size = new System.Drawing.Size(59, 13);
            this.NewPrice_Label.TabIndex = 2;
            this.NewPrice_Label.Text = "New Price:";
            // 
            // OldPrice_Label
            // 
            this.OldPrice_Label.AutoSize = true;
            this.OldPrice_Label.Location = new System.Drawing.Point(41, 39);
            this.OldPrice_Label.Name = "OldPrice_Label";
            this.OldPrice_Label.Size = new System.Drawing.Size(53, 13);
            this.OldPrice_Label.TabIndex = 3;
            this.OldPrice_Label.Text = "Old Price:";
            // 
            // Price_Label
            // 
            this.Price_Label.AutoSize = true;
            this.Price_Label.Location = new System.Drawing.Point(103, 39);
            this.Price_Label.Name = "Price_Label";
            this.Price_Label.Size = new System.Drawing.Size(28, 13);
            this.Price_Label.TabIndex = 4;
            this.Price_Label.Text = "0.00";
            // 
            // PriceChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 162);
            this.Controls.Add(this.Price_Label);
            this.Controls.Add(this.OldPrice_Label);
            this.Controls.Add(this.NewPrice_Label);
            this.Controls.Add(this.SavePrice_Button);
            this.Controls.Add(this.NewPrice_Textbox);
            this.Name = "PriceChange";
            this.Text = "Price Change";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NewPrice_Textbox;
        private System.Windows.Forms.Button SavePrice_Button;
        private System.Windows.Forms.Label NewPrice_Label;
        private System.Windows.Forms.Label OldPrice_Label;
        private System.Windows.Forms.Label Price_Label;
    }
}
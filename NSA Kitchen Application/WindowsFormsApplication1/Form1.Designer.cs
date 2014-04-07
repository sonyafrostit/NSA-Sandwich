namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.Windows.Forms.TreeView treeView1;
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("-Mustard");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("All-Star Sandwich", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("+Onion");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Avocado Burger", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.toplabelnumber = new System.Windows.Forms.Label();
            this.label1number = new System.Windows.Forms.Label();
            this.label2number = new System.Windows.Forms.Label();
            this.label3number = new System.Windows.Forms.Label();
            this.label4number = new System.Windows.Forms.Label();
            this.label5number = new System.Windows.Forms.Label();
            this.toplabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.mytable1 = new System.Windows.Forms.FlowLayoutPanel();
            this.mytable2 = new System.Windows.Forms.FlowLayoutPanel();
            this.mytable3 = new System.Windows.Forms.FlowLayoutPanel();
            this.mytable4 = new System.Windows.Forms.FlowLayoutPanel();
            this.mytable5 = new System.Windows.Forms.FlowLayoutPanel();
            treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.BackColor = System.Drawing.Color.Black;
            treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            treeView1.CausesValidation = false;
            treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeView1.ForeColor = System.Drawing.Color.White;
            treeView1.FullRowSelect = true;
            treeView1.HideSelection = false;
            treeView1.ItemHeight = 24;
            treeView1.LineColor = System.Drawing.Color.DimGray;
            treeView1.Location = new System.Drawing.Point(6, 40);
            treeView1.Name = "treeView1";
            treeNode1.BackColor = System.Drawing.Color.Black;
            treeNode1.Name = "Mod";
            treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.Text = "-Mustard";
            treeNode2.BackColor = System.Drawing.Color.Black;
            treeNode2.Name = "Item";
            treeNode2.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode2.Text = "All-Star Sandwich";
            treeNode3.BackColor = System.Drawing.Color.Black;
            treeNode3.Name = "Mod";
            treeNode3.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            treeNode3.Text = "+Onion";
            treeNode4.BackColor = System.Drawing.Color.Black;
            treeNode4.Name = "Node0";
            treeNode4.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            treeNode4.Text = "Avocado Burger";
            treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4});
            treeView1.Scrollable = false;
            treeView1.Size = new System.Drawing.Size(184, 404);
            treeView1.TabIndex = 0;
            treeView1.TabStop = false;
            treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect_1);
            // 
            // toplabelnumber
            // 
            this.toplabelnumber.AutoSize = true;
            this.toplabelnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.toplabelnumber.ForeColor = System.Drawing.Color.White;
            this.toplabelnumber.Location = new System.Drawing.Point(290, 6);
            this.toplabelnumber.Name = "toplabelnumber";
            this.toplabelnumber.Size = new System.Drawing.Size(84, 26);
            this.toplabelnumber.TabIndex = 0;
            this.toplabelnumber.Text = "######";
            // 
            // label1number
            // 
            this.label1number.AutoSize = true;
            this.label1number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1number.ForeColor = System.Drawing.Color.White;
            this.label1number.Location = new System.Drawing.Point(62, 450);
            this.label1number.Name = "label1number";
            this.label1number.Size = new System.Drawing.Size(63, 20);
            this.label1number.TabIndex = 7;
            this.label1number.Text = "######";
            // 
            // label2number
            // 
            this.label2number.AutoSize = true;
            this.label2number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2number.ForeColor = System.Drawing.Color.White;
            this.label2number.Location = new System.Drawing.Point(250, 450);
            this.label2number.Name = "label2number";
            this.label2number.Size = new System.Drawing.Size(63, 20);
            this.label2number.TabIndex = 8;
            this.label2number.Text = "######";
            // 
            // label3number
            // 
            this.label3number.AutoSize = true;
            this.label3number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3number.ForeColor = System.Drawing.Color.White;
            this.label3number.Location = new System.Drawing.Point(438, 450);
            this.label3number.Name = "label3number";
            this.label3number.Size = new System.Drawing.Size(63, 20);
            this.label3number.TabIndex = 9;
            this.label3number.Text = "######";
            // 
            // label4number
            // 
            this.label4number.AutoSize = true;
            this.label4number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4number.ForeColor = System.Drawing.Color.White;
            this.label4number.Location = new System.Drawing.Point(626, 450);
            this.label4number.Name = "label4number";
            this.label4number.Size = new System.Drawing.Size(63, 20);
            this.label4number.TabIndex = 10;
            this.label4number.Text = "######";
            // 
            // label5number
            // 
            this.label5number.AutoSize = true;
            this.label5number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5number.ForeColor = System.Drawing.Color.White;
            this.label5number.Location = new System.Drawing.Point(814, 450);
            this.label5number.Name = "label5number";
            this.label5number.Size = new System.Drawing.Size(63, 20);
            this.label5number.TabIndex = 11;
            this.label5number.Text = "######";
            // 
            // toplabel
            // 
            this.toplabel.AutoSize = true;
            this.toplabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.toplabel.ForeColor = System.Drawing.Color.White;
            this.toplabel.Location = new System.Drawing.Point(6, 6);
            this.toplabel.Name = "toplabel";
            this.toplabel.Size = new System.Drawing.Size(282, 26);
            this.toplabel.TabIndex = 1;
            this.toplabel.Text = "Number of orders in queue: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Order: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(194, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Order: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(382, 450);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Order: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(570, 450);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Order: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(758, 450);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Order: ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(6, 480);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 50);
            this.button1.TabIndex = 12;
            this.button1.Text = "1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(194, 480);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 50);
            this.button2.TabIndex = 13;
            this.button2.Text = "2";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(382, 480);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(184, 50);
            this.button3.TabIndex = 14;
            this.button3.Text = "3";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(570, 480);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(184, 50);
            this.button4.TabIndex = 15;
            this.button4.Text = "4";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(758, 480);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(184, 50);
            this.button5.TabIndex = 16;
            this.button5.Text = "5";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // mytable1
            // 
            this.mytable1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mytable1.ForeColor = System.Drawing.Color.White;
            this.mytable1.Location = new System.Drawing.Point(6, 40);
            this.mytable1.Name = "mytable1";
            this.mytable1.Size = new System.Drawing.Size(184, 404);
            this.mytable1.TabIndex = 17;
            this.mytable1.Paint += new System.Windows.Forms.PaintEventHandler(this.mytable1_Paint);
            // 
            // mytable2
            // 
            this.mytable2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mytable2.ForeColor = System.Drawing.Color.White;
            this.mytable2.Location = new System.Drawing.Point(194, 40);
            this.mytable2.Name = "mytable2";
            this.mytable2.Size = new System.Drawing.Size(184, 404);
            this.mytable2.TabIndex = 18;
            // 
            // mytable3
            // 
            this.mytable3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mytable3.ForeColor = System.Drawing.Color.White;
            this.mytable3.Location = new System.Drawing.Point(382, 40);
            this.mytable3.Name = "mytable3";
            this.mytable3.Size = new System.Drawing.Size(184, 404);
            this.mytable3.TabIndex = 19;
            // 
            // mytable4
            // 
            this.mytable4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mytable4.ForeColor = System.Drawing.Color.White;
            this.mytable4.Location = new System.Drawing.Point(570, 40);
            this.mytable4.Name = "mytable4";
            this.mytable4.Size = new System.Drawing.Size(184, 404);
            this.mytable4.TabIndex = 20;
            // 
            // mytable5
            // 
            this.mytable5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mytable5.ForeColor = System.Drawing.Color.White;
            this.mytable5.Location = new System.Drawing.Point(758, 40);
            this.mytable5.Name = "mytable5";
            this.mytable5.Size = new System.Drawing.Size(184, 404);
            this.mytable5.TabIndex = 21;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(952, 534);
            this.Controls.Add(treeView1);
            this.Controls.Add(this.mytable1);
            this.Controls.Add(this.mytable2);
            this.Controls.Add(this.mytable3);
            this.Controls.Add(this.mytable4);
            this.Controls.Add(this.mytable5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.toplabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toplabelnumber);
            this.Controls.Add(this.label5number);
            this.Controls.Add(this.label4number);
            this.Controls.Add(this.label3number);
            this.Controls.Add(this.label2number);
            this.Controls.Add(this.label1number);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kitchen Interface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label toplabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label toplabelnumber;
        private System.Windows.Forms.Label label1number;
        private System.Windows.Forms.Label label2number;
        private System.Windows.Forms.Label label3number;
        private System.Windows.Forms.Label label4number;
        private System.Windows.Forms.Label label5number;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.FlowLayoutPanel mytable1;
        private System.Windows.Forms.FlowLayoutPanel mytable2;
        private System.Windows.Forms.FlowLayoutPanel mytable3;
        private System.Windows.Forms.FlowLayoutPanel mytable4;
        private System.Windows.Forms.FlowLayoutPanel mytable5;
    }
}


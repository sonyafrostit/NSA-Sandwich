using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerInterface
{
    public partial class CreditForm1 : Form
    {
        int orderID;
        Decimal cost; //for show
        NSADatabase db;
        public CreditForm1(int orderID, Decimal cost, NSADatabase db)
        {
            InitializeComponent();
            this.orderID = orderID;
            this.cost = cost;
            this.db = db;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CCBox.TextLength == 16)
            {
                db.CustomQuery("UPDATE orders SET status = 1 WHERE orderid = " + orderID + ";");
                CreditForm2 f2 = new CreditForm2();
                f2.passValue = CCBox.Text;
                f2.ShowDialog();
                Close();
            }

            else
            { checkLabel.Text = "Invalid card length!"; }

           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

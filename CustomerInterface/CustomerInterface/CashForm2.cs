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
    public partial class CashForm2 : Form
    {
        long orderID;
        Decimal cost;
        NSADatabase db;
        public CashForm2(long orderID, Decimal cost, NSADatabase db)
        {
            InitializeComponent();
            this.orderID = orderID;
            this.cost = cost;
            this.db = db;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CashForm1 f1= new CashForm1();
            db.CustomQuery("UPDATE orders SET status = 1 WHERE orderid = " + orderID + ";").Close();
            f1.passValueOntoForms1 = textBox1.Text;
            f1.passValueOntoForms2 = textBox2.Text;
            double result1 = Convert.ToDouble(textBox1.Text) ;
            double result2 = Convert.ToDouble(textBox2.Text);
            string result = Convert.ToString(result1 - result2);
            f1.passValueOntoForms3 = result;
            f1.ShowDialog();
            Close();
        }

        private void CashForm2_Load(object sender, EventArgs e)
        {

        }
    }
}

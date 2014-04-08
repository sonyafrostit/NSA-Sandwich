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
    public partial class CashCreditSelect : Form
    {
        int orderID;
        Decimal cost;
        NSADatabase db;
        public CashCreditSelect(int orderID, Decimal cost, NSADatabase db)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CashForm2 cf = new CashForm2(orderID, cost, db);
            cf.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

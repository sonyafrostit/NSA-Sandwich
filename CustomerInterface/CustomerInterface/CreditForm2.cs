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
    public partial class CreditForm2 : Form
    {
        private string creditcardnum;
        private string receipt;

        public string passValue
        {
            get { return creditcardnum; }
            set { creditcardnum = value; }
        }
        public CreditForm2(string receipt)
        {
            InitializeComponent();
            this.receipt = receipt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            receiptFinal form = new receiptFinal(receipt);
            form.Show();
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string last_four_digit = creditcardnum.Substring(creditcardnum.Length - 4, 4);
            label2.Text = "Your transaction has been processed. \n" + "Credit Card Number: "  + "XXXX-XXXX-XXXX-" + last_four_digit;
        }
    }
}

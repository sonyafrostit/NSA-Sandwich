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
    
    public partial class CashForm1 : Form
    {
        private string total_to_pay;
        private string total_received;
        private string change_to_be_given;

        public string passValueOntoForms1
        {
            get { return total_to_pay; }
            set { total_to_pay = value; }
        }

        public string passValueOntoForms2
        {
            get { return total_to_pay; }
            set { total_received = value; }
        }

        public string passValueOntoForms3
        {
            get { return total_to_pay; }
            set { change_to_be_given = value; }
        }

        public CashForm1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Application.Run(new StartForm());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            due_amount.Text = total_to_pay;
            received_amount.Text = total_received;
            change_amount.Text = change_to_be_given;
        }

        private void due_amount_Click(object sender, EventArgs e)
        {
            
        }
    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emulate_cashPayment
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1= new Form1();
            f1.passValueOntoForms1 = textBox1.Text;
            f1.passValueOntoForms2 = textBox2.Text;
            double result1 = Convert.ToDouble(textBox1.Text) ;
            double result2 = Convert.ToDouble(textBox2.Text);
            string result = Convert.ToString(result1 - result2);
            f1.passValueOntoForms3 = result;
            f1.ShowDialog();
            Close();
        }
    }
}

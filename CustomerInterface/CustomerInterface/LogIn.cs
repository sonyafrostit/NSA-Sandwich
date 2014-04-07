using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace CustomerInterface
{
    public partial class LogInForm : Form
    {
        private CultureInfo ci;
        private string accountNumber;

        public LogInForm(CultureInfo language)
        {
            InitializeComponent();
            ci = language;
        }

        private void signInBut_TextChanged(object sender, EventArgs e)
        {
            accountNumber = signInBut.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(accountNumber))
                errorLabel.Text = "Enter your account number!";

            else
            {
                KioskWindow mainForm = new KioskWindow(ci, accountNumber);
                mainForm.Show();
                Hide();
            }
        }
    }
}

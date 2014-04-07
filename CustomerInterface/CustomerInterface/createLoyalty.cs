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
    public partial class createLoyalty : Form
    {
        private CultureInfo ci;
        private string name;
        private string email;

        public createLoyalty(CultureInfo language)
        {
            InitializeComponent();
            ci = language;
        }

        private void createLoyaltyBut_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(name))
            {
                errorLabel.Text = "Enter your name!";
            }

            else if (String.IsNullOrEmpty(email))
            {
                errorLabel.Text = "Enter your email!";
            }

            else
            {
                //create account
                KioskWindow form = new KioskWindow(ci);
                form.Show();
                Hide();
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            name = nameTextBox.Text;
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            email = emailTextBox.Text;
        }
    }
}

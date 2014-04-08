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
        private NSADatabase db;

        public createLoyalty(CultureInfo language)
        {
            InitializeComponent();
            ci = language;
            db = new NSADatabase();
        }

        //called when user tries to create an account
        private void createLoyaltyBut_Click(object sender, EventArgs e)
        {
            //get text box text
            name = nameTextBox.Text.ToString();
            email = emailTextBox.Text;
            if (String.IsNullOrEmpty(name))
                errorLabel.Text = "Enter your name!";

            else if (String.IsNullOrEmpty(email))
                errorLabel.Text = "Enter your email!";

            else
            {
                try
                {
                    // connect to DB if it is not connected
                    if (!db.Connected())
                    {
                        db.OpenConnection();
                    }

                    //writeLine to see if db can connect (this line is called)
                    Console.WriteLine("Connection opened");
                    //create the loyalty account and save the account number
                    string accountNumber = db.createLoyaltyAccount(name, email);

                    if (accountNumber != "FAIL")
                    {
                        List<string>[] accountInfo = new List<string>[4];
                        accountInfo[0].Add(name);
                        accountInfo[1].Add(email);
                        accountInfo[2].Add("0");
                        accountInfo[3].Add(accountNumber);
                        KioskWindow form = new KioskWindow(ci, accountInfo);
                        form.Show();
                        Hide();
                    }

                    else
                        errorLabel.Text = "SYSTEM IS DOWN";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Save Loyalty Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}

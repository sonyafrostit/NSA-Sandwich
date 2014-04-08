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
        private NSADatabase db;

        public LogInForm(CultureInfo language)
        {
            InitializeComponent();
            ci = language;
            db = new NSADatabase();
        }

        //called when user tries to log in
        private void button1_Click(object sender, EventArgs e)
        {
            accountNumber = signInBut.Text.ToString();
            if (String.IsNullOrEmpty(accountNumber))
                errorLabel.Text = "Enter your account number!";

            int recordCount = 0;        //the number of accounts found
            List<string>[] loyaltyData;   //the loyalty account data to be found
            
           //connect to DB if it is not connected
            if (!db.Connected())
            {
                 db.OpenConnection();
            }

                // Get the loyalty account data from the database
            recordCount = db.getLoyaltyAccountInfo(out loyaltyData, accountNumber);

            if(recordCount <= 0)
                errorLabel.Text = "Loyalty account not found!";

            else
            {
                KioskWindow mainForm = new KioskWindow(ci, loyaltyData);
                mainForm.Show();
                Hide();
            }
        }
    }
}

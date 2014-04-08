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
using System.Resources;
using System.Reflection;

namespace CustomerInterface
{
    public partial class LogInForm : Form
    {
        private CultureInfo ci; //users language
        private string accountNumber; //users entered account number
        private NSADatabase db; //db is used to connect to db

        public LogInForm(CultureInfo language)
        {
            InitializeComponent();
            ci = language;
            setLang();
            db = new NSADatabase();
        }

        //sets the language for the interface
        private void setLang()
        {
            Assembly a = Assembly.Load("CustomerInterface");
            ResourceManager rm = new ResourceManager("CustomerInterface.Lang.lang", a);
            signInBut.Text = rm.GetString("signIn", ci);
            enterInfoLabel.Text = rm.GetString("enterAccountInfo", ci);
            
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

            //Get the loyalty account data from the database and save amount found in record count
            recordCount = db.getLoyaltyAccountInfo(out loyaltyData, accountNumber);

            if(recordCount <= 0) //if 0 or less are found, loyalty account was not found or function failed
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

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
using System.Reflection;
using System.Resources;

namespace CustomerInterface
{
    public partial class createLoyalty : Form
    {
        private CultureInfo ci; //users language
        private string name; //name for account user enters
        private string email; //email for account user enters
        private NSADatabase db; //db is used to connect to db

        public createLoyalty(CultureInfo language)
        {
            InitializeComponent();
            ci = language;
            db = new NSADatabase();
            setLang();
        }

        //sets the language for the interface
        private void setLang()
        {
            Assembly a = Assembly.Load("CustomerInterface");
            ResourceManager rm = new ResourceManager("CustomerInterface.Lang.lang", a);
            infoLabel.Text = rm.GetString("enterInfo", ci);
            nameLabel.Text = rm.GetString("name", ci);
            emailAddressLabel.Text = rm.GetString("email", ci);
            createLoyaltyBut.Text = rm.GetString("createLoyalty", ci);
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
                if (!db.Connected())
                {
                    db.OpenConnection();
                }

                //create the loyalty account and save the account number
                string accountNumber = db.createLoyaltyAccount(name, email);

                if (accountNumber != "FAIL")
                {
                    List<string>[] accountInfo = new List<string>[4];
                    accountInfo[0] = new List<string>();
                    accountInfo[1] = new List<string>();
                    accountInfo[2] = new List<string>();
                    accountInfo[3] = new List<string>();

                    accountInfo[0].Add(name);
                    accountInfo[1].Add(email);
                    accountInfo[2].Add("0");
                    accountInfo[3].Add(accountNumber);
                    KioskWindow form = new KioskWindow(ci, accountInfo); //send info to KioskWindow
                    form.Show();
                    form.FormClosed += new FormClosedEventHandler(CreateLoyalty_FormClosed);
                    Hide();
                }

                else
                    errorLabel.Text = "SYSTEM IS DOWN";
            }
        }

        void CreateLoyalty_FormClosed(object sender, FormClosedEventArgs e)
        {
            StartForm from = new StartForm();
            from.Show();
            from.FormClosed += new FormClosedEventHandler(StartMenu_FormClosed);
            this.Hide();
        }

        void StartMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

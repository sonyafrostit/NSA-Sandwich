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
    public partial class LogInOrGuest : Form
    {
        private CultureInfo ci; //users selected language
        public LogInOrGuest(CultureInfo language)
        {
            InitializeComponent();
            ci = language;
            setLang();
        }

        //sets the language for the interface
        private void setLang()
        {
            Assembly a = Assembly.Load("CustomerInterface");
            ResourceManager rm = new ResourceManager("CustomerInterface.Lang.lang", a);
            signInButton.Text = rm.GetString("signIntoLoyalty", ci);
            guestButton.Text = rm.GetString("continueAsGuest", ci);
        }

        //called when user clicks to order as a guest
        private void guestButton_Click(object sender, EventArgs e)
        {
            KioskWindow mainForm = new KioskWindow(ci);
            mainForm.Show();
            Hide(); //hides form until needed again
        }

        //called when user clicks to sign in to their loyalty account
        private void signInButton_Click(object sender, EventArgs e)
        {
            LogInForm logInForm = new LogInForm(ci);
            logInForm.Show();
            Hide(); //hides form until needed again
        }
    }
}

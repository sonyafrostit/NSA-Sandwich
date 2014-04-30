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
    public partial class NSAKidsMeal : Form
    {
        private CultureInfo ci; //users selected language
        public List<string>[] accountNumber; //users entered account number
        public NSAKidsMeal(CultureInfo language)
        {
            InitializeComponent();
            ci = language;
            setLang();
        }

        public NSAKidsMeal(CultureInfo language, List<string>[] loyaltyaccount)
        {
            InitializeComponent();
            ci = language;
            setLang();
            accountNumber = loyaltyaccount;
        }
        //sets the language for the interface
        private void setLang()
        {
            Assembly a = Assembly.Load("CustomerInterface");
            ResourceManager rm = new ResourceManager("CustomerInterface.Lang.lang", a);
         }

        private void NSAKidsMeal_Load(object sender, EventArgs e)
        {

        }

        private void kidsNum_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (accountNumber == null)
            {
                KioskWindow newKiosk = new KioskWindow(ci);
                newKiosk.passValueMax = kidsNum.Text;
                newKiosk.FormClosed += new FormClosedEventHandler(KidsMeal_FormClosed);
                newKiosk.Show();
                Hide();
            }
            else
            {
                KioskWindow newKiosk = new KioskWindow(ci, accountNumber);
                newKiosk.passValueMax = kidsNum.Text;
                newKiosk.FormClosed += new FormClosedEventHandler(KidsMeal_FormClosed);
                newKiosk.Show();
                Hide();
            }
        }

        void KidsMeal_FormClosed(object sender, FormClosedEventArgs e)
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

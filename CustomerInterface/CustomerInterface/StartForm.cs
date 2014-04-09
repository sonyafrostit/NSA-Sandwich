using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Globalization;

namespace CustomerInterface
{
    public partial class StartForm : Form
    {
        private CultureInfo ci; //users selected language

        public StartForm()
        {
            InitializeComponent();
        }

        //changes interface when new language is chosen
        public void setLang(CultureInfo ci)
        {
            Assembly a = Assembly.Load("CustomerInterface");
            ResourceManager rm = new ResourceManager("CustomerInterface.Lang.lang", a);
            welcomeText.Text = rm.GetString("welcomeText", ci);
            scanLoyaltyText.Text = rm.GetString("scanLoyaltyText", ci);
            createLoyaltyBtn.Text = rm.GetString("createLoyaltyBut", ci);
            startOrderBtn.Text = rm.GetString("startOrderBut", ci);
            selectLangText.Text = rm.GetString("selectLangText", ci);
        }

        //changes language to english
        private void enBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("en-US");
            setLang(ci);
        }

        //changes language to french
        private void frBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("fr-FR");
            setLang(ci);
        }

        //changes language to german
        private void geBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("de-DE");
            setLang(ci);
        }

        //changes language to spanish
        private void spBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("es-ES");
            setLang(ci);
        }

        //called when user clicks to start an order
        private void startOrderBtn_Click_1(object sender, EventArgs e)
        {
            LogInOrGuest form = new LogInOrGuest(ci);
            form.Show();
            form.FormClosed += new FormClosedEventHandler(CustomerKiosk_FormClosed);
            this.Hide();
        }

        //called when user clicks to create a loyalty account
        private void createLoyaltyBtn_Click(object sender, EventArgs e)
        {
            createLoyalty form = new createLoyalty(ci);
            form.Show();
            form.FormClosed += new FormClosedEventHandler(CustomerKiosk_FormClosed);
            this.Hide();
        }

        void CustomerKiosk_FormClosed(object sender, FormClosedEventArgs e)
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

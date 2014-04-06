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
        CultureInfo ci;
        public StartForm()
        {
            InitializeComponent();
        }

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

        private void enBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("en-US");
            setLang(ci);
        }

        private void frBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("fr-FR");
            setLang(ci);
        }

        private void geBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("de-DE");
            setLang(ci);
        }

        private void spBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("es-ES");
            setLang(ci);
        }
        KioskWindow mainForm = new KioskWindow();
        private void startOrderBtn_Click(object sender, EventArgs e)
        {
            
            
        }

        private void startOrderBtn_Click_1(object sender, EventArgs e)
        {
            mainForm.Show();
            Hide();
        }
    }
}

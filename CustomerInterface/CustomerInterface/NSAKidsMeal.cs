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
        public NSAKidsMeal(CultureInfo language)
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
         }

        private void NSAKidsMeal_Load(object sender, EventArgs e)
        {

        }

        private void kidsNum_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KioskWindow newKiosk = new KioskWindow(ci);
            newKiosk.passValueMax = kidsNum.Text;
            newKiosk.Show();
            Hide();
        }
    }
}

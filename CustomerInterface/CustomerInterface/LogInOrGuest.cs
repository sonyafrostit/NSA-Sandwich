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
    public partial class LogInOrGuest : Form
    {
        private CultureInfo ci;
        public LogInOrGuest(CultureInfo language)
        {
            InitializeComponent();
            ci = language;
        }

        private void guestButton_Click(object sender, EventArgs e)
        {
            KioskWindow mainForm = new KioskWindow(ci);
            mainForm.Show();
            Hide();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            LogInForm logInForm = new LogInForm(ci);
            logInForm.Show();
            Hide();
        }
    }
}

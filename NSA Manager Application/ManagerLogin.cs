using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSA_Manager
{
    public partial class ManagerLogin_Form : Form
    {
        //constant for the config file name
        private const string XML_CONFIG_FILE = "NSAConfig.xml";

        //appconfig object containing the application settings
        private AppConfig ConfigurationSettings;

        //Database object that we use to access the data in the database.
        private NSADatabase nsadb;  //Database connection object.

        //this is how we know if the database was able to be loaded initially
        //if this is not set then we ignore the timer ticks and do not attempt to reload
        private bool InitialLoadSuccess;

        public ManagerLogin_Form()
        {
            InitialLoadSuccess = false;
            InitializeComponent();

            //load the Config XML file.
            try
            {
                ConfigurationSettings = new AppConfig(XML_CONFIG_FILE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading App Config:" + XML_CONFIG_FILE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Initislize the NSADatabase object
            try
            {
                nsadb = new NSADatabase(ConfigurationSettings.DatabaseServer, ConfigurationSettings.DatabaseName,
                    ConfigurationSettings.DatabaseUserName, ConfigurationSettings.DatabasePassword,
                    ConfigurationSettings.StoreNumber);
                InitialLoadSuccess = nsadb.Connected();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading Database: " + XML_CONFIG_FILE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            string Username = Username_Textbox.Text.ToString();
            string Password = Password_Textbox.Text.ToString();
            string isassist = null;

            if (String.IsNullOrWhiteSpace(Username) || String.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Not All Fields Filled In!", "Manager Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                // Get the loyalty account data from the database
                isassist = nsadb.ManagerLogin(Username, Password);

                if(isassist == "-1")
                {
                    MessageBox.Show("Username or Password Incorrect!", "Manager Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if(isassist == "0")
                {
                    ManagerKiosk frm = new ManagerKiosk();
                    frm.Show();
                    frm.FormClosed += new FormClosedEventHandler(ManagerKiosk_FormClosed);
                    this.Hide();
                }
                else if (isassist == "1")
                {
                    ManagerKiosk2 frm = new ManagerKiosk2();
                    frm.Show();
                    frm.FormClosed += new FormClosedEventHandler(ManagerKiosk_FormClosed);
                    this.Hide();
                }
            }
        }

        void ManagerKiosk_FormClosed(object sender, FormClosedEventArgs e)
        {   
            this.Close();
        }
    }
}

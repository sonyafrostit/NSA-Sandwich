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
    public partial class PriceChange : Form
    {
        //Stores information for Form
        private string curitem;
        private string oldPrice;

        //constant for the config file name
        private const string XML_CONFIG_FILE = "NSAConfig.xml";

        //appconfig object containing the application settings
        private AppConfig ConfigurationSettings;

        //Database object that we use to access the data in the database.
        private NSADatabase nsadb;  //Database connection object.

        //this is how we know if the database was able to be loaded initially
        //if this is not set then we ignore the timer ticks and do not attempt to reload
        private bool InitialLoadSuccess;

        public PriceChange(string menuitemid, string price)
        {
            InitializeComponent();
            InitialLoadSuccess = false;

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

            // Load Passed in Information
            curitem = menuitemid;
            oldPrice = price;
            Price_Label.Text = "$" + oldPrice;
        }

        private void SavePrice_Button_Click(object sender, EventArgs e)
        {
            string newPrice = NewPrice_Textbox.Text.ToString();

            // connect to DB if it is not connected
            if (!nsadb.Connected())
            {
                nsadb.OpenConnection();
            }

            //request the Records to display on the manager orders list
            nsadb.ManagerSetPrice(curitem, newPrice);
            MessageBox.Show("Price Updated!", "Price Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        } //SavePrice_Button_Click
    }
}

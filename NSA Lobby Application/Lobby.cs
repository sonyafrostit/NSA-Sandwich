///////////////////////////////////////////////////////////////////////////////
//Module Name:  Lobby.cs
//Project:      NSA Lobby Application
//Developer:    Trae Watkins
//Last Changes: 3/17/2014 - Trae Watkins
//
//      This is a class for the Lobby Display Application for the NSA group 
//      Project for the  CSCE4444 class.
//      
//      The application will load the last 10 orders that are listed as 
//      Status ID 2 
//          0 - not placed
//          1 - placed and ready to be made (put on Kitchen interface)
//          2 - Order Created and delivered (put on lobby screen)
//          
//      The last 10 orders will be updated every 5 seconds.
//          this is set in the ReloadTimer on the form.
//
//      This application uses a file called "NSAConfig.xml" that contains
//      the settings for the application.
//      
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using NSA;

namespace NSA_Lobby_Application
{
    public partial class Lobby : Form {

        //constant for the config file name
        private const string XML_CONFIG_FILE = "NSAConfig.xml";

        //appconfig object containing the application settings
        private AppConfig ConfigurationSettings;

        //Database object that we use to access the data in the database.
        private NSADatabase nsadb;  //Database connection object.

        //this is how we know if the database was able to be loaded initially
        //if this is not set then we ignore the timer ticks and do not attempt to reload
        private bool InitialLoadSuccess;

        //constructor for the lobbyform
        public Lobby(){

            InitialLoadSuccess = false;

            //auto generated code that builds the form
            InitializeComponent();

            //load the Config XML file.
            try {
                ConfigurationSettings = new AppConfig(XML_CONFIG_FILE);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error loading App Config:" + XML_CONFIG_FILE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Initislize the NSADatabase object
            try {
                nsadb = new NSADatabase(ConfigurationSettings.DatabaseServer, ConfigurationSettings.DatabaseName,
                    ConfigurationSettings.DatabaseUserName, ConfigurationSettings.DatabasePassword,
                    ConfigurationSettings.StoreNumber);
                InitialLoadSuccess = nsadb.Connected();

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error loading Database: " + XML_CONFIG_FILE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Load the orders to the Form
            try {
                if (nsadb.Connected()) {
                    DisplayOrders();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error Displaying orders:" + XML_CONFIG_FILE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        } //Lobby()

        //AssignLabelText is created because there is no way to create "Control Arrays"
        //The idea is to minic a control array and take an index and place the text into
        //the correct labelsbased on the index. 
        //the indexes of the Order labels are 0 .. 9  which correspond to
        // the Order1 .. order 10
        private void AssignLabelText(int index, string ordernumber, string time) {
            switch (index) {
                case 0:
                    Order1.Text = ordernumber;
                    TimeOrder1.Text = time;
                    break;
                case 1:
                    Order2.Text = ordernumber;
                    TimeOrder2.Text = time;
                    break;
                case 2:
                    Order3.Text = ordernumber;
                    TimeOrder3.Text = time;
                    break;
                case 3:
                    Order4.Text = ordernumber;
                    TimeOrder4.Text = time;
                    break;
                case 4:
                    Order5.Text = ordernumber;
                    TimeOrder5.Text = time;
                    break;
                case 5:
                    Order6.Text = ordernumber;
                    TimeOrder6.Text = time;
                    break;
                case 6:
                    Order7.Text = ordernumber;
                    TimeOrder7.Text = time;
                    break;
                case 7:
                    Order8.Text = ordernumber;
                    TimeOrder8.Text = time;
                    break;
                case 8:
                    Order9.Text = ordernumber;
                    TimeOrder9.Text = time;
                    break;
                case 9:
                    Order10.Text = ordernumber;
                    TimeOrder10.Text = time;
                    break;
                default:
                    break;
            }
        }// AssignLabelText()

        //Display the waiting orders.
        private void DisplayOrders() {
            try {
                int ordercount = 0;        // the number of orders to display
                List<string>[] Lobbydata;   // the orders that will be displayed

                // connect to DB if it is not connected
                if (!nsadb.Connected()) {
                    nsadb.OpenConnection();
                }

                //request the Records to display on the lobby window
                ordercount = nsadb.LobbyOrdersData(out Lobbydata);

                //loop over the records and load them to the labels
                for (int index = 0; index < 10; index++) {
                    if (index < ordercount) {
                        AssignLabelText(index, Lobbydata[0][index], Lobbydata[1][index]);
                    } else {
                        AssignLabelText(index, "", "");
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error loading " + XML_CONFIG_FILE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Timer event that triggers the reload of the Orders.
        private void ReloadTimer_Tick(object sender, EventArgs e) {
            if (InitialLoadSuccess) {
                Remove20MinuteOrders(); 
                DisplayOrders();
            }
        } //LoadConfig()

        //Remove all orders that are older than 20 minutes.
        public bool Remove20MinuteOrders() {

            string query = "UPDATE orders SET status = 3 Where storeid = " + ConfigurationSettings.StoreNumber.ToString() + 
                            " AND status = 2 AND timedelivered < DATE_SUB(NOW() , INTERVAL 20 MINUTE)";

            nsadb.ExecuteQuery(query);

            return true;
        }

    }
}

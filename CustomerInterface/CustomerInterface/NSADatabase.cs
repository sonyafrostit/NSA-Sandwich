///////////////////////////////////////////////////////////////////////////////
//Module Name:  DatabaseConnection.cs
//Project:      NSA Lobby Application
//Developer:    Trae Watkins
//Last Changes: 3/22/2014 - Trae Watkins
//
//     This is a DB connection class for our project for CSCE4444
//
//     We will be connecting to a My SQL database and this class will handle 
//     initializing building the connection and closing it.
//     
//     2014-03-22 Added a custom query class that will return a MySqlDataReader
//                object that will give the user access to the records based
//                on the query passed to the method. 
//                VERY IMPORTANT: is is up to the user to close the data reader
//
//      2014-03-26 Moved to NSA namespace
///////////////////////////////////////////////////////////////////////////////
using System.Windows.Forms;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using MySql.Data;
using NSA;

namespace CustomerInterface
{
    public class NSADatabase
    {
        private MySqlConnection Connection;

        //constant for the config file name
        private const string XML_CONFIG_FILE = "NSAConfig.xml";

        //appconfig object containing the application settings
        private AppConfig ConfigurationSettings;


        public MySqlConnection Connection1
        {
            get { return Connection; }
            set { Connection = value; }
        }
        private string DBServer;    //IP address or host name for server
        private string DBName;      //Database name to use
        private string DBUser;      //DB username
        private string DBPassword;  //Password for the username used.
        private int StoreNumber;    //Store Number.

        public int StoreNumber1
        {
            get { return StoreNumber; }
            set { StoreNumber = value; }
        }
        private int RecordCount; //Number of record that are currently loaded.

        //Constructor - Default Sets default values and DOES not open connectiton.
        public NSADatabase()
        {

            //string[] configFileLines = { "1", "54.186.234.139", "nsa_database", "trae", ""};
            //if (File.Exists("config")) {
            //    configFileLines = File.ReadAllLines("config");
                
            //}

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
            
            //Default values are used since none are specified.
            //Initialize(configFileLines[1], configFileLines[2], configFileLines[3], configFileLines[4], Convert.ToInt32(configFileLines[0]));
            //Initialize("localhost", "nsa_database", "root", "1234", 1);

            Initialize(ConfigurationSettings.DatabaseServer,
                       ConfigurationSettings.DatabaseName,
                       ConfigurationSettings.DatabaseUserName,
                       ConfigurationSettings.DatabasePassword,
                       ConfigurationSettings.StoreNumber);
            
        }

        //Constructor that specifies the connection other than the default 
        //Will attempt to open the connection.
        public NSADatabase(string server, string dbname, string dbuser, string password, int storenum)
        {
            Initialize(server, dbname, dbuser, password, storenum);
            this.OpenConnection();
        }

        //Initialize - store values for the private variables and initialize the connection object.
        private void Initialize(string server, string dbname, string dbuser, string password, int storenum)
        {
            //Save the connection info to class private properties.
            DBServer = server;
            DBName = dbname;
            DBUser = dbuser;
            DBPassword = password;

            StoreNumber = storenum;

            RecordCount = 0;

            //Build Connecion string
            string connectionString;
            connectionString = "SERVER=" + DBServer + ";" + "DATABASE=" + DBName + ";" + "UID=" + DBUser + ";" + "PASSWORD=" + DBPassword + ";";

            Connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch (MySqlException exMySQL)
            {
                string error;
                switch (exMySQL.Number)
                {

                    //0: Cannot connect to server.
                    case 0:
                        error = "Cannot connect to server. Check the connection settings or Contact lobbyerror@it.nsasammich.com";

                        break;

                    //1045: Invalid user name and/or password.
                    case 1045:
                        error = "Invalid username/password, please try again";
                        break;

                    //unknown MySQL error
                    default:
                        error = "Unhandled MySQL Connection Error.";
                        break;
                }

                throw new Exception(error, exMySQL);

            }
            catch (Exception ex)
            {
                //Catch all other errors.
                string error = "Unknown error while connection to MySQL DB" + "\n" + "Error:" + ex.Message;
                throw new Exception(error, ex);
            }
        }

        //Close connection to database
        public bool CloseConnection()
        {
            Connection.Close();
            return true;
        }

        //Retrieve the data for the Lobby orders app.
        public int LobbyOrdersData(out List<string>[] lobbyorders)
        {

            string query = "SELECT orderid, DATE_FORMAT(timedelivered, \"%h:%i %p\") as timedelivered FROM orders WHERE status = 2 and storeid = " + StoreNumber.ToString() + " ORDER BY timedelivered DESC LIMIT 10";

            //Change the lobby orders list list to store the result
            lobbyorders = new List<string>[2];
            lobbyorders[0] = new List<string>();
            lobbyorders[1] = new List<string>();

            //initial record count is 0
            RecordCount = 0;

            //If DB connection is open attem to get data.
            if (Connection.State == System.Data.ConnectionState.Open)
            {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                MySqlDataReader mysqlreader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (mysqlreader.Read())
                {
                    lobbyorders[0].Add(mysqlreader["orderid"] + "");
                    lobbyorders[1].Add(mysqlreader["timedelivered"] + "");

                    //increment the record count 
                    RecordCount++;
                }

                //close Data Reader
                mysqlreader.Close();

                //return number of records found.
                return RecordCount;

            }
            else
            {
                //if the DB is not open then no records can be read.
                return -1;
            }

        } //LobbyOrdersData
        
        //Use query string parameter and get data from the database returning a MySqlDataReader. 
        //IMPORTANT: the user of the reader needs to make sure and close the connection.
        public MySqlDataReader CustomQuery(string query)
        {

            //If DB connection is open attem to get data.
            if (Connection.State == System.Data.ConnectionState.Open)
            {

                MySqlCommand cmd = null;
                MySqlDataReader mysqlreader = null;

                try
                {
                    //Create MySQL Command object.
                    cmd = new MySqlCommand(query, Connection);

                    //Create a MySQL reader and Execute the query
                    mysqlreader = cmd.ExecuteReader();

                    //Return the Datareader
                    return mysqlreader;

                }
                catch (Exception)
                {
                    if (mysqlreader != null)
                    {
                        mysqlreader.Close();
                    }
                    throw;
                }

            }
            else
            {
                //if the DB is not open then no records can be read.
                return null;
            }

        } //CustomQuery
        public NSAMenuCategory[] getMenu() {
            NSAMenuItem[] items = getMenuItems();
            List<NSAMenuCategory> categories = new List<NSAMenuCategory>();
            MySqlDataReader menuItemReader = CustomQuery("SELECT menutypeid, name FROM menutypes;");
            while (menuItemReader.Read())
            {
                NSAMenuCategory newMC = new NSAMenuCategory();
                newMC.Name = (string)menuItemReader["name"];
                newMC.Id = (int)menuItemReader["menutypeid"];
                List<NSAMenuItem> newMC_Items = new List<NSAMenuItem>();
                foreach (NSAMenuItem nmi in items) {
                    if (nmi.CategoryID == newMC.Id) {
                        newMC_Items.Add(nmi);
                    }
                }
                newMC.Items = newMC_Items.ToArray();
                newMC.Items = items;
                categories.Add(newMC);
            }
            menuItemReader.Close();
            return categories.ToArray();
            
        }
        public NSAMenuItem getComboDrink()
        {
            //get the item to be added to the "combo" return NULL item if item isnt found

            NSAMenuItem newItem = null;

            //build query
            StringBuilder query = new StringBuilder();
            query.Append("SELECT m.menuitemid, m.name, m.price, m.menutypeid, c.discountamount ");
            query.Append("FROM menuitem m join combodrinkmenuid c on m.storeid = c.storeid AND m.menuitemid = c.menuitemid ");
            query.Append("WHERE m.storeid = ");
            query.Append(StoreNumber.ToString());
            query.Append(";");

            //execute query
            MySqlDataReader menuItemReader = CustomQuery(query.ToString());

            //if we found a discount item build the item to retuen
            if (menuItemReader != null)
            {
                newItem = new NSAMenuItem();
                if (menuItemReader.Read())
                {

                    newItem.Name = (string)menuItemReader["name"];
                    newItem.Id = (int)menuItemReader["menuitemid"];
                    newItem.CategoryID = (int)menuItemReader["menutypeid"];
                    //Combo
                    newItem.Price = (float)menuItemReader["price"];
                }
            }
            menuItemReader.Close();

            //return the item will be null 
            return newItem;
        }

        public NSAMenuItem getDiscountItem(){
            //there is a menuitem in the database called Discount that will beused to keep track of the discounts
            //the ID for this item may vary from store to store but the type will be unassigned.
            //the generic doscount will have a price of $0 for the discount
            StringBuilder query = new StringBuilder();

            
            NSAMenuItem newItem = null;

            //Build the query to get the item in question
            query.Clear();
            query.Append("SELECT menuitemid, name, menutypeid ");
            query.Append("FROM menuitem ");
            query.Append("WHERE name = 'Discount' AND menutypeid = 0 AND storeid = ");
            query.Append(StoreNumber.ToString());
            query.Append(";");

            //run the query
            MySqlDataReader menuItemReader = CustomQuery(query.ToString());

            //if resuts build item
            if (menuItemReader != null)
            {
                menuItemReader.Read();
                newItem = new NSAMenuItem();
                newItem.Name = (string)menuItemReader["name"];
                newItem.Id = (int)menuItemReader["menuitemid"];
                newItem.CategoryID = (int)menuItemReader["menutypeid"];
                newItem.Price = 0; //the default discount is 0

            }

            //close reader
            menuItemReader.Close();
            //return item ... will be null if the item is not found
            return newItem;
        }

        public NSAMenuItem getComboDrinkDiscount()
        {
            //get a discount item that has the combo drink discount.
            float Discount = 0;
            NSAMenuItem newItem = null;

            StringBuilder query = new StringBuilder();

            //get teh proper discount amount
            query.Append("SELECT storeid,discountamount FROM combodrinkmenuid WHERE storeid = ");
            query.Append(StoreNumber.ToString());
            query.Append(";");

            MySqlDataReader menuItemReader = CustomQuery(query.ToString());
            if (menuItemReader != null){
                if (menuItemReader.Read())
                {
                    Discount = (float)menuItemReader["discountamount"];
                }
            }

            menuItemReader.Close();

            //get a generic discount item
            newItem = getDiscountItem();

            //if the discount item exists then replace teh discount cost.
            if (newItem != null) {
                newItem.Price = -1 * Discount;
            }

            return newItem;
        }

        public NSAMenuItem[] getMenuItems() {
            MySqlDataReader menuItemReader = CustomQuery("SELECT menuitemid, name, price, menutypeid FROM menuitem WHERE storeid = " + StoreNumber.ToString() + " and deleted = 0;");
            List<NSAMenuItem> itemList = new List<NSAMenuItem>();
            if (menuItemReader != null)
            {
                while (menuItemReader.Read())
                {
                    NSAMenuItem newItem = new NSAMenuItem();
                    newItem.Name = (string)menuItemReader["name"];
                    newItem.Id = (int)menuItemReader["menuitemid"];
                    newItem.CategoryID = (int)menuItemReader["menutypeid"];
                    newItem.Price = (float)menuItemReader["price"];
                    itemList.Add(newItem);
                }
            }
            menuItemReader.Close();
            return itemList.ToArray();
            
        }
        public NSAOrder[] getFavoriteOrders(long loyaltyid) {
            List<NSAOrder> favOrders = new List<NSAOrder>();
            NSAOrder[] pastOrders = getPastOrders(loyaltyid);
            List<long> favOrderIDs = new List<long>();
            MySqlDataReader favOrderReader = CustomQuery("SELECT orderid FROM favoriteorder WHERE loyaltyaccount = " + loyaltyid + ";");
            if (favOrderReader != null)
            {
                while (favOrderReader.Read())
                {
                    
                    favOrderIDs.Add((int)favOrderReader["orderid"]);
                }
            }
            foreach (NSAOrder order in pastOrders) {
                if (favOrderIDs.Contains(order.Id)) {
                    favOrders.Add(order);
                }
            }
            favOrderReader.Close();
            return favOrders.ToArray();
        }
        public NSAOrder[] getPastOrders(long loyaltyid) {
            MySqlDataReader menuItemReader = CustomQuery("SELECT orderid FROM orders WHERE loyaltyid = " + loyaltyid + ";");
            List<NSAOrder> orderList = new List<NSAOrder>();
            if (menuItemReader != null)
            {
                while (menuItemReader.Read())
                {
                    NSAOrder newOrder = new NSAOrder();
                    newOrder.Id = (int)menuItemReader["orderitemid"];
                    
                    orderList.Add(newOrder);
                }
            }
            menuItemReader.Close();
            for (int i = 0; i < orderList.Count; i++) {
                orderList[i] = getPastOrderItems(orderList[i]);
            }
            menuItemReader.Close();
            return orderList.ToArray();
        }
        public NSAOrder getPastOrderItems(NSAOrder order) {
            MySqlDataReader menuItemReader = CustomQuery("SELECT name, price, menuitemid FROM orderitems WHERE orderid = " + order.Id +";");
            List<NSAHistoryItem> itemList = new List<NSAHistoryItem>();
            if (menuItemReader != null)
            {
                while (menuItemReader.Read())
                {
                    NSAHistoryItem newItem = new NSAHistoryItem();
                    newItem.Name = (string)menuItemReader["name"];
                    newItem.Id = (int)menuItemReader["menuitemid"];
                    newItem.Price = (float)menuItemReader["price"];
                    newItem.getComponents(this, getComponents());
                    itemList.Add(newItem);
                }
            }
            menuItemReader.Close();
            foreach (NSAMenuItem nmi in itemList) {
                nmi.Components = new List<NSAComponent>();
                MySqlDataReader miComponentREader = CustomQuery("SELECT ");
            }
            
            foreach (NSAHistoryItem i in itemList){
                order.Items.Add(i);
            }
            return order;
            
        }
        public NSAFavoriteItem[] getFavoriteItems(string loyaltyid)
        {
            MySqlDataReader menuItemReader = CustomQuery("SELECT favoriteitemid, name, price FROM favoriteitems WHERE loyaltyid = " + loyaltyid + ";");
            List<NSAFavoriteItem> itemList = new List<NSAFavoriteItem>();
            if (menuItemReader != null)
            {
                while (menuItemReader.Read())
                {
                    NSAFavoriteItem newItem = new NSAFavoriteItem();
                    newItem.Name = menuItemReader["name"].ToString();
                    newItem.Id = (int)menuItemReader["favoriteitemid"];
                    newItem.Price = (float)menuItemReader["price"];
                    itemList.Add(newItem);
                }
            }
            menuItemReader.Close();
            return itemList.ToArray();

        }
        public Dictionary<int, string> getCategories() {
            Dictionary<int, string> categories = new Dictionary<int, string>();
            MySqlDataReader componentCategoryReader = CustomQuery("SELECT categoryid, categoryname FROM componentcategories;");
            if (componentCategoryReader != null)
            {
                while (componentCategoryReader.Read())
                {
                    categories.Add((int)componentCategoryReader["categoryid"], (string)componentCategoryReader["categoryname"]);
                }
            }
            componentCategoryReader.Close();
            return categories;
        }
        public NSAComponent[] getComponents()
        {

            Dictionary<int, string> categories = getCategories();
            MySqlDataReader componentReader = CustomQuery("SELECT componentid, name, categoryid FROM components WHERE storeid = " + StoreNumber.ToString() + " and deleted = 0;");
            List<NSAComponent> itemList = new List<NSAComponent>();
            if (componentReader != null)
            {
                while (componentReader.Read())
                {
                    NSAComponent newcomponent = new NSAComponent();
                    newcomponent.ComponentID = (int)componentReader["componentid"];
                    newcomponent.Name = (string)componentReader["name"];
                    newcomponent.Category = categories[(int)componentReader["categoryid"]];
                    
                    itemList.Add(newcomponent);
                }
            }
            componentReader.Close();
            return itemList.ToArray();

        }

        public string[] getTop3Entrees()
        {
            //returns a string array of the top 3 selling entrees from the previous day.

            //build query
            StringBuilder query = new StringBuilder();
            query.Append("SELECT  J.name, count(J.menuitemid) as Rank ");
            query.Append("FROM (SELECT OI.name, OI.menuitemid, O.timeplaced ");
	        query.Append("FROM orderitems OI join orders O ON OI.orderID = O.orderID ");
	        query.Append("Where DATE(O.timeplaced) = DATE(DATE_SUB(NOW(), INTERVAL 1 DAY)) AND O.storeid = 1 AND ");
		    query.Append("OI.menuitemid in (SELECT menuitemid FROM menuitem where storeid = ");
            query.Append(StoreNumber.ToString());
            query.Append(" AND menutypeid in (1,2))) as J ");
            query.Append("GROUP BY name ORDER BY Rank DESC LIMIT 3;");

            //run query
            MySqlDataReader componentReader = CustomQuery(query.ToString());

            //build list if we have items -- array may have < 3 items if < 3 types of entrees were sold.
            List<string> itemList = new List<string>();
            if (componentReader != null)
            {
                while (componentReader.Read())
                {
                    string tempString = "";
                    tempString = (string)componentReader["name"];
                    itemList.Add(tempString);
                }
                componentReader.Close();
            }

            //return array.
            return itemList.ToArray();

        }
        public void createNewOrder() {
            CustomQuery("INSERT;");

        }

        //Return true if Database is connected
        public bool Connected()
        {
            return (Connection.State == System.Data.ConnectionState.Open);
        }

        //create a loyalty account and returns its account number
        public string createLoyaltyAccount(string accountname, string emailaddress)
        {
            List<String> loyaltyaccounts;

            if (Connection.State == System.Data.ConnectionState.Open)
            {
                string query = "SELECT loyaltyid FROM loyaltyaccounts WHERE storeid = " + StoreNumber.ToString() + " ORDER BY loyaltyid";

                //Change the Manager orders list list to store the result
                loyaltyaccounts = new List<string>();

                //initial record count is 0
                RecordCount = 0;

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                MySqlDataReader mysqlreader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (mysqlreader.Read())
                {
                    loyaltyaccounts.Add(mysqlreader["loyaltyid"] + "");

                    //increment the record count 
                    RecordCount++;
                }

                string idNum; //idNum stores the account number
          
                //close Data Reader
                mysqlreader.Close();

                if (RecordCount == 0)
                {
                    idNum = StoreNumber.ToString("D4") + RecordCount.ToString("D8"); //store number
                    query = "INSERT INTO loyaltyaccounts (loyaltyid, storeid, name, emailaddress) VALUES ('" + StoreNumber.ToString("D4") + RecordCount.ToString("D8") + "', '" + StoreNumber.ToString() + "', '" + accountname.ToString() + "', '" + emailaddress.ToString() + "')";
                }
                else
                {
                    int accountnumber = Convert.ToInt32(loyaltyaccounts[RecordCount - 1]);
                    accountnumber++;
                    idNum = accountnumber.ToString("D12"); //store number
                    query = "INSERT INTO loyaltyaccounts (loyaltyid, storeid, name, emailaddress) VALUES ('" + accountnumber.ToString("D12") + "', '" + StoreNumber.ToString() + "', '" + accountname.ToString() + "', '" + emailaddress.ToString() + "')";
                }

                //Create MySQL Command object.
                cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                cmd.ExecuteNonQuery();
                return idNum;
            }
            return "FAIL";
        }

        //gets a loyalty accounts info
        public int getLoyaltyAccountInfo(out List<string>[] loyaltyaccounts, string accountNumber)
        {
            loyaltyaccounts = new List<string>[4]; //store data in loyaltyaccount
            loyaltyaccounts[0] = new List<string>();
            loyaltyaccounts[1] = new List<string>();
            loyaltyaccounts[2] = new List<string>();
            loyaltyaccounts[3] = new List<string>();

            string query = "SELECT name, emailaddress, rewardscount FROM loyaltyaccounts WHERE storeid = " + StoreNumber.ToString() +
                        " and loyaltyid = " + accountNumber.ToString() + " ORDER BY loyaltyid";

            //If DB connection is open attem to get data.
            if (Connection.State == System.Data.ConnectionState.Open)
            {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                MySqlDataReader mysqlreader = cmd.ExecuteReader();

                //Read the data and store them in the lists
                while (mysqlreader.Read())
                {
                    loyaltyaccounts[0].Add(mysqlreader["name"] + "");
                    loyaltyaccounts[1].Add(mysqlreader["emailaddress"] + "");
                    loyaltyaccounts[2].Add(mysqlreader["rewardscount"] + "");

                    //increment the record count 
                    RecordCount++;
                }

                loyaltyaccounts[3].Add(accountNumber); //add the account number to [3][0]
                //close Data Reader

                mysqlreader.Close();

                //return number of records found. (if 0 or -1 account was not found)
                return RecordCount;

            }
            else
            {
                //if the DB is not open then no records can be read.
                return -1;
            }
        }

    } //class DatabaseConnection
}
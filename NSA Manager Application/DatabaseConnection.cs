using System.Windows.Forms;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using MySql.Data;

namespace NSA_Manager
{
    class NSADatabase
    {
        private MySqlConnection Connection;
        private string DBServer;    //IP address or host name for server
        private string DBName;      //Database name to use
        private string DBUser;      //DB username
        private string DBPassword;  //Password for the username used.
        private int StoreNumber;    //Store Number.
        private int RecordCount; //Number of record that are currently loaded.

        //Constructor - Default Sets default values and DOES not open connectiton.
        public NSADatabase()
        {
            //Default values are used since none are specified.
            Initialize("localhost", "nsa-database", "root", "", 1);
        }

        //Will attempt to open the connection.
        public NSADatabase(string server, string dbname, string dbuser, string password) {
            Initialize(server, dbname, dbuser, password, -1);
            this.OpenConnection();
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

        //Retrieve the data for the Manager Orders List.
        public int ManagerOrdersData(out List<string>[] managerorders)
        {

            string query = "SELECT orderid, DATE_FORMAT(timeplaced, \"%h:%i %p\") as timeplaced, refunded FROM orders WHERE status > 0 and storeid = " + StoreNumber.ToString() + " ORDER BY orderid";

            //Change the Manager orders list list to store the result
            managerorders = new List<string>[3];
            managerorders[0] = new List<string>();
            managerorders[1] = new List<string>();
            managerorders[2] = new List<string>();

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
                    managerorders[0].Add(mysqlreader["orderid"] + "");
                    managerorders[1].Add(mysqlreader["timeplaced"] + "");
                    managerorders[2].Add(mysqlreader["refunded"] + "");

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

        } //ManagerOrdersData

        // Gets Information for Manager Order Items List
        public int ManagerOrderItemData(out List<string>[] managerorderitems, string orderid)
        {
            string query = "SELECT orderitemid, name, refunded FROM orderitems WHERE orderid = " + orderid.ToString() + " and storeid = " + StoreNumber.ToString() + " ORDER BY menuitemid";

            //Change the Manager orders list list to store the result
            managerorderitems = new List<string>[3];
            managerorderitems[0] = new List<string>();
            managerorderitems[1] = new List<string>();
            managerorderitems[2] = new List<string>();

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
                    managerorderitems[0].Add(mysqlreader["orderitemid"] + "");
                    managerorderitems[1].Add(mysqlreader["name"] + "");
                    managerorderitems[2].Add(mysqlreader["refunded"] + "");

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
        } //ManagerOrderItemData

        // Updates an Order in the database to mark that it has been Refunded
        public void ManagerRefundOrders( string orderid )
        {
            string query = "UPDATE orders SET refunded = 1 WHERE orderid = " + orderid.ToString() + " and storeid = " + StoreNumber.ToString();

            if (Connection.State == System.Data.ConnectionState.Open)
            {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                cmd.ExecuteNonQuery();

            }
        } //ManagerRefundOrders

        // Updates an Order Item in the database to mark that it has been Refunded
        public void ManagerRefundItem(string orderid, string orderitemid)
        {
            string query = "UPDATE orderitems SET refunded = 1 WHERE orderid = " + orderid.ToString() + " and orderitemid = '" + orderitemid.ToString() + "' and storeid = " + StoreNumber.ToString();

            if (Connection.State == System.Data.ConnectionState.Open)
            {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                cmd.ExecuteNonQuery();

            }
        } //ManagerRefundItem

        //Retrieve the data for the Loyalty Account List.
        public int ManagerGetLoyaltyAccount(out List<string>[] loyaltyaccounts, string loyaltyid, string accountname, string emailaddress)
        {
            string query = "";

            // Checks to see if textbox are empty
            if (String.IsNullOrWhiteSpace(loyaltyid))
            {
                if (String.IsNullOrWhiteSpace(accountname))
                {
                    if (String.IsNullOrWhiteSpace(emailaddress))
                    {
                        query = "SELECT loyaltyid, emailaddress FROM loyaltyaccounts WHERE storeid = " + StoreNumber.ToString() +
                            " ORDER BY loyaltyid";
                    }
                    else
                    {
                        query = "SELECT loyaltyid, emailaddress FROM loyaltyaccounts WHERE storeid = " + StoreNumber.ToString() +
                            " and emailaddress = '" + emailaddress.ToString() + "' ORDER BY loyaltyid";
                    }
                }
                else if (String.IsNullOrWhiteSpace(emailaddress))
                {
                    query = "SELECT loyaltyid, emailaddress FROM loyaltyaccounts WHERE storeid = " + StoreNumber.ToString() +
                            " and name = '" + accountname.ToString() + "' ORDER BY loyaltyid";
                }
            }
            else if (String.IsNullOrWhiteSpace(accountname))
            {
                if (String.IsNullOrWhiteSpace(emailaddress))
                {
                    query = "SELECT loyaltyid, emailaddress FROM loyaltyaccounts WHERE storeid = " + StoreNumber.ToString() +
                        " and loyaltyid = " + loyaltyid.ToString() + " ORDER BY loyaltyid";
                }
                else
                {
                    query = "SELECT loyaltyid, emailaddress FROM loyaltyaccounts WHERE storeid = " + StoreNumber.ToString() +
                        " and loyaltyid = " + loyaltyid.ToString() + " and emailaddress = '" + emailaddress.ToString() + "' ORDER BY loyaltyid";
                }
            }
            else if (String.IsNullOrWhiteSpace(emailaddress))
            {
                query = "SELECT loyaltyid, emailaddress FROM loyaltyaccounts WHERE storeid = " + StoreNumber.ToString() +
                            " and loyaltyid = " + loyaltyid.ToString() + " and name = '" + accountname.ToString() + "' ORDER BY loyaltyid";
            }

            //Change the Manager orders list list to store the result
            loyaltyaccounts = new List<string>[2];
            loyaltyaccounts[0] = new List<string>();
            loyaltyaccounts[1] = new List<string>();

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
                    loyaltyaccounts[0].Add(mysqlreader["loyaltyid"] + "");
                    loyaltyaccounts[1].Add(mysqlreader["emailaddress"] + "");

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

        } //ManagerGetLoyaltyAccount

        public void ManagerSaveLoyaltyAccount(string accountname, string emailaddress)
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

                //close Data Reader
                mysqlreader.Close();

                if(RecordCount == 0)
                {
                    query = "INSERT INTO loyaltyaccounts (loyaltyid, storeid, name, emailaddress) VALUES ('" + StoreNumber.ToString("D4") + RecordCount.ToString("D8") + "', '" + StoreNumber.ToString() + "', '" + accountname.ToString() + "', '" + emailaddress.ToString() + "')";
                }
                else
                {
                    int accountnumber = Convert.ToInt32(loyaltyaccounts[RecordCount - 1]);
                    accountnumber++;

                    query = "INSERT INTO loyaltyaccounts (loyaltyid, storeid, name, emailaddress) VALUES ('" + accountnumber.ToString("D12") + "', '" + StoreNumber.ToString() + "', '" + accountname.ToString() + "', '" + emailaddress.ToString() + "')";
                }

                //Create MySQL Command object.
                cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                cmd.ExecuteNonQuery();

            }
        } //ManagerSaveLoyaltyAccount

        public void ManagerClearOrderScreen()
        {
            string query = "UPDATE orders SET status = 3 Where storeid = " + StoreNumber.ToString() + " AND status = 2";

            if (Connection.State == System.Data.ConnectionState.Open)
            {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                cmd.ExecuteNonQuery();

            }
        } //Manager Clear Orders Screen

        //Retrieve the data for the Manager Accounts List.
        public int ManagerAccountsData(out List<string>[] manageraccounts)
        {

            string query = "SELECT managerid, firstname, lastname, employeeid FROM managers WHERE isassistant = 1 and storeid = " + StoreNumber.ToString() + " ORDER BY managerid";

            //Change the Manager Accounts list to store the result
            manageraccounts = new List<string>[4];
            manageraccounts[0] = new List<string>();
            manageraccounts[1] = new List<string>();
            manageraccounts[2] = new List<string>();
            manageraccounts[3] = new List<string>();

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
                    manageraccounts[0].Add(mysqlreader["managerid"] + "");
                    manageraccounts[1].Add(mysqlreader["firstname"] + "");
                    manageraccounts[2].Add(mysqlreader["lastname"] + "");
                    manageraccounts[3].Add(mysqlreader["employeeid"] + "");

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

        } //ManagerAccountsData

        public int ManagerGetInventoryData(out List<string>[] inventorydata)
        {

            string query = "SELECT componentid, name, quantity FROM components WHERE storeid = " + StoreNumber.ToString() + " ORDER BY name";

            //Change the inventory data list to store the result
            inventorydata = new List<string>[3];
            inventorydata[0] = new List<string>();
            inventorydata[1] = new List<string>();
            inventorydata[2] = new List<string>();

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
                    inventorydata[0].Add(mysqlreader["componentid"] + "");
                    inventorydata[1].Add(mysqlreader["name"] + "");
                    inventorydata[2].Add(mysqlreader["quantity"] + "");

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

        } //ManagerGetInventoryData

        public int ManagerGetComponentData(out List<string>[] componentdata)
        {

            string query = "SELECT componentid, name, price FROM components WHERE deleted = 0 and storeid = " + StoreNumber.ToString() + " ORDER BY componentid";

            //Change the inventory data list to store the result
            componentdata = new List<string>[3];
            componentdata[0] = new List<string>();
            componentdata[1] = new List<string>();
            componentdata[2] = new List<string>();

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
                    componentdata[0].Add(mysqlreader["componentid"] + "");
                    componentdata[1].Add(mysqlreader["name"] + "");
                    componentdata[2].Add(mysqlreader["price"] + "");

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

        } //ManagerGetComponentData

        public int ManagerGetMenuItemData(out List<string>[] menuitemdata)
        {

            string query = "SELECT menuitemid, name FROM menuitem WHERE deleted = 0 and storeid = " + StoreNumber.ToString() + " ORDER BY menuitemid";

            //Change the inventory data list to store the result
            menuitemdata = new List<string>[2];
            menuitemdata[0] = new List<string>();
            menuitemdata[1] = new List<string>();

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
                    menuitemdata[0].Add(mysqlreader["menuitemid"] + "");
                    menuitemdata[1].Add(mysqlreader["name"] + "");

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

        } //ManagerGetComponentData

        public void ManagerDeleteLoyaltyAccount(string loyaltyid)
        {
            string query = "DELETE FROM loyaltyaccounts WHERE loyaltyid = " + loyaltyid.ToString() + " and storeid = " + StoreNumber.ToString();

            if (Connection.State == System.Data.ConnectionState.Open)
            {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                cmd.ExecuteNonQuery();

            }
        } //ManagerDeleteLoyaltyAccount

        public void ManagerDeleteManagerAccount(string managerid)
        {
            string query = "DELETE FROM managers WHERE managerid = " + managerid.ToString() + " and storeid = " + StoreNumber.ToString();

            if (Connection.State == System.Data.ConnectionState.Open)
            {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                cmd.ExecuteNonQuery();

            }
        } //ManagerDeleteManagerAccount

        public void ManagerSaveManagerAccount(string firstname, string lastname, string employeeid, string password)
        {
            string query = "INSERT INTO managers (storeid, firstname, lastname, employeeid, password, isassistant) VALUES ('" + StoreNumber.ToString() + "', '" + firstname.ToString() + "', '" + lastname.ToString() + "', '" + employeeid.ToString() + "', '" + password.ToString() + "', 1 )";

            if (Connection.State == System.Data.ConnectionState.Open)
            {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                cmd.ExecuteNonQuery();

            }
        } //ManagerSaveManagerAccount

        public void ManagerUpdateInventory(string componentid, string quantity)
        {
            string query = "UPDATE components SET quantity = " + quantity.ToString() + " WHERE componentid = " + componentid.ToString();

            if (Connection.State == System.Data.ConnectionState.Open)
            {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                cmd.ExecuteNonQuery();

            }
        } //ManagerUpdateInventory

        public void ManagerDeleteComponent(string componentid)
        {
            string query = "UPDATE components SET deleted = 1 WHERE componentid = " + componentid.ToString() + " and storeid = " + StoreNumber.ToString();

            if (Connection.State == System.Data.ConnectionState.Open)
            {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                cmd.ExecuteNonQuery();

            }
        } //ManagerDeleteComponent

        public void ManagerSaveComponent(string componentname, string componentcategory, string componentprice, string componentcost, string componenthighquantity, string componentlowquantity)
        {
            string query = "INSERT INTO components (storeid, name, cost, price, categoryid, quantity, lowquantity, deleted) VALUES ('" + StoreNumber.ToString() + "', '"
                + componentname.ToString() + "', '" + componentcost.ToString() + "', '" + componentprice.ToString() + "', '" + componentcategory.ToString() + "', '" 
                + componenthighquantity.ToString() + "', '" + componentlowquantity.ToString() + "', 0 )";

            if (Connection.State == System.Data.ConnectionState.Open)
            {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                cmd.ExecuteNonQuery();
            }
        } //ManagerSaveComponent

        public void ManagerDeleteMenuItem(string menuitemid)
        {
            string query = "UPDATE menuitem SET deleted = 1 WHERE menuitemid = " + menuitemid.ToString() + " and storeid = " + StoreNumber.ToString();

            if (Connection.State == System.Data.ConnectionState.Open)
            {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                cmd.ExecuteNonQuery();

            }
        } //ManagerDeleteMenuItem

        public string ManagerCreateMenuItem(string menuitemname, string menuitemcategory, string menuitemprice, string isspecial)
        {
            string menuitemid = null;

            string createquery = "INSERT INTO menuitem (storeid, name, cost, price, isspecial, menutypeid, deleted) VALUES ('" + StoreNumber.ToString() + "', '" + menuitemname.ToString() + "', 0, '" + menuitemprice.ToString() + "', '" +isspecial.ToString() + "', '" + menuitemcategory.ToString() + "', 0)";
            string query = "SELECT menuitemid FROM menuitem WHERE name = '" + menuitemname.ToString() + "' and storeid = " + StoreNumber.ToString() + " ORDER BY menuitemid";

            if (Connection.State == System.Data.ConnectionState.Open)
            {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(createquery, Connection);

                //Create a MySQL reader and Execute the query
                cmd.ExecuteNonQuery();

                //Create MySQL Command object.
                cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                MySqlDataReader mysqlreader = cmd.ExecuteReader();

                //Read the data and store them in the list
                mysqlreader.Read();
                menuitemid = mysqlreader["menuitemid"].ToString();

                //close Data Reader
                mysqlreader.Close();
            }

            return menuitemid;
        } // ManagerCreateMenuItem

        public void ManagerCreateMenuItemComponent(string menuitemid, string componentid)
        {
            string query = "INSERT INTO menuitemcomponents (menuitemid, storeid, component) VALUES ('" + menuitemid.ToString() + "', '" + StoreNumber.ToString() + "', '" + componentid.ToString() + "')";

            if (Connection.State == System.Data.ConnectionState.Open)
            {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                cmd.ExecuteNonQuery();
            }
        } //ManagerCreateMenuItemComponent

        public void ManagerCreateSpecial(string menuitemid, string begindate, string enddate, int daymask)
        {
            string query = "INSERT INTO specials (menuitemid, storeid, begindate, enddate, daymask) VALUES ('" + menuitemid.ToString() + "', '" + StoreNumber.ToString() + "', '" + begindate.Trim(new Char[] { '/' }) + "', '" + enddate.Trim(new Char[] { '/' }) + "', '" + daymask.ToString() + "')";

            if (Connection.State == System.Data.ConnectionState.Open)
            {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                cmd.ExecuteNonQuery();
            }
        } //ManagerCreateSpecial

        public string ManagerLogin(string username, string password)
        {
            string assistflag = "-1";

            string query = "SELECT * FROM managers WHERE storeid = " + StoreNumber.ToString() + " and employeeid = '" + username.ToString() + "' and password = '" + password.ToString() + "' ORDER BY managerid";

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
                    assistflag = mysqlreader["isassistant"].ToString();

                    //increment the record count 
                    RecordCount++;
                }

                //close Data Reader
                mysqlreader.Close();

                if (RecordCount == 1)
                {
                    return assistflag;
                }
            }

            return assistflag;
        }

        //Return true if Database is connected
        public bool Connected()
        {
            return (Connection.State == System.Data.ConnectionState.Open);
        }

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

    } //class DatabaseConnection

} //CSCE_4444_Term_Project
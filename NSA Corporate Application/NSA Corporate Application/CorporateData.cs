using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

using NSA;

namespace NSA_Corporate_Application {
    class CorporateData {
        //Database object that we use to access the data in the database.
        private NSADatabase nsadb;  //Database connection object.

        //Constructor - Hiding the default constructor 
        private CorporateData() {
        }

        //Constructor that specifies the connection other than the default 
        //Will attempt to open the connection.
        public CorporateData(string server, string dbname, string dbuser, string password) {
            nsadb = new NSADatabase(server, dbname, dbuser, password);
        }

        public bool Connected(){
            return nsadb.Connected();
        }

        //Get the information about the stores in the Database
        public int StoresData(out List<string>[] Stores) {

            string query = "SELECT storeid, name, address, city, state, zip FROM stores;";

            //Change the Manager Accounts list to store the result
            Stores = new List<string>[6];
            Stores[0] = new List<string>();
            Stores[1] = new List<string>();
            Stores[2] = new List<string>();
            Stores[3] = new List<string>();
            Stores[4] = new List<string>();
            Stores[5] = new List<string>();

            //initial record count is 0
            int recordcount = 0;

            //test for open connection and try to open
            if (!nsadb.Connected()) {
                nsadb.OpenConnection();
            }

            //If DB connection is open attem to get data.
            if (nsadb.Connected()) {

                //Create a MySQL reader and Execute the query
                MySqlDataReader mysqlreader = nsadb.CustomQuery(query);

                //Read the data and store them in the list
                while (mysqlreader.Read()) {
                    Stores[0].Add(mysqlreader["storeid"] + "");
                    Stores[1].Add(mysqlreader["name"] + "");
                    Stores[2].Add(mysqlreader["address"] + "");
                    Stores[3].Add(mysqlreader["city"] + "");
                    Stores[4].Add(mysqlreader["state"] + "");
                    Stores[5].Add(mysqlreader["zip"] + "");

                    //increment the record count 
                    recordcount++;
                }

                //close Data Reader
                mysqlreader.Close();

                //return number of records found.
                return recordcount;

            } else {
                //if the DB is not open then no records can be read.
                return -1;
            }

        } //Stores

        //Insert a new store
        public void CorporateSaveStore(string StoreName, string StoreAddress, string StoreCity, string StoreState, string StoreZip) {
            StringBuilder query = new StringBuilder();

            query.Append("INSERT INTO stores (name, address, city, state, zip) VALUES ('");
            query.Append(StoreName);
            query.Append("', '");
            query.Append(StoreAddress);
            query.Append("', '");
            query.Append(StoreCity);
            query.Append("', '");
            query.Append(StoreState);
            query.Append("', '");
            query.Append(StoreZip);
            query.Append("');");

            // connect to DB if it is not connected
            if (!nsadb.Connected()) {
                nsadb.OpenConnection();
            }

            //If DB connection is open attem to execute insert query.
            if (nsadb.Connected()) {
                nsadb.ExecuteQuery(query.ToString());
            }


        }

        //Delete Store.
        public void CorporateStore(string storeid) {
            string query = "DELETE FROM stores WHERE storeid = '" + storeid + "';";

            // connect to DB if it is not connected
            if (!nsadb.Connected()) {
                nsadb.OpenConnection();
            }

            //If DB connection is open attem to get data.
            if (nsadb.Connected()) {

                nsadb.ExecuteQuery(query);

            }
        } //CorporatDeleteManagerAccount

        // Gets Information for Manager Order Items List
        public int CorporateOrderItemData(out List<string>[] corporateorderitems,string storeid, string orderid) {

            StringBuilder query = new StringBuilder();
            
            //Build the Query
            query.Append("SELECT orderitemid, name, refunded FROM orderitems WHERE orderid =");
            query.Append( orderid.ToString());
            query.Append(" AND storeid =");
            query.Append(storeid);
            query.Append(" ORDER BY menuitemid");

            //Change the Manager orders list list to store the result
            corporateorderitems = new List<string>[3];
            corporateorderitems[0] = new List<string>();
            corporateorderitems[1] = new List<string>();
            corporateorderitems[2] = new List<string>();

            int RecordCount = 0;

            // connect to DB if it is not connected
            if (!nsadb.Connected()) {
                nsadb.OpenConnection();
            }

            //If DB connection is open attem to get data.
            if (nsadb.Connected()) {

                //Create a MySQL reader and Execute the query
                MySqlDataReader mysqlreader = nsadb.CustomQuery(query.ToString());

                //Read the data and store them in the list
                while (mysqlreader.Read()) {
                    corporateorderitems[0].Add(mysqlreader["orderitemid"] + "");
                    corporateorderitems[1].Add(mysqlreader["name"] + "");
                    corporateorderitems[2].Add(mysqlreader["refunded"] + "");

                    //increment the record count 
                    RecordCount++;
                }

                //close Data Reader
                mysqlreader.Close();

                //return number of records found.
                return RecordCount;

            } else {
                //if the DB is not open then no records can be read.
                return -1;
            }
        } //CorporateOrderItemData

        //Retrieve the data for the Manager Orders List.
        public int CorporateOrdersData(out List<string>[] corporateorders, string storeid) {

            string query = "SELECT orderid, DATE_FORMAT(timeplaced, \"%h:%i %p\") as timeplaced, refunded FROM orders WHERE status > 0 and storeid = " + storeid + " ORDER BY orderid";

            //Change the Manager orders list list to store the result
            corporateorders = new List<string>[3];
            corporateorders[0] = new List<string>();
            corporateorders[1] = new List<string>();
            corporateorders[2] = new List<string>();

            //initial record count is 0
            int RecordCount = 0;

            // connect to DB if it is not connected
            if (!nsadb.Connected()) {
                nsadb.OpenConnection();
            }

            //If DB connection is open attem to get data.
            if (nsadb.Connected()) {

                //Create a MySQL reader and Execute the query
                MySqlDataReader mysqlreader = nsadb.CustomQuery(query.ToString());

                //Read the data and store them in the list
                while (mysqlreader.Read()) {
                    corporateorders[0].Add(mysqlreader["orderid"] + "");
                    corporateorders[1].Add(mysqlreader["timeplaced"] + "");
                    corporateorders[2].Add(mysqlreader["refunded"] + "");

                    //increment the record count 
                    RecordCount++;
                }

                //close Data Reader
                mysqlreader.Close();

                //return number of records found.
                return RecordCount;

            } else {
                //if the DB is not open then no records can be read.
                return -1;
            }

        } //CorporateOrdersData

        //Retrieve the data for the Loyalty Account List.
        public int CorporateLoyaltyAccountData(out List<string>[] loyaltyaccounts, string storeID) {
            string query = "";

            // Checks to see if string is empty or null to determine which query to use
            if (String.IsNullOrWhiteSpace(storeID)) {
                query = "SELECT storeid, loyaltyid, emailaddress FROM loyaltyaccounts ORDER BY loyaltyid";
            } else {
                query = "SELECT storeid, loyaltyid, emailaddress FROM loyaltyaccounts WHERE storeid = '" +
                            storeID + "' ORDER BY loyaltyid";
            }

            //Change the Manager orders list list to store the result
            loyaltyaccounts = new List<string>[3];
            loyaltyaccounts[0] = new List<string>();
            loyaltyaccounts[1] = new List<string>();
            loyaltyaccounts[2] = new List<string>();

            //initial record count is 0
            int RecordCount = 0;

            // connect to DB if it is not connected
            if (!nsadb.Connected()) {
                nsadb.OpenConnection();
            }

            //If DB connection is open attem to get data.
            if (nsadb.Connected()) {

                //Create a MySQL reader and Execute the query
                MySqlDataReader mysqlreader = nsadb.CustomQuery(query);

                //Read the data and store them in the list
                while (mysqlreader.Read()) {
                    loyaltyaccounts[0].Add(mysqlreader["storeid"] + "");
                    loyaltyaccounts[1].Add(mysqlreader["loyaltyid"] + "");
                    loyaltyaccounts[2].Add(mysqlreader["emailaddress"] + "");

                    //increment the record count 
                    RecordCount++;
                }

                //close Data Reader
                mysqlreader.Close();

                //return number of records found.
                return RecordCount;

            } else {
                //if the DB is not open then no records can be read.
                return -1;
            }

        } //CorporateGetLoyaltyAccount

        //Retrieve the data for the Manager Accounts List.
        public int CorporateManagerAccountsData(out List<string>[] manageraccounts) {

            string query = "SELECT storeid, managerid, firstname, lastname, employeeid FROM managers WHERE isassistant = 0 ORDER BY storeid";

            //Change the Manager Accounts list to store the result
            manageraccounts = new List<string>[5];
            manageraccounts[0] = new List<string>();
            manageraccounts[1] = new List<string>();
            manageraccounts[2] = new List<string>();
            manageraccounts[3] = new List<string>();
            manageraccounts[4] = new List<string>();

            //initial record count is 0
            int RecordCount = 0;

            // connect to DB if it is not connected
            if (!nsadb.Connected()) {
                nsadb.OpenConnection();
            }

            //If DB connection is open attem to get data.
            if (nsadb.Connected()) {

                //Create a MySQL reader and Execute the query
                MySqlDataReader mysqlreader = nsadb.CustomQuery(query);

                //Read the data and store them in the list
                while (mysqlreader.Read()) {
                    manageraccounts[0].Add(mysqlreader["storeid"] + "");
                    manageraccounts[1].Add(mysqlreader["managerid"] + "");
                    manageraccounts[2].Add(mysqlreader["firstname"] + "");
                    manageraccounts[3].Add(mysqlreader["lastname"] + "");
                    manageraccounts[4].Add(mysqlreader["employeeid"] + "");

                    //increment the record count 
                    RecordCount++;
                }

                //close Data Reader
                mysqlreader.Close();

                //return number of records found.
                return RecordCount;

            } else {
                //if the DB is not open then no records can be read.
                return -1;
            }

        } //CorporateManagerAccountsData

        //Inserta a new manager into the database 
        public void CorporateSaveManagerAccount(string firstname, string lastname, string employeeid, string password, string storeID) {
            StringBuilder query = new StringBuilder();
            
            query.Append("INSERT INTO managers (storeid, firstname, lastname, employeeid, password, isassistant) VALUES ('");
            query.Append(storeID);
            query.Append("', '");
            query.Append(firstname);
            query.Append("', '" );
            query.Append(lastname);
            query.Append("', '" );
            query.Append(employeeid);
            query.Append("', '");
            query.Append(password);
            query.Append("', 0 );");

            // connect to DB if it is not connected
            if (!nsadb.Connected()) {
                nsadb.OpenConnection();
            }

            //If DB connection is open attem to execute insert query.
            if (nsadb.Connected()) {
                nsadb.ExecuteQuery(query.ToString());
            }

        } //CorporateSaveManagerAccount

        //Delete Manager Account.
        public void CorporatDeleteManagerAccount(string managerid) {
            string query = "DELETE FROM managers WHERE managerid = '" + managerid + "';";

            // connect to DB if it is not connected
            if (!nsadb.Connected()) {
                nsadb.OpenConnection();
            }

            //If DB connection is open attem to get data.
            if (nsadb.Connected()) {

                nsadb.ExecuteQuery(query);

            }
        } //CorporatDeleteManagerAccount

        //Get data for inventory window
        public int CorporateGetInventoryData(out List<string>[] inventorydata, string storeid) {

            string query = "SELECT componentid, name, quantity FROM components WHERE storeid = " + storeid + " ORDER BY name";

            //Change the inventory data list to store the result
            inventorydata = new List<string>[3];
            inventorydata[0] = new List<string>();
            inventorydata[1] = new List<string>();
            inventorydata[2] = new List<string>();

            //initial record count is 0
            int RecordCount = 0;

            //If DB connection is open attem to get data.
            if (nsadb.Connected()) {

                //Create a MySQL reader and Execute the query
                MySqlDataReader mysqlreader = nsadb.CustomQuery(query);

                //Read the data and store them in the list
                while (mysqlreader.Read()) {
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

            } else {
                //if the DB is not open then no records can be read.
                return -1;
            }

        } //CorporateGetInventoryData

    }
}

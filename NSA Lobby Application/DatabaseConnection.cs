///////////////////////////////////////////////////////////////////////////////
//Module Name:  DatabaseConnection.cs
//Project:      NSA Lobby Application
//Developer:    Trae Watkins
//Last Changes: 3/26/2014 - Trae Watkins
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

namespace NSA{
    public class NSADatabase {
        private MySqlConnection Connection;
        private string DBServer;    //IP address or host name for server
        private string DBName;      //Database name to use
        private string DBUser;      //DB username
        private string DBPassword;  //Password for the username used.
        private int StoreNumber;    //Store Number.
        private int RecordCount; //Number of record that are currently loaded.

        //Constructor - Default Sets default values and DOES not open connectiton.
        public NSADatabase() {
            //Default values are used since none are specified.
            Initialize("localhost", "nsa-database", "root", "", 1);

        }

        //Constructor that specifies the connection other than the default 
        //Will attempt to open the connection.
        public NSADatabase(string server, string dbname, string dbuser, string password, int storenum) {
            Initialize(server, dbname, dbuser, password, storenum);
            this.OpenConnection();
        }

        //Initialize - store values for the private variables and initialize the connection object.
        private void Initialize(string server, string dbname, string dbuser, string password, int storenum) {
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
        public bool OpenConnection() {
            try {
                Connection.Open();
                return true;
            } catch (MySqlException exMySQL) {
                string error;
                switch (exMySQL.Number) {

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

            } catch (Exception ex) {
                //Catch all other errors.
                string error = "Unknown error while connection to MySQL DB" + "\n" + "Error:" + ex.Message;
                throw new Exception(error, ex);
            }
        }

        //Close connection to database
        public bool CloseConnection() {
            Connection.Close();
            return true;
        }

        //Retrieve the data for the Lobby orders app.
        public int LobbyOrdersData(out List<string>[] lobbyorders) {

            string query = "SELECT orderid, DATE_FORMAT(timedelivered, \"%h:%i %p\") as timedelivered FROM orders WHERE status = 2 and storeid = " + StoreNumber.ToString() + " ORDER BY timedelivered DESC LIMIT 10";

            //Change the lobby orders list list to store the result
            lobbyorders = new List<string>[2];
            lobbyorders[0] = new List<string>();
            lobbyorders[1] = new List<string>();

            //initial record count is 0
            RecordCount = 0;

            //If DB connection is open attem to get data.
            if (Connection.State == System.Data.ConnectionState.Open) {

                //Create MySQL Command object.
                MySqlCommand cmd = new MySqlCommand(query, Connection);

                //Create a MySQL reader and Execute the query
                MySqlDataReader mysqlreader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (mysqlreader.Read()) {
                    lobbyorders[0].Add(mysqlreader["orderid"] + "");
                    lobbyorders[1].Add(mysqlreader["timedelivered"] + "");

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

        } //LobbyOrdersData

        //Use query string parameter and get data from the database returning a MySqlDataReader. 
        //IMPORTANT: the user of the reader needs to make sure and close the connection.
        public MySqlDataReader CustomQuery(string query) {

            //If DB connection is open attem to get data.
            if (Connection.State == System.Data.ConnectionState.Open) {

                MySqlCommand cmd = null;
                MySqlDataReader mysqlreader = null;

                try {
                    //Create MySQL Command object.
                    cmd = new MySqlCommand(query, Connection);

                    //Create a MySQL reader and Execute the query
                    mysqlreader = cmd.ExecuteReader();

                    //Return the Datareader
                    return mysqlreader;

                } catch (Exception) {
                    if (mysqlreader != null) {
                        mysqlreader.Close();
                    }
                    throw;
                }

            } else {
                //if the DB is not open then no records can be read.
                return null;
            }

        } //CustomQuery

        //Return true if Database is connected
        public bool Connected() {
            return (Connection.State == System.Data.ConnectionState.Open);
        }

    } //class DatabaseConnection
}
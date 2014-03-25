using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CSCE_4444_Term_Project
{
    class AppConfig
    {

        //Constants used in reading the XML Config file
        private const string XML_CONFIG_SECTION = "NSAConfigSettings";
        private const string XML_DB_HOST = "DBServer";
        private const string XML_DB_NAME = "DBName";
        private const string XML_DB_USER = "DBUser";
        private const string XML_DB_PASS = "DBPassword";
        private const string XML_STORE_ID = "StoreID";

        //Storage of the config settings
        private string gcFilePath;
        private string gcDBServer;    //IP address or host name for server
        private string gcDBName;      //Database name to use
        private string gcDBUser;      //DB username
        private string gcDBPassword;  //Password for the username used.
        private int gcStoreNumber;    //Store Number.

        private bool gcLoaded;

        //Properties

        //Has the Config been loaded.
        public bool IsLoaded
        {
            get
            {
                return gcLoaded;
            }
            set
            {
                gcLoaded = value;
            }
        }

        //Declare a Name property of type string:
        public string FilePath
        {
            get
            {
                return gcFilePath;
            }
            set
            {
                gcFilePath = value;
            }
        }

        //Property for the Database host
        public string DatabaseServer
        {
            get
            {
                return gcDBServer;
            }
            set
            {
                gcDBServer = value;
            }
        }

        //Property for the Name of the Database
        public string DatabaseName
        {
            get
            {
                return gcDBName;
            }
            set
            {
                gcDBName = value;
            }
        }

        //Property for the Database Username
        public string DatabaseUserName
        {
            get
            {
                return gcDBUser;
            }
            set
            {
                gcDBUser = value;
            }
        }

        //Property for the Database Password
        public string DatabasePassword
        {
            get
            {
                return gcDBPassword;
            }
            set
            {
                gcDBPassword = value;
            }
        }

        //Property for the Database Username
        public int StoreNumber
        {
            get
            {
                return gcStoreNumber;
            }
            set
            {
                gcStoreNumber = value;
            }
        }

        //empty constructor
        public AppConfig()
        {
            gcFilePath = "";
            gcLoaded = false;
        }

        //Constructor that initializes the class loading the xml specified in filepath
        public AppConfig(string filepath)
        {
            gcLoaded = Load(filepath);
        }

        //Loads the Data from the XML file specified stored in the FilePath property
        public bool Load()
        {
            if (gcFilePath.Equals(""))
            {
                throw new Exception("File Not Specified. Filename was not given prior to trying to load the settings.");
            }
            return Load(gcFilePath);
        } //public bool Load() 

        //Loads the Data from the XML file specified in file path
        public bool Load(string filepath)
        {

            //save the specified path to the property;
            gcFilePath = filepath;

            XmlTextReader xmlReader = new XmlTextReader(gcFilePath);
            while (xmlReader.Read())
            {
                if (xmlReader.IsStartElement())
                {
                    switch (xmlReader.Name)
                    {

                        //Load the database host name or give emptu string if empty.
                        case XML_DB_HOST:
                            if ((xmlReader.NodeType != XmlNodeType.None))
                            {
                                gcDBServer = xmlReader.ReadElementContentAsString();
                            }
                            else
                            {
                                gcDBServer = "";
                            }
                            break;

                        //Load the database name or give empty string.
                        case XML_DB_NAME:
                            if ((xmlReader.NodeType != XmlNodeType.None))
                            {
                                gcDBName = xmlReader.ReadElementContentAsString();
                            }
                            else
                            {
                                gcDBName = "";
                            }
                            break;
                        //Load the database user name or give empty string.
                        case XML_DB_USER:
                            if ((xmlReader.NodeType != XmlNodeType.None))
                            {
                                gcDBUser = xmlReader.ReadElementContentAsString();
                            }
                            else
                            {
                                gcDBUser = "";
                            }
                            break;

                        //Load the user password or leave as empty string.
                        case XML_DB_PASS:
                            if ((xmlReader.NodeType != XmlNodeType.None))
                            {
                                gcDBPassword = xmlReader.ReadElementContentAsString();
                            }
                            else
                            {
                                gcDBPassword = "";
                            }
                            break;

                        //load the store id that is being used give the invlaid store number 0
                        case XML_STORE_ID:
                            if ((xmlReader.NodeType != XmlNodeType.None))
                            {
                                gcStoreNumber = Convert.ToInt32(xmlReader.ReadElementContentAsString());
                            }
                            else
                            {
                                gcStoreNumber = 0;
                            }
                            break;

                        default:
                            break;
                    } //switch (xmlReader.Name) {
                } //if (xmlReader.IsStartElement())
            } //while (xmlReader ...

            return true;

        } //public void Load(string filepath)

    }
}
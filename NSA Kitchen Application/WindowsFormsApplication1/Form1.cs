using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using NSA;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //The kitchen iterface maintains a list of orders, defined
        //by the Order class.
        List<Order> list_of_orders = new List<Order>();


        //constant for the config file name
        private const string XML_CONFIG_FILE = "NSAConfig.xml";

        //appconfig object containing the application settings
        private AppConfig ConfigurationSettings;

        //Database object that we use to access the data in the database.
        private NSADatabase nsadb;  //Database connection object.

        //this is how we know if the database was able to be loaded initially
        //if this is not set then we ignore the timer ticks and do not attempt to reload
        private bool InitialLoadSuccess;

        public Form1()
        {
            InitializeComponent();

            //TEST DATA
            ///*
            Mod mustard = new Mod(0, "mustard");
            Mod ketchup = new Mod(0, "ketchup");
            Mod bacon = new Mod(1, "bacon");
            Item Cheeseburger = new Item(1, "Cheeseburger");
            Cheeseburger.add(mustard);
            Cheeseburger.add(ketchup);
            Item Cheeseburger2 = new Item(2, "Cheeseburger");
            Cheeseburger2.add(ketchup);
            Cheeseburger2.add(bacon);
            Order TESTorder = new Order(0, Cheeseburger);
            TESTorder.add(Cheeseburger2);
            list_of_orders.Add(TESTorder);
            Order TESTorder1 = new Order(1, Cheeseburger);
            list_of_orders.Add(TESTorder1);
            //After button is clicked, check for new updates.
            //*/
            // END TEST DATA

            //Grab orders from the database
            UpdateFromDatabase();
            //Update the kitchen screen to reflect the new list_of_orders
            UpdateAllTables();

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

            //Check database for intial data
            UpdateFromDatabase();
            //Update the kitchen screen to reflect the new list_of_orders
            UpdateAllTables();

        }
        public void UpdateFromDatabase()
        {
            /*
            //test for open connection and try to open
            if (!(nsadb.Connected()))
            {
                nsadb.OpenConnection();
            }

            if (nsadb.Connected())
            {

                StringBuilder query = new StringBuilder();

                query.Append("Select Q2.* ,CC.component , CC.name as addname, CC.categoryid ");
                query.Append("from (Select Q.orderID, Q.storeid, Q.status, Q.timedelivered,Q.orderitemid, ");
                query.Append("Q.name,OIR.componentremoved , OIR.name as removedname from ");
                query.Append("(Select O.orderID, O.storeid, O.status, O.timedelivered,OI.orderitemid, OI.name");
                query.Append("from orders O, orderitems OI where O.orderid = OI.orderid ) Q left join ( ");
                query.Append("Select orderitemremoved.orderitemid, orderitemremoved.componentremoved , components.name");
                query.Append("From orderitemremoved,components where componentremoved = componentid ) AS OIR on ");
                query.Append("Q.orderitemid = OIR.orderitemid )as Q2 left join ( Select orderitemcomponents.orderitemid, ");
                query.Append("orderitemcomponents.component , components.name, components.categoryid From orderitemcomponents,");
                query.Append("components where component = componentid ) AS CC on Q2.orderitemid = CC.orderitemid where ");
                query.Append("Q2.storeid = 1 AND Q2.status = 1 Order by orderID, orderitemid, categoryid, componentremoved");

                //Create a MySQL reader and Execute the query
                MySqlDataReader mysqlreader = nsadb.CustomQuery(query.ToString());

                Mod createtempaddmod = null;
                Mod createtempremovemod = null;
                Order createtemporder= null;
                Item createtempitem=null;

                //Read the data and store them in the list
                while (mysqlreader.Read())
                {
                    int i;
                    bool createid = false;
                    bool createitem = false;
                    if (!(mysqlreader["orderID"] == null))
                    {
                        i = Convert.ToInt32(mysqlreader["orderID"]);
                        createid = true;
                        for (int j = 0; j < list_of_orders.Count(); j++)
                        {
                            if (i == list_of_orders[j].getOrderId())
                            {
                                createid = false;
                            }

                        }
                        if (createid)
                        {
                            createtemporder = new Order(i);

                        }

                    }//end of order id check

                    if (!(mysqlreader["orderitemid"] == null) && !(mysqlreader["name"] == null))
                    {
                        createitem = true;
                        if (createtempitem != null)
                        {
                            if (createtempitem.getId() != Convert.ToInt32(mysqlreader["orderitemid"]))
                            {
                                createtempitem = new Item(Convert.ToInt32(mysqlreader["orderitemid"]), mysqlreader["name"].ToString());
                            }
                        }
                        else
                        {
                            createtempitem = new Item(Convert.ToInt32(mysqlreader["orderitemid"]), mysqlreader["name"].ToString());

                        }

                        if (!(mysqlreader["component"] == null) && !(mysqlreader["addname"] == null))
                        {
                            createtempaddmod = new Mod(1, mysqlreader["addname"].ToString());
                            createtempitem.add(createtempaddmod);
                        }
                        else
                        {
                            createtempaddmod = null;
                        }

                        if (!(mysqlreader["componentremoved"] == null) && !(mysqlreader["removedname"] == null))
                        {
                            createtempremovemod = new Mod(0, mysqlreader["removedname"].ToString());
                            createtempitem.add(createtempremovemod);
                        }
                        else
                        {
                            createtempremovemod = null;
                        }
                    }
                    //use the Data as you need to the 
                    if (createid)
                    {
                        if(createitem)
                        {
                            createtemporder.add(createtempitem);
                        }
                        list_of_orders.Add(createtemporder);


                    }
                    else if(createitem)
                    {
                        for (int j = 0; j < list_of_orders.Count(); j++)
                        {

                            if (createtemporder.getOrderId() == list_of_orders[j].getOrderId())
                            {
                                list_of_orders[j].add(createtempitem);
                                j = list_of_orders.Count();
                            }

                        }
                    }
                }
                //close Data Reader
                mysqlreader.Close(); 

            }
            else
            {
                MessageBox.Show("Cannot Connect to Database.", "Cannot connect to the Database make sure you have network access.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/
        }
        public void UpdateAllTables()
        {
            //Suspend change of layouts and updates to the trees until everything is redefined
            this.SuspendLayout();
            treeView1.BeginUpdate();
            treeView2.BeginUpdate();
            treeView3.BeginUpdate();
            treeView4.BeginUpdate();
            treeView5.BeginUpdate();
            //Update the total number of orders at the top
            UpdateTotalOrderNumber();
            int i = 0;
            //For each table in the window screen, change or set the order
            for(i = 0;(i<5) && (i <list_of_orders.Count()); i++)
            {
                //Get an order from the queue of orders
                int temp = list_of_orders[i].getOrderId();
                Order temporder = list_of_orders[i];

                //Create nodes to be added to the order so they can be displayed
                TreeNode modNode = new TreeNode("Condiment");
                TreeNode itemNode = new TreeNode("Sandwich");
                
                //First Window
                if(i == 0)
                {
                    //If the ID in the window is already the same as the next order, don't update the Window
                    if (!(this.label1number.Text == temp.ToString()))
                    {
                        //Clear the treeview
                        treeView1.Nodes.Clear();
                        //Set label to the order ID
                        this.label1number.Text = temp.ToString();

                        //For every item in the order, create a treenode and add it to the treeview in the window
                        for (int j = 0; j < temporder.numItems(); j++)
                        {
                            itemNode = new TreeNode(temporder.itemAt(j).getName());
                            //For every modification to the item, create a treenode and add it to the item treenode
                            for (int k = 0; k < temporder.itemAt(j).numMods(); k++)
                            {
                                //gets name of the condiment
                                string tempstring = temporder.itemAt(j).itemAt(k).getCondiment();
                                //If the condiment type is 0, remove it
                                if (temporder.itemAt(j).itemAt(k).getType() == 0)
                                {
                                    tempstring = "-" + tempstring;
                                    modNode = new TreeNode(tempstring);
                                    itemNode.Nodes.Add(modNode);

                                }
                                //If the condiment type is 1, add it
                                else if (temporder.itemAt(j).itemAt(k).getType() == 1)
                                {
                                    tempstring = "+" + tempstring;
                                    modNode = new TreeNode(tempstring);
                                    itemNode.Nodes.Add(modNode);
                                }
                            }
                            treeView1.Nodes.Add(itemNode);
                        }
                        treeView1.ExpandAll();
                    }
                }else if(i == 1) //See comments for i == 0;
                {
                    //If the ID in the window is already the same as the next order, don't update the Window
                    if (!(this.label2number.Text == temp.ToString()))
                    {
                        treeView2.Nodes.Clear();
                        this.label2number.Text = temp.ToString();

                        for (int j = 0; j < temporder.numItems(); j++)
                        {
                            itemNode = new TreeNode(temporder.itemAt(j).getName());
                            for (int k = 0; k < temporder.itemAt(j).numMods(); k++)
                            {
                                string tempstring = temporder.itemAt(j).itemAt(k).getCondiment();
                                if (temporder.itemAt(j).itemAt(k).getType() == 0)
                                {
                                    tempstring = "-" + tempstring;
                                    modNode = new TreeNode(tempstring);
                                    itemNode.Nodes.Add(modNode);

                                }
                                else if (temporder.itemAt(j).itemAt(k).getType() == 1)
                                {
                                    tempstring = "+" + tempstring;
                                    modNode = new TreeNode(tempstring);
                                    itemNode.Nodes.Add(modNode);
                                }
                            }
                            treeView2.Nodes.Add(itemNode);
                        }
                        treeView2.ExpandAll();
                    }
                }
                else if (i == 2) //See comments for i == 0;
                {
                    //If the ID in the window is already the same as the next order, don't update the Window
                    if (!(this.label3number.Text == temp.ToString()))
                    {
                        treeView3.Nodes.Clear();
                        this.label3number.Text = temp.ToString();

                        for (int j = 0; j < temporder.numItems(); j++)
                        {
                            itemNode = new TreeNode(temporder.itemAt(j).getName());
                            for (int k = 0; k < temporder.itemAt(j).numMods(); k++)
                            {
                                string tempstring = temporder.itemAt(j).itemAt(k).getCondiment();
                                if (temporder.itemAt(j).itemAt(k).getType() == 0)
                                {
                                    tempstring = "-" + tempstring;
                                    modNode = new TreeNode(tempstring);
                                    itemNode.Nodes.Add(modNode);

                                }
                                else if (temporder.itemAt(j).itemAt(k).getType() == 1)
                                {
                                    tempstring = "+" + tempstring;
                                    modNode = new TreeNode(tempstring);
                                    itemNode.Nodes.Add(modNode);
                                }
                            }
                            treeView3.Nodes.Add(itemNode);
                        }
                        treeView3.ExpandAll();
                    }
                }
                else if (i == 3) //See comments for i == 0;
                {
                    //If the ID in the window is already the same as the next order, don't update the Window
                    if (!(this.label4number.Text == temp.ToString()))
                    {
                        treeView4.Nodes.Clear();
                        this.label4number.Text = temp.ToString();

                        for (int j = 0; j < temporder.numItems(); j++)
                        {
                            itemNode = new TreeNode(temporder.itemAt(j).getName());
                            for (int k = 0; k < temporder.itemAt(j).numMods(); k++)
                            {
                                string tempstring = temporder.itemAt(j).itemAt(k).getCondiment();
                                if (temporder.itemAt(j).itemAt(k).getType() == 0)
                                {
                                    tempstring = "-" + tempstring;
                                    modNode = new TreeNode(tempstring);
                                    itemNode.Nodes.Add(modNode);

                                }
                                else if (temporder.itemAt(j).itemAt(k).getType() == 1)
                                {
                                    tempstring = "+" + tempstring;
                                    modNode = new TreeNode(tempstring);
                                    itemNode.Nodes.Add(modNode);
                                }
                            }
                            treeView4.Nodes.Add(itemNode);
                        }
                        treeView4.ExpandAll();
                    }
                }
                else if (i == 4) //See comments for i == 0;
                {
                    //If the ID in the window is already the same as the next order, don't update the Window
                    if (!(this.label5number.Text == temp.ToString()))
                    {
                        treeView5.Nodes.Clear();
                        this.label5number.Text = temp.ToString();

                        for (int j = 0; j < temporder.numItems(); j++)
                        {
                            itemNode = new TreeNode(temporder.itemAt(j).getName());
                            for (int k = 0; k < temporder.itemAt(j).numMods(); k++)
                            {
                                string tempstring = temporder.itemAt(j).itemAt(k).getCondiment();
                                if (temporder.itemAt(j).itemAt(k).getType() == 0)
                                {
                                    tempstring = "-" + tempstring;
                                    modNode = new TreeNode(tempstring);
                                    itemNode.Nodes.Add(modNode);

                                }
                                else if (temporder.itemAt(j).itemAt(k).getType() == 1)
                                {
                                    tempstring = "+" + tempstring;
                                    modNode = new TreeNode(tempstring);
                                    itemNode.Nodes.Add(modNode);
                                }
                            }
                            treeView5.Nodes.Add(itemNode);
                        }
                        treeView5.ExpandAll();
                    }
                }
            }
            //If there are less than 5 total orders in the queue, clear the windows that don't have orders
            while(i<5)
            {
                if (i == 0)
                {
                    this.label1number.Text = "";
                    //clear treeview5
                    treeView1.Nodes.Clear();
                    label1.Hide();
                }
                else if (i == 1)
                {

                    this.label2number.Text = "";
                    //clear treeview4
                    treeView2.Nodes.Clear();
                    label2.Hide();
                }
                else if (i == 2)
                {

                    this.label3number.Text = "";
                    //clear treeview3
                    treeView3.Nodes.Clear();
                    label3.Hide();
                }
                else if (i == 3)
                {

                    this.label4number.Text = "";
                    //clear treeview4
                    treeView4.Nodes.Clear();
                    label4.Hide();
                }
                else if (i == 4)
                {

                    this.label5number.Text = "";
                    //clear treeview5
                    treeView5.Nodes.Clear();
                    label5.Hide();

                }

                i++;
            }

            //Redraw all trees and layouts
            treeView1.EndUpdate();
            treeView2.EndUpdate();
            treeView3.EndUpdate();
            treeView4.EndUpdate();
            treeView5.EndUpdate();
            this.ResumeLayout();
        }
        public void UpdateTotalOrderNumber()
        {
            //Set the total number of orders the number of orders in the list_of_orders list
            int totalOrders = list_of_orders.Count();
            if (list_of_orders.Count() == 0)
            {
                //If the text you are going to set is the same as current text, don't redraw
                if(this.toplabelnumber.Text != "0")
                {
                this.toplabelnumber.Text = "0";
                }
                
            }
            else
            {
                //If the text you are going to set is the same as current text, don't redraw
                if (this.toplabelnumber.Text != totalOrders.ToString()) 
                { 
                   this.toplabelnumber.Text = totalOrders.ToString();
                }
            }
            

        }
        public void SendToDatabase(int id)
        {

            //Take the order ID and send the corresponding list_of_orders to the database

            //Remove the order from the list_of_orders
            for(int i = 0; i < list_of_orders.Count(); i++)
            {
                if(list_of_orders[i].getOrderId() == id)
                {
                    list_of_orders.RemoveAt(i);
                }

            }

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (HasCheckedChildNodes(e.Node)) e.Cancel = false;
        }
        
        // Returns a value indicating whether the specified  
        // TreeNode has checked child nodes. 
        private bool HasCheckedChildNodes(TreeNode node)
        {
            if (node.Nodes.Count == 0) return false;
            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode.Checked) return true;
                // Recursively check the children of the current child node. 
                if (HasCheckedChildNodes(childNode)) return true;
            }
            return false;
        }

        private void mytable1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //assume there is no order on the screen in the beginning
            int ordernumber = -1;

            if (!(this.label1number.Text.Equals("", StringComparison.Ordinal)))
            {
                //if the label doesn't
                ordernumber = Convert.ToInt32(this.label1number.Text);
            }
         

            if (ordernumber != -1)
            {
                //Send order to database and remove it from the list, if there
                //was an order there
                SendToDatabase(ordernumber);
            }
            
            //After button is clicked, check for new updates.
            UpdateFromDatabase();
            //Update the kitchen screen to reflect the new list_of_orders
            UpdateAllTables();
   

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //assume there is no order on the screen in the beginning
            int ordernumber = -1;

            if (!(this.label2number.Text.Equals("", StringComparison.Ordinal)))
            {
                //if the label doesn't
                ordernumber = Convert.ToInt32(this.label2number.Text);
            }


            if (ordernumber != -1)
            {
                //Send order to database and remove it from the list, if there
                //was an order there
                SendToDatabase(ordernumber);
            }

            //After button is clicked, check for new updates.
            UpdateFromDatabase();
            //Update the kitchen screen to reflect the new list_of_orders
            UpdateAllTables();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //assume there is no order on the screen in the beginning
            int ordernumber = -1;

            if (!(this.label3number.Text.Equals("", StringComparison.Ordinal)))
            {
                //if the label doesn't
                ordernumber = Convert.ToInt32(this.label3number.Text);
            }
            if (ordernumber != -1)
            {
                //Send order to database and remove it from the list, if there
                //was an order there
                SendToDatabase(ordernumber);
            }

            //After button is clicked, check for new updates.
            UpdateFromDatabase();
            //Update the kitchen screen to reflect the new list_of_orders
            UpdateAllTables();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //assume there is no order on the screen in the beginning
            int ordernumber = -1;

            if (!(this.label4number.Text.Equals("", StringComparison.Ordinal)))
            {
                //if the label doesn't
                ordernumber = Convert.ToInt32(this.label4number.Text);
            }
            if (ordernumber != -1)
            {
                //Send order to database and remove it from the list, if there
                //was an order there
                SendToDatabase(ordernumber);
            }

            //After button is clicked, check for new updates.
            UpdateFromDatabase();
            //Update the kitchen screen to reflect the new list_of_orders
            UpdateAllTables();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //assume there is no order on the screen in the beginning
            int ordernumber = -1;

            if (!(this.label5number.Text.Equals("", StringComparison.Ordinal)))
            {
                //if the label doesn't
                ordernumber = Convert.ToInt32(this.label5number.Text);
            }

            if (ordernumber != -1)
            {
                //Send order to database and remove it from the list, if there
                //was an order there
                SendToDatabase(ordernumber);
            }

            //After button is clicked, check for new updates.
            UpdateFromDatabase();
            //Update the kitchen screen to reflect the new list_of_orders
            UpdateAllTables();
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            //After button is clicked, check for new updates.
            UpdateFromDatabase();
            //Update the kitchen screen to reflect the new list_of_orders
            UpdateAllTables();
        }
    }
}

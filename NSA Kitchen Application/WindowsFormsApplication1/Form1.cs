using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //The kitchen iterface maintains a list of orders, defined
        //by the Order class.
        List<Order> list_of_orders = new List<Order>();
        public Form1()
        {
            InitializeComponent();
        }
        public void UpdateFromDatabase()
        {
            //Go to Database, parse items of status 1 to the list_of_orders
        }
        public void UpdateAllTables()
        {
            UpdateTotalOrderNumber();
            int i = 0;
            for(i = 0;(i<5) || (i <list_of_orders.Count()); i ++)
            {
                int temp = list_of_orders[i].getOrderId();
                if(i == 0)
                {
                    this.label1number.Text = temp.ToString();
                    //Set treeview 1 based of list_of_order
                }else if(i == 1)
                {

                    this.label2number.Text = temp.ToString();
                    //Set treeview 2 based of list_of_order
                }
                else if (i == 2)
                {

                    this.label3number.Text = temp.ToString();
                    //Set treeview 3 based of list_of_order
                }
                else if (i == 3)
                {

                    this.label4number.Text = temp.ToString();
                    //Set treeview 4 based of list_of_order
                }
                else if (i == 4)
                {

                    this.label5number.Text = temp.ToString();
                    //Set treeview 5 based of list_of_order
                }
                

            }
            while(i<5)
            {
                if (i == 0)
                {
                    this.label1number.Text = "######";
                    //clear treeview5
                }
                else if (i == 1)
                {

                    this.label2number.Text = "######";
                    //clear treeview4
                }
                else if (i == 2)
                {

                    this.label3number.Text = "######";
                    //clear treeview3
                }
                else if (i == 3)
                {

                    this.label4number.Text = "######";
                    //clear treeview4
                }
                else if (i == 4)
                {

                    this.label5number.Text = "######";
                    //clear treeview5

                }


                i++;
            }


        }
        public void UpdateTotalOrderNumber()
        {
            int totalOrders = list_of_orders.Count();
            if (list_of_orders.Count() == 0)
            {
                this.toplabelnumber.Text = "######";
            }
            else
            {
                this.toplabelnumber.Text = totalOrders.ToString();
            }
            

        }
        public void SendToDatabase(int id)
        {

            //Take the order ID and send the corresponding list_of_orders to the database

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

            if (!(this.label1number.Text.Equals("######", StringComparison.Ordinal)))
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

            if (!(this.label2number.Text.Equals("######", StringComparison.Ordinal)))
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

            if (!(this.label3number.Text.Equals("######", StringComparison.Ordinal)))
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

            if (!(this.label4number.Text.Equals("######", StringComparison.Ordinal)))
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
        {//Once a button is clicked, connect to database and update list_of_order
            UpdateFromDatabase();
            UpdateAllTables();
            //assume there is no order on the screen in the beginning
            int ordernumber = -1;

            if (!(this.label5number.Text.Equals("######", StringComparison.Ordinal)))
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
        public class Order
        {
            //Each order contains a list of items within that order
            private List<Item> list_of_items = new List<Item>();
            //internal orderid, should be set to same ID as database 
            private int orderid;
            public Order()
            {
                orderid = -1;
            }
            public Order(int orderid)
            {
                this.orderid = orderid;

            }
            public Order(int orderid, Item newitem)
            {
                this.orderid = orderid;
                this.list_of_items.Add(newitem);

            }
            public Order(int orderid, List<Item> list_of_items)
            {
                this.orderid = orderid;
                this.list_of_items = list_of_items;

            }
            public int getOrderId()
            {
                return this.orderid;
            }
            public void add(Item newitem)
            {
                this.list_of_items.Add(newitem);
            }
            public void add(List<Item> list_of_items)
            {
                this.list_of_items = list_of_items;
            }
            public List<Item> getOrderItems()
            {
                return this.list_of_items;
            }


        }
        //Items consist of sandwiches, chips, dessert, etc.
        public class Item
        {
            //each item has a list of possible modifers to it
            //Add ketchup would be one modifer
            //Remove mustard would be another... etc.
            private List<Mod> list_of_mods = new List<Mod>();
            private string itemName;
            public Item()
            {
                itemName = "ENTREE";
            }
            public Item(string itemName)
            {
                this.itemName = itemName;
            }
            public Item(string itemName, Mod newmod)
            {
                this.itemName = itemName;
                this.list_of_mods.Add(newmod);
            }
            public Item(string itemName, List<Mod> list_of_mods)
            {
                this.itemName = itemName;
                this.list_of_mods = list_of_mods;
            }
            public void add(List<Mod> list_of_mods)
            {
                this.list_of_mods = list_of_mods;
            }
            public void add(Mod newmod)
            {
                this.list_of_mods.Add(newmod);

            }
            public string getName()
            {
                return this.itemName;
            }
            public List<Mod> getMods()
            {
                return this.list_of_mods;
            }


        }
        //A Mod is a condiment
        public class Mod
        {
            //mod_type refers to how the condiment should be applied
            //0 = no "condiment"
            //1 = add "condiment"
            private int mod_type;
            //Type of "condiment" to be removed or added
            private string condiment;
            public Mod()
            {
                mod_type = -1;
                condiment = "CONDIMENT";
            }
            public Mod(int mod_type, string condiment)
            {
                this.mod_type = mod_type;
                this.condiment = condiment;

            }
            public int getType()
            {
                return this.mod_type;

            }
            public string getCondiment()
            {
                return this.condiment;
            }


        }
    }
}

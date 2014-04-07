using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //The kitchen iterface maintains a list of orders, defined
            //by the Order class.
            List<Order> list_of_orders = new List<Order>();

            //Initialize Form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());



            //Not yet implemented
            /*
              
             while(1)
             {
             * //Every 5 seconds, POLL database to check for new orders
             * System.Threading.Thread.Sleep(5000)
             
             //Connect to Database
             //Create an Order object from database from all entries with status = 1
             //Put all Order objects into the order list.
             
             UpdateDisplay();
             }
             
              
             
              
              
             
             * }
        
              
             
             
             
             
             
             
             */



        }
        public static void UpdateDisplay()
        {

            //The interface contains 5 order boxes
            //For Each Order box that has no orders, display the first order in the list that
            //isn't already display in previous order boxes.
     




        }
        //Program maintains a list of orders
        public class Order
        {
            //Each order contains a list of items within that order

            private List<Item> list_of_items = new List<Item>();
            //internal orderid, should be set to same ID as database 
            private int orderid;
            public Order()
            {
                //Uses info from database
            }


        }
        //Items consist of sandwiches, chips, dessert, etc.
        public class Item
        {
            //each item has a list of possible modifers to it
            //Add ketchup would be one modifer
            //Remove mustard would be another... etc.
            private List<Mod> list_of_mods = new List<Mod>();
            public Item()
            {

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

            }


        }
    }
}

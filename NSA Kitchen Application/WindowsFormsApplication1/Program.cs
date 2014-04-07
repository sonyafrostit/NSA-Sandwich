using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

namespace WindowsFormsApplication1
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {

            //Initialize Form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 myform = new Form1();
            Application.Run(myform);

          
              //BUTTON DRIVEN EVENT
            // while(true)
             //{
               //Every 5 seconds, POLL database to check for new orders
             //System.Threading.Thread.Sleep(5);
             
             //Connect to Database
             //Create an Order object from database from all entries with status = 1
             //Put all Order objects into the order list.

                 
             //UpdateDisplay
             //}

        }
        //Unused
        public static void UpdateDisplay()
        {
             
            //The interface contains 5 order boxes
            //For Each Order box that has no orders, display the first order in the list that
            //isn't already display in previous order boxes.
            

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CSCE_4444_Term_Project
{
    public partial class ManagerKiosk : Form
    {

        //constant for the config file name
        private const string XML_CONFIG_FILE = "NSAConfig.xml";

        //appconfig object containing the application settings
        private AppConfig ConfigurationSettings;

        //Database object that we use to access the data in the database.
        private NSADatabase nsadb;  //Database connection object.

        //this is how we know if the database was able to be loaded initially
        //if this is not set then we ignore the timer ticks and do not attempt to reload
        private bool InitialLoadSuccess;

        //Constructor for Manager Kiosk
        public ManagerKiosk()
        {
            InitialLoadSuccess = false;
            InitializeComponent();

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

            // Intial Load of all Lists
            LoadOrders();
            LoadManagerAccountList();
            LoadManagerInventoryList();
            LoadManagerComponentList();
            LoadManagerMenuItemList();

            // Event Handler Definitions
            RefreshOrders_Button.Click += new EventHandler(this.RefreshOrders_Click);
            RefundItem_Button.Click += new EventHandler(this.RefundItem_Click);
            LoyaltyAccountSearch_Button.Click += new EventHandler(this.LoyaltyAccountSearch_Button_Click);
            SaveLoyaltyAccount_Button.Click += new EventHandler(this.SaveLoyaltyAccount_Button_Click);
            ClearPickupWindow_Button.Click += new EventHandler(this.ClearOrderScreen_Button_Click);
            DeleteLoyaltyAccount_Button.Click += new EventHandler(this.DeleteLoyaltyAccount_Click);
            DeleteAssistantManager_Button.Click += new EventHandler(this.DeleteManagerAccount_Click);
            AssistantManagerSave_Button.Click += new EventHandler(this.SaveManagerAccount_Button_Click);
            InventoryUpdate_Button.Click += new EventHandler(this.UpdateInventory_Click);
        }

        public class BoxFormat
        {
            private string mydisplayText;
            private string mydatabaseID;

            public BoxFormat(string strdisplayText, string strdatabaseID)
            {

                this.mydisplayText = strdisplayText;
                this.mydatabaseID = strdatabaseID;
            }

            public string displayText
            {
                get
                {
                    return mydisplayText;
                }
            }

            public string databaseID
            {

                get
                {
                    return mydatabaseID;
                }
            }
        }

        public void LoadOrders()
        {
            try
            {
                int ordercount = 0;        // the number of orders to display
                List<string>[] Managerdata;   // the orders that will be displayed
                ArrayList ListBoxInfo = new ArrayList(); // Array list where formatted text will be stored

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                //request the Records to display on the manager orders list
                ordercount = nsadb.ManagerOrdersData(out Managerdata);

                // Clear any existing data in the list box
                Orders_Listbox.DataSource = null;
                Orders_Listbox.Items.Clear();

                //loop over the records and format them in the Array List
                for (int index = 0; index < ordercount; index++)
                {
                    if(Managerdata[2][index] == "0")
                    {
                        ListBoxInfo.Add(new BoxFormat("#" + Managerdata[0][index] + " - " + Managerdata[1][index], Managerdata[0][index]));
                    }
                    else
                    {
                        ListBoxInfo.Add(new BoxFormat("#" + Managerdata[0][index] + " - " + Managerdata[1][index] + " - Refunded", Managerdata[0][index]));
                    }
                }

                // Insert Array List into the List Box
                Orders_Listbox.DataSource = ListBoxInfo;

                // Define which information is actually displayed by the listbox and returned
                Orders_Listbox.DisplayMember = "displayText";
                Orders_Listbox.ValueMember = "databaseID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading Orders List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // LoadOrders

        private void Orders_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Get the currently selected item in the ListBox. 
                string curItem = ((BoxFormat)Orders_Listbox.SelectedItem).databaseID;

                // Clears existing items in the list
                OrderItems_Listbox.DataSource = null;
                OrderItems_Listbox.Items.Clear();

                // Loads Order Items list using currently selected item.
                LoadOrderItems(curItem);
            }
            catch
            {

            }
        } // Orders_ListBox_SelectedIndexChanged

        public void LoadOrderItems( string OrderID )
        {
            try
            {
                int ordercount = 0;        // the number of order items to display
                List<string>[] ManagerItemdata; // the order items that will be displayed
                ArrayList ListBoxInfo = new ArrayList(); // Array list where formatted text will be stored

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                //request the Records to display on the manager order litems list
                ordercount = nsadb.ManagerOrderItemData(out ManagerItemdata, OrderID);

                //loop over the records and format them in the Array List
                for (int index = 0; index < ordercount; index++)
                {
                    if (ManagerItemdata[2][index] == "0")
                    {
                        ListBoxInfo.Add(new BoxFormat(ManagerItemdata[1][index], ManagerItemdata[0][index]));
                    }
                    else
                    {
                        ListBoxInfo.Add(new BoxFormat(ManagerItemdata[1][index] + " - Refunded", ManagerItemdata[0][index]));
                    }
                }

                // Insert Array List into the List Box
                OrderItems_Listbox.DataSource = ListBoxInfo;

                // Define which information is actually displayed by the listbox and returned
                OrderItems_Listbox.DisplayMember = "displayText";
                OrderItems_Listbox.ValueMember = "databaseID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading Order Items List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // LoadOrderItems

        private void RefundOrders_Click(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox. 
            try
            {
                string curItem = ((BoxFormat)Orders_Listbox.SelectedItem).databaseID;

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                // Update the database to mark selected order Refunded and Refresh List
                nsadb.ManagerRefundOrders(curItem);
                LoadOrders();

                // Give User Feedback that Refund was Successful
                MessageBox.Show("Order #" + curItem + " Refunded.", "Refund Orders", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Order Not Selected!", "Refund Orders", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } // RefundOrders_Click

        private void RefundItem_Click(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox. 
            try
            {
                string curOrder = ((BoxFormat)Orders_Listbox.SelectedItem).databaseID;

                string curItem = ((BoxFormat)OrderItems_Listbox.SelectedItem).databaseID;

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                // Update the database to mark selected order Refunded
                nsadb.ManagerRefundItem(curOrder, curItem);


                // Clears existing items in the list
                OrderItems_Listbox.DataSource = null;
                OrderItems_Listbox.Items.Clear();

                MessageBox.Show("Order #" + curOrder + " - " + curItem + " Refunded.", "Refund Order Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Order Item Not Selected!", "Refund Order Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } // RefundItem_Click

        private void RefreshOrders_Click(object sender, EventArgs e)
        {
            // Clears OrderItems List
            OrderItems_Listbox.DataSource = null;
            OrderItems_Listbox.Items.Clear();
            OrderItems_Listbox.ClearSelected();

            // Refreshes the Orders List
            Orders_Listbox.ClearSelected();
            LoadOrders();
        } // RefreshOrders_Click

        private void LoyaltyAccountSearch_Button_Click(object sender, EventArgs e)
        {
            // Get the text entered into the text boxes. 
            try
            {
                int ordercount = 0;        // the number of orders to display
                List<string>[] Loyaltydata;   // the orders that will be displayed
                ArrayList ListBoxInfo = new ArrayList(); // Array List where formatted text will be stored.

                // Buffer to store text
                string AccountID = SearchAccountNumber_Textbox.Text.ToString();
                string AccountName = SearchAccountName_Textbox.Text.ToString();
                string EmailAddress = SearchEmailAddress_Textbox.Text.ToString();
        
                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                // Get the loyalty account data from the database
                ordercount = nsadb.ManagerGetLoyaltyAccount(out Loyaltydata, AccountID, AccountName, EmailAddress);

                // Clear any existing data in the list box
                AccountsFound_Listbox.DataSource = null;
                AccountsFound_Listbox.Items.Clear();

                //loop over the records and format them in the Array List
                for (int index = 0; index < ordercount; index++)
                {
                    int accountnumber = Convert.ToInt32(Loyaltydata[0][index]);
                    ListBoxInfo.Add(new BoxFormat(accountnumber.ToString("D12") + " - " + Loyaltydata[1][index], accountnumber.ToString("D12")));
                }

                // Insert Array List into the List Box
                AccountsFound_Listbox.DataSource = ListBoxInfo;

                // Define which information is actually displayed by the listbox and returned
                AccountsFound_Listbox.DisplayMember = "displayText";
                AccountsFound_Listbox.ValueMember = "databaseID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loyalty Account Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } // LoyaltyAccountSearch_Button_Click

        private void SaveLoyaltyAccount_Button_Click(object sender, EventArgs e)
        {
            // Get the text entered into the text boxes. 
            try
            {
                // Buffer to store text
                string AccountName = AddAccountName_Textbox.Text.ToString();
                string EmailAddress = AddEmailAddress_Textbox.Text.ToString();

                if (String.IsNullOrWhiteSpace(AccountName) || String.IsNullOrWhiteSpace(EmailAddress))
                {
                    MessageBox.Show("Not All Fields Filled In!", "Save Loyalty Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // connect to DB if it is not connected
                    if (!nsadb.Connected())
                    {
                        nsadb.OpenConnection();
                    }

                    // Get the loyalty account data from the database
                    nsadb.ManagerSaveLoyaltyAccount(AccountName, EmailAddress);

                    // Inform User that Account was successfully Created.
                    MessageBox.Show("Loyalty Account Created - " + EmailAddress + ".", "Save Loyalty Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Loyalty Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } // SaveLoyaltyAccount_Button_Click

        private void ClearOrderScreen_Button_Click(object sender, EventArgs e)
        {
            // Clear the Lobby Order Screen. 
            try
            {
                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                // Update the database to mark selected order Refunded
                nsadb.ManagerClearOrderScreen();

                // Inform User that Lobby Pickup Screen was successfully cleared.
                MessageBox.Show("Lobby Pickup Screen Cleared.", "Clear Order Screen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database not Connected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } // ClearOrderScreen_Button_Click

        public void LoadManagerAccountList()
        {
            try
            {
                int ordercount = 0;        // the number of orders to display
                List<string>[] ManagerAccountdata;   // the orders that will be displayed
                ArrayList ListBoxInfo = new ArrayList(); // Array List where formatted text will be stored.

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                //request the Records to display on the manager orders list
                ordercount = nsadb.ManagerAccountsData(out ManagerAccountdata);

                // Clear any existing data in the list box
                AssistantManagers_Listbox.DataSource = null;
                AssistantManagers_Listbox.Items.Clear();

                //loop over the records and format them in the Array List
                for (int index = 0; index < ordercount; index++)
                {
                    ListBoxInfo.Add(new BoxFormat(ManagerAccountdata[1][index] + " " + ManagerAccountdata[2][index] + " - " + ManagerAccountdata[3][index], ManagerAccountdata[0][index]));
                }

                // Insert Array List into the List Box
                AssistantManagers_Listbox.DataSource = ListBoxInfo;

                // Define which information is actually displayed by the listbox and returned
                AssistantManagers_Listbox.DisplayMember = "displayText";
                AssistantManagers_Listbox.ValueMember = "databaseID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading Orders List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //LoadManagerAccountList

        public void LoadManagerInventoryList()
        {
            try
            {
                int ordercount = 0;        // the number of orders to display
                List<string>[] ManagerInventorydata;   // the orders that will be displayed
                ArrayList ListBoxInfo = new ArrayList(); // Array List where formatted text will be stored.

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                //request the Records to display on the manager orders list
                ordercount = nsadb.ManagerGetInventoryData(out ManagerInventorydata);

                // Clear any existing data in the list box
                Inventory_Listbox.DataSource = null;
                Inventory_Listbox.Items.Clear();

                //loop over the records and format them in the Array List
                for (int index = 0; index < ordercount; index++)
                {
                    ListBoxInfo.Add(new BoxFormat(ManagerInventorydata[1][index] + " - " + ManagerInventorydata[2][index], ManagerInventorydata[0][index]));
                }

                // Insert Array List into the List Box
                Inventory_Listbox.DataSource = ListBoxInfo;

                // Define which information is actually displayed by the listbox and returned
                Inventory_Listbox.DisplayMember = "displayText";
                Inventory_Listbox.ValueMember = "databaseID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading Inventory List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //LoadManagerInventoryList

        public void LoadManagerComponentList()
        {
            try
            {
                int ordercount = 0;        // the number of orders to display
                List<string>[] ManagerComponentdata;   // the orders that will be displayed

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                //request the Records to display on the manager orders list
                ordercount = nsadb.ManagerGetComponentData(out ManagerComponentdata);

                // Clear previous Values
                Components_Listbox.Items.Clear();

                //loop over the records and load them to the listbox
                for (int index = 0; index < ordercount; index++)
                {
                    Components_Listbox.Items.Add("#" + ManagerComponentdata[0][index] + " - " + ManagerComponentdata[1][index] + " - " + ManagerComponentdata[2][index] + " - $" + String.Format("{0:0.00}", ManagerComponentdata[3][index]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading Component List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //LoadManagerComponentList

        public void LoadManagerMenuItemList()
        {
            try
            {
                int ordercount = 0;        // the number of orders to display
                List<string>[] ManagerMenuItemdata;   // the orders that will be displayed

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                //request the Records to display on the manager orders list
                ordercount = nsadb.ManagerGetMenuItemData(out ManagerMenuItemdata);

                // Clear previous Values
                MenuItems_Listbox.Items.Clear();

                //loop over the records and load them to the listbox
                for (int index = 0; index < ordercount; index++)
                {
                    MenuItems_Listbox.Items.Add(ManagerMenuItemdata[0][index] + " - " + ManagerMenuItemdata[1][index]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading Component List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //LoadManagerMenuItemList

        private void DeleteLoyaltyAccount_Click(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox. 
            try
            {
                string curItem = ((BoxFormat)AccountsFound_Listbox.SelectedItem).databaseID;

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                // Update the database to mark selected order Refunded and clear Accounts Found List
                nsadb.ManagerDeleteLoyaltyAccount(curItem);
                AccountsFound_Listbox.DataSource = null;
                AccountsFound_Listbox.Items.Clear();

                // Inform User that Account was successfully deleted.
                MessageBox.Show("Account #" + curItem + " Deleted.", "Delete Loyalty Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Account Not Selected!", "Delete Loyalty Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } // DeleteLoyaltyAccount_Click

        private void DeleteManagerAccount_Click(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox. 
            try
            {
                string curItem = ((BoxFormat)AssistantManagers_Listbox.SelectedItem).databaseID;

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                // Update the database to mark selected order Refunded and clear Manager Accounts List
                nsadb.ManagerDeleteManagerAccount(curItem);
                LoadManagerAccountList();

                // Inform User that Account was successfully Deleted.
                MessageBox.Show("Manager Account #" + curItem + " Deleted.", "Delete Manager Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Account Not Selected!", "Delete Manager Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } // DeleteManagerAccount_Click

        private void SaveManagerAccount_Button_Click(object sender, EventArgs e)
        {
            // Get the text entered into the text boxes. 
            try
            {
                // Buffer to store text
                string FirstName = AssistantManagerFirstName_Textbox.Text.ToString();
                string LastName = AssistantManagerLastName_Textbox.Text.ToString();
                string EmployeeID = EmployeeID_Textbox.Text.ToString();
                string Password = AssistantManagerPassword_Textbox.Text.ToString();
                string PasswordConfirm = AssistantManagerConfirm_Textbox.Text.ToString();

                if (String.IsNullOrWhiteSpace(FirstName) || String.IsNullOrWhiteSpace(LastName) || String.IsNullOrWhiteSpace(EmployeeID) 
                    || String.IsNullOrWhiteSpace(Password) || String.IsNullOrWhiteSpace(PasswordConfirm))
                {
                    MessageBox.Show("Not All Fields Filled In!", "Save Manager Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                if (Password != PasswordConfirm)
                {
                    MessageBox.Show("Passwords Do Not Match!", "Save Manager Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                // Get the loyalty account data from the database
                nsadb.ManagerSaveManagerAccount(FirstName, LastName, EmployeeID, Password);

                // Refresh Managers List 
                LoadManagerAccountList();

                // Inform user that account was successfully created.
                MessageBox.Show("Account - " + FirstName + " " + LastName + " Created.", "Save Manager Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Shouldnt Be Seeing This!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } // SaveLoyaltyAccount_Button_Click

        private void UpdateInventory_Click(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox. 
            try
            {
                string curItem = ((BoxFormat)Inventory_Listbox.SelectedItem).databaseID;
                string quantity = ItemCount_Textbox.Text.ToString();

                if (string.IsNullOrWhiteSpace(quantity))
                {
                    quantity = "0";
                }

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                // Update the database to mark selected order Refunded and refresh inventory list
                nsadb.ManagerUpdateInventory(curItem, quantity);
                LoadManagerInventoryList();

                // Inform User that Inventory was Successfully Updated.
                MessageBox.Show("Component #" + curItem + " Updated.", "Update Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Component Not Selected!", "Update Inventory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } // DeleteUpdateInventory_Click
    }
}

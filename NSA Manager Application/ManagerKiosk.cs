using System;
using System.Globalization;
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

namespace NSA_Manager
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
        public ManagerKiosk(int isassistant)
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
            LoadKidsMealDays();
            LoadManagerAccountList();
            LoadManagerInventoryList();
            LoadManagerComponentList();
            LoadManagerMenuItemList();
            LoadReports();

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
            ComponentDelete_Button.Click += new EventHandler(this.DeleteComponent_Click);
            ComponentSave_Button.Click += new EventHandler(this.SaveComponent_Click);
            MenuItemDelete_Button.Click += new EventHandler(this.DeleteMenuItem_Click);
            MenuItemSave_Button.Click += new EventHandler(this.SaveMenuItem_Click);
            PrintReport_Button.Click += new EventHandler(this.PrintReport_Button_Click);

            if(isassistant == 1)
            {
                ManagerKiosk_TabPage.TabPages.Remove(AssistantManagers);
            }
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

                // If there is no data in the database skip attempting to load the List
                // It will cause an error.
                if (ordercount == 0)
                {
                    return;
                }

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

        public void LoadKidsMealDays()
        {
            try
            {
                int[] kidsmealdays;   // the Kids Meal Day Flags

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                //request the Records to display on the manager orders list
                nsadb.ManagerGetKidsMealDays(out kidsmealdays);

                // Checks Days checkboxes if true in database.
                if (kidsmealdays[0] == 1)
                {
                    KidsMealDayMonday_CheckBox.Checked = true;
                }
                if (kidsmealdays[1] == 1)
                {
                    KidsMealDayTuesday_CheckBox.Checked = true;
                }
                if (kidsmealdays[2] == 1)
                {
                    KidsMealDayWednesday_CheckBox.Checked = true;
                }
                if (kidsmealdays[3] == 1)
                {
                    KidsMealDayThursday_CheckBox.Checked = true;
                }
                if (kidsmealdays[4] == 1)
                {
                    KidsMealDayFriday_CheckBox.Checked = true;
                }
                if (kidsmealdays[5] == 1)
                {
                    KidsMealDaySaturday_CheckBox.Checked = true;
                }
                if (kidsmealdays[6] == 1)
                {
                    KidsMealDaySunday_CheckBox.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading Kids Meal Days", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        } // LoadKidsMealDays

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

                // If there is no data in the database skip attempting to load the List
                // It will cause an error.
                if (ordercount == 0)
                {
                    return;
                }

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
            catch
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
            catch
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

                // If there is no data in the database skip attempting to load the List
                // It will cause an error.
                if (ordercount == 0)
                {
                    return;
                }

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

                // If there is no data in the database skip attempting to load the List
                // It will cause an error.
                if (ordercount == 0)
                {
                    return;
                }

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
                int categorycount = 0;
                List<string>[] ManagerComponentdata;   // the orders that will be displayed
                List<string>[] ManagerComponentCategory; // The component categories
                ArrayList ListBoxInfo = new ArrayList(); // Array List where formatted text will be stored.
                ArrayList CategoryInfo = new ArrayList();

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                //request the Records to display on the manager orders list
                ordercount = nsadb.ManagerGetComponentData(out ManagerComponentdata);
                categorycount = nsadb.ManagerGetComponentCategory(out ManagerComponentCategory);

                // Clear any existing data in the list box
                Components_Listbox.DataSource = null;
                Components_Listbox.Items.Clear();
                ComponentCategory_comboBox.DataSource = null;
                ComponentCategory_comboBox.Items.Clear();

                // If there is no data in the database skip attempting to load the List
                // It will cause an error.
                if (ordercount == 0)
                {
                    return;
                }

                //loop over the records and format them in the Array List
                for (int index = 0; index < ordercount; index++)
                {
                    ListBoxInfo.Add(new BoxFormat(ManagerComponentdata[1][index] + " - $" + ManagerComponentdata[2][index], ManagerComponentdata[0][index]));
                }

                if (categorycount == 0)
                {
                    return;
                }

                //loop over the records and format them in the Array List
                for (int index = 0; index < categorycount; index++)
                {
                    CategoryInfo.Add(new BoxFormat(ManagerComponentCategory[1][index], ManagerComponentCategory[0][index]));
                }

                // Insert Array List into the List Box
                Components_Listbox.DataSource = ListBoxInfo;
                ComponentCategory_comboBox.DataSource = CategoryInfo;

                // Define which information is actually displayed by the listbox and returned
                Components_Listbox.DisplayMember = "displayText";
                Components_Listbox.ValueMember = "databaseID";
                ComponentCategory_comboBox.DisplayMember = "displayText";
                ComponentCategory_comboBox.ValueMember = "databaseID";
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
                int itemcount = 0;        // the number of menu items returned by database
                int componentcount = 0;   // The number of components returned by database
                int categorycount = 0;    // The number of component category returned
                List<string>[] ManagerMenuItemdata;   // The Menu Items that will be displayed
                List<string>[] ManagerComponentdata;  // The Components that will be displayed
                List<string>[] ManagerItemCategory;   // The Categories that will be displayed
                ArrayList ListBoxInfo = new ArrayList(); // Array List where formatted text will be stored.
                ArrayList CheckBoxInfo = new ArrayList(); // Array List where formatted text will be stored.
                ArrayList CategoryInfo = new ArrayList(); // Array List where formatted text will be stored.

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                //request the Records to display on the manager orders list
                itemcount = nsadb.ManagerGetMenuItemData(out ManagerMenuItemdata);
                componentcount = nsadb.ManagerGetComponentData(out ManagerComponentdata);
                categorycount = nsadb.ManagerGetMenuItemCategory(out ManagerItemCategory);

                // Clear any existing data in the list box
                MenuItems_Listbox.DataSource = null;
                MenuItems_Listbox.Items.Clear();
                MenuItemsComponent_CheckedListbox.DataSource = null;
                MenuItemsComponent_CheckedListbox.Items.Clear();
                MenuItemCategory_comboBox.DataSource = null;
                MenuItemCategory_comboBox.Items.Clear();

                // If there is no data in the database skip attempting to load the List
                // It will cause an error.
                if (itemcount == 0)
                {
                    return;
                }

                //loop over the records and format them in the Array List
                for (int index = 0; index < itemcount; index++)
                {
                    ListBoxInfo.Add(new BoxFormat(ManagerMenuItemdata[1][index], ManagerMenuItemdata[0][index]));
                }

                if (categorycount == 0)
                {
                    return;
                }

                //loop over the records and format them in the Array List
                for (int index = 0; index < categorycount; index++)
                {
                    CategoryInfo.Add(new BoxFormat(ManagerItemCategory[1][index], ManagerItemCategory[0][index]));
                }

                if (componentcount == 0)
                {
                    return;
                }

                for (int index = 0; index < componentcount; index++ )
                {
                    CheckBoxInfo.Add(new BoxFormat(ManagerComponentdata[1][index], ManagerComponentdata[0][index]));
                }

                // Insert Array List into the List Box
                MenuItems_Listbox.DataSource = ListBoxInfo;
                MenuItemsComponent_CheckedListbox.DataSource = CheckBoxInfo;
                MenuItemCategory_comboBox.DataSource = CategoryInfo;

                // Define which information is actually displayed by the listbox and returned
                MenuItems_Listbox.DisplayMember = "displayText";
                MenuItems_Listbox.ValueMember = "databaseID";
                MenuItemsComponent_CheckedListbox.DisplayMember = "displayText";
                MenuItemsComponent_CheckedListbox.ValueMember = "databaseID";
                MenuItemCategory_comboBox.DisplayMember = "displayText";
                MenuItemCategory_comboBox.ValueMember = "databaseID";
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

                // Save the loyalty account data in the database
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

        private void DeleteComponent_Click(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox. 
            try
            {
                string curItem = ((BoxFormat)Components_Listbox.SelectedItem).databaseID;

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                // Update the database to mark selected order Refunded and clear Manager Accounts List
                nsadb.ManagerDeleteComponent(curItem);
                LoadManagerComponentList();

                // Inform User that Account was successfully Deleted.
                MessageBox.Show("Component #" + curItem + " Deleted.", "Delete Component", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Component Not Selected!", "Delete Component", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } // DeleteComponent_Click

        private void SaveComponent_Click(object sender, EventArgs e) // SaveComponent_Click
        {
            try
            {
                // Buffer to store text
                string ComponentName = ComponentName_Textbox.Text.ToString();
                string ComponentCategory = ((BoxFormat)ComponentCategory_comboBox.SelectedItem).databaseID;
                string ComponentPrice = ComponentPrice_Textbox.Text.ToString();
                string ComponentCost = ComponentCost_Textbox.Text.ToString();
                string ComponentHighQuantity = ComponentHighQuantity_Textbox.Text.ToString();
                string ComponentLowQuantity = ComponentLowQuantity_Textbox.Text.ToString();

                if (String.IsNullOrWhiteSpace(ComponentName) || String.IsNullOrWhiteSpace(ComponentCategory) || String.IsNullOrWhiteSpace(ComponentPrice) 
                    || String.IsNullOrWhiteSpace(ComponentCost) || String.IsNullOrWhiteSpace(ComponentHighQuantity) || String.IsNullOrWhiteSpace(ComponentLowQuantity) )
                {
                    MessageBox.Show("Not All Fields Filled In!", "Save Component", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                // Save the Component data to the Database
                nsadb.ManagerSaveComponent(ComponentName, ComponentCategory, ComponentPrice, ComponentCost, ComponentHighQuantity, ComponentLowQuantity);

                //Refresh List
                LoadManagerComponentList();
                
                // Inform user that account was successfully created.
                MessageBox.Show("Component - " + ComponentName + " Created.", "Save Component", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Shouldnt Be Seeing This!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e) // DeleteMenuItem_Click
        {
            // Get the currently selected item in the ListBox. 
            try
            {
                string curItem = ((BoxFormat)MenuItems_Listbox.SelectedItem).databaseID;

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                // Update the database to mark selected order Refunded and clear Manager Accounts List
                nsadb.ManagerDeleteMenuItem(curItem);
                LoadManagerMenuItemList();

                // Inform User that Account was successfully Deleted.
                MessageBox.Show("Menu Item #" + curItem + " Deleted.", "Delete Menu Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Menu Item Not Selected!", "Delete Menu Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Buffer to store text
                string MenuItemName = MenuItemName_Textbox.Text.ToString();
                string MenuItemCategory = ((BoxFormat)MenuItemCategory_comboBox.SelectedItem).databaseID;
                string MenuItemPrice = MenuItemPrice_Textbox.Text.ToString();
                string isspecial = null;
                string MenuItemID = null;
                int DayMask = 0;
                object Components = MenuItemsComponent_CheckedListbox.SelectedItems;

                // Checks if Special has been checked
                if(MenuItemSpecial_Checkbox.Checked)
                {
                    isspecial = "1";

                    // Test Checkboxes for Day Mask
                    if(SpecialDayMonday_Checkbox.Checked)
                    {
                        DayMask += 1;
                    }

                    if (SpecialDayTuesday_Checkbox.Checked)
                    {
                        DayMask += 2;
                    }

                    if (SpecialDayWednesday_Checkbox.Checked)
                    {
                        DayMask += 4;
                    }

                    if (SpecialDayThursday_Checkbox.Checked)
                    {
                        DayMask += 8;
                    }

                    if (SpecialDayFriday_Checkbox.Checked)
                    {
                        DayMask += 16;
                    }

                    if (SpecialDaySaturday_Checkbox.Checked)
                    {
                        DayMask += 32;
                    }

                    if (SpecialDaySunday_Checkbox.Checked)
                    {
                        DayMask += 64;
                    }
                }
                else
                {
                    isspecial = "0";
                }

                // Checks if all Text Boxes filled
                if (String.IsNullOrWhiteSpace(MenuItemName) || String.IsNullOrWhiteSpace(MenuItemCategory) || String.IsNullOrWhiteSpace(MenuItemPrice) )
                {
                    MessageBox.Show("Not All Fields Filled In!", "Save Menu Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Checks if Menu Item has atleast 1 component
                if (MenuItemsComponent_CheckedListbox.CheckedItems.Count == 0)
                {
                    MessageBox.Show("No Components Selected!", "Save Menu Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // connect to DB if it is not connected
                if (!nsadb.Connected())
                {
                    nsadb.OpenConnection();
                }

                // Create the Menu Item in the Database
                MenuItemID = nsadb.ManagerCreateMenuItem(MenuItemName, MenuItemCategory, MenuItemPrice, isspecial);

                foreach (object itemChecked in MenuItemsComponent_CheckedListbox.CheckedItems)
                {
                    // Create the Menu Item Component in the Database
                    nsadb.ManagerCreateMenuItemComponent(MenuItemID, ((BoxFormat)itemChecked).databaseID);
                }

                // Checks if Special has been checked
                if (MenuItemSpecial_Checkbox.Checked)
                {
                    // Create the Special in the Database
                    nsadb.ManagerCreateSpecial(MenuItemID, DateBegin_Calender.SelectionRange.Start.ToString("d", CultureInfo.CreateSpecificCulture("ja-jp")), 
                        DateEnd_Calender.SelectionRange.Start.ToString("d", CultureInfo.CreateSpecificCulture("ja-jp")), DayMask);
                }
                // Refresh List
                LoadManagerMenuItemList();

                // Inform user that Menu Item was successfully created.
                MessageBox.Show("Menu Item - " + MenuItemName + " Created.", "Save Menu Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Menu Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } 
        } // ManagerSaveMenuItem

        private void LoadReports()
        {
            //create instance of report object.
            Reports rept = new Reports();

            //loop over number reports.
            for (int i = 0; i < rept.NumberReportsAvalaible(); i++)
            {
                //add report names to list box
                Reports_Listbox.Items.Add(rept.ReportName(i));
            }

            //Reports_Listbox.SelectedIndex = 0;
        } // Load Reports

        private void GenerateReport()
        {
            //create instance of report object.
            Reports rept = new Reports(ConfigurationSettings.DatabaseServer,
                                       ConfigurationSettings.DatabaseName,
                                       ConfigurationSettings.DatabaseUserName,
                                       ConfigurationSettings.DatabasePassword);

            rept.AddStore(ConfigurationSettings.StoreNumber);

            // generate the report and place it into a Webbrowser window.
            string report = rept.GenerateReport(Reports_Listbox.SelectedIndex);
            webReports.Navigate("about:blank");

            //if a report exists we have to empty the control
            if (webReports.Document != null)
            {
                webReports.Document.Write(string.Empty);
            }
            webReports.DocumentText = report;
        }

        private void Reports_Listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateReport();
        } // Reports_Listbox_SelectedIndexChanged

        private void PrintReport_Button_Click(object sender, EventArgs e)
        {
            webReports.ShowPrintDialog();
        }

        private void PriceChange_Button_Click(object sender, EventArgs e)
        {
            string curItem = ((BoxFormat)MenuItems_Listbox.SelectedItem).databaseID;
            string oldPrice = null;

            oldPrice = nsadb.ManagerGetPrice(curItem);

            PriceChange FormCreate = new PriceChange(curItem, oldPrice);
            FormCreate.Show();
        }

        private void KidsMealDaySave_Button_Click(object sender, EventArgs e)
        {
            // Days created to store Checked status
            int []days = new int[7];

            // Gets if Checkboxes are checked and assigns to days array.
            if(KidsMealDayMonday_CheckBox.Checked)
            {
                days[0] = 1;
            }
            else
            {
                days[0] = 0;
            }
            if (KidsMealDayTuesday_CheckBox.Checked)
            {
                days[1] = 1;
            }
            else
            {
                days[1] = 0;
            }
            if (KidsMealDayWednesday_CheckBox.Checked)
            {
                days[2] = 1;
            }
            else
            {
                days[2] = 0;
            }
            if (KidsMealDayThursday_CheckBox.Checked)
            {
                days[3] = 1;
            }
            else
            {
                days[3] = 0;
            }
            if (KidsMealDayFriday_CheckBox.Checked)
            {
                days[4] = 1;
            }
            else
            {
                days[4] = 0;
            }
            if (KidsMealDaySaturday_CheckBox.Checked)
            {
                days[5] = 1;
            }
            else
            {
                days[5] = 0;
            }
            if (KidsMealDaySunday_CheckBox.Checked)
            {
                days[6] = 1;
            }
            else
            {
                days[6] = 0;
            }

            nsadb.UpdateKidsMealDays(days);

            // Inform user that Kids Meal Days was successfully Updated.
            MessageBox.Show("Kids Meal Days Updated!", "Update Kids Meal Days", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadKidsMealDays();
        } // PrintReport_Button_Click
    }
}

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

using NSA;

namespace NSA_Corporate_Application
{
    public partial class CorporateUI : Form
    {

        //constant for the config file name
        private const string XML_CONFIG_FILE = "NSAConfig.xml";

        //appconfig object containing the application settings
        private AppConfig ConfigurationSettings;

        //Database object that we use to access the data in the database.
        private CorporateData CorpData;  //Database connection object.

        //this is how we know if the database was able to be loaded initially
        //if this is not set then we ignore the timer ticks and do not attempt to reload
        private bool InitialLoadSuccess;

        //Constructor for Coporate UI
        public CorporateUI()
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
                CorpData = new CorporateData(ConfigurationSettings.DatabaseServer, ConfigurationSettings.DatabaseName,
                    ConfigurationSettings.DatabaseUserName, ConfigurationSettings.DatabasePassword);
                InitialLoadSuccess = CorpData.Connected();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading Database: " + XML_CONFIG_FILE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Intial Load of all Lists
            LoadStoresLong(Stores_List);
            LoadStores(Orders_Stores);
            LoadStores(Loyalty_Stores);
            LoadStores(Inventory_Stores);
            LoadStores(Reports_Stores);

            LoadStores(StoresComboBox);

            LoadReports(Reports_Listbox);

            //load orders iwth the selected store.
            string selectedStore = ((BoxFormat)Orders_Stores.SelectedItem).databaseID;
            LoadOrders(selectedStore,Orders_Listbox);

            LoadManagerAccountList(Managers_Listbox);

            selectedStore = ((BoxFormat)Inventory_Stores.SelectedItem).databaseID;
            LoadInventoryList(selectedStore, Inventory_Listbox);

            // Event Handler Definitions
            //RefreshOrders_Button.Click += new EventHandler(this.RefreshOrders_Click);
            DeleteAssistantManager_Button.Click += new EventHandler(this.DeleteManagerAccount_Click);
            AssistantManagerSave_Button.Click += new EventHandler(this.SaveManagerAccount_Button_Click);
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

        //Functions for loading the stores list and combo boxes
        public void LoadStoresLong(ListBox StoreList) {
            int storecount = 0;        // the number of orders to display
            List<string>[] storeslist;   // the orders that will be displayed
            ArrayList ListBoxInfo = new ArrayList(); // Array list where formatted text will be stored

            // Clear any existing data in the list box
            StoreList.DataSource = null;
            StoreList.Items.Clear();

            //get data from database.
            storecount = CorpData.StoresData(out storeslist);

            if (storecount > 0) {
                //loop over the records and format them in the Array List
                for (int index = 0; index < storecount; index++) {
                    int intTemp = Convert.ToInt32(storeslist[0][index]);

                    StringBuilder storestring = new StringBuilder();
                    storestring.Append(intTemp.ToString("D4"));   //Store ID
                    storestring.Append(" - ");
                    storestring.Append(storeslist[1][index]);     //Store NAme
                    storestring.Append("  ");
                    storestring.Append(storeslist[2][index]);     //City 
                    storestring.Append("  ");
                    storestring.Append(storeslist[3][index]);     //State
                    storestring.Append("  ");
                    storestring.Append(storeslist[4][index]);     //Zip

                    ListBoxInfo.Add(new BoxFormat(storestring.ToString(), storeslist[0][index]));
                }

                // Insert Array List into the List Box
                StoreList.DataSource = ListBoxInfo;

                // Define which information is actually displayed by the listbox and returned
                StoreList.DisplayMember = "displayText";
                StoreList.ValueMember = "databaseID";
            }

        }

        public void LoadStores(ListBox StoreList) {
            int storecount = 0;        // the number of orders to display
            List<string>[] storeslist;   // the orders that will be displayed
            ArrayList ListBoxInfo = new ArrayList(); // Array list where formatted text will be stored

            // Clear any existing data in the list box
            StoreList.DataSource = null;
            StoreList.Items.Clear();

            //get data from database.
            storecount = CorpData.StoresData(out storeslist);

            if (storecount > 0) {
                //loop over the records and format them in the Array List
                for (int index = 0; index < storecount; index++) {
                    int intTemp = Convert.ToInt32(storeslist[0][index]);
                    ListBoxInfo.Add(new BoxFormat((intTemp.ToString("D4") + " - " + storeslist[1][index]), storeslist[0][index]));
                }

                // Insert Array List into the List Box
                StoreList.DataSource = ListBoxInfo;

                // Define which information is actually displayed by the listbox and returned
                StoreList.DisplayMember = "displayText";
                StoreList.ValueMember = "databaseID";
            }

        }

        public void LoadStores(ComboBox StoreList) {
            int storecount = 0;        // the number of orders to display
            List<string>[] storeslist;   // the orders that will be displayed
            ArrayList ListBoxInfo = new ArrayList(); // Array list where formatted text will be stored

            // Clear any existing data in the list box
            StoreList.DataSource = null;
            StoreList.Items.Clear();

            //get data from database.
            storecount = CorpData.StoresData(out storeslist);

            if (storecount > 0) {
                //loop over the records and format them in the Array List
                for (int index = 0; index < storecount; index++) {
                    int intTemp = Convert.ToInt32(storeslist[0][index]);
                    ListBoxInfo.Add(new BoxFormat((intTemp.ToString("D4") + " - " + storeslist[1][index]), storeslist[0][index]));
                }

                // Insert Array List into the List Box
                StoreList.DataSource = ListBoxInfo;

                // Define which information is actually displayed by the listbox and returned
                StoreList.DisplayMember = "displayText";
                StoreList.ValueMember = "databaseID";
            }
        }

        //Functions for the Stores Tab

        //delete the manaager account that is selected.
        private void DeleteStore_Click(object sender, EventArgs e) {
            if (CorpData.Connected()) {
                // Get the currently selected item in the ListBox. 
                string storeid = ((BoxFormat)Stores_List.SelectedItem).databaseID;

                if (!string.IsNullOrWhiteSpace(storeid)) {
                    // Update the database to mark selected order Refunded and clear Manager Accounts List
                    CorpData.CorporateStore(storeid);

                    LoadStoresLong(Stores_List);
                    // Inform User that Account was successfully Deleted.
                    MessageBox.Show("Store #" + storeid + " Deleted.", "Delete Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("Store Not Selected!", "Delete Store", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                //Reload stores Lists
                LoadStoresLong(Stores_List);
                LoadStores(Orders_Stores);
                LoadStores(Loyalty_Stores);
                LoadStores(Inventory_Stores);
                LoadStores(Reports_Stores);
                LoadStores(StoresComboBox);

            } else {
                MessageBox.Show("Store Not Deleted!", "Database not connected.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } // DeleteStore_Click

        //Save New Store
        private void SaveStore_Click(object sender, EventArgs e) {
            // Get the text entered into the text boxes. 
            try {
                // Buffer to store text
                string StoreName = StoreName_Text.Text;
                string StoreAddress = StoreAddress_Text.Text;
                string StoreCity = StoreCity_Text.Text;
                string StoreState = StoreState_Text.Text;
                string StoreZip = StoreZip_Text.Text;

                if (String.IsNullOrWhiteSpace(StoreName) || String.IsNullOrWhiteSpace(StoreAddress) || String.IsNullOrWhiteSpace(StoreCity)
                    || String.IsNullOrWhiteSpace(StoreState) || String.IsNullOrWhiteSpace(StoreZip)) {
                    MessageBox.Show("Not All Fields Filled In!", "Save New Store", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                // connect to DB if it is not connected
                if (CorpData.Connected()) {
                    // Save a new store to the DB using the Coporate Save Store.
                    CorpData.CorporateSaveStore(StoreName, StoreAddress, StoreCity, StoreState, StoreZip); // ManagerSaveManagerAccount(FirstName, LastName, EmployeeID, Password);

                    //Reload stores Lists
                    LoadStoresLong(Stores_List);
                    LoadStores(Orders_Stores);
                    LoadStores(Loyalty_Stores);
                    LoadStores(Inventory_Stores);
                    LoadStores(Reports_Stores);
                    LoadStores(StoresComboBox);

                    // Inform user that account was successfully created.
                    MessageBox.Show("Store - " + StoreName + " Created.", "Save New Store", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Shouldnt Be Seeing This!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }//SaveStore_Click

        //Functions for the Orders Tab

        //When the selected index for the stores list changes reload the orders list
        private void Orders_Stores_SelectedIndexChanged(object sender, EventArgs e) {
            //load orders iwth the selected store.
            if (Orders_Stores.SelectedIndex != -1) { 
                string selectedStore = ((BoxFormat)Orders_Stores.SelectedItem).databaseID;

                //Clear any existing data in the orders list box
                Orders_Listbox.DataSource = null;
                Orders_Listbox.Items.Clear();

                LoadOrders(selectedStore,Orders_Listbox);
            }

        }

        //When the selected index for the orders list changes reload the order items list
        private void Orders_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Orders_Listbox.SelectedIndex != -1) {
                    // Get the currently selected item in the Stores and orders ListBoxes. 
                    string curStore = ((BoxFormat)Orders_Stores.SelectedItem).databaseID;
                    string curOrder = ((BoxFormat)Orders_Listbox.SelectedItem).databaseID;

                    // Clear any existing data in the list box
                    OrderItems_Listbox.DataSource = null;
                    OrderItems_Listbox.Items.Clear();

                    // Loads Order Items list using currently selected item.
                    LoadOrderItems(curStore,curOrder,OrderItems_Listbox);
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error loading Orders Items List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // Orders_ListBox_SelectedIndexChanged
        
        //load the orders to the orderlist box
        public void LoadOrders(string selectedStore, ListBox orderslist)
        {
            try
            {
                int ordercount = 0;        // the number of orders to display
                List<string>[] OrderData;   // the orders that will be displayed
                ArrayList ListBoxInfo = new ArrayList(); // Array list where formatted text will be stored

                if (!string.IsNullOrWhiteSpace(selectedStore)) {
                    //request the Records to display on the manager orders list
                    ordercount = CorpData.CorporateOrdersData(out OrderData, selectedStore);

                    if (ordercount > 0) {
                        //loop over the records and format them in the Array List
                        for (int index = 0; index < ordercount; index++) {
                            if (OrderData[2][index] == "0") {
                                ListBoxInfo.Add(new BoxFormat("#" + OrderData[0][index] + " - " + OrderData[1][index], OrderData[0][index]));
                            } else {
                                ListBoxInfo.Add(new BoxFormat("#" + OrderData[0][index] + " - " + OrderData[1][index] + " - Refunded", OrderData[0][index]));
                            }
                        }

                        // Insert Array List into the List Box
                        orderslist.DataSource = ListBoxInfo;

                        // Define which information is actually displayed by the listbox and returned
                        orderslist.DisplayMember = "displayText";
                        orderslist.ValueMember = "databaseID";
                    }

                } else {
                    MessageBox.Show("A store is not currently selected please select a store and try again.", "No Store selected", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading Orders List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // LoadOrders

        //load the order items list
        public void LoadOrderItems(string storeID, string orderID, ListBox orderitemslist)
        {
            try
            {
                int orderitemcount = 0;        // the number of order items to display
                List<string>[] OrderItemdata; // the order items that will be displayed
                ArrayList ListBoxInfo = new ArrayList(); // Array list where formatted text will be stored

                //request the Records to display on the manager order litems list
                orderitemcount = CorpData.CorporateOrderItemData(out OrderItemdata, storeID, orderID);

                if (orderitemcount > 0) {
                    //loop over the records and format them in the Array List
                    for (int index = 0; index < orderitemcount; index++) {
                        if (OrderItemdata[2][index] == "0") {
                            ListBoxInfo.Add(new BoxFormat(OrderItemdata[1][index], OrderItemdata[0][index]));
                        } else {
                            ListBoxInfo.Add(new BoxFormat(OrderItemdata[1][index] + " - Refunded", OrderItemdata[0][index]));
                        }
                    }
                    // Insert Array List into the List Box
                    orderitemslist.DataSource = ListBoxInfo;

                    // Define which information is actually displayed by the listbox and returned
                    orderitemslist.DisplayMember = "displayText";
                    orderitemslist.ValueMember = "databaseID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading Order Items List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // LoadOrderItems

        //when the button is clicked reload the items
        private void RefreshOrders_Button_Click(object sender, EventArgs e) {
            //load orders iwth the selected store.
            string selectedStore = ((BoxFormat)Orders_Stores.SelectedItem).databaseID;

            //Clear any existing data in the orders list box
            Orders_Listbox.DataSource = null;
            Orders_Listbox.Items.Clear();

            LoadOrders(selectedStore,Orders_Listbox);
        }

        //Methods for the Loyalty accounts Tab
        //load the loyalty acounts to loyalty accounts list box based on the storelistlistbox.
        public void LoadLoyaltyAccounts(ListBox storelist, ListBox loyaltyaccountslist) {
            // Get the text entered into the text boxes. 
            try {
                int itemcount = 0;        // the number of orders to display
                List<string>[] Loyaltydata;   // the orders that will be displayed
                ArrayList ListBoxInfo = new ArrayList(); // Array List where formatted text will be stored.

                //Get the selected Store
                string selectedStore = ((BoxFormat)storelist.SelectedItem).databaseID;

                // Get the loyalty account data from the database
                itemcount = CorpData.CorporateLoyaltyAccountData(out Loyaltydata, selectedStore);

                // Clear any existing data in the list box
                AccountsFound_Listbox.DataSource = null;
                AccountsFound_Listbox.Items.Clear();

                if (itemcount > 0){
                    //loop over the records and format them in the Array List
                    for (int index = 0; index < itemcount; index++) {
                        int StoreNumber = Convert.ToInt32(Loyaltydata[0][index]);
                        int accountnumber = Convert.ToInt32(Loyaltydata[1][index]);
                        ListBoxInfo.Add(new BoxFormat(accountnumber.ToString("D4") + accountnumber.ToString("D8") + " - " + Loyaltydata[2][index], (accountnumber.ToString("D4") + accountnumber.ToString("D8"))));
                    }

                    // Insert Array List into the List Box
                    loyaltyaccountslist.DataSource = ListBoxInfo;

                    // Define which information is actually displayed by the listbox and returned
                    loyaltyaccountslist.DisplayMember = "displayText";
                    loyaltyaccountslist.ValueMember = "databaseID";
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Loyalty Account Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //load the loyalty accounts when the use makes a change,
        private void Loyalty_Stores_SelectedIndexChanged(object sender, EventArgs e) {
            if (Loyalty_Stores.SelectedIndex != -1) {
                LoadLoyaltyAccounts(Loyalty_Stores, AccountsFound_Listbox);
            }
        }

        //MEthods for the Manager Accounts tab
        //load the list of managers to the list box 
        public void LoadManagerAccountList(ListBox managerslist)
        {
            try
            {
                int managercount = 0;        // the number of orders to display
                List<string>[] ManagerAccountdata;   // the orders that will be displayed
                ArrayList ListBoxInfo = new ArrayList(); // Array List where formatted text will be stored.

                //request the Records to display on the manager orders list
                managercount = CorpData.CorporateManagerAccountsData(out ManagerAccountdata);

                // Clear any existing data in the list box
                Managers_Listbox.DataSource = null;
                Managers_Listbox.Items.Clear();

                if (managercount > 0) {
                    //loop over the records and format them in the Array List
                    for (int index = 0; index < managercount; index++) {
                        ListBoxInfo.Add(new BoxFormat(ManagerAccountdata[2][index] + " " + ManagerAccountdata[3][index] + " - Store #" + ManagerAccountdata[0][index], ManagerAccountdata[1][index]));
                    }

                    // Insert Array List into the List Box
                    Managers_Listbox.DataSource = ListBoxInfo;

                    // Define which information is actually displayed by the listbox and returned
                    Managers_Listbox.DisplayMember = "displayText";
                    Managers_Listbox.ValueMember = "databaseID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading Orders List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //LoadManagerAccountsList
        
        //delete the manaager account that is selected.
        private void DeleteManagerAccount_Click(object sender, EventArgs e){
            // connect to DB if it is not connected
            if (CorpData.Connected()) {
                // Get the currently selected item in the ListBox. 
                string curItem = ((BoxFormat)Managers_Listbox.SelectedItem).databaseID;
                    
                if (!string.IsNullOrWhiteSpace(curItem)){
                    // Update the database to mark selected order Refunded and clear Manager Accounts List
                    CorpData.CorporatDeleteManagerAccount(curItem);

                    LoadManagerAccountList(Managers_Listbox);
                    // Inform User that Account was successfully Deleted.
                    MessageBox.Show("Manager Account #" + curItem + " Deleted.", "Delete Manager Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("Account Not Selected!", "Delete Manager Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } else {
                MessageBox.Show("Account Not Deleted!", "Database not connected.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } // DeleteManagerAccount_Click
        
        //Save new manager to Database.
        private void SaveManagerAccount_Button_Click(object sender, EventArgs e)
        {
            // Get the text entered into the text boxes. 
            try {
                // Buffer to store text
                string storeid = ((BoxFormat)StoresComboBox.SelectedItem).databaseID;
                string FirstName = AssistantManagerFirstName_Textbox.Text.ToString();
                string LastName = AssistantManagerLastName_Textbox.Text.ToString();
                string EmployeeID = EmployeeID_Textbox.Text.ToString();
                string Password = AssistantManagerPassword_Textbox.Text.ToString();
                string PasswordConfirm = AssistantManagerConfirm_Textbox.Text.ToString();

                if (String.IsNullOrWhiteSpace(FirstName) || String.IsNullOrWhiteSpace(LastName) || String.IsNullOrWhiteSpace(EmployeeID)
                    || String.IsNullOrWhiteSpace(Password) || String.IsNullOrWhiteSpace(PasswordConfirm) || String.IsNullOrWhiteSpace(storeid)) {
                    MessageBox.Show("Not All Fields Filled In!", "Save Manager Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                if (Password != PasswordConfirm) {
                    MessageBox.Show("Passwords Do Not Match!", "Save Manager Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                // connect to DB if it is not connected
                if (CorpData.Connected()) {
                    // Get the loyalty account data from the database
                    CorpData.CorporateSaveManagerAccount(FirstName, LastName, EmployeeID, Password, storeid); // ManagerSaveManagerAccount(FirstName, LastName, EmployeeID, Password);

                    // Refresh Managers List 
                    LoadManagerAccountList(Managers_Listbox);

                    // Inform user that account was successfully created.
                    MessageBox.Show("Account - " + FirstName + " " + LastName + " Created.", "Save Manager Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Shouldnt Be Seeing This!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } // SaveLoyaltyAccount_Button_Click       
        
        //load the list of inventory for teh specified store
        public void LoadInventoryList(string storeid, ListBox inventorylistbox)
        {
            try
            {
                int itemcount = 0;        // the number of orders to display
                List<string>[] Inventorydata;   // the orders that will be displayed
                ArrayList ListBoxInfo = new ArrayList(); // Array List where formatted text will be stored.

                // connect to DB if it is not connected
                if (CorpData.Connected()){

                    //request the Records to display on the manager orders list
                    itemcount = CorpData.CorporateGetInventoryData(out Inventorydata, storeid);

                    // Clear any existing data in the list box
                    inventorylistbox.DataSource = null;
                    inventorylistbox.Items.Clear();

                    if (itemcount > 0) {
                        //loop over the records and format them in the Array List
                        for (int index = 0; index < itemcount; index++) {
                            ListBoxInfo.Add(new BoxFormat(Inventorydata[1][index] + " - " + Inventorydata[2][index], Inventorydata[0][index]));
                        }

                        // Insert Array List into the List Box
                        inventorylistbox.DataSource = ListBoxInfo;

                        // Define which information is actually displayed by the listbox and returned
                        inventorylistbox.DisplayMember = "displayText";
                        inventorylistbox.ValueMember = "databaseID";
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading Inventory List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //LoadManagerInventoryList

        private void Inventory_Stores_SelectedIndexChanged(object sender, EventArgs e) {
            if (Inventory_Stores.SelectedIndex != -1) {
                string selectedStore = ((BoxFormat)Inventory_Stores.SelectedItem).databaseID;
                LoadInventoryList(selectedStore, Inventory_Listbox);
            }
        }

        //functions for the reports tab
        
        private void Reports_Listbox_SelectedIndexChanged(object sender, EventArgs e) {
            GenerateReport();
        }

        private void LoadReports(ListBox reportslist) {
            //create instance of report object.
            Reports rept = new Reports();

            //loop over number reports.
            for (int i = 0; i < rept.NumberReportsAvalaible(); i++) {
                //add report names to list box
                reportslist.Items.Add(rept.ReportName(i));
            }

            //Reports_Listbox.SelectedIndex = 0;
        }

        private void GenerateReport() {
            //create instance of report object.
            Reports rept = new Reports();

            //Add the stores to the report generator
            for (int i = 0; i < Reports_Stores.SelectedIndices.Count; ++i) {
                rept.AddStore(Convert.ToInt32(((BoxFormat) Reports_Stores.Items[Reports_Stores.SelectedIndices[i]]).databaseID));
            }

            // generate the report and place it into a Webbrowser window.
            string report = rept.GenerateReport(Reports_Listbox.SelectedIndex);
            webReports.Navigate("about:blank");

            //if a report exists we have to empty the control
            if (webReports.Document != null) {
                webReports.Document.Write(string.Empty);
            }
            webReports.DocumentText = report;
        }

        private void PrintReport_Button_Click(object sender, EventArgs e) {
            webReports.ShowPrintDialog();
        }


    }
}
 
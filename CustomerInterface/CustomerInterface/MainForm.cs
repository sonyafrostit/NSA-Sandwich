using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Globalization;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Net.Mail;
using System.Net;

namespace CustomerInterface
{
    public partial class KioskWindow : Form
    {
        //CultureInfo stores the lanuage
        //(default is US if language not chosen in splash screen)
        private CultureInfo ci;
        private Assembly a; //loads assembly for CustomerInterface
        private ResourceManager rm; //manages the resources and gets the text localization for users language

        //db will connect to the databse
        private NSADatabase db;
        private NSAMenuCategory[] menu; //contains menu
        private NSAOrder currentOrder; //current order
        private NSAComponent[] componentsList;
        private CustomizeForm customizeItemForm; //used when user tries to customize an order
        private NSALoyaltyAccount account; //stores loyalty account info
                                           //acc #, name, email, rewards

        //constructor called when logging in as guest
        public KioskWindow(CultureInfo language)
        {
            ci = language; //set the language
            a = Assembly.Load("CustomerInterface"); //load the assembly and resourcemanager
            rm = new ResourceManager("CustomerInterface.Lang.lang", a);

            InitializeComponent();
            db = new NSADatabase();
            db.OpenConnection();
            componentsList = db.getComponents();
            menu = db.getMenu();

            updateMenu();
            currentOrder = new NSAOrder();
            setLang(ci);
        }

        //constructor called when logging in with a loyalty account
        public KioskWindow(CultureInfo language, List<string>[] accountNumber)
        {
            ci = language; //set the language
            a = Assembly.Load("CustomerInterface"); //load the assembly and resourcemanager
            rm = new ResourceManager("CustomerInterface.Lang.lang", a);

            
            account = new NSALoyaltyAccount(accountNumber[0][0], accountNumber[1][0], accountNumber[2][0], accountNumber[3][0]);
            InitializeComponent();

            db = new NSADatabase();
            db.OpenConnection();
            componentsList = db.getComponents();
            menu = db.getMenu();

            setAccountTab();
            updateMenu();
            currentOrder = new NSAOrder();
            setLang(ci);
        }

        private void setAccountTab()
        {
            nameTextBox.Text = account.getName();
            emailTextBox.Text = account.getEmail();
            accountNumberLabel.Text = account.getAccountNumber();
            rewardCountLabel.Text = account.getOrdersNeeded();
        }

        private void updateMenu()
        {
            DataParser dataParser = new DataParser(ci); //parses Categories, Menu Items, and Components and displays them in the users language
            foreach (NSAMenuCategory category in menu)
            {
	            //Do not Display "unassigned" category
	            if (category.Id == 0){
	                continue;
	            }
                ListViewGroup LVG = new ListViewGroup(dataParser.parseCategory(category.Name));
                foreach (NSAMenuItem item in category.Items)
                {
                    if (item.CategoryID != category.Id)
                    {
                        continue;
                    }
                    ListViewItem newitem = new ListViewItem(dataParser.parseItem(item.Name), item.Image, LVG);
                    newitem.Tag = item;
                    menuListView.Items.Add(newitem);
                }
                menuListView.Groups.Add(LVG);
            }

            ListViewGroup RandomGroup = new ListViewGroup(dataParser.parseCategory("Random"));
            ListViewItem randomItemLVI = new ListViewItem("Random Sandwich!", RandomGroup);
            NSARandomItem randomItem = new NSARandomItem();
            randomItem.CategoryID = 1;
            randomItem.Price = 9.99;
            randomItem.MenuType = "Random!";
            randomItem.Name = "Random";
            randomItemLVI.Tag = randomItem;
            menuListView.Items.Add(randomItemLVI);
            menuListView.Groups.Add(RandomGroup);

            rm.GetString("accountNumber", ci);
            rm.GetString("accountNumber", ci);
        }

        //clears the menu (mostly used to set items to a users language)
        private void clearMenu()
        {
            menuListView.Items.Clear();
        }

        private void addItemToOrder(NSAMenuItem item) {
            
            item.GenerateItem(componentsList);
            
            //item.getComponents(db, componentsList);
            currentOrder.AddItem(new NSAMenuItem(item));
            
            UpdateOrderView();
            

        }

        private void UpdateOrderView() {
            try
            {
                DataParser cp = new DataParser(ci);
                OrderView.Items.Clear();
                Decimal totalPrice = 0;
                for (int i = 0; i < currentOrder.Items.Count; i++)
                {

                    ListViewItem lvi = new ListViewItem(cp.parseItem(currentOrder.Items.ElementAt(i).Name));
                    totalPrice += (Decimal)currentOrder.Items.ElementAt(i).Price;
                    lvi.Tag = i; // Set to the index of the order item
                    OrderView.Items.Add(lvi);
                    if (currentOrder.Items.ElementAt(i).Components.Count > 0)
                    {
                        
                        foreach (NSAComponent c in currentOrder.Items.ElementAt(i).Components)
                        {
                            
                            ListViewItem changeItem = new ListViewItem(""); // Set to blank so we can see the change
                            changeItem.SubItems.Add(cp.parseItem(c.ToString()));
                            changeItem.Tag = i;
                            OrderView.Items.Add(changeItem);
                        }


                    }

                }

                OrderView.Items.Add(new ListViewItem("Total: " + totalPrice));
            }
            catch (System.NullReferenceException e) {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void printReceipt()
        {
            StringBuilder receipt = new StringBuilder();

            string message = "Thank you for visiting us! Here is your receipt for your order. Come again!";
            receipt.Append(message);
            receipt.AppendLine();
            receipt.AppendLine();

            receipt.Append("Item                     Changes");
            receipt.AppendLine();

            foreach (ListViewItem item in OrderView.Items)
            {
                receipt.Append(item.Text);

                if (item.SubItems.Count > 1)
                {
                    for (int i = 0; i < item.SubItems.Count; i++)
                    {
                        if ((i % 2) == 0)
                        {
                            continue;
                        }

                        else
                        {
                            receipt.Append("                           ");
                            receipt.Append(item.SubItems[i].Text);
                        }
                    }
                }
                receipt.AppendLine();
                receipt.AppendLine();
            }


            MailMessage mail = new MailMessage();
            mail.To.Add("cse4444project@gmail.com");
            mail.Subject = "NSA Receipt";
            mail.From = new MailAddress("cse4444project@gmail.com");
            mail.Body = receipt.ToString();

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("cse4444project@gmail.com", "NSAproject1");
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }

        private void removeItemFromOrder(NSAMenuItem item)
        { 
        
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem t in menuListView.SelectedItems)
            {
                ((NSAMenuItem)t.Tag).getComponents(db, componentsList);

                addItemToOrder((NSAMenuItem)t.Tag);
                //ask add about making combo if entree is sandwich or salad - TRAE
                if (((NSAMenuItem)t.Tag).CategoryID == 1 || ((NSAMenuItem)t.Tag).CategoryID == 2)
                {
                    //make sure that the number of discounts and combo drinks are less than the number of entrees before adding more.

                    if (CanHaveComboDiscount()){
                        //Ask to make combo - "Make this entree a combo for a 1.00 discount?"
                        DataParser dataParser = new DataParser(ci); //parses displays them in the users language
                        DialogResult result = MessageBox.Show(rm.GetString("askmakecombo", ci), rm.GetString("makecombocaption", ci), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            //get the drink combo item and add it to the order
                            NSAMenuItem newComboItem = db.getComboDrink();
                            addItemToOrder(newComboItem);

                            //Get the drink combo Discount and add it to the order
                            NSAMenuItem newComboDiscount = db.getComboDrinkDiscount();
                            addItemToOrder(newComboDiscount);
                        }
                    }
                }

                UpdateOrderView();
            }
        }

        private bool CanHaveComboDiscount(){
        // need to check if the current order is eligiable for another combo. discount.
            bool canDiscount = false;

            int numEntrees = 0;
            int numComboDrinks = 0;
            int numDiscounts = 0;

            NSAMenuItem newComboItem = db.getComboDrink();
            NSAMenuItem newDiscountItem = db.getDiscountItem();

            // count how may of the various items we have.
            for (int i = 0; i < currentOrder.Items.Count; i++)
            {
                if ((int)currentOrder.Items.ElementAt(i).CategoryID == 1 ||
                     (int)currentOrder.Items.ElementAt(i).CategoryID == 2)
                {
                         numEntrees++;
                }

                if ((int)currentOrder.Items.ElementAt(i).Id == newComboItem.Id)
                {
                    numComboDrinks++;
                }

                if ((int)currentOrder.Items.ElementAt(i).Id == newDiscountItem.Id)
                {
                    numDiscounts++;
                }

            }

            if ( numEntrees > numComboDrinks  && numEntrees >numDiscounts ){
                canDiscount = true;
            }

            return canDiscount;
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
                
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void OrderListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LanguageTab_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (OrderView.SelectedItems.Count > 0)
            {
                customizeItemForm = new CustomizeForm();
                customizeItemForm.setLang(ci);
                customizeItemForm.CustomizeComponents = componentsList;
                customizeItemForm.CustomizeItem = (NSAMenuItem)currentOrder.Items[(int)OrderView.SelectedItems[0].Tag];
                customizeItemForm.OriginalIndex = OrderView.SelectedIndices[0];
                customizeItemForm.populateComponents();
                customizeItemForm.Show();
            }
        }

        //sets language of the interface to users chosen language
        public void setLang(CultureInfo ci)
        {
            selectLangText.Text = rm.GetString("selectLangText", ci); //language tab localization

            button1.Text = rm.GetString("finishOrderBut", ci); //order interface localization
            WelcomeLabel.Text = rm.GetString("welcome", ci);
            button6.Text = rm.GetString("customizeBut", ci);
            RemoveButton.Text = rm.GetString("removeBut", ci);
            OrderView.Columns[0].Text = rm.GetString("itemCat", ci);
            OrderView.Columns[1].Text = rm.GetString("changesCat", ci);

            KioskTabs.TabPages[0].Text = rm.GetString("menuTab", ci); //tab name localization
            KioskTabs.TabPages[1].Text = rm.GetString("loyaltyTab", ci);
            KioskTabs.TabPages[2].Text = rm.GetString("languageTab", ci);

            AccNumberTagLabel.Text = rm.GetString("accountNumber", ci); //account tab localization
            nameLabel.Text = rm.GetString("name", ci);
            emailLabel.Text = rm.GetString("email", ci);
            pastOrdersLabel.Text = rm.GetString("pastOrders", ci);
            favoriteItemsLabel.Text = rm.GetString("favoriteItems", ci);
            rewardsLabel.Text = rm.GetString("rewards", ci);

            UpdateOrderView(); //also updates the current orders language
            clearMenu();
            updateMenu();   //menu is also supported
        }

        //changes the language to english
        private void enBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("en-US");
            setLang(ci);
        }

        //changes the language to french
        private void frBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("fr-FR");
            setLang(ci);
        }

        //changes the language to german
        private void geBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("de-DE");
            setLang(ci);
        }

        //changes the language to spanish
        private void spBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("es-ES");
            setLang(ci);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string parsedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            MySqlCommand cmd;
            string cmdstring;
            if (account == null)
            {
                cmdstring = String.Format("INSERT INTO orders (storeid, status, timeplaced, total, tax) VALUES( {0}, {1}, \'{2}\', {3}, {4} );", db.StoreNumber1, 0, parsedDate, currentOrder.Total, currentOrder.Tax);
                cmd = new MySqlCommand(cmdstring, db.Connection1);
            }
            else {
                cmdstring = "INSERT INTO orders (storeid, loyaltyid, status, timeplaced, total, tax, refunded) VALUES('" + db.StoreNumber1 + "', '" + account.getAccountNumber() + "', '0', '" + parsedDate + "', '" + currentOrder.Total.ToString() + "', '" + currentOrder.Tax.ToString() + "', '" + (Convert.ToInt32(account.getRewardCount()) == 0) + "');";
                cmd = new MySqlCommand( cmdstring, db.Connection1);
                
            }
            cmd.ExecuteReader().Close();
            currentOrder.Id = cmd.LastInsertedId;
            if (account != null && saveorder)
            {
                MySqlCommand histcmd = new MySqlCommand(String.Format("INSERT INTO favoriteorder (orderID, storeid, loyaltyid) VALUES ({0}, {1}, {2});", currentOrder.Id, db.StoreNumber1, account.getAccountNumber()));
                histcmd.ExecuteReader().Close();
            }
            foreach (NSAMenuItem item in currentOrder.Items) { 
                MySqlCommand cmd2 = new MySqlCommand(String.Format("INSERT INTO orderitems (storeid, orderid, menuitemid, name, price) VALUES ({0}, {1}, {2}, '{3}', {4});", db.StoreNumber1, currentOrder.Id, item.Id, item.Name, item.Price), db.Connection1);
                cmd2.ExecuteReader().Close();
                long orderitemid;
                orderitemid = cmd2.LastInsertedId;
                foreach (NSAComponent comp in item.Components) {
                    MySqlCommand cmd3 = new MySqlCommand(("INSERT INTO orderitemcomponents (orderitemid, storeid, component) VALUES (" + orderitemid + ", " + db.StoreNumber1 + ", " + comp.ComponentID + ");"), db.Connection1);
                    cmd3.ExecuteReader().Close();
                }
            }
            CashCreditSelect ccs = new CashCreditSelect(currentOrder.Id, (currentOrder.Total + currentOrder.Tax), db);
            ccs.Show();
            ccs.FormClosed += new FormClosedEventHandler(CustomerKiosk_FormClosed);
            Hide();
        }

        void CustomerKiosk_FormClosed(object sender, FormClosedEventArgs e)
        {
            StartForm from = new StartForm();
            from.Show();
            from.FormClosed += new FormClosedEventHandler(StartMenu_FormClosed);
            this.Hide();
        }

        void StartMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in OrderView.SelectedItems) {
                currentOrder.Items.RemoveAt((int)item.Tag);
            }
            UpdateOrderView();
        }

        private void KioskWindow_Activated(object sender, EventArgs e)
        {
            
            if (customizeItemForm != null)
            {
                
                NSAChanges changes = customizeItemForm.Changes;

                
                customizeItemForm.Close();
                
                currentOrder.Items.RemoveAt(changes.OriginalItem);
                
                addItemToOrder(changes.FinishedItem);

                
                
                UpdateOrderView();
                
            }
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void KioskWindow_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (account != null && OrderView.SelectedItems.Count > 0)
            {
                MySqlCommand cmd2 = new MySqlCommand(String.Format("INSERT INTO favoriteitems (storeid, loyaltyid, name, price, menuitemid) VALUES ({0}, {1}, {2}, '{3}', {4}, {5});", db.StoreNumber1, account.getAccountNumber(), ((NSAMenuItem)OrderView.SelectedItems[0].Tag).Name, ((NSAMenuItem)OrderView.SelectedItems[0].Tag).Price, ((NSAMenuItem)OrderView.SelectedItems[0].Tag).Id), db.Connection1);
                cmd2.ExecuteReader().Close();
                long favitemid = cmd2.LastInsertedId;
                foreach (NSAComponent comp in ((NSAMenuItem)OrderView.SelectedItems[0].Tag).Components)
                {
                    MySqlCommand cmd3 = new MySqlCommand(("INSERT INTO favoriteitemcomponents (favoriteitemid, storeid, componentid) VALUES (" + favitemid + ", " + db.StoreNumber1 + ", " + comp.ComponentID + ");"), db.Connection1);
                    cmd3.ExecuteReader().Close();
                }
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            saveorder = true;
        }
        bool saveorder = false;
    }
}

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
using NSAData;

namespace CustomerInterface
{
    public partial class KioskWindow : Form
    {
        //CultureInfo stores the lanuage
        //(default is US if language not chosen in splash screen)
        private CultureInfo ci;
        private Assembly a;
        private ResourceManager rm;

        //db will connect to the databse
        private NSADatabase db;
        private NSAMenuCategory[] menu;
        private NSAOrder currentOrder;
        private NSAComponent[] componentsList;
        private CustomizeForm customizeItemForm;
        private NSALoyaltyAccount account;

        //constructor called when logging in as guest
        public KioskWindow(CultureInfo language)
        {
            ci = language;
            a = Assembly.Load("CustomerInterface");
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
            ci = language;
            a = Assembly.Load("CustomerInterface");
            rm = new ResourceManager("CustomerInterface.Lang.lang", a);

            //account = new NSALoyaltyAccount(accountNumber);
            account = new NSALoyaltyAccount(accountNumber[0][0], accountNumber[1][0], accountNumber[2][0], accountNumber[3][0]);
            setAccountTab();

            InitializeComponent();
            db = new NSADatabase();
            db.OpenConnection();
            componentsList = db.getComponents();
            menu = db.getMenu();

            updateMenu();
            currentOrder = new NSAOrder();
            setLang(ci);
        }

        private void setAccountTab()
        {
            nameTextBox.Text = account.getName();
            emailTextBox.Text = account.getEmail();
            accountNumberLabel.Text = account.getAccountNumber();
            rewardsLabel.Text = account.getRewardCount() + " more orders to free sandwich";
        }

        private void updateMenu()
        {
            DataParser dataParser = new DataParser(ci);
            foreach (NSAMenuCategory category in menu)
            {
                ListViewGroup LVG = new ListViewGroup(dataParser.parseCategory(category.Name));
                foreach (NSAMenuItem item in category.Items)
                {
                    if (item.CategoryID != category.Id)
                    {
                        continue;
                    }
                    ListViewItem newitem = new ListViewItem(dataParser.parseMenuItem(item.Name), item.Image, LVG);
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

                    ListViewItem lvi = new ListViewItem(cp.parseComponent(currentOrder.Items.ElementAt(i).Name));
                    totalPrice += (Decimal)currentOrder.Items.ElementAt(i).Price;
                    lvi.Tag = i; // Set to the index of the order item
                    OrderView.Items.Add(lvi);
                    if (currentOrder.Items.ElementAt(i).Components.Count > 0)
                    {
                        
                        foreach (NSAComponent c in currentOrder.Items.ElementAt(i).Components)
                        {
                            
                            ListViewItem changeItem = new ListViewItem(""); // Set to blank so we can see the change
                            changeItem.SubItems.Add(cp.parseComponent(c.ToString()));
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
        private void removeItemFromOrder(NSAMenuItem item)
        { 
        
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem t in menuListView.SelectedItems)
            {
                ((NSAMenuItem)t.Tag).getComponents(db, componentsList);
                addItemToOrder((NSAMenuItem)t.Tag);
                UpdateOrderView();
            }
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
                customizeItemForm.CustomizeComponents = componentsList;
                customizeItemForm.CustomizeItem = (NSAMenuItem)currentOrder.Items[(int)OrderView.SelectedItems[0].Tag];
                customizeItemForm.OriginalIndex = OrderView.SelectedIndices[0];
                customizeItemForm.populateComponents();
                customizeItemForm.Show();
            }
        }

        public void setLang(CultureInfo ci)
        {
            selectLangText.Text = rm.GetString("selectLangText", ci);

            button1.Text = rm.GetString("finishOrderBut", ci);
            WelcomeLabel.Text = rm.GetString("welcome", ci);
            button6.Text = rm.GetString("customizeBut", ci);
            RemoveButton.Text = rm.GetString("removeBut", ci);
            OrderView.Columns[0].Text = rm.GetString("itemCat", ci);
            OrderView.Columns[1].Text = rm.GetString("changesCat", ci);

            KioskTabs.TabPages[0].Text = rm.GetString("menuTab", ci);
            KioskTabs.TabPages[1].Text = rm.GetString("loyaltyTab", ci);
            KioskTabs.TabPages[2].Text = rm.GetString("languageTab", ci);

            AccNumberTagLabel.Text = rm.GetString("accountNumber", ci);
            nameLabel.Text = rm.GetString("name", ci);
            emailLabel.Text = rm.GetString("email", ci);
            pastOrdersLabel.Text = rm.GetString("pastOrders", ci);
            favoriteItemsLabel.Text = rm.GetString("favoriteItems", ci);

            UpdateOrderView();
            clearMenu();
            updateMenu();
        }

        private void enBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("en-US");
            setLang(ci);
        }

        private void frBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("fr-FR");
            setLang(ci);
        }

        private void geBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("de-DE");
            setLang(ci);
        }

        private void spBtn_Click(object sender, EventArgs e)
        {
            ci = new CultureInfo("es-ES");
            setLang(ci);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

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

    }
}

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

namespace CustomerInterface
{
    public partial class KioskWindow : Form
    {
        //needs to be taken from StartForm 
        //(default is US if language not chosen in splash screen)
        CultureInfo ci;
        NSADatabase db;
        NSAMenuCategory[] menu;
        NSAOrder currentOrder;
        NSAComponent[] componentsList;
        public KioskWindow()
        {
            InitializeComponent();
            db = new NSADatabase();
            db.OpenConnection();
            componentsList = db.getComponents();
            menu = db.getMenu();
            updateMenu();
            currentOrder = new NSAOrder();
        }

        private void updateMenu()
        {
            ComponentParser cp = new ComponentParser(ci);
            foreach (NSAMenuCategory category in menu)
            {
                ListViewGroup LVG = new ListViewGroup(category.Name);
                foreach (NSAMenuItem item in category.Items)
                {
                    if (item.CategoryID != category.Id)
                    {
                        continue;
                    }
                    ListViewItem newitem = new ListViewItem(cp.parseMenuItem(item.Name), item.Image, LVG);
                    newitem.Tag = item;
                    menuListView.Items.Add(newitem);
                }
                menuListView.Groups.Add(LVG);
            }

            ListViewGroup RandomGroup = new ListViewGroup("Random!");
            ListViewItem randomItemLVI = new ListViewItem("Random Sandwich!", RandomGroup);
            NSARandomItem randomItem = new NSARandomItem();
            randomItem.CategoryID = 1;
            randomItem.Price = 9.99;
            randomItem.MenuType = "Random!";
            randomItem.Name = "Random";
            randomItemLVI.Tag = randomItem;
            menuListView.Items.Add(randomItemLVI);
            menuListView.Groups.Add(RandomGroup);
        }

        private void clearMenu()
        {
            menuListView.Items.Clear();
        }

        private void addItemToOrder(NSAMenuItem item) {
            item.GenerateItem(componentsList);

            currentOrder.AddItem(new NSAMenuItem(item));


        }
        private void UpdateOrderView() {
            ComponentParser cp = new ComponentParser(ci);
            OrderView.Items.Clear();
            Decimal totalPrice = 0;
            for (int i = 0; i < currentOrder.Items.Count; i++) {
                ListViewItem lvi = new ListViewItem(cp.parseComponent(currentOrder.Items.ElementAt(i).Name));
                totalPrice += (Decimal)currentOrder.Items.ElementAt(i).Price;
                lvi.Tag = i; // Set to the index of the order item
                OrderView.Items.Add(lvi);
                if (currentOrder.Items.ElementAt(i).ComponentChanges.Count > 0) {
                    
                    foreach (String c in currentOrder.Items.ElementAt(i).ComponentChanges) {
                        ListViewItem changeItem = new ListViewItem(""); // Set to blank so we can see the change
                        changeItem.SubItems.Add(cp.parseComponent(c));
                        changeItem.Tag = i;
                        OrderView.Items.Add(changeItem);
                    }
                    
                    
                }
                
            }
            OrderView.Items.Add(new ListViewItem("Total: " + totalPrice));
        }
        private void removeItemFromOrder(NSAMenuItem item)
        { 
        
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem t in menuListView.SelectedItems)
            {
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
            CustomizeForm customizeItemForm = new CustomizeForm();
            customizeItemForm.CustomizeComponents = componentsList;
            customizeItemForm.populateComponents();
            customizeItemForm.Show();
        }

        public void setLang(CultureInfo ci)
        {
            Assembly a = Assembly.Load("CustomerInterface");
            ResourceManager rm = new ResourceManager("CustomerInterface.Lang.lang", a);
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

    }
}

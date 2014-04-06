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
        CultureInfo ci;
        NSADatabase db;
        NSAMenuCategory[] menu;
        NSAOrder currentOrder;
        public KioskWindow()
        {
            InitializeComponent();
            db = new NSADatabase();
            db.OpenConnection();
            menu = db.getMenu();
            foreach (NSAMenuCategory category in menu) {
                ListViewGroup LVG = new ListViewGroup(category.Name);
                foreach (NSAMenuItem item in category.Items) {
                    if (item.CategoryID != category.Id) {
                        continue;
                    }
                    ListViewItem newitem = new ListViewItem(item.Name, item.Image, LVG);
                    newitem.Tag = item;
                    menuListView.Items.Add(newitem);
                }
                menuListView.Groups.Add(LVG);
            }
            currentOrder = new NSAOrder();

        }
        private void addItemToOrder(NSAMenuItem item) {
            currentOrder.AddItem(item);


        }
        private void UpdateOrderView() {
            OrderView.Items.Clear();

            for (int i = 0; i < currentOrder.Items.Count; i++) {
                ListViewItem lvi = new ListViewItem(currentOrder.Items.ElementAt(i).Name);
                
                if (currentOrder.Items.ElementAt(i).ComponentChanges.Count > 0) {
                    StringBuilder sb = new StringBuilder();
                    foreach (String c in currentOrder.Items.ElementAt(i).ComponentChanges) {
                        sb.Append(c).Append("\n");
                    }
                    lvi.SubItems.Add(sb.ToString());
                    
                }
                OrderView.Items.Add(lvi);
            }
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

        }

        public void setLang(CultureInfo ci)
        {
            Assembly a = Assembly.Load("CustomerInterface");
            ResourceManager rm = new ResourceManager("CustomerInterface.Lang.lang", a);
            selectLangText.Text = rm.GetString("selectLangText", ci);
            KioskTabs.TabPages[0].Text = rm.GetString("menuTab", ci);
            KioskTabs.TabPages[1].Text = rm.GetString("loyaltyTab", ci);
            AccNumberTagLabel.Text = rm.GetString("accountNumber", ci);
            nameLabel.Text = rm.GetString("name", ci);
            emailLabel.Text = rm.GetString("email", ci);
            button1.Text = rm.GetString("finishOrderBut", ci);
            WelcomeLabel.Text = rm.GetString("welcome", ci);
            button6.Text = rm.GetString("customizeBut", ci);
            RemoveButton.Text = rm.GetString("removeBut", ci);
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
            foreach (int index in OrderView.SelectedIndices) {
                currentOrder.Items.RemoveAt(index);
            }
            UpdateOrderView();
        }

    }
}

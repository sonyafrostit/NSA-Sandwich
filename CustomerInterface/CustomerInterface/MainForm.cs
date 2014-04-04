using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerInterface
{
    public partial class KioskWindow : Form
    {
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
            UpdateOrderView();


        }
        private void UpdateOrderView() {
            OrderView.Clear();
            
            for (int i = 0; i < currentOrder.Items.Count; i++) {
                ListViewItem lvi = new ListViewItem(currentOrder.Items.ElementAt(i).Name);
                StringBuilder sb = new StringBuilder();
                foreach (String c in currentOrder.Items.ElementAt(i).ComponentChanges) {
                    sb.Append(c).Append("\n");
                }
                lvi.SubItems.Add(sb.ToString());
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

    }
}

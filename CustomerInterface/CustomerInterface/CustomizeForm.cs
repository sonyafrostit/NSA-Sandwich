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
    public partial class CustomizeForm : Form
    {
        public CustomizeForm()
        {
            InitializeComponent();
            
        }
        NSAComponent[] customizeComponents;
        public void populateComponents() {
            foreach (NSAComponent comp in customizeComponents)
            {
                if (comp.Category != "Bread")
                {
                    OtherListBox.Items.Add(comp.Name);
                }
                else {
                    BreadList.Items.Add(new ListViewItem(comp.Name));
                }
            }
        
        }
        public NSAComponent[] CustomizeComponents
        {
            get { return customizeComponents; }
            set { customizeComponents = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void OtherListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

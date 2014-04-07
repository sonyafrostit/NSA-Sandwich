﻿using System;
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
        NSAMenuItem customizeItem;
        NSAChanges changes;
        
        public NSAChanges Changes
        {
            get { return changes; }
            set { changes = value; }
        }
        int originalIndex;

        public int OriginalIndex
        {
            get { return originalIndex; }
            set { originalIndex = value; }
        }
        public NSAMenuItem CustomizeItem
        {
            get { return customizeItem; }
            set { customizeItem = value; }
        }
        public void populateComponents() {
            
            BreadPanel.Visible = customizeItem.BreadIndex >= 0;
            
            foreach (NSAComponent comp in customizeComponents)
            {
                if (comp.Category != "Bread")
                {
                    OtherListBox.Items.Add(comp, customizeItem.Components.Contains(comp));
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

        private void BreadList_SelectedIndexChanged(object sender, EventArgs e)
        {
            customizeItem.Components.Add((NSAComponent)BreadList.SelectedItems[0].Tag);
            customizeItem.BreadIndex = customizeItem.Components.Count - 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            changes = new NSAChanges();
            NSAMenuItem resultItem = new NSAMenuItem(customizeItem);
            List<NSAComponent> finalComponents = new List<NSAComponent>();
            foreach (Object customComponent in OtherListBox.CheckedItems) {
                finalComponents.Add((NSAComponent)customComponent);
                
            }
            if (customizeItem.BreadIndex > -1) {
                finalComponents.Add(customizeItem.Components[customizeItem.BreadIndex]);
            }
            resultItem.Components = finalComponents;
            changes.FinishedItem = resultItem;
            changes.OriginalItem = OriginalIndex;
            Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BreadPanel_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}

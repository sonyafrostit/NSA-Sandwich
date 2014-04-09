namespace NSA_Corporate_Application
{
    partial class CorporateUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Reports = new System.Windows.Forms.TabPage();
            this.webReports = new System.Windows.Forms.WebBrowser();
            this.label6 = new System.Windows.Forms.Label();
            this.Reports_Stores = new System.Windows.Forms.ListBox();
            this.PrintReport_Button = new System.Windows.Forms.Button();
            this.Reports_Listbox = new System.Windows.Forms.ListBox();
            this.ReportsTitle_Label = new System.Windows.Forms.Label();
            this.Inventory = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.Inventory_Stores = new System.Windows.Forms.ListBox();
            this.Inventory_Listbox = new System.Windows.Forms.ListBox();
            this.InventoryTitle_Label = new System.Windows.Forms.Label();
            this.AssistantManagers = new System.Windows.Forms.TabPage();
            this.StoresComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AssistantManagerLastName_Label = new System.Windows.Forms.Label();
            this.AssistantManagerLastName_Textbox = new System.Windows.Forms.TextBox();
            this.AssistantManagerConfirm_Textbox = new System.Windows.Forms.TextBox();
            this.AssistantManagerPassword_Textbox = new System.Windows.Forms.TextBox();
            this.EmployeeID_Textbox = new System.Windows.Forms.TextBox();
            this.AssistantManagerFirstName_Textbox = new System.Windows.Forms.TextBox();
            this.DeleteAssistantManager_Button = new System.Windows.Forms.Button();
            this.Managers_Listbox = new System.Windows.Forms.ListBox();
            this.AssistantManagersList_Label = new System.Windows.Forms.Label();
            this.AssistantManagerSave_Button = new System.Windows.Forms.Button();
            this.AssistantManagersConfirm_Label = new System.Windows.Forms.Label();
            this.AssistantMangerPassword_Label = new System.Windows.Forms.Label();
            this.EmployeeID_Label = new System.Windows.Forms.Label();
            this.AssistantManagerFirstName_Label = new System.Windows.Forms.Label();
            this.AssistantManagerTitle_Label = new System.Windows.Forms.Label();
            this.LoyaltyAccounts = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.Loyalty_Stores = new System.Windows.Forms.ListBox();
            this.AccountsFound_Listbox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Orders = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.Orders_Stores = new System.Windows.Forms.ListBox();
            this.RefreshOrders_Button = new System.Windows.Forms.Button();
            this.OrdersItems_Label = new System.Windows.Forms.Label();
            this.OrderItems_Listbox = new System.Windows.Forms.ListBox();
            this.OrdersList_Label = new System.Windows.Forms.Label();
            this.Orders_Listbox = new System.Windows.Forms.ListBox();
            this.ManagerKiosk_TabPage = new System.Windows.Forms.TabControl();
            this.Stores = new System.Windows.Forms.TabPage();
            this.DeleteStore = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.Stores_List = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.StoreAddress_Text = new System.Windows.Forms.TextBox();
            this.StoreZip_Text = new System.Windows.Forms.TextBox();
            this.StoreState_Text = new System.Windows.Forms.TextBox();
            this.StoreCity_Text = new System.Windows.Forms.TextBox();
            this.StoreName_Text = new System.Windows.Forms.TextBox();
            this.SaveStore = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Reports.SuspendLayout();
            this.Inventory.SuspendLayout();
            this.AssistantManagers.SuspendLayout();
            this.LoyaltyAccounts.SuspendLayout();
            this.Orders.SuspendLayout();
            this.ManagerKiosk_TabPage.SuspendLayout();
            this.Stores.SuspendLayout();
            this.SuspendLayout();
            // 
            // Reports
            // 
            this.Reports.Controls.Add(this.webReports);
            this.Reports.Controls.Add(this.label6);
            this.Reports.Controls.Add(this.Reports_Stores);
            this.Reports.Controls.Add(this.PrintReport_Button);
            this.Reports.Controls.Add(this.Reports_Listbox);
            this.Reports.Controls.Add(this.ReportsTitle_Label);
            this.Reports.Location = new System.Drawing.Point(4, 22);
            this.Reports.Name = "Reports";
            this.Reports.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Reports.Size = new System.Drawing.Size(1255, 654);
            this.Reports.TabIndex = 4;
            this.Reports.Text = "Reports";
            this.Reports.UseVisualStyleBackColor = true;
            // 
            // webReports
            // 
            this.webReports.Location = new System.Drawing.Point(466, 31);
            this.webReports.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.webReports.MinimumSize = new System.Drawing.Size(10, 10);
            this.webReports.Name = "webReports";
            this.webReports.Size = new System.Drawing.Size(778, 566);
            this.webReports.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 24);
            this.label6.TabIndex = 18;
            this.label6.Text = "Stores";
            // 
            // Reports_Stores
            // 
            this.Reports_Stores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Reports_Stores.FormattingEnabled = true;
            this.Reports_Stores.ItemHeight = 16;
            this.Reports_Stores.Location = new System.Drawing.Point(6, 31);
            this.Reports_Stores.Name = "Reports_Stores";
            this.Reports_Stores.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.Reports_Stores.Size = new System.Drawing.Size(211, 564);
            this.Reports_Stores.TabIndex = 17;
            // 
            // PrintReport_Button
            // 
            this.PrintReport_Button.Location = new System.Drawing.Point(1103, 613);
            this.PrintReport_Button.Name = "PrintReport_Button";
            this.PrintReport_Button.Size = new System.Drawing.Size(141, 33);
            this.PrintReport_Button.TabIndex = 3;
            this.PrintReport_Button.Text = "Print";
            this.PrintReport_Button.UseVisualStyleBackColor = true;
            this.PrintReport_Button.Click += new System.EventHandler(this.PrintReport_Button_Click);
            // 
            // Reports_Listbox
            // 
            this.Reports_Listbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reports_Listbox.FormattingEnabled = true;
            this.Reports_Listbox.ItemHeight = 16;
            this.Reports_Listbox.Location = new System.Drawing.Point(221, 31);
            this.Reports_Listbox.Name = "Reports_Listbox";
            this.Reports_Listbox.Size = new System.Drawing.Size(242, 564);
            this.Reports_Listbox.TabIndex = 1;
            this.Reports_Listbox.SelectedIndexChanged += new System.EventHandler(this.Reports_Listbox_SelectedIndexChanged);
            // 
            // ReportsTitle_Label
            // 
            this.ReportsTitle_Label.AutoSize = true;
            this.ReportsTitle_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ReportsTitle_Label.Location = new System.Drawing.Point(217, 3);
            this.ReportsTitle_Label.Name = "ReportsTitle_Label";
            this.ReportsTitle_Label.Size = new System.Drawing.Size(75, 24);
            this.ReportsTitle_Label.TabIndex = 0;
            this.ReportsTitle_Label.Text = "Reports";
            // 
            // Inventory
            // 
            this.Inventory.Controls.Add(this.label5);
            this.Inventory.Controls.Add(this.Inventory_Stores);
            this.Inventory.Controls.Add(this.Inventory_Listbox);
            this.Inventory.Controls.Add(this.InventoryTitle_Label);
            this.Inventory.Location = new System.Drawing.Point(4, 22);
            this.Inventory.Name = "Inventory";
            this.Inventory.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Inventory.Size = new System.Drawing.Size(1255, 654);
            this.Inventory.TabIndex = 3;
            this.Inventory.Text = "Inventory";
            this.Inventory.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 24);
            this.label5.TabIndex = 18;
            this.label5.Text = "Stores";
            // 
            // Inventory_Stores
            // 
            this.Inventory_Stores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Inventory_Stores.FormattingEnabled = true;
            this.Inventory_Stores.ItemHeight = 16;
            this.Inventory_Stores.Location = new System.Drawing.Point(6, 31);
            this.Inventory_Stores.Name = "Inventory_Stores";
            this.Inventory_Stores.Size = new System.Drawing.Size(211, 612);
            this.Inventory_Stores.TabIndex = 17;
            this.Inventory_Stores.SelectedIndexChanged += new System.EventHandler(this.Inventory_Stores_SelectedIndexChanged);
            // 
            // Inventory_Listbox
            // 
            this.Inventory_Listbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Inventory_Listbox.FormattingEnabled = true;
            this.Inventory_Listbox.ItemHeight = 16;
            this.Inventory_Listbox.Location = new System.Drawing.Point(221, 31);
            this.Inventory_Listbox.Name = "Inventory_Listbox";
            this.Inventory_Listbox.Size = new System.Drawing.Size(623, 612);
            this.Inventory_Listbox.TabIndex = 1;
            // 
            // InventoryTitle_Label
            // 
            this.InventoryTitle_Label.AutoSize = true;
            this.InventoryTitle_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.InventoryTitle_Label.Location = new System.Drawing.Point(217, 5);
            this.InventoryTitle_Label.Name = "InventoryTitle_Label";
            this.InventoryTitle_Label.Size = new System.Drawing.Size(86, 24);
            this.InventoryTitle_Label.TabIndex = 0;
            this.InventoryTitle_Label.Text = "Inventory";
            // 
            // AssistantManagers
            // 
            this.AssistantManagers.Controls.Add(this.StoresComboBox);
            this.AssistantManagers.Controls.Add(this.label4);
            this.AssistantManagers.Controls.Add(this.AssistantManagerLastName_Label);
            this.AssistantManagers.Controls.Add(this.AssistantManagerLastName_Textbox);
            this.AssistantManagers.Controls.Add(this.AssistantManagerConfirm_Textbox);
            this.AssistantManagers.Controls.Add(this.AssistantManagerPassword_Textbox);
            this.AssistantManagers.Controls.Add(this.EmployeeID_Textbox);
            this.AssistantManagers.Controls.Add(this.AssistantManagerFirstName_Textbox);
            this.AssistantManagers.Controls.Add(this.DeleteAssistantManager_Button);
            this.AssistantManagers.Controls.Add(this.Managers_Listbox);
            this.AssistantManagers.Controls.Add(this.AssistantManagersList_Label);
            this.AssistantManagers.Controls.Add(this.AssistantManagerSave_Button);
            this.AssistantManagers.Controls.Add(this.AssistantManagersConfirm_Label);
            this.AssistantManagers.Controls.Add(this.AssistantMangerPassword_Label);
            this.AssistantManagers.Controls.Add(this.EmployeeID_Label);
            this.AssistantManagers.Controls.Add(this.AssistantManagerFirstName_Label);
            this.AssistantManagers.Controls.Add(this.AssistantManagerTitle_Label);
            this.AssistantManagers.Location = new System.Drawing.Point(4, 22);
            this.AssistantManagers.Name = "AssistantManagers";
            this.AssistantManagers.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.AssistantManagers.Size = new System.Drawing.Size(1255, 654);
            this.AssistantManagers.TabIndex = 2;
            this.AssistantManagers.Text = "Store Managers";
            this.AssistantManagers.UseVisualStyleBackColor = true;
            // 
            // StoresComboBox
            // 
            this.StoresComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoresComboBox.FormattingEnabled = true;
            this.StoresComboBox.Location = new System.Drawing.Point(556, 66);
            this.StoresComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StoresComboBox.Name = "StoresComboBox";
            this.StoresComboBox.Size = new System.Drawing.Size(225, 24);
            this.StoresComboBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(410, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Store:";
            // 
            // AssistantManagerLastName_Label
            // 
            this.AssistantManagerLastName_Label.AutoSize = true;
            this.AssistantManagerLastName_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AssistantManagerLastName_Label.Location = new System.Drawing.Point(410, 117);
            this.AssistantManagerLastName_Label.Name = "AssistantManagerLastName_Label";
            this.AssistantManagerLastName_Label.Size = new System.Drawing.Size(90, 20);
            this.AssistantManagerLastName_Label.TabIndex = 14;
            this.AssistantManagerLastName_Label.Text = "Last Name:";
            // 
            // AssistantManagerLastName_Textbox
            // 
            this.AssistantManagerLastName_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssistantManagerLastName_Textbox.Location = new System.Drawing.Point(556, 116);
            this.AssistantManagerLastName_Textbox.Name = "AssistantManagerLastName_Textbox";
            this.AssistantManagerLastName_Textbox.Size = new System.Drawing.Size(224, 23);
            this.AssistantManagerLastName_Textbox.TabIndex = 6;
            // 
            // AssistantManagerConfirm_Textbox
            // 
            this.AssistantManagerConfirm_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssistantManagerConfirm_Textbox.Location = new System.Drawing.Point(556, 192);
            this.AssistantManagerConfirm_Textbox.Name = "AssistantManagerConfirm_Textbox";
            this.AssistantManagerConfirm_Textbox.Size = new System.Drawing.Size(224, 23);
            this.AssistantManagerConfirm_Textbox.TabIndex = 9;
            // 
            // AssistantManagerPassword_Textbox
            // 
            this.AssistantManagerPassword_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssistantManagerPassword_Textbox.Location = new System.Drawing.Point(556, 168);
            this.AssistantManagerPassword_Textbox.Name = "AssistantManagerPassword_Textbox";
            this.AssistantManagerPassword_Textbox.Size = new System.Drawing.Size(224, 23);
            this.AssistantManagerPassword_Textbox.TabIndex = 8;
            // 
            // EmployeeID_Textbox
            // 
            this.EmployeeID_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeID_Textbox.Location = new System.Drawing.Point(556, 142);
            this.EmployeeID_Textbox.Name = "EmployeeID_Textbox";
            this.EmployeeID_Textbox.Size = new System.Drawing.Size(224, 23);
            this.EmployeeID_Textbox.TabIndex = 7;
            // 
            // AssistantManagerFirstName_Textbox
            // 
            this.AssistantManagerFirstName_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssistantManagerFirstName_Textbox.Location = new System.Drawing.Point(556, 90);
            this.AssistantManagerFirstName_Textbox.Name = "AssistantManagerFirstName_Textbox";
            this.AssistantManagerFirstName_Textbox.Size = new System.Drawing.Size(224, 23);
            this.AssistantManagerFirstName_Textbox.TabIndex = 5;
            // 
            // DeleteAssistantManager_Button
            // 
            this.DeleteAssistantManager_Button.Location = new System.Drawing.Point(37, 605);
            this.DeleteAssistantManager_Button.Name = "DeleteAssistantManager_Button";
            this.DeleteAssistantManager_Button.Size = new System.Drawing.Size(267, 42);
            this.DeleteAssistantManager_Button.TabIndex = 12;
            this.DeleteAssistantManager_Button.Text = "Delete Manager";
            this.DeleteAssistantManager_Button.UseVisualStyleBackColor = true;
            // 
            // Managers_Listbox
            // 
            this.Managers_Listbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Managers_Listbox.FormattingEnabled = true;
            this.Managers_Listbox.ItemHeight = 16;
            this.Managers_Listbox.Location = new System.Drawing.Point(6, 31);
            this.Managers_Listbox.Name = "Managers_Listbox";
            this.Managers_Listbox.Size = new System.Drawing.Size(349, 564);
            this.Managers_Listbox.TabIndex = 11;
            // 
            // AssistantManagersList_Label
            // 
            this.AssistantManagersList_Label.AutoSize = true;
            this.AssistantManagersList_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AssistantManagersList_Label.Location = new System.Drawing.Point(6, 4);
            this.AssistantManagersList_Label.Name = "AssistantManagersList_Label";
            this.AssistantManagersList_Label.Size = new System.Drawing.Size(127, 20);
            this.AssistantManagersList_Label.TabIndex = 13;
            this.AssistantManagersList_Label.Text = "Store Managers:";
            // 
            // AssistantManagerSave_Button
            // 
            this.AssistantManagerSave_Button.Location = new System.Drawing.Point(556, 220);
            this.AssistantManagerSave_Button.Name = "AssistantManagerSave_Button";
            this.AssistantManagerSave_Button.Size = new System.Drawing.Size(223, 30);
            this.AssistantManagerSave_Button.TabIndex = 10;
            this.AssistantManagerSave_Button.Text = "Save Manager Account";
            this.AssistantManagerSave_Button.UseVisualStyleBackColor = true;
            // 
            // AssistantManagersConfirm_Label
            // 
            this.AssistantManagersConfirm_Label.AutoSize = true;
            this.AssistantManagersConfirm_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AssistantManagersConfirm_Label.Location = new System.Drawing.Point(410, 193);
            this.AssistantManagersConfirm_Label.Name = "AssistantManagersConfirm_Label";
            this.AssistantManagersConfirm_Label.Size = new System.Drawing.Size(141, 20);
            this.AssistantManagersConfirm_Label.TabIndex = 4;
            this.AssistantManagersConfirm_Label.Text = "Confirm Password:";
            // 
            // AssistantMangerPassword_Label
            // 
            this.AssistantMangerPassword_Label.AutoSize = true;
            this.AssistantMangerPassword_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AssistantMangerPassword_Label.Location = new System.Drawing.Point(410, 169);
            this.AssistantMangerPassword_Label.Name = "AssistantMangerPassword_Label";
            this.AssistantMangerPassword_Label.Size = new System.Drawing.Size(82, 20);
            this.AssistantMangerPassword_Label.TabIndex = 3;
            this.AssistantMangerPassword_Label.Text = "Password:";
            // 
            // EmployeeID_Label
            // 
            this.EmployeeID_Label.AutoSize = true;
            this.EmployeeID_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.EmployeeID_Label.Location = new System.Drawing.Point(410, 143);
            this.EmployeeID_Label.Name = "EmployeeID_Label";
            this.EmployeeID_Label.Size = new System.Drawing.Size(104, 20);
            this.EmployeeID_Label.TabIndex = 2;
            this.EmployeeID_Label.Text = "Employee ID:";
            // 
            // AssistantManagerFirstName_Label
            // 
            this.AssistantManagerFirstName_Label.AutoSize = true;
            this.AssistantManagerFirstName_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AssistantManagerFirstName_Label.Location = new System.Drawing.Point(410, 90);
            this.AssistantManagerFirstName_Label.Name = "AssistantManagerFirstName_Label";
            this.AssistantManagerFirstName_Label.Size = new System.Drawing.Size(90, 20);
            this.AssistantManagerFirstName_Label.TabIndex = 1;
            this.AssistantManagerFirstName_Label.Text = "First Name:";
            // 
            // AssistantManagerTitle_Label
            // 
            this.AssistantManagerTitle_Label.AutoSize = true;
            this.AssistantManagerTitle_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.AssistantManagerTitle_Label.Location = new System.Drawing.Point(409, 31);
            this.AssistantManagerTitle_Label.Name = "AssistantManagerTitle_Label";
            this.AssistantManagerTitle_Label.Size = new System.Drawing.Size(160, 24);
            this.AssistantManagerTitle_Label.TabIndex = 0;
            this.AssistantManagerTitle_Label.Text = "Manager Account";
            // 
            // LoyaltyAccounts
            // 
            this.LoyaltyAccounts.Controls.Add(this.label1);
            this.LoyaltyAccounts.Controls.Add(this.Loyalty_Stores);
            this.LoyaltyAccounts.Controls.Add(this.AccountsFound_Listbox);
            this.LoyaltyAccounts.Controls.Add(this.label2);
            this.LoyaltyAccounts.Location = new System.Drawing.Point(4, 22);
            this.LoyaltyAccounts.Name = "LoyaltyAccounts";
            this.LoyaltyAccounts.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.LoyaltyAccounts.Size = new System.Drawing.Size(1255, 654);
            this.LoyaltyAccounts.TabIndex = 1;
            this.LoyaltyAccounts.Text = "Loyalty Accounts";
            this.LoyaltyAccounts.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Stores";
            // 
            // Loyalty_Stores
            // 
            this.Loyalty_Stores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Loyalty_Stores.FormattingEnabled = true;
            this.Loyalty_Stores.ItemHeight = 16;
            this.Loyalty_Stores.Location = new System.Drawing.Point(6, 31);
            this.Loyalty_Stores.Name = "Loyalty_Stores";
            this.Loyalty_Stores.Size = new System.Drawing.Size(211, 548);
            this.Loyalty_Stores.TabIndex = 19;
            this.Loyalty_Stores.SelectedIndexChanged += new System.EventHandler(this.Loyalty_Stores_SelectedIndexChanged);
            // 
            // AccountsFound_Listbox
            // 
            this.AccountsFound_Listbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AccountsFound_Listbox.FormattingEnabled = true;
            this.AccountsFound_Listbox.ItemHeight = 16;
            this.AccountsFound_Listbox.Location = new System.Drawing.Point(225, 31);
            this.AccountsFound_Listbox.Name = "AccountsFound_Listbox";
            this.AccountsFound_Listbox.Size = new System.Drawing.Size(544, 548);
            this.AccountsFound_Listbox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(222, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Accounts Found";
            // 
            // Orders
            // 
            this.Orders.Controls.Add(this.label3);
            this.Orders.Controls.Add(this.Orders_Stores);
            this.Orders.Controls.Add(this.RefreshOrders_Button);
            this.Orders.Controls.Add(this.OrdersItems_Label);
            this.Orders.Controls.Add(this.OrderItems_Listbox);
            this.Orders.Controls.Add(this.OrdersList_Label);
            this.Orders.Controls.Add(this.Orders_Listbox);
            this.Orders.Location = new System.Drawing.Point(4, 22);
            this.Orders.Name = "Orders";
            this.Orders.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Orders.Size = new System.Drawing.Size(1255, 654);
            this.Orders.TabIndex = 0;
            this.Orders.Text = "Orders";
            this.Orders.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Stores";
            // 
            // Orders_Stores
            // 
            this.Orders_Stores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Orders_Stores.FormattingEnabled = true;
            this.Orders_Stores.ItemHeight = 16;
            this.Orders_Stores.Location = new System.Drawing.Point(6, 31);
            this.Orders_Stores.Name = "Orders_Stores";
            this.Orders_Stores.Size = new System.Drawing.Size(211, 612);
            this.Orders_Stores.TabIndex = 10;
            this.Orders_Stores.SelectedIndexChanged += new System.EventHandler(this.Orders_Stores_SelectedIndexChanged);
            // 
            // RefreshOrders_Button
            // 
            this.RefreshOrders_Button.Location = new System.Drawing.Point(221, 613);
            this.RefreshOrders_Button.Name = "RefreshOrders_Button";
            this.RefreshOrders_Button.Size = new System.Drawing.Size(201, 33);
            this.RefreshOrders_Button.TabIndex = 8;
            this.RefreshOrders_Button.Text = "Refresh Orders";
            this.RefreshOrders_Button.UseVisualStyleBackColor = true;
            this.RefreshOrders_Button.Click += new System.EventHandler(this.RefreshOrders_Button_Click);
            // 
            // OrdersItems_Label
            // 
            this.OrdersItems_Label.AutoSize = true;
            this.OrdersItems_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.OrdersItems_Label.Location = new System.Drawing.Point(428, 6);
            this.OrdersItems_Label.Name = "OrdersItems_Label";
            this.OrdersItems_Label.Size = new System.Drawing.Size(108, 24);
            this.OrdersItems_Label.TabIndex = 7;
            this.OrdersItems_Label.Text = "Order Items";
            // 
            // OrderItems_Listbox
            // 
            this.OrderItems_Listbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.OrderItems_Listbox.FormattingEnabled = true;
            this.OrderItems_Listbox.ItemHeight = 16;
            this.OrderItems_Listbox.Location = new System.Drawing.Point(428, 31);
            this.OrderItems_Listbox.Name = "OrderItems_Listbox";
            this.OrderItems_Listbox.Size = new System.Drawing.Size(818, 612);
            this.OrderItems_Listbox.TabIndex = 6;
            // 
            // OrdersList_Label
            // 
            this.OrdersList_Label.AutoSize = true;
            this.OrdersList_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrdersList_Label.Location = new System.Drawing.Point(222, 5);
            this.OrdersList_Label.Name = "OrdersList_Label";
            this.OrdersList_Label.Size = new System.Drawing.Size(100, 24);
            this.OrdersList_Label.TabIndex = 5;
            this.OrdersList_Label.Text = "Orders List";
            // 
            // Orders_Listbox
            // 
            this.Orders_Listbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Orders_Listbox.FormattingEnabled = true;
            this.Orders_Listbox.ItemHeight = 16;
            this.Orders_Listbox.Location = new System.Drawing.Point(221, 31);
            this.Orders_Listbox.Name = "Orders_Listbox";
            this.Orders_Listbox.Size = new System.Drawing.Size(203, 564);
            this.Orders_Listbox.TabIndex = 3;
            this.Orders_Listbox.SelectedIndexChanged += new System.EventHandler(this.Orders_ListBox_SelectedIndexChanged);
            // 
            // ManagerKiosk_TabPage
            // 
            this.ManagerKiosk_TabPage.Controls.Add(this.Stores);
            this.ManagerKiosk_TabPage.Controls.Add(this.Orders);
            this.ManagerKiosk_TabPage.Controls.Add(this.LoyaltyAccounts);
            this.ManagerKiosk_TabPage.Controls.Add(this.AssistantManagers);
            this.ManagerKiosk_TabPage.Controls.Add(this.Inventory);
            this.ManagerKiosk_TabPage.Controls.Add(this.Reports);
            this.ManagerKiosk_TabPage.Location = new System.Drawing.Point(2, 2);
            this.ManagerKiosk_TabPage.Name = "ManagerKiosk_TabPage";
            this.ManagerKiosk_TabPage.SelectedIndex = 0;
            this.ManagerKiosk_TabPage.Size = new System.Drawing.Size(1263, 680);
            this.ManagerKiosk_TabPage.TabIndex = 0;
            // 
            // Stores
            // 
            this.Stores.Controls.Add(this.DeleteStore);
            this.Stores.Controls.Add(this.label14);
            this.Stores.Controls.Add(this.Stores_List);
            this.Stores.Controls.Add(this.label8);
            this.Stores.Controls.Add(this.StoreAddress_Text);
            this.Stores.Controls.Add(this.StoreZip_Text);
            this.Stores.Controls.Add(this.StoreState_Text);
            this.Stores.Controls.Add(this.StoreCity_Text);
            this.Stores.Controls.Add(this.StoreName_Text);
            this.Stores.Controls.Add(this.SaveStore);
            this.Stores.Controls.Add(this.label9);
            this.Stores.Controls.Add(this.label10);
            this.Stores.Controls.Add(this.label11);
            this.Stores.Controls.Add(this.label12);
            this.Stores.Controls.Add(this.label13);
            this.Stores.Location = new System.Drawing.Point(4, 22);
            this.Stores.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Stores.Name = "Stores";
            this.Stores.Size = new System.Drawing.Size(1255, 654);
            this.Stores.TabIndex = 5;
            this.Stores.Text = "Stores";
            this.Stores.UseVisualStyleBackColor = true;
            // 
            // DeleteStore
            // 
            this.DeleteStore.Location = new System.Drawing.Point(130, 604);
            this.DeleteStore.Name = "DeleteStore";
            this.DeleteStore.Size = new System.Drawing.Size(267, 42);
            this.DeleteStore.TabIndex = 33;
            this.DeleteStore.Text = "Delete Store";
            this.DeleteStore.UseVisualStyleBackColor = true;
            this.DeleteStore.Click += new System.EventHandler(this.DeleteStore_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 24);
            this.label14.TabIndex = 32;
            this.label14.Text = "Stores";
            // 
            // Stores_List
            // 
            this.Stores_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Stores_List.FormattingEnabled = true;
            this.Stores_List.ItemHeight = 16;
            this.Stores_List.Location = new System.Drawing.Point(6, 31);
            this.Stores_List.Name = "Stores_List";
            this.Stores_List.Size = new System.Drawing.Size(534, 564);
            this.Stores_List.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(544, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Address:";
            // 
            // StoreAddress_Text
            // 
            this.StoreAddress_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoreAddress_Text.Location = new System.Drawing.Point(690, 83);
            this.StoreAddress_Text.Name = "StoreAddress_Text";
            this.StoreAddress_Text.Size = new System.Drawing.Size(224, 23);
            this.StoreAddress_Text.TabIndex = 23;
            // 
            // StoreZip_Text
            // 
            this.StoreZip_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoreZip_Text.Location = new System.Drawing.Point(691, 159);
            this.StoreZip_Text.Name = "StoreZip_Text";
            this.StoreZip_Text.Size = new System.Drawing.Size(224, 23);
            this.StoreZip_Text.TabIndex = 26;
            // 
            // StoreState_Text
            // 
            this.StoreState_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoreState_Text.Location = new System.Drawing.Point(690, 135);
            this.StoreState_Text.Name = "StoreState_Text";
            this.StoreState_Text.Size = new System.Drawing.Size(224, 23);
            this.StoreState_Text.TabIndex = 25;
            // 
            // StoreCity_Text
            // 
            this.StoreCity_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoreCity_Text.Location = new System.Drawing.Point(690, 109);
            this.StoreCity_Text.Name = "StoreCity_Text";
            this.StoreCity_Text.Size = new System.Drawing.Size(224, 23);
            this.StoreCity_Text.TabIndex = 24;
            // 
            // StoreName_Text
            // 
            this.StoreName_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoreName_Text.Location = new System.Drawing.Point(690, 56);
            this.StoreName_Text.Name = "StoreName_Text";
            this.StoreName_Text.Size = new System.Drawing.Size(224, 23);
            this.StoreName_Text.TabIndex = 22;
            // 
            // SaveStore
            // 
            this.SaveStore.Location = new System.Drawing.Point(691, 187);
            this.SaveStore.Name = "SaveStore";
            this.SaveStore.Size = new System.Drawing.Size(223, 30);
            this.SaveStore.TabIndex = 27;
            this.SaveStore.Text = "Save Store";
            this.SaveStore.UseVisualStyleBackColor = true;
            this.SaveStore.Click += new System.EventHandler(this.SaveStore_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(544, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Zip Code:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(544, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "State";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.Location = new System.Drawing.Point(544, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "City:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label12.Location = new System.Drawing.Point(544, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 20);
            this.label12.TabIndex = 18;
            this.label12.Text = "Store Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label13.Location = new System.Drawing.Point(544, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 24);
            this.label13.TabIndex = 17;
            this.label13.Text = "Add New Store";
            // 
            // CorporateUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.ManagerKiosk_TabPage);
            this.Name = "CorporateUI";
            this.Text = "NSA Corporate";
            this.Reports.ResumeLayout(false);
            this.Reports.PerformLayout();
            this.Inventory.ResumeLayout(false);
            this.Inventory.PerformLayout();
            this.AssistantManagers.ResumeLayout(false);
            this.AssistantManagers.PerformLayout();
            this.LoyaltyAccounts.ResumeLayout(false);
            this.LoyaltyAccounts.PerformLayout();
            this.Orders.ResumeLayout(false);
            this.Orders.PerformLayout();
            this.ManagerKiosk_TabPage.ResumeLayout(false);
            this.Stores.ResumeLayout(false);
            this.Stores.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Reports;
        private System.Windows.Forms.Button PrintReport_Button;
        private System.Windows.Forms.ListBox Reports_Listbox;
        private System.Windows.Forms.Label ReportsTitle_Label;
        private System.Windows.Forms.TabPage Inventory;
        private System.Windows.Forms.ListBox Inventory_Listbox;
        private System.Windows.Forms.Label InventoryTitle_Label;
        private System.Windows.Forms.TabPage AssistantManagers;
        private System.Windows.Forms.Label AssistantManagerLastName_Label;
        private System.Windows.Forms.TextBox AssistantManagerLastName_Textbox;
        private System.Windows.Forms.TextBox AssistantManagerConfirm_Textbox;
        private System.Windows.Forms.TextBox AssistantManagerPassword_Textbox;
        private System.Windows.Forms.TextBox EmployeeID_Textbox;
        private System.Windows.Forms.TextBox AssistantManagerFirstName_Textbox;
        private System.Windows.Forms.Button DeleteAssistantManager_Button;
        private System.Windows.Forms.ListBox Managers_Listbox;
        private System.Windows.Forms.Label AssistantManagersList_Label;
        private System.Windows.Forms.Button AssistantManagerSave_Button;
        private System.Windows.Forms.Label AssistantManagersConfirm_Label;
        private System.Windows.Forms.Label AssistantMangerPassword_Label;
        private System.Windows.Forms.Label EmployeeID_Label;
        private System.Windows.Forms.Label AssistantManagerFirstName_Label;
        private System.Windows.Forms.Label AssistantManagerTitle_Label;
        private System.Windows.Forms.TabPage LoyaltyAccounts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox Loyalty_Stores;
        private System.Windows.Forms.ListBox AccountsFound_Listbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage Orders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox Orders_Stores;
        private System.Windows.Forms.Button RefreshOrders_Button;
        private System.Windows.Forms.Label OrdersItems_Label;
        private System.Windows.Forms.ListBox OrderItems_Listbox;
        private System.Windows.Forms.Label OrdersList_Label;
        private System.Windows.Forms.ListBox Orders_Listbox;
        private System.Windows.Forms.TabControl ManagerKiosk_TabPage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox Reports_Stores;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox Inventory_Stores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.WebBrowser webReports;
        private System.Windows.Forms.ComboBox StoresComboBox;
        private System.Windows.Forms.TabPage Stores;
        private System.Windows.Forms.Button DeleteStore;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox Stores_List;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox StoreAddress_Text;
        private System.Windows.Forms.TextBox StoreZip_Text;
        private System.Windows.Forms.TextBox StoreState_Text;
        private System.Windows.Forms.TextBox StoreCity_Text;
        private System.Windows.Forms.TextBox StoreName_Text;
        private System.Windows.Forms.Button SaveStore;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;

    }
}


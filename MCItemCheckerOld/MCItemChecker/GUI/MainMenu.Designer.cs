namespace MCItemChecker
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageModpacksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageItemTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvitems = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.tbsearchid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbsearchname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbsearchmodpack = new System.Windows.Forms.ComboBox();
            this.cbsearchtype = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bclearsearch = new System.Windows.Forms.Button();
            this.bsearchitem = new System.Windows.Forms.Button();
            this.TabItemInfo = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.litemtype = new System.Windows.Forms.Label();
            this.lmodpack = new System.Windows.Forms.Label();
            this.litemid = new System.Windows.Forms.Label();
            this.litemname = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvsubitems = new System.Windows.Forms.ListView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.TabCalculate = new System.Windows.Forms.TabPage();
            this.cbBase = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.lcalcitemname = new System.Windows.Forms.Label();
            this.bcalculateclear = new System.Windows.Forms.Button();
            this.lvcalculateitems = new System.Windows.Forms.ListView();
            this.bfilter = new System.Windows.Forms.Button();
            this.cbfiltertype = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            this.TabItemInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.TabCalculate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(774, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.itemsToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(774, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit To Main Menu";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newItemToolStripMenuItem,
            this.manageModpacksToolStripMenuItem,
            this.manageItemTypesToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteItemToolStripMenuItem});
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.itemsToolStripMenuItem.Text = "Items";
            // 
            // newItemToolStripMenuItem
            // 
            this.newItemToolStripMenuItem.Name = "newItemToolStripMenuItem";
            this.newItemToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newItemToolStripMenuItem.Text = "Manage Items";
            this.newItemToolStripMenuItem.Click += new System.EventHandler(this.ManageItemsToolStripMenuItem_Click);
            // 
            // manageModpacksToolStripMenuItem
            // 
            this.manageModpacksToolStripMenuItem.Name = "manageModpacksToolStripMenuItem";
            this.manageModpacksToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.manageModpacksToolStripMenuItem.Text = "Manage Modpacks";
            this.manageModpacksToolStripMenuItem.Click += new System.EventHandler(this.ManageModPackToolStripMenuItem_Click);
            // 
            // manageItemTypesToolStripMenuItem
            // 
            this.manageItemTypesToolStripMenuItem.Name = "manageItemTypesToolStripMenuItem";
            this.manageItemTypesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.manageItemTypesToolStripMenuItem.Text = "Manage Item Types";
            this.manageItemTypesToolStripMenuItem.Click += new System.EventHandler(this.ManageItemTypeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // deleteItemToolStripMenuItem
            // 
            this.deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            this.deleteItemToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteItemToolStripMenuItem.Text = "Delete Item";
            this.deleteItemToolStripMenuItem.Click += new System.EventHandler(this.DeleteItem);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToTextToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // exportToTextToolStripMenuItem
            // 
            this.exportToTextToolStripMenuItem.Name = "exportToTextToolStripMenuItem";
            this.exportToTextToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToTextToolStripMenuItem.Text = "Export To Text";
            this.exportToTextToolStripMenuItem.Click += new System.EventHandler(this.ExportToTextToolStripMenuItem_Click);
            // 
            // lvitems
            // 
            this.lvitems.FullRowSelect = true;
            this.lvitems.HideSelection = false;
            this.lvitems.Location = new System.Drawing.Point(12, 27);
            this.lvitems.Name = "lvitems";
            this.lvitems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvitems.Size = new System.Drawing.Size(369, 266);
            this.lvitems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvitems.TabIndex = 9;
            this.lvitems.UseCompatibleStateImageBehavior = false;
            this.lvitems.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvItems_ColumnClick);
            this.lvitems.SelectedIndexChanged += new System.EventHandler(this.LvCalculateItems_Click);
            this.lvitems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvItems_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Item Name:";
            // 
            // tbsearchid
            // 
            this.tbsearchid.Location = new System.Drawing.Point(80, 325);
            this.tbsearchid.Name = "tbsearchid";
            this.tbsearchid.Size = new System.Drawing.Size(28, 20);
            this.tbsearchid.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Item ID:";
            // 
            // tbsearchname
            // 
            this.tbsearchname.Location = new System.Drawing.Point(80, 299);
            this.tbsearchname.Name = "tbsearchname";
            this.tbsearchname.Size = new System.Drawing.Size(180, 20);
            this.tbsearchname.TabIndex = 54;
            this.tbsearchname.TextChanged += new System.EventHandler(this.TbSearchName_TextChanged);
            this.tbsearchname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbSearchNname_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Type:";
            // 
            // cbsearchmodpack
            // 
            this.cbsearchmodpack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsearchmodpack.FormattingEnabled = true;
            this.cbsearchmodpack.Location = new System.Drawing.Point(80, 351);
            this.cbsearchmodpack.Name = "cbsearchmodpack";
            this.cbsearchmodpack.Size = new System.Drawing.Size(180, 21);
            this.cbsearchmodpack.Sorted = true;
            this.cbsearchmodpack.TabIndex = 60;
            // 
            // cbsearchtype
            // 
            this.cbsearchtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsearchtype.FormattingEnabled = true;
            this.cbsearchtype.Location = new System.Drawing.Point(154, 324);
            this.cbsearchtype.Name = "cbsearchtype";
            this.cbsearchtype.Size = new System.Drawing.Size(106, 21);
            this.cbsearchtype.TabIndex = 58;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 354);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "ModPack:";
            // 
            // bclearsearch
            // 
            this.bclearsearch.Location = new System.Drawing.Point(289, 344);
            this.bclearsearch.Name = "bclearsearch";
            this.bclearsearch.Size = new System.Drawing.Size(75, 23);
            this.bclearsearch.TabIndex = 80;
            this.bclearsearch.Text = "Clear";
            this.bclearsearch.UseVisualStyleBackColor = true;
            this.bclearsearch.Click += new System.EventHandler(this.BClearSearch_Click);
            // 
            // bsearchitem
            // 
            this.bsearchitem.Location = new System.Drawing.Point(289, 309);
            this.bsearchitem.Name = "bsearchitem";
            this.bsearchitem.Size = new System.Drawing.Size(75, 23);
            this.bsearchitem.TabIndex = 79;
            this.bsearchitem.Text = "Search Item";
            this.bsearchitem.UseVisualStyleBackColor = true;
            this.bsearchitem.Click += new System.EventHandler(this.BFindItem_Click);
            // 
            // TabItemInfo
            // 
            this.TabItemInfo.Controls.Add(this.panel1);
            this.TabItemInfo.Controls.Add(this.lvsubitems);
            this.TabItemInfo.Location = new System.Drawing.Point(4, 22);
            this.TabItemInfo.Name = "TabItemInfo";
            this.TabItemInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TabItemInfo.Size = new System.Drawing.Size(367, 332);
            this.TabItemInfo.TabIndex = 0;
            this.TabItemInfo.Text = "Item Info";
            this.TabItemInfo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.litemtype);
            this.panel1.Controls.Add(this.lmodpack);
            this.panel1.Controls.Add(this.litemid);
            this.panel1.Controls.Add(this.litemname);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(20, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 89);
            this.panel1.TabIndex = 12;
            // 
            // litemtype
            // 
            this.litemtype.AutoSize = true;
            this.litemtype.Location = new System.Drawing.Point(80, 67);
            this.litemtype.Name = "litemtype";
            this.litemtype.Size = new System.Drawing.Size(41, 13);
            this.litemtype.TabIndex = 10;
            this.litemtype.Text = "label11";
            // 
            // lmodpack
            // 
            this.lmodpack.AutoSize = true;
            this.lmodpack.Location = new System.Drawing.Point(80, 47);
            this.lmodpack.Name = "lmodpack";
            this.lmodpack.Size = new System.Drawing.Size(41, 13);
            this.lmodpack.TabIndex = 9;
            this.lmodpack.Text = "label11";
            // 
            // litemid
            // 
            this.litemid.AutoSize = true;
            this.litemid.Location = new System.Drawing.Point(80, 27);
            this.litemid.Name = "litemid";
            this.litemid.Size = new System.Drawing.Size(41, 13);
            this.litemid.TabIndex = 8;
            this.litemid.Text = "label11";
            // 
            // litemname
            // 
            this.litemname.AutoSize = true;
            this.litemname.Location = new System.Drawing.Point(80, 7);
            this.litemname.Name = "litemname";
            this.litemname.Size = new System.Drawing.Size(41, 13);
            this.litemname.TabIndex = 7;
            this.litemname.Text = "label11";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Item Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Item Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ModPack:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Item ID:";
            // 
            // lvsubitems
            // 
            this.lvsubitems.FullRowSelect = true;
            this.lvsubitems.HideSelection = false;
            this.lvsubitems.Location = new System.Drawing.Point(20, 131);
            this.lvsubitems.Name = "lvsubitems";
            this.lvsubitems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvsubitems.Size = new System.Drawing.Size(327, 187);
            this.lvsubitems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvsubitems.TabIndex = 11;
            this.lvsubitems.UseCompatibleStateImageBehavior = false;
            this.lvsubitems.DoubleClick += new System.EventHandler(this.LvSubItems_DoubleClick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.TabItemInfo);
            this.tabControl.Controls.Add(this.TabCalculate);
            this.tabControl.Location = new System.Drawing.Point(387, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(375, 358);
            this.tabControl.TabIndex = 7;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // TabCalculate
            // 
            this.TabCalculate.Controls.Add(this.cbBase);
            this.TabCalculate.Controls.Add(this.label9);
            this.TabCalculate.Controls.Add(this.numAmount);
            this.TabCalculate.Controls.Add(this.lcalcitemname);
            this.TabCalculate.Controls.Add(this.bcalculateclear);
            this.TabCalculate.Controls.Add(this.lvcalculateitems);
            this.TabCalculate.Controls.Add(this.bfilter);
            this.TabCalculate.Controls.Add(this.cbfiltertype);
            this.TabCalculate.Controls.Add(this.label11);
            this.TabCalculate.Controls.Add(this.label12);
            this.TabCalculate.Location = new System.Drawing.Point(4, 22);
            this.TabCalculate.Name = "TabCalculate";
            this.TabCalculate.Padding = new System.Windows.Forms.Padding(3);
            this.TabCalculate.Size = new System.Drawing.Size(367, 332);
            this.TabCalculate.TabIndex = 1;
            this.TabCalculate.Text = "Calculate";
            this.TabCalculate.UseVisualStyleBackColor = true;
            // 
            // cbBase
            // 
            this.cbBase.AutoSize = true;
            this.cbBase.Location = new System.Drawing.Point(212, 264);
            this.cbBase.Name = "cbBase";
            this.cbBase.Size = new System.Drawing.Size(78, 17);
            this.cbBase.TabIndex = 124;
            this.cbBase.Text = "Base Items";
            this.cbBase.UseVisualStyleBackColor = true;
            this.cbBase.CheckStateChanged += new System.EventHandler(this.CbBase_CheckStateChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(104, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 123;
            this.label9.Text = "Amount:";
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(153, 261);
            this.numAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(53, 20);
            this.numAmount.TabIndex = 122;
            this.numAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.ValueChanged += new System.EventHandler(this.NumAmount_ValueChanged);
            // 
            // lcalcitemname
            // 
            this.lcalcitemname.AutoSize = true;
            this.lcalcitemname.Location = new System.Drawing.Point(125, 13);
            this.lcalcitemname.Name = "lcalcitemname";
            this.lcalcitemname.Size = new System.Drawing.Size(0, 13);
            this.lcalcitemname.TabIndex = 121;
            // 
            // bcalculateclear
            // 
            this.bcalculateclear.Location = new System.Drawing.Point(184, 296);
            this.bcalculateclear.Name = "bcalculateclear";
            this.bcalculateclear.Size = new System.Drawing.Size(75, 23);
            this.bcalculateclear.TabIndex = 117;
            this.bcalculateclear.Text = "Clear";
            this.bcalculateclear.UseVisualStyleBackColor = true;
            this.bcalculateclear.Click += new System.EventHandler(this.BCalculateClear_Click);
            // 
            // lvcalculateitems
            // 
            this.lvcalculateitems.FullRowSelect = true;
            this.lvcalculateitems.HideSelection = false;
            this.lvcalculateitems.Location = new System.Drawing.Point(23, 36);
            this.lvcalculateitems.Name = "lvcalculateitems";
            this.lvcalculateitems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvcalculateitems.Size = new System.Drawing.Size(321, 189);
            this.lvcalculateitems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvcalculateitems.TabIndex = 120;
            this.lvcalculateitems.UseCompatibleStateImageBehavior = false;
            // 
            // bfilter
            // 
            this.bfilter.Location = new System.Drawing.Point(94, 296);
            this.bfilter.Name = "bfilter";
            this.bfilter.Size = new System.Drawing.Size(75, 23);
            this.bfilter.TabIndex = 116;
            this.bfilter.Text = "Filter";
            this.bfilter.UseVisualStyleBackColor = true;
            this.bfilter.Click += new System.EventHandler(this.BFilter_Click);
            // 
            // cbfiltertype
            // 
            this.cbfiltertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbfiltertype.FormattingEnabled = true;
            this.cbfiltertype.Location = new System.Drawing.Point(153, 234);
            this.cbfiltertype.Name = "cbfiltertype";
            this.cbfiltertype.Size = new System.Drawing.Size(106, 21);
            this.cbfiltertype.TabIndex = 119;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(91, 238);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 118;
            this.label11.Text = "Filter Type:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(59, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 113;
            this.label12.Text = "Item Name:";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 394);
            this.Controls.Add(this.bclearsearch);
            this.Controls.Add(this.bsearchitem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbsearchid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbsearchname);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbsearchmodpack);
            this.Controls.Add(this.cbsearchtype);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lvitems);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(790, 433);
            this.MinimumSize = new System.Drawing.Size(790, 433);
            this.Name = "MainMenu";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.TabItemInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.TabCalculate.ResumeLayout(false);
            this.TabCalculate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListView lvitems;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newItemToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbsearchid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbsearchname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbsearchmodpack;
        private System.Windows.Forms.ComboBox cbsearchtype;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bclearsearch;
        private System.Windows.Forms.Button bsearchitem;
        private System.Windows.Forms.ToolStripMenuItem deleteItemToolStripMenuItem;
        private System.Windows.Forms.TabPage TabItemInfo;
        private System.Windows.Forms.ListView lvsubitems;
        private System.Windows.Forms.Label litemtype;
        private System.Windows.Forms.Label lmodpack;
        private System.Windows.Forms.Label litemid;
        private System.Windows.Forms.Label litemname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage TabCalculate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label lcalcitemname;
        private System.Windows.Forms.Button bcalculateclear;
        private System.Windows.Forms.ListView lvcalculateitems;
        private System.Windows.Forms.Button bfilter;
        private System.Windows.Forms.ComboBox cbfiltertype;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem manageModpacksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageItemTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToTextToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbBase;
    }
}


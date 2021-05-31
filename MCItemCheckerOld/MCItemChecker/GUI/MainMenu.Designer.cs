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
            this.lvItems = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSearchName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSearchModpack = new System.Windows.Forms.ComboBox();
            this.cbSearchType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bClearSearch = new System.Windows.Forms.Button();
            this.bSearchItem = new System.Windows.Forms.Button();
            this.TabItemInfo = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.litemtype = new System.Windows.Forms.Label();
            this.lmodpack = new System.Windows.Forms.Label();
            this.litemname = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageModpacksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageItemTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.TabItemInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.TabCalculate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvItems
            // 
            this.lvItems.FullRowSelect = true;
            this.lvItems.HideSelection = false;
            this.lvItems.Location = new System.Drawing.Point(12, 27);
            this.lvItems.Name = "lvItems";
            this.lvItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvItems.Size = new System.Drawing.Size(536, 402);
            this.lvItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvItems.TabIndex = 9;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvItems_ColumnClick);
            this.lvItems.SelectedIndexChanged += new System.EventHandler(this.LvCalculateItems_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 441);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Item Name:";
            // 
            // tbSearchName
            // 
            this.tbSearchName.Location = new System.Drawing.Point(82, 438);
            this.tbSearchName.Name = "tbSearchName";
            this.tbSearchName.Size = new System.Drawing.Size(296, 20);
            this.tbSearchName.TabIndex = 54;
            this.tbSearchName.TextChanged += new System.EventHandler(this.TbSearchName_TextChanged);
            this.tbSearchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbSearchNname_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 467);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Type:";
            // 
            // cbSearchModpack
            // 
            this.cbSearchModpack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchModpack.FormattingEnabled = true;
            this.cbSearchModpack.Location = new System.Drawing.Point(82, 491);
            this.cbSearchModpack.Name = "cbSearchModpack";
            this.cbSearchModpack.Size = new System.Drawing.Size(296, 21);
            this.cbSearchModpack.Sorted = true;
            this.cbSearchModpack.TabIndex = 60;
            // 
            // cbSearchType
            // 
            this.cbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchType.FormattingEnabled = true;
            this.cbSearchType.Location = new System.Drawing.Point(82, 464);
            this.cbSearchType.Name = "cbSearchType";
            this.cbSearchType.Size = new System.Drawing.Size(296, 21);
            this.cbSearchType.TabIndex = 58;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 494);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "ModPack:";
            // 
            // bClearSearch
            // 
            this.bClearSearch.Location = new System.Drawing.Point(241, 528);
            this.bClearSearch.Name = "bClearSearch";
            this.bClearSearch.Size = new System.Drawing.Size(75, 23);
            this.bClearSearch.TabIndex = 80;
            this.bClearSearch.Text = "Clear";
            this.bClearSearch.UseVisualStyleBackColor = true;
            this.bClearSearch.Click += new System.EventHandler(this.BClearSearch_Click);
            // 
            // bSearchItem
            // 
            this.bSearchItem.Location = new System.Drawing.Point(64, 528);
            this.bSearchItem.Name = "bSearchItem";
            this.bSearchItem.Size = new System.Drawing.Size(75, 23);
            this.bSearchItem.TabIndex = 79;
            this.bSearchItem.Text = "Search Item";
            this.bSearchItem.UseVisualStyleBackColor = true;
            this.bSearchItem.Click += new System.EventHandler(this.BFindItem_Click);
            // 
            // TabItemInfo
            // 
            this.TabItemInfo.Controls.Add(this.panel1);
            this.TabItemInfo.Controls.Add(this.lvsubitems);
            this.TabItemInfo.Location = new System.Drawing.Point(4, 22);
            this.TabItemInfo.Name = "TabItemInfo";
            this.TabItemInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TabItemInfo.Size = new System.Drawing.Size(503, 495);
            this.TabItemInfo.TabIndex = 0;
            this.TabItemInfo.Text = "Item Info";
            this.TabItemInfo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.litemtype);
            this.panel1.Controls.Add(this.lmodpack);
            this.panel1.Controls.Add(this.litemname);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(20, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 79);
            this.panel1.TabIndex = 12;
            // 
            // litemtype
            // 
            this.litemtype.AutoSize = true;
            this.litemtype.Location = new System.Drawing.Point(80, 51);
            this.litemtype.Name = "litemtype";
            this.litemtype.Size = new System.Drawing.Size(61, 13);
            this.litemtype.TabIndex = 10;
            this.litemtype.Text = "<item type>";
            // 
            // lmodpack
            // 
            this.lmodpack.AutoSize = true;
            this.lmodpack.Location = new System.Drawing.Point(80, 29);
            this.lmodpack.Name = "lmodpack";
            this.lmodpack.Size = new System.Drawing.Size(63, 13);
            this.lmodpack.TabIndex = 9;
            this.lmodpack.Text = "<modpack>";
            // 
            // litemname
            // 
            this.litemname.AutoSize = true;
            this.litemname.Location = new System.Drawing.Point(80, 7);
            this.litemname.Name = "litemname";
            this.litemname.Size = new System.Drawing.Size(64, 13);
            this.litemname.TabIndex = 7;
            this.litemname.Text = "<itemname>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 51);
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
            this.label3.Location = new System.Drawing.Point(12, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ModPack:";
            // 
            // lvsubitems
            // 
            this.lvsubitems.FullRowSelect = true;
            this.lvsubitems.HideSelection = false;
            this.lvsubitems.Location = new System.Drawing.Point(20, 100);
            this.lvsubitems.Name = "lvsubitems";
            this.lvsubitems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvsubitems.Size = new System.Drawing.Size(461, 378);
            this.lvsubitems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvsubitems.TabIndex = 11;
            this.lvsubitems.UseCompatibleStateImageBehavior = false;
            this.lvsubitems.DoubleClick += new System.EventHandler(this.LvSubItems_DoubleClick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.TabItemInfo);
            this.tabControl.Controls.Add(this.TabCalculate);
            this.tabControl.Location = new System.Drawing.Point(561, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(511, 521);
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
            this.TabCalculate.Size = new System.Drawing.Size(503, 495);
            this.TabCalculate.TabIndex = 1;
            this.TabCalculate.Text = "Calculate";
            this.TabCalculate.UseVisualStyleBackColor = true;
            // 
            // cbBase
            // 
            this.cbBase.AutoSize = true;
            this.cbBase.Location = new System.Drawing.Point(319, 419);
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
            this.label9.Location = new System.Drawing.Point(91, 418);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 123;
            this.label9.Text = "Amount:";
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(140, 416);
            this.numAmount.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(117, 20);
            this.numAmount.TabIndex = 122;
            this.numAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumAmount_KeyPressed);
            // 
            // lcalcitemname
            // 
            this.lcalcitemname.AutoSize = true;
            this.lcalcitemname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcalcitemname.Location = new System.Drawing.Point(109, 13);
            this.lcalcitemname.Name = "lcalcitemname";
            this.lcalcitemname.Size = new System.Drawing.Size(74, 13);
            this.lcalcitemname.TabIndex = 121;
            this.lcalcitemname.Text = "<itemname>";
            // 
            // bcalculateclear
            // 
            this.bcalculateclear.Location = new System.Drawing.Point(350, 454);
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
            this.lvcalculateitems.Size = new System.Drawing.Size(458, 344);
            this.lvcalculateitems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvcalculateitems.TabIndex = 120;
            this.lvcalculateitems.UseCompatibleStateImageBehavior = false;
            // 
            // bfilter
            // 
            this.bfilter.Location = new System.Drawing.Point(116, 454);
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
            this.cbfiltertype.Location = new System.Drawing.Point(140, 389);
            this.cbfiltertype.Name = "cbfiltertype";
            this.cbfiltertype.Size = new System.Drawing.Size(271, 21);
            this.cbfiltertype.TabIndex = 119;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(78, 393);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 118;
            this.label11.Text = "Filter Type:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 13);
            this.label12.TabIndex = 113;
            this.label12.Text = "Viewing Item:";
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
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.exitToolStripMenuItem.Text = "Exit To Main Menu";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newItemToolStripMenuItem,
            this.manageModpacksToolStripMenuItem,
            this.manageItemTypesToolStripMenuItem});
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.itemsToolStripMenuItem.Text = "Item Database";
            // 
            // newItemToolStripMenuItem
            // 
            this.newItemToolStripMenuItem.Name = "newItemToolStripMenuItem";
            this.newItemToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.newItemToolStripMenuItem.Text = "Manage Items";
            this.newItemToolStripMenuItem.Click += new System.EventHandler(this.ManageItemsToolStripMenuItem_Click);
            // 
            // manageModpacksToolStripMenuItem
            // 
            this.manageModpacksToolStripMenuItem.Name = "manageModpacksToolStripMenuItem";
            this.manageModpacksToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.manageModpacksToolStripMenuItem.Text = "Manage Modpacks";
            this.manageModpacksToolStripMenuItem.Click += new System.EventHandler(this.ManageModPackToolStripMenuItem_Click);
            // 
            // manageItemTypesToolStripMenuItem
            // 
            this.manageItemTypesToolStripMenuItem.Name = "manageItemTypesToolStripMenuItem";
            this.manageItemTypesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.manageItemTypesToolStripMenuItem.Text = "Manage Item Types";
            this.manageItemTypesToolStripMenuItem.Click += new System.EventHandler(this.ManageItemTypeToolStripMenuItem_Click);
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
            this.exportToTextToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exportToTextToolStripMenuItem.Text = "Export To Text";
            this.exportToTextToolStripMenuItem.Click += new System.EventHandler(this.ExportToTextToolStripMenuItem_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.itemsToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.bClearSearch);
            this.Controls.Add(this.bSearchItem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSearchName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbSearchModpack);
            this.Controls.Add(this.cbSearchType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lvItems);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1100, 600);
            this.MinimumSize = new System.Drawing.Size(1100, 600);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.TabItemInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.TabCalculate.ResumeLayout(false);
            this.TabCalculate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSearchName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSearchModpack;
        private System.Windows.Forms.ComboBox cbSearchType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bClearSearch;
        private System.Windows.Forms.Button bSearchItem;
        private System.Windows.Forms.TabPage TabItemInfo;
        private System.Windows.Forms.ListView lvsubitems;
        private System.Windows.Forms.Label litemtype;
        private System.Windows.Forms.Label lmodpack;
        private System.Windows.Forms.Label litemname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbBase;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageModpacksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageItemTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToTextToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
    }
}


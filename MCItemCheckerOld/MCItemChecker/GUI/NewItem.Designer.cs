namespace MCItemChecker
{
    partial class NewItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewItem));
            this.TabNewItem = new System.Windows.Forms.TabPage();
            this.bImportmodify = new System.Windows.Forms.Button();
            this.tbAddAmount = new System.Windows.Forms.TextBox();
            this.tbRemoveAmount = new System.Windows.Forms.TextBox();
            this.bRemoveItem = new System.Windows.Forms.Button();
            this.bAddItem = new System.Windows.Forms.Button();
            this.lvSubItems = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNewItemName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbNewItemModpack = new System.Windows.Forms.ComboBox();
            this.cbNewItemType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lmoditem = new System.Windows.Forms.Label();
            this.lmoditemname = new System.Windows.Forms.Label();
            this.bDiscard = new System.Windows.Forms.Button();
            this.bCreateItem = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabModPack = new System.Windows.Forms.TabPage();
            this.bmodpackdelete = new System.Windows.Forms.Button();
            this.lbmodpacks = new System.Windows.Forms.ListBox();
            this.bmodpackadd = new System.Windows.Forms.Button();
            this.tbmodpackname = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TabType = new System.Windows.Forms.TabPage();
            this.bdeletetype = new System.Windows.Forms.Button();
            this.lbtype = new System.Windows.Forms.ListBox();
            this.baddtype = new System.Windows.Forms.Button();
            this.tbtype = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bclearsearch = new System.Windows.Forms.Button();
            this.bsearchitem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbsearchname = new MCItemChecker.GUI.Controls.DelayedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbsearchmodpack = new System.Windows.Forms.ComboBox();
            this.cbsearchtype = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lvitems = new System.Windows.Forms.ListView();
            this.TabNewItem.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabModPack.SuspendLayout();
            this.TabType.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabNewItem
            // 
            this.TabNewItem.BackColor = System.Drawing.Color.White;
            this.TabNewItem.Controls.Add(this.bImportmodify);
            this.TabNewItem.Controls.Add(this.tbAddAmount);
            this.TabNewItem.Controls.Add(this.tbRemoveAmount);
            this.TabNewItem.Controls.Add(this.bRemoveItem);
            this.TabNewItem.Controls.Add(this.bAddItem);
            this.TabNewItem.Controls.Add(this.lvSubItems);
            this.TabNewItem.Controls.Add(this.panel2);
            this.TabNewItem.Location = new System.Drawing.Point(4, 22);
            this.TabNewItem.Name = "TabNewItem";
            this.TabNewItem.Padding = new System.Windows.Forms.Padding(3);
            this.TabNewItem.Size = new System.Drawing.Size(610, 491);
            this.TabNewItem.TabIndex = 0;
            this.TabNewItem.Tag = "TabNewItem";
            this.TabNewItem.Text = "New Item";
            // 
            // bImportmodify
            // 
            this.bImportmodify.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bImportmodify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bImportmodify.Location = new System.Drawing.Point(19, 285);
            this.bImportmodify.Name = "bImportmodify";
            this.bImportmodify.Size = new System.Drawing.Size(75, 23);
            this.bImportmodify.TabIndex = 107;
            this.bImportmodify.Text = "Modify >>";
            this.bImportmodify.UseVisualStyleBackColor = false;
            this.bImportmodify.Click += new System.EventHandler(this.BImportModify_Click);
            // 
            // tbAddAmount
            // 
            this.tbAddAmount.Location = new System.Drawing.Point(19, 48);
            this.tbAddAmount.Name = "tbAddAmount";
            this.tbAddAmount.Size = new System.Drawing.Size(75, 20);
            this.tbAddAmount.TabIndex = 106;
            this.tbAddAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbAddAmount_KeyPress);
            // 
            // tbRemoveAmount
            // 
            this.tbRemoveAmount.Location = new System.Drawing.Point(19, 188);
            this.tbRemoveAmount.Name = "tbRemoveAmount";
            this.tbRemoveAmount.Size = new System.Drawing.Size(75, 20);
            this.tbRemoveAmount.TabIndex = 105;
            // 
            // bRemoveItem
            // 
            this.bRemoveItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRemoveItem.Location = new System.Drawing.Point(19, 159);
            this.bRemoveItem.Name = "bRemoveItem";
            this.bRemoveItem.Size = new System.Drawing.Size(75, 23);
            this.bRemoveItem.TabIndex = 104;
            this.bRemoveItem.Text = "<< Remove";
            this.bRemoveItem.UseVisualStyleBackColor = false;
            this.bRemoveItem.Click += new System.EventHandler(this.BRemoveSubItem_Click);
            // 
            // bAddItem
            // 
            this.bAddItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAddItem.Location = new System.Drawing.Point(19, 74);
            this.bAddItem.Name = "bAddItem";
            this.bAddItem.Size = new System.Drawing.Size(75, 23);
            this.bAddItem.TabIndex = 103;
            this.bAddItem.Text = "Add >>";
            this.bAddItem.UseVisualStyleBackColor = false;
            this.bAddItem.Click += new System.EventHandler(this.BAddSubItem_Click);
            // 
            // lvSubItems
            // 
            this.lvSubItems.FullRowSelect = true;
            this.lvSubItems.GridLines = true;
            this.lvSubItems.HideSelection = false;
            this.lvSubItems.Location = new System.Drawing.Point(132, 122);
            this.lvSubItems.Name = "lvSubItems";
            this.lvSubItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvSubItems.Size = new System.Drawing.Size(456, 283);
            this.lvSubItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvSubItems.TabIndex = 101;
            this.lvSubItems.UseCompatibleStateImageBehavior = false;
            this.lvSubItems.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvItems_ColumnClick);
            this.lvSubItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvSubItems_DeletePress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbNewItemName);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbNewItemModpack);
            this.panel2.Controls.Add(this.cbNewItemType);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lmoditem);
            this.panel2.Controls.Add(this.lmoditemname);
            this.panel2.Controls.Add(this.bDiscard);
            this.panel2.Controls.Add(this.bCreateItem);
            this.panel2.Location = new System.Drawing.Point(115, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(489, 479);
            this.panel2.TabIndex = 102;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(264, 13);
            this.label5.TabIndex = 126;
            this.label5.Text = "The following items are required to craft the given item:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 121;
            this.label4.Text = "Item Name:";
            // 
            // tbNewItemName
            // 
            this.tbNewItemName.Location = new System.Drawing.Point(117, 9);
            this.tbNewItemName.Name = "tbNewItemName";
            this.tbNewItemName.Size = new System.Drawing.Size(296, 20);
            this.tbNewItemName.TabIndex = 122;
            this.tbNewItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbNewItemName_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(77, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 123;
            this.label7.Text = "Type:";
            // 
            // cbNewItemModpack
            // 
            this.cbNewItemModpack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNewItemModpack.FormattingEnabled = true;
            this.cbNewItemModpack.Location = new System.Drawing.Point(117, 62);
            this.cbNewItemModpack.Name = "cbNewItemModpack";
            this.cbNewItemModpack.Size = new System.Drawing.Size(296, 21);
            this.cbNewItemModpack.Sorted = true;
            this.cbNewItemModpack.TabIndex = 126;
            // 
            // cbNewItemType
            // 
            this.cbNewItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNewItemType.FormattingEnabled = true;
            this.cbNewItemType.Location = new System.Drawing.Point(117, 35);
            this.cbNewItemType.Name = "cbNewItemType";
            this.cbNewItemType.Size = new System.Drawing.Size(296, 21);
            this.cbNewItemType.TabIndex = 124;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 125;
            this.label9.Text = "ModPack:";
            // 
            // lmoditem
            // 
            this.lmoditem.AutoSize = true;
            this.lmoditem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmoditem.Location = new System.Drawing.Point(37, 451);
            this.lmoditem.Name = "lmoditem";
            this.lmoditem.Size = new System.Drawing.Size(93, 13);
            this.lmoditem.TabIndex = 110;
            this.lmoditem.Text = "Modifying Item:";
            this.lmoditem.Visible = false;
            // 
            // lmoditemname
            // 
            this.lmoditemname.AutoSize = true;
            this.lmoditemname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmoditemname.Location = new System.Drawing.Point(136, 451);
            this.lmoditemname.Name = "lmoditemname";
            this.lmoditemname.Size = new System.Drawing.Size(67, 13);
            this.lmoditemname.TabIndex = 109;
            this.lmoditemname.Text = "<item name>";
            // 
            // bDiscard
            // 
            this.bDiscard.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bDiscard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDiscard.Location = new System.Drawing.Point(282, 411);
            this.bDiscard.Name = "bDiscard";
            this.bDiscard.Size = new System.Drawing.Size(75, 23);
            this.bDiscard.TabIndex = 77;
            this.bDiscard.Text = "Discard";
            this.bDiscard.UseVisualStyleBackColor = false;
            this.bDiscard.Click += new System.EventHandler(this.BClear_Click);
            // 
            // bCreateItem
            // 
            this.bCreateItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bCreateItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCreateItem.Location = new System.Drawing.Point(147, 411);
            this.bCreateItem.Name = "bCreateItem";
            this.bCreateItem.Size = new System.Drawing.Size(75, 23);
            this.bCreateItem.TabIndex = 62;
            this.bCreateItem.Text = "Create";
            this.bCreateItem.UseVisualStyleBackColor = false;
            this.bCreateItem.Click += new System.EventHandler(this.BAdd_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabNewItem);
            this.tabControl1.Controls.Add(this.TabModPack);
            this.tabControl1.Controls.Add(this.TabType);
            this.tabControl1.Location = new System.Drawing.Point(554, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(618, 517);
            this.tabControl1.TabIndex = 54;
            // 
            // TabModPack
            // 
            this.TabModPack.BackColor = System.Drawing.Color.White;
            this.TabModPack.Controls.Add(this.bmodpackdelete);
            this.TabModPack.Controls.Add(this.lbmodpacks);
            this.TabModPack.Controls.Add(this.bmodpackadd);
            this.TabModPack.Controls.Add(this.tbmodpackname);
            this.TabModPack.Controls.Add(this.label11);
            this.TabModPack.Location = new System.Drawing.Point(4, 22);
            this.TabModPack.Name = "TabModPack";
            this.TabModPack.Padding = new System.Windows.Forms.Padding(3);
            this.TabModPack.Size = new System.Drawing.Size(610, 491);
            this.TabModPack.TabIndex = 2;
            this.TabModPack.Text = "ModPack";
            // 
            // bmodpackdelete
            // 
            this.bmodpackdelete.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bmodpackdelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bmodpackdelete.Location = new System.Drawing.Point(264, 341);
            this.bmodpackdelete.Name = "bmodpackdelete";
            this.bmodpackdelete.Size = new System.Drawing.Size(75, 23);
            this.bmodpackdelete.TabIndex = 20;
            this.bmodpackdelete.Text = "Delete";
            this.bmodpackdelete.UseVisualStyleBackColor = false;
            this.bmodpackdelete.Click += new System.EventHandler(this.BModPackDelete_Click);
            // 
            // lbmodpacks
            // 
            this.lbmodpacks.FormattingEnabled = true;
            this.lbmodpacks.Location = new System.Drawing.Point(81, 109);
            this.lbmodpacks.Name = "lbmodpacks";
            this.lbmodpacks.ScrollAlwaysVisible = true;
            this.lbmodpacks.Size = new System.Drawing.Size(427, 212);
            this.lbmodpacks.Sorted = true;
            this.lbmodpacks.TabIndex = 16;
            // 
            // bmodpackadd
            // 
            this.bmodpackadd.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bmodpackadd.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bmodpackadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bmodpackadd.Location = new System.Drawing.Point(433, 65);
            this.bmodpackadd.Name = "bmodpackadd";
            this.bmodpackadd.Size = new System.Drawing.Size(75, 23);
            this.bmodpackadd.TabIndex = 19;
            this.bmodpackadd.Text = "Add";
            this.bmodpackadd.UseVisualStyleBackColor = false;
            this.bmodpackadd.Click += new System.EventHandler(this.BModpackAdd_Click);
            // 
            // tbmodpackname
            // 
            this.tbmodpackname.Location = new System.Drawing.Point(171, 67);
            this.tbmodpackname.Name = "tbmodpackname";
            this.tbmodpackname.Size = new System.Drawing.Size(232, 20);
            this.tbmodpackname.TabIndex = 18;
            this.tbmodpackname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbModpackName_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(78, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "ModPack Name:";
            // 
            // TabType
            // 
            this.TabType.BackColor = System.Drawing.Color.White;
            this.TabType.Controls.Add(this.bdeletetype);
            this.TabType.Controls.Add(this.lbtype);
            this.TabType.Controls.Add(this.baddtype);
            this.TabType.Controls.Add(this.tbtype);
            this.TabType.Controls.Add(this.label13);
            this.TabType.Location = new System.Drawing.Point(4, 22);
            this.TabType.Name = "TabType";
            this.TabType.Padding = new System.Windows.Forms.Padding(3);
            this.TabType.Size = new System.Drawing.Size(610, 491);
            this.TabType.TabIndex = 3;
            this.TabType.Text = "Item Type";
            // 
            // bdeletetype
            // 
            this.bdeletetype.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bdeletetype.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bdeletetype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdeletetype.Location = new System.Drawing.Point(264, 341);
            this.bdeletetype.Name = "bdeletetype";
            this.bdeletetype.Size = new System.Drawing.Size(75, 23);
            this.bdeletetype.TabIndex = 25;
            this.bdeletetype.Text = "Delete";
            this.bdeletetype.UseVisualStyleBackColor = false;
            this.bdeletetype.Click += new System.EventHandler(this.BTypeDelete_Click);
            // 
            // lbtype
            // 
            this.lbtype.FormattingEnabled = true;
            this.lbtype.Location = new System.Drawing.Point(81, 109);
            this.lbtype.Name = "lbtype";
            this.lbtype.ScrollAlwaysVisible = true;
            this.lbtype.Size = new System.Drawing.Size(427, 212);
            this.lbtype.Sorted = true;
            this.lbtype.TabIndex = 21;
            // 
            // baddtype
            // 
            this.baddtype.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.baddtype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.baddtype.Location = new System.Drawing.Point(433, 65);
            this.baddtype.Name = "baddtype";
            this.baddtype.Size = new System.Drawing.Size(75, 23);
            this.baddtype.TabIndex = 24;
            this.baddtype.Text = "Add";
            this.baddtype.UseVisualStyleBackColor = false;
            this.baddtype.Click += new System.EventHandler(this.BAddType_Click);
            // 
            // tbtype
            // 
            this.tbtype.Location = new System.Drawing.Point(171, 67);
            this.tbtype.Name = "tbtype";
            this.tbtype.Size = new System.Drawing.Size(232, 20);
            this.tbtype.TabIndex = 23;
            this.tbtype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbType_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(78, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Type Name:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 113;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // bclearsearch
            // 
            this.bclearsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bclearsearch.Location = new System.Drawing.Point(241, 528);
            this.bclearsearch.Name = "bclearsearch";
            this.bclearsearch.Size = new System.Drawing.Size(75, 23);
            this.bclearsearch.TabIndex = 122;
            this.bclearsearch.Text = "Clear";
            this.bclearsearch.UseVisualStyleBackColor = true;
            this.bclearsearch.Click += new System.EventHandler(this.BClearSearch_Click);
            // 
            // bsearchitem
            // 
            this.bsearchitem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bsearchitem.Location = new System.Drawing.Point(64, 528);
            this.bsearchitem.Name = "bsearchitem";
            this.bsearchitem.Size = new System.Drawing.Size(75, 23);
            this.bsearchitem.TabIndex = 121;
            this.bsearchitem.Text = "Search Item";
            this.bsearchitem.UseVisualStyleBackColor = true;
            this.bsearchitem.Click += new System.EventHandler(this.BFindItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "Item Name:";
            // 
            // tbsearchname
            // 
            this.tbsearchname.Delay = 250;
            this.tbsearchname.Location = new System.Drawing.Point(82, 438);
            this.tbsearchname.Name = "tbsearchname";
            this.tbsearchname.Size = new System.Drawing.Size(296, 20);
            this.tbsearchname.TabIndex = 116;
            this.tbsearchname.DelayedTextChanged += new System.EventHandler(this.Tbsearchname_DelayedTextChanged);
            this.tbsearchname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbSearchName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(42, 467);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 117;
            this.label2.Text = "Type:";
            // 
            // cbsearchmodpack
            // 
            this.cbsearchmodpack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsearchmodpack.FormattingEnabled = true;
            this.cbsearchmodpack.Location = new System.Drawing.Point(82, 491);
            this.cbsearchmodpack.Name = "cbsearchmodpack";
            this.cbsearchmodpack.Size = new System.Drawing.Size(296, 21);
            this.cbsearchmodpack.Sorted = true;
            this.cbsearchmodpack.TabIndex = 120;
            // 
            // cbsearchtype
            // 
            this.cbsearchtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsearchtype.FormattingEnabled = true;
            this.cbsearchtype.Location = new System.Drawing.Point(82, 464);
            this.cbsearchtype.Name = "cbsearchtype";
            this.cbsearchtype.Size = new System.Drawing.Size(296, 21);
            this.cbsearchtype.TabIndex = 118;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 494);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 119;
            this.label3.Text = "ModPack:";
            // 
            // lvitems
            // 
            this.lvitems.FullRowSelect = true;
            this.lvitems.GridLines = true;
            this.lvitems.HideSelection = false;
            this.lvitems.Location = new System.Drawing.Point(12, 27);
            this.lvitems.Name = "lvitems";
            this.lvitems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvitems.Size = new System.Drawing.Size(536, 402);
            this.lvitems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvitems.TabIndex = 114;
            this.lvitems.UseCompatibleStateImageBehavior = false;
            this.lvitems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvItems_KeyDown);
            this.lvitems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Lvitems_MouseDoubleClick);
            // 
            // NewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.bclearsearch);
            this.Controls.Add(this.bsearchitem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbsearchname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbsearchmodpack);
            this.Controls.Add(this.cbsearchtype);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvitems);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 600);
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "NewItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "NewItem";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewItem_FormClosed);
            this.Load += new System.EventHandler(this.NewItem_Load);
            this.TabNewItem.ResumeLayout(false);
            this.TabNewItem.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabModPack.ResumeLayout(false);
            this.TabModPack.PerformLayout();
            this.TabType.ResumeLayout(false);
            this.TabType.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage TabNewItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox tbAddAmount;
        private System.Windows.Forms.TextBox tbRemoveAmount;
        private System.Windows.Forms.Button bRemoveItem;
        private System.Windows.Forms.Button bAddItem;
        private System.Windows.Forms.ListView lvSubItems;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bDiscard;
        private System.Windows.Forms.Button bCreateItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button bImportmodify;
        private System.Windows.Forms.Label lmoditem;
        private System.Windows.Forms.Label lmoditemname;
        private System.Windows.Forms.TabPage TabModPack;
        private System.Windows.Forms.TabPage TabType;
        private System.Windows.Forms.Button bmodpackdelete;
        private System.Windows.Forms.ListBox lbmodpacks;
        private System.Windows.Forms.Button bmodpackadd;
        private System.Windows.Forms.TextBox tbmodpackname;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button bdeletetype;
        private System.Windows.Forms.ListBox lbtype;
        private System.Windows.Forms.Button baddtype;
        private System.Windows.Forms.TextBox tbtype;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button bclearsearch;
        private System.Windows.Forms.Button bsearchitem;
        private System.Windows.Forms.Label label1;
        private GUI.Controls.DelayedTextBox tbsearchname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbsearchmodpack;
        private System.Windows.Forms.ComboBox cbsearchtype;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvitems;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNewItemName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbNewItemModpack;
        private System.Windows.Forms.ComboBox cbNewItemType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
    }
}
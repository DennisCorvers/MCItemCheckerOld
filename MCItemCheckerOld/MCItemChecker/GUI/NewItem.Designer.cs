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
            this.tbadd = new System.Windows.Forms.TextBox();
            this.tbremove = new System.Windows.Forms.TextBox();
            this.bremove = new System.Windows.Forms.Button();
            this.badd = new System.Windows.Forms.Button();
            this.tbitemid = new System.Windows.Forms.TextBox();
            this.tbitemname = new System.Windows.Forms.TextBox();
            this.lvsubitems = new System.Windows.Forms.ListView();
            this.cbmodpack = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbtype = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lmoditem = new System.Windows.Forms.Label();
            this.lmoditemname = new System.Windows.Forms.Label();
            this.bclear = new System.Windows.Forms.Button();
            this.badditem = new System.Windows.Forms.Button();
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
            this.lvitems = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.tbsearchid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbsearchname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbsearchmodpack = new System.Windows.Forms.ComboBox();
            this.cbsearchtype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bclearsearch = new System.Windows.Forms.Button();
            this.bsearchitem = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabNewItem.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabModPack.SuspendLayout();
            this.TabType.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabNewItem
            // 
            this.TabNewItem.BackColor = System.Drawing.Color.Transparent;
            this.TabNewItem.Controls.Add(this.bImportmodify);
            this.TabNewItem.Controls.Add(this.tbadd);
            this.TabNewItem.Controls.Add(this.tbremove);
            this.TabNewItem.Controls.Add(this.bremove);
            this.TabNewItem.Controls.Add(this.badd);
            this.TabNewItem.Controls.Add(this.tbitemid);
            this.TabNewItem.Controls.Add(this.tbitemname);
            this.TabNewItem.Controls.Add(this.lvsubitems);
            this.TabNewItem.Controls.Add(this.cbmodpack);
            this.TabNewItem.Controls.Add(this.label5);
            this.TabNewItem.Controls.Add(this.cbtype);
            this.TabNewItem.Controls.Add(this.label6);
            this.TabNewItem.Controls.Add(this.label7);
            this.TabNewItem.Controls.Add(this.label8);
            this.TabNewItem.Controls.Add(this.panel2);
            this.TabNewItem.Location = new System.Drawing.Point(4, 22);
            this.TabNewItem.Name = "TabNewItem";
            this.TabNewItem.Padding = new System.Windows.Forms.Padding(3);
            this.TabNewItem.Size = new System.Drawing.Size(430, 350);
            this.TabNewItem.TabIndex = 0;
            this.TabNewItem.Tag = "TabNewItem";
            this.TabNewItem.Text = "New Item";
            // 
            // bImportmodify
            // 
            this.bImportmodify.Location = new System.Drawing.Point(19, 236);
            this.bImportmodify.Name = "bImportmodify";
            this.bImportmodify.Size = new System.Drawing.Size(75, 23);
            this.bImportmodify.TabIndex = 107;
            this.bImportmodify.Text = "Modify >>";
            this.bImportmodify.UseVisualStyleBackColor = true;
            this.bImportmodify.Click += new System.EventHandler(this.BImportModify_Click);
            // 
            // tbadd
            // 
            this.tbadd.Location = new System.Drawing.Point(37, 57);
            this.tbadd.Name = "tbadd";
            this.tbadd.Size = new System.Drawing.Size(37, 20);
            this.tbadd.TabIndex = 106;
            // 
            // tbremove
            // 
            this.tbremove.Location = new System.Drawing.Point(37, 188);
            this.tbremove.Name = "tbremove";
            this.tbremove.Size = new System.Drawing.Size(37, 20);
            this.tbremove.TabIndex = 105;
            // 
            // bremove
            // 
            this.bremove.Location = new System.Drawing.Point(19, 159);
            this.bremove.Name = "bremove";
            this.bremove.Size = new System.Drawing.Size(75, 23);
            this.bremove.TabIndex = 104;
            this.bremove.Text = "<< Remove";
            this.bremove.UseVisualStyleBackColor = true;
            this.bremove.Click += new System.EventHandler(this.BRemoveSubItem_Click);
            // 
            // badd
            // 
            this.badd.Location = new System.Drawing.Point(19, 83);
            this.badd.Name = "badd";
            this.badd.Size = new System.Drawing.Size(75, 23);
            this.badd.TabIndex = 103;
            this.badd.Text = "Add >>";
            this.badd.UseVisualStyleBackColor = true;
            this.badd.Click += new System.EventHandler(this.BAddSubItem_Click);
            // 
            // tbitemid
            // 
            this.tbitemid.Location = new System.Drawing.Point(208, 45);
            this.tbitemid.Name = "tbitemid";
            this.tbitemid.Size = new System.Drawing.Size(28, 20);
            this.tbitemid.TabIndex = 96;
            // 
            // tbitemname
            // 
            this.tbitemname.Location = new System.Drawing.Point(208, 19);
            this.tbitemname.Name = "tbitemname";
            this.tbitemname.Size = new System.Drawing.Size(180, 20);
            this.tbitemname.TabIndex = 94;
            this.tbitemname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbItemName_KeyPress);
            // 
            // lvsubitems
            // 
            this.lvsubitems.FullRowSelect = true;
            this.lvsubitems.HideSelection = false;
            this.lvsubitems.Location = new System.Drawing.Point(132, 98);
            this.lvsubitems.Name = "lvsubitems";
            this.lvsubitems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvsubitems.Size = new System.Drawing.Size(273, 93);
            this.lvsubitems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvsubitems.TabIndex = 101;
            this.lvsubitems.UseCompatibleStateImageBehavior = false;
            this.lvsubitems.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvItems_ColumnClick);
            this.lvsubitems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvSubItems_DeletePress);
            // 
            // cbmodpack
            // 
            this.cbmodpack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmodpack.FormattingEnabled = true;
            this.cbmodpack.Location = new System.Drawing.Point(208, 71);
            this.cbmodpack.Name = "cbmodpack";
            this.cbmodpack.Size = new System.Drawing.Size(180, 21);
            this.cbmodpack.Sorted = true;
            this.cbmodpack.TabIndex = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "ModPack:";
            // 
            // cbtype
            // 
            this.cbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtype.FormattingEnabled = true;
            this.cbtype.Location = new System.Drawing.Point(282, 44);
            this.cbtype.Name = "cbtype";
            this.cbtype.Size = new System.Drawing.Size(106, 21);
            this.cbtype.TabIndex = 98;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 97;
            this.label6.Text = "Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(158, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 95;
            this.label7.Text = "Item ID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(141, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 93;
            this.label8.Text = "Item Name:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lmoditem);
            this.panel2.Controls.Add(this.lmoditemname);
            this.panel2.Controls.Add(this.bclear);
            this.panel2.Controls.Add(this.badditem);
            this.panel2.Location = new System.Drawing.Point(115, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 340);
            this.panel2.TabIndex = 102;
            // 
            // lmoditem
            // 
            this.lmoditem.AutoSize = true;
            this.lmoditem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmoditem.Location = new System.Drawing.Point(42, 240);
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
            this.lmoditemname.Location = new System.Drawing.Point(141, 240);
            this.lmoditemname.Name = "lmoditemname";
            this.lmoditemname.Size = new System.Drawing.Size(10, 13);
            this.lmoditemname.TabIndex = 109;
            this.lmoditemname.Text = "-";
            // 
            // bclear
            // 
            this.bclear.Location = new System.Drawing.Point(180, 200);
            this.bclear.Name = "bclear";
            this.bclear.Size = new System.Drawing.Size(75, 23);
            this.bclear.TabIndex = 77;
            this.bclear.Text = "Clear";
            this.bclear.UseVisualStyleBackColor = true;
            this.bclear.Click += new System.EventHandler(this.BClear_Click);
            // 
            // badditem
            // 
            this.badditem.Location = new System.Drawing.Point(45, 200);
            this.badditem.Name = "badditem";
            this.badditem.Size = new System.Drawing.Size(75, 23);
            this.badditem.TabIndex = 62;
            this.badditem.Text = "Add";
            this.badditem.UseVisualStyleBackColor = true;
            this.badditem.Click += new System.EventHandler(this.BAdd_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabNewItem);
            this.tabControl1.Controls.Add(this.TabModPack);
            this.tabControl1.Controls.Add(this.TabType);
            this.tabControl1.Location = new System.Drawing.Point(327, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 376);
            this.tabControl1.TabIndex = 54;
            // 
            // TabModPack
            // 
            this.TabModPack.BackColor = System.Drawing.Color.Transparent;
            this.TabModPack.Controls.Add(this.bmodpackdelete);
            this.TabModPack.Controls.Add(this.lbmodpacks);
            this.TabModPack.Controls.Add(this.bmodpackadd);
            this.TabModPack.Controls.Add(this.tbmodpackname);
            this.TabModPack.Controls.Add(this.label11);
            this.TabModPack.Location = new System.Drawing.Point(4, 22);
            this.TabModPack.Name = "TabModPack";
            this.TabModPack.Padding = new System.Windows.Forms.Padding(3);
            this.TabModPack.Size = new System.Drawing.Size(430, 350);
            this.TabModPack.TabIndex = 2;
            this.TabModPack.Text = "ModPack";
            // 
            // bmodpackdelete
            // 
            this.bmodpackdelete.Location = new System.Drawing.Point(181, 283);
            this.bmodpackdelete.Name = "bmodpackdelete";
            this.bmodpackdelete.Size = new System.Drawing.Size(75, 23);
            this.bmodpackdelete.TabIndex = 20;
            this.bmodpackdelete.Text = "Delete";
            this.bmodpackdelete.UseVisualStyleBackColor = true;
            this.bmodpackdelete.Click += new System.EventHandler(this.BModPackSelete_Click);
            // 
            // lbmodpacks
            // 
            this.lbmodpacks.FormattingEnabled = true;
            this.lbmodpacks.Location = new System.Drawing.Point(56, 137);
            this.lbmodpacks.MultiColumn = true;
            this.lbmodpacks.Name = "lbmodpacks";
            this.lbmodpacks.Size = new System.Drawing.Size(322, 121);
            this.lbmodpacks.Sorted = true;
            this.lbmodpacks.TabIndex = 16;
            // 
            // bmodpackadd
            // 
            this.bmodpackadd.Location = new System.Drawing.Point(181, 94);
            this.bmodpackadd.Name = "bmodpackadd";
            this.bmodpackadd.Size = new System.Drawing.Size(75, 23);
            this.bmodpackadd.TabIndex = 19;
            this.bmodpackadd.Text = "Add";
            this.bmodpackadd.UseVisualStyleBackColor = true;
            this.bmodpackadd.Click += new System.EventHandler(this.BModpackAdd_Click);
            // 
            // tbmodpackname
            // 
            this.tbmodpackname.Location = new System.Drawing.Point(146, 59);
            this.tbmodpackname.Name = "tbmodpackname";
            this.tbmodpackname.Size = new System.Drawing.Size(180, 20);
            this.tbmodpackname.TabIndex = 18;
            this.tbmodpackname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbModpackName_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(53, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "ModPack Name:";
            // 
            // TabType
            // 
            this.TabType.BackColor = System.Drawing.Color.Transparent;
            this.TabType.Controls.Add(this.bdeletetype);
            this.TabType.Controls.Add(this.lbtype);
            this.TabType.Controls.Add(this.baddtype);
            this.TabType.Controls.Add(this.tbtype);
            this.TabType.Controls.Add(this.label13);
            this.TabType.Location = new System.Drawing.Point(4, 22);
            this.TabType.Name = "TabType";
            this.TabType.Padding = new System.Windows.Forms.Padding(3);
            this.TabType.Size = new System.Drawing.Size(430, 350);
            this.TabType.TabIndex = 3;
            this.TabType.Text = "Item Type";
            // 
            // bdeletetype
            // 
            this.bdeletetype.Location = new System.Drawing.Point(181, 283);
            this.bdeletetype.Name = "bdeletetype";
            this.bdeletetype.Size = new System.Drawing.Size(75, 23);
            this.bdeletetype.TabIndex = 25;
            this.bdeletetype.Text = "Delete";
            this.bdeletetype.UseVisualStyleBackColor = true;
            this.bdeletetype.Click += new System.EventHandler(this.BTypeDelete_Click);
            // 
            // lbtype
            // 
            this.lbtype.FormattingEnabled = true;
            this.lbtype.Location = new System.Drawing.Point(56, 137);
            this.lbtype.MultiColumn = true;
            this.lbtype.Name = "lbtype";
            this.lbtype.Size = new System.Drawing.Size(322, 121);
            this.lbtype.Sorted = true;
            this.lbtype.TabIndex = 21;
            // 
            // baddtype
            // 
            this.baddtype.Location = new System.Drawing.Point(181, 94);
            this.baddtype.Name = "baddtype";
            this.baddtype.Size = new System.Drawing.Size(75, 23);
            this.baddtype.TabIndex = 24;
            this.baddtype.Text = "Add";
            this.baddtype.UseVisualStyleBackColor = true;
            this.baddtype.Click += new System.EventHandler(this.BAddType_Click);
            // 
            // tbtype
            // 
            this.tbtype.Location = new System.Drawing.Point(146, 59);
            this.tbtype.Name = "tbtype";
            this.tbtype.Size = new System.Drawing.Size(180, 20);
            this.tbtype.TabIndex = 23;
            this.tbtype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbType_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(53, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Type Name:";
            // 
            // lvitems
            // 
            this.lvitems.FullRowSelect = true;
            this.lvitems.HideSelection = false;
            this.lvitems.Location = new System.Drawing.Point(30, 48);
            this.lvitems.Name = "lvitems";
            this.lvitems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvitems.Size = new System.Drawing.Size(273, 188);
            this.lvitems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvitems.TabIndex = 103;
            this.lvitems.UseCompatibleStateImageBehavior = false;
            this.lvitems.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvItems_ColumnClick);
            this.lvitems.DoubleClick += new System.EventHandler(this.LvDoubleClick);
            this.lvitems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvItems_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 104;
            this.label4.Text = "Item Name:";
            // 
            // tbsearchid
            // 
            this.tbsearchid.Location = new System.Drawing.Point(100, 268);
            this.tbsearchid.Name = "tbsearchid";
            this.tbsearchid.Size = new System.Drawing.Size(28, 20);
            this.tbsearchid.TabIndex = 107;
            this.tbsearchid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbSearchId_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Item ID:";
            // 
            // tbsearchname
            // 
            this.tbsearchname.Location = new System.Drawing.Point(100, 242);
            this.tbsearchname.Name = "tbsearchname";
            this.tbsearchname.Size = new System.Drawing.Size(180, 20);
            this.tbsearchname.TabIndex = 105;
            this.tbsearchname.TextChanged += new System.EventHandler(this.TbSearchName_TextChanged);
            this.tbsearchname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbSearchName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 108;
            this.label2.Text = "Type:";
            // 
            // cbsearchmodpack
            // 
            this.cbsearchmodpack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsearchmodpack.FormattingEnabled = true;
            this.cbsearchmodpack.Location = new System.Drawing.Point(100, 294);
            this.cbsearchmodpack.Name = "cbsearchmodpack";
            this.cbsearchmodpack.Size = new System.Drawing.Size(180, 21);
            this.cbsearchmodpack.Sorted = true;
            this.cbsearchmodpack.TabIndex = 111;
            // 
            // cbsearchtype
            // 
            this.cbsearchtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsearchtype.FormattingEnabled = true;
            this.cbsearchtype.Location = new System.Drawing.Point(174, 267);
            this.cbsearchtype.Name = "cbsearchtype";
            this.cbsearchtype.Size = new System.Drawing.Size(106, 21);
            this.cbsearchtype.TabIndex = 109;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 110;
            this.label1.Text = "ModPack:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bclearsearch);
            this.panel1.Controls.Add(this.bsearchitem);
            this.panel1.Location = new System.Drawing.Point(12, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 340);
            this.panel1.TabIndex = 112;
            // 
            // bclearsearch
            // 
            this.bclearsearch.Location = new System.Drawing.Point(161, 298);
            this.bclearsearch.Name = "bclearsearch";
            this.bclearsearch.Size = new System.Drawing.Size(75, 23);
            this.bclearsearch.TabIndex = 78;
            this.bclearsearch.Text = "Clear";
            this.bclearsearch.UseVisualStyleBackColor = true;
            this.bclearsearch.Click += new System.EventHandler(this.BClearSearch_Click);
            // 
            // bsearchitem
            // 
            this.bsearchitem.Location = new System.Drawing.Point(61, 298);
            this.bsearchitem.Name = "bsearchitem";
            this.bsearchitem.Size = new System.Drawing.Size(75, 23);
            this.bsearchitem.TabIndex = 53;
            this.bsearchitem.Text = "Search Item";
            this.bsearchitem.UseVisualStyleBackColor = true;
            this.bsearchitem.Click += new System.EventHandler(this.BFindItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(774, 24);
            this.menuStrip1.TabIndex = 113;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
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
            // NewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 395);
            this.Controls.Add(this.lvitems);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbsearchid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbsearchname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbsearchmodpack);
            this.Controls.Add(this.cbsearchtype);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(790, 433);
            this.MinimumSize = new System.Drawing.Size(790, 433);
            this.Name = "NewItem";
            this.Text = "NewItem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewItem_FormClosing);
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
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage TabNewItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ListView lvitems;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbsearchid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbsearchname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbsearchmodpack;
        private System.Windows.Forms.ComboBox cbsearchtype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bclearsearch;
        private System.Windows.Forms.Button bsearchitem;
        private System.Windows.Forms.TextBox tbadd;
        private System.Windows.Forms.TextBox tbremove;
        private System.Windows.Forms.Button bremove;
        private System.Windows.Forms.Button badd;
        private System.Windows.Forms.TextBox tbitemid;
        private System.Windows.Forms.TextBox tbitemname;
        private System.Windows.Forms.ListView lvsubitems;
        private System.Windows.Forms.ComboBox cbmodpack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbtype;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bclear;
        private System.Windows.Forms.Button badditem;
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

    }
}
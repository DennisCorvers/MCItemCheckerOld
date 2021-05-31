using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MCItemChecker.Utils;

namespace MCItemChecker
{
    public partial class NewItem : Form
    {
        private ItemChecker m_itemchecker;
        private MainMenu m_mainform;
        private bool m_modifyingItem = false;
        private Item m_moditem;
        private Dictionary<Item, double> m_subItems = new Dictionary<Item, double>();


        public NewItem()
        {
            InitializeComponent();
        }

        public NewItem(ItemChecker IC, MainMenu mainform)
            : this()
        {
            m_itemchecker = IC;
            m_mainform = mainform;
            lvitems.ListViewItemSorter = new ListViewComparer();
            tbadd.Text = "1";
            tbremove.Text = "1";

            Text = m_mainform.Text;

            UpdateTypeControls();
            UpdateModPackControls();
            cbmodpack.SelectedItem = "-";
            cbsearchmodpack.SelectedItem = "-";
            cbsearchtype.SelectedItem = "-";
            cbtype.SelectedItem = "-";

            Initlvitems();
            Initlvsubitems();
        }

        public NewItem(ItemChecker IC, MainMenu mainform, string tabname)
            : this(IC, mainform)
        {
            if (tabname == "Items")
            { tabControl1.SelectedTab = TabNewItem; }
            else if (tabname == "Modpack")
            { tabControl1.SelectedTab = TabModPack; }
            else if (tabname == "Types")
            { tabControl1.SelectedTab = TabType; }
        }

        private void UpdateTypeControls()
        {
            GUIControl.UpdateControl(m_itemchecker.Types, cbsearchtype);
            GUIControl.UpdateControl(m_itemchecker.Types, cbtype);
            GUIControl.UpdateControl(m_itemchecker.Types, lbtype);
        }

        private void UpdateModPackControls()
        {
            GUIControl.UpdateControl(m_itemchecker.ModPacks, cbmodpack);
            GUIControl.UpdateControl(m_itemchecker.ModPacks, cbsearchmodpack);
            GUIControl.UpdateControl(m_itemchecker.ModPacks, lbmodpacks);
        }

        private void Initlvitems()
        {
            ColumnHeader headerid, headername, headertype, headermodpack;
            headerid = new ColumnHeader();
            headername = new ColumnHeader();
            headertype = new ColumnHeader();
            headermodpack = new ColumnHeader();
            lvitems.Scrollable = true;
            lvitems.View = View.Details;

            headerid.Text = "ID";
            headerid.TextAlign = HorizontalAlignment.Left;
            headerid.Width = 30;
            headername.Text = "Name";
            headername.TextAlign = HorizontalAlignment.Left;
            headername.Width = 200;
            headertype.Text = "Type";
            headertype.TextAlign = HorizontalAlignment.Left;
            headertype.Width = 10;
            headermodpack.Text = "ModPack";
            headermodpack.TextAlign = HorizontalAlignment.Left;
            headermodpack.Width = 10;
            lvitems.Columns.Add(headerid);
            lvitems.Columns.Add(headername);
            lvitems.Columns.Add(headertype);
            lvitems.Columns.Add(headermodpack);

            GUIControl.Sort(lvitems, 1, SortOrder.Descending);
        }
        private void Initlvsubitems()
        {
            ColumnHeader headerid, headername, headeramount, headertype;
            headerid = new ColumnHeader();
            headername = new ColumnHeader();
            headeramount = new ColumnHeader();
            headertype = new ColumnHeader();
            lvsubitems.Scrollable = true;
            lvsubitems.View = View.Details;

            headerid.Text = "ID";
            headerid.TextAlign = HorizontalAlignment.Left;
            headerid.Width = 30;
            headername.Text = "Name";
            headername.TextAlign = HorizontalAlignment.Left;
            headername.Width = 180;
            headeramount.Text = "Amount";
            headeramount.TextAlign = HorizontalAlignment.Left;
            headeramount.Width = 50;
            headertype.Text = "Type";
            headertype.TextAlign = HorizontalAlignment.Left;
            headertype.Width = 0;
            lvsubitems.Columns.Add(headerid);
            lvsubitems.Columns.Add(headername);
            lvsubitems.Columns.Add(headeramount);
            lvsubitems.Columns.Add(headertype);
        }
        private void LvItems_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (!(sender is ListView listView))
                return;

            GUIControl.Sort(listView, e.Column);
        }
        private void NewItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            Close();
        }
        private void NewItem_Load(object sender, EventArgs e)
            => UpdateItemList(m_itemchecker.Items.Values);
        private void UpdateItemList(IEnumerable<Item> Items)
            => GUIControl.UpdateItemListView(lvitems, Items);

        private void UpdateSubItems(Dictionary<Item, double> subitemlist)
        {
            lvsubitems.Items.Clear();
            foreach (KeyValuePair<Item, double> pair in subitemlist)
            {
                var item = new ListViewItem(new[] {
                    pair.Key.ItemID.ToString(), pair.Key.ItemName,
                    Math.Round(pair.Value, 3).ToString(), pair.Key.Type
                })
                { Tag = pair };
                lvsubitems.Items.Add(item);
                item = null;
            }
        }

        private void AddNewItem(Item item = null)
        {
            Dictionary<Item, double> subitems = new Dictionary<Item, double>(m_subItems);

            if (tbitemname.Text.Trim().Length == 0)
            {
                MessageBox.Show("Enter an Item Name first");
                return;
            }

            Item newItem = new Item(
                tbitemname.Text,
                cbtype.SelectedItem.ToString(),
                cbmodpack.SelectedItem.ToString(),
                subitems);

            if (m_modifyingItem == true && item != null)
            {
                if (!m_itemchecker.EditItem(newItem, item))
                    GUIControl.InfoMessage("Unable to edit item. Make sure the name is unique.");
            }
            else
            {
                if (!m_itemchecker.AddNewItem(newItem))
                    GUIControl.InfoMessage("Unable add a new item. Make sure the name is unique.");
            }

            UpdateItemList(m_itemchecker.Items.Values);
            ClearNewItem();
        }

        private void LvItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (!(sender is ListView))
                    return;

                ListView lv = (ListView)sender;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Item Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes && m_itemchecker.DeleteItem(lv.GetSelectedMCItem().ItemID))
                {
                    try
                    {
                        lv.Items.Remove(lv.SelectedItems[0]);
                    }
                    catch
                    {
                        GUIControl.UpdateItemListView(lv, m_itemchecker.Items.Values);
                    }
                }
            }
        }

        private void BAdd_Click(object sender, EventArgs e)
            => AddNewItem(m_moditem);

        private void BFindItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbsearchname.Text))
            {
                MessageBox.Show("Enter an Item Name.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            GUIControl.UpdateItemListView(lvitems, FindItem());
        }

        private void BClearSearch_Click(object sender, EventArgs e)
        {
            tbsearchname.Text = "";
            tbsearchid.Text = "";
            cbsearchtype.SelectedValue = "-";
            cbsearchmodpack.SelectedValue = "-";
            UpdateItemList(m_itemchecker.Items.Values);
        }

        private void BAddSubItem_Click(object sender, EventArgs e)
        {
            if (lvitems.SelectedItems.Count == 0)
            {
                GUIControl.InfoMessage("Select an item to add first.");
                return;
            }

            AddSubItem(lvitems.GetSelectedMCItem());
        }

        private void AddSubItem(Item item)
        {
            if (tbadd.Text == "")
                tbadd.Text = "1";

            if (!tbadd.Text.FractionToDouble(out double amount))
            {
                tbadd.Text = "";
                return;
            }

            if (amount < 0 || amount == 0)
            {
                GUIControl.InfoMessage("Enter an amount first.");
                return;
            }

            if (item.ItemName.ToLower() == tbitemname.Text.ToLower())
            {
                GUIControl.InfoMessage("Can't add an item to itself.");
                return;
            }

            if (m_subItems.ContainsKey(item))
                m_subItems[item] = m_subItems[item] + amount;
            else
                m_subItems.Add(item, amount);


            if (m_subItems != null)
            {
                UpdateSubItems(m_subItems);
            }

            tbadd.Text = "1";
        }

        private void BRemoveSubItem_Click(object sender, EventArgs e)
        {
            if (lvsubitems.SelectedItems.Count == 0)
            {
                GUIControl.InfoMessage("Select an item to remove first.");
                return;
            }

            Removesubitem(lvsubitems.GetSelectedMCSubItem());
        }

        private void Removesubitem(KeyValuePair<Item, double> subItem)
        {
            if (tbadd.Text == "")
                tbadd.Text = "1";

            if (!tbadd.Text.FractionToDouble(out double amount))
            {
                tbadd.Text = "";
                return;
            }

            if (amount < 0 || amount == 0)
            {
                GUIControl.InfoMessage("Enter an amount first.");
                return;
            }

            double newvalue = subItem.Value - amount;
            if (newvalue < 0 || newvalue == 0)
                m_subItems.Remove(subItem.Key);
            else
                m_subItems[subItem.Key] = subItem.Value - amount;

            UpdateSubItems(m_subItems);

            tbremove.Text = "1";
        }

        private void ClearNewItem()
        {
            tbitemid.Text = "";
            tbitemname.Text = "";
            m_subItems.Clear();
            lvsubitems.Items.Clear();
            lmoditem.Visible = false;
            lmoditemname.Text = "-";
            lmoditemname.Visible = false;
            m_modifyingItem = false;
            m_moditem = null;
        }

        private void BClear_Click(object sender, EventArgs e)
            => ClearNewItem();

        private void LvSubItems_DeletePress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            if (lvsubitems.SelectedItems.Count == 0)
                GUIControl.InfoMessage("Select an item for deletion first.");

            var tpair = lvsubitems.GetSelectedMCSubItem();
            m_subItems.Remove(tpair.Key);
            UpdateSubItems(m_subItems);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
            => Close();

        private void LvDoubleClick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == TabNewItem)
                BAddSubItem_Click(sender, e);
        }
        private void TbItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                BAdd_Click(sender, e);
        }
        private void TbSearchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                BFindItem_Click(sender, e);
        }
        private void TbSearchId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                BFindItem_Click(sender, e);
        }

        private void TbSearchName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbsearchname.Text))
                GUIControl.UpdateItemListView(lvitems, FindItem());
        }
        private IEnumerable<Item> FindItem()
        {
            string itemName = tbsearchname.Text;
            string type = cbsearchtype.SelectedItem?.ToString();
            string modpack = cbsearchmodpack.SelectedItem?.ToString();

            return m_itemchecker.FindItem(itemName, type, modpack);
        }
        private void BImportModify_Click(object sender, EventArgs e)
        {
            if (lvitems.SelectedItems.Count == 0)
            {
                GUIControl.InfoMessage("Select an item to modify first.");
                return;
            }

            ClearNewItem();
            m_moditem = lvitems.GetSelectedMCItem();
            tbitemid.Text = Convert.ToString(m_moditem.ItemID);
            tbitemname.Text = m_moditem.ItemName;
            cbmodpack.SelectedItem = m_moditem.ModPack;
            cbtype.SelectedItem = m_moditem.Type;

            UpdateSubItems(m_moditem.Recipe);
            m_subItems = new Dictionary<Item, double>(m_moditem.Recipe);
            lmoditem.Visible = true;
            lmoditemname.Visible = true;
            lmoditemname.Text = m_moditem.ItemName;
            m_modifyingItem = true;
        }

        private void Addmodpack()
        {
            if (tbmodpackname.Text.Trim().Length == 0)
            {
                GUIControl.InfoMessage("Enter a modpack name first.");
                return;
            }

            if (!m_itemchecker.AddNewModPack(tbmodpackname.Text))
            {
                GUIControl.InfoMessage("Modpack is already present.");
                return;
            }

            UpdateModPackControls();
            tbmodpackname.Text = "";
            m_mainform.UpdateModPackControls();
        }
        private void BModPackSelete_Click(object sender, EventArgs e)
        {
            if (lbmodpacks.SelectedItems.Count == 0)
            {
                GUIControl.InfoMessage("Select a modpack for deletion first.");
                return;
            }

            if (lbmodpacks.SelectedValue.ToString() == "-")
            {
                GUIControl.InfoMessage("Cannot delete default value.");
                return;
            }

            if (!m_itemchecker.DeleteModPack(lbmodpacks.SelectedItem.ToString()))
            {
                GUIControl.InfoMessage("Could not delete selected ModPack.");
            }

            UpdateModPackControls();
            m_mainform.UpdateModPackControls();
        }
        private void BAddType_Click(object sender, EventArgs e)
            => AddType();

        private void AddType()
        {
            if (tbtype.Text.Trim().Length == 0)
            {
                GUIControl.InfoMessage("Enter a type name first.");
                return;
            }

            if (m_itemchecker.AddNewType(tbtype.Text) == false)
            {
                GUIControl.InfoMessage("Type is already present.");
                return;
            }

            UpdateTypeControls();
            tbtype.Text = "";
            m_mainform.UpdateItemTypeControls();
        }
        private void BTypeDelete_Click(object sender, EventArgs e)
        {
            if (lbtype.SelectedItems.Count == 0)
            {
                GUIControl.InfoMessage("Select an Item Type for deletion first.");
                return;
            }

            if (lbtype.SelectedValue.ToString() == "-")
            {
                GUIControl.InfoMessage("Cannot delete default value.");
                return;
            }

            if (m_itemchecker.DeleteType(lbtype.SelectedItem.ToString()) == false)
            {
                GUIControl.InfoMessage("Could not delete selected type.");
            }

            UpdateTypeControls();
            m_mainform.UpdateItemTypeControls();
        }

        private void TbModpackName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                Addmodpack();
        }
        private void TbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                AddType();
        }
        private void BModpackAdd_Click(object sender, EventArgs e)
            => Addmodpack();

        private void NewItem_FormClosing(object sender, FormClosingEventArgs e)
            => UpdateMainForm();

        private void UpdateMainForm()
        {
            m_mainform.UpdateItemList(m_itemchecker.Items.Values);
        }
    }
}

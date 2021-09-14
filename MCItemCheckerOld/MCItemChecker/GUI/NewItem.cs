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
            lvSubItems.ListViewItemSorter = new ListViewComparer();
            tbAddAmount.Text = "1";
            tbRemoveAmount.Text = "1";

            Text = m_mainform.Text;

            UpdateTypeControls();
            UpdateModControls();

            cbsearchmod.SelectedItem = ItemChecker.DefaultName;
            cbsearchtype.SelectedItem = ItemChecker.DefaultName;

            ClearNewItem();

            Initlvitems();
            Initlvsubitems();
        }

        public NewItem(ItemChecker IC, MainMenu mainform, Tabs tabType)
            : this(IC, mainform)
        {
            switch (tabType)
            {
                case Tabs.Mods:
                    tabControl1.SelectedTab = TabMod;
                    break;
                case Tabs.ItemTypes:
                    tabControl1.SelectedTab = TabType;
                    break;

                default:
                    tabControl1.SelectedTab = TabNewItem;
                    break;
            }
        }

        private void Initlvitems()
        {
            lvitems.Scrollable = true;
            lvitems.View = View.Details;

            var headers = lvitems.Columns;
            headers.Add("Name", 275, HorizontalAlignment.Left);
            headers.Add("Type", 125, HorizontalAlignment.Left);
            headers.Add("Mod", 125, HorizontalAlignment.Left);

            GUIControl.Sort(lvitems, 0, SortOrder.Ascending);
        }
        private void Initlvsubitems()
        {
            lvSubItems.Scrollable = true;
            lvSubItems.View = View.Details;

            var headers = lvSubItems.Columns;
            headers.Add("Name", 250, HorizontalAlignment.Left);
            headers.Add("Amount", 100, HorizontalAlignment.Left);
            headers.Add("Mod", 100, HorizontalAlignment.Left);
        }

        private void UpdateModControls()
        {
            var mods = m_itemchecker.Mods;
            GUIControl.UpdateControl(mods, cbNewItemMod);
            GUIControl.UpdateControl(mods, cbsearchmod);
            GUIControl.UpdateControl(mods, lbmods);
        }
        private void UpdateTypeControls()
        {
            var itemTypes = m_itemchecker.Types;
            GUIControl.UpdateControl(itemTypes, cbNewItemType);
            GUIControl.UpdateControl(itemTypes, cbsearchtype);
            GUIControl.UpdateControl(itemTypes, lbtype);
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
            => UpdateItemList(m_itemchecker.ItemList);
        private void UpdateItemList(IEnumerable<Item> items)
        {
            lvitems.Items.Clear();

            lvitems.InsertCollection(items, (i) =>
            { return new ListViewItem(new[] { i.ItemName, i.Type, i.ModName }); });
        }

        private void UpdateSubItems(Dictionary<Item, double> subitemlist)
        {
            lvSubItems.Items.Clear();

            lvSubItems.InsertCollection(subitemlist, (x) =>
            {
                return new ListViewItem(new[] { x.Key.ItemName, x.Value.ToString(2), x.Key.Type });
            });
        }

        private void AddNewItem(Item item = null)
        {
            Dictionary<Item, double> subitems = new Dictionary<Item, double>(m_subItems);

            if (string.IsNullOrWhiteSpace(tbNewItemName.Text))
            {
                GUIControl.InfoMessage("Enter an Item Name first");
                return;
            }

            Item newItem = new Item(
                tbNewItemName.Text,
                cbNewItemType.SelectedItem.ToString(),
                cbNewItemMod.SelectedItem.ToString(),
                subitems);

            if (m_modifyingItem == true && item != null)
            {
                if (!m_itemchecker.EditItem(newItem, item))
                {
                    GUIControl.InfoMessage("Unable to edit item. Make sure the name is unique.");
                    return;
                }
            }
            else
            {
                if (!m_itemchecker.AddNewItem(newItem))
                {
                    GUIControl.InfoMessage("Unable add a new item. Make sure the name is unique.");
                    return;
                }
            }

            UpdateItemList(m_itemchecker.ItemList);
            ClearNewItem();
        }

        private void LvItems_KeyDown(object sender, KeyEventArgs e)
        {
            ListView lv = (ListView)sender;

            if (!lv.TryGetSelectedItem(out Item item))
                return;

            switch (e.KeyCode)
            {
                case Keys.Delete:
                    DeleteItems(lv);
                    return;

                case Keys.E:
                    e.SuppressKeyPress = true;
                    SetModificationItem(item);
                    tbNewItemName.Select();
                    return;
            }
        }

        private void DeleteItems(ListView listview)
        {
            var listviewItems = listview.GetSelectedListViewItems();

            if (listviewItems.Count < 1)
                return;

            DialogResult result = MessageBox.Show($"Are you sure you want to delete  the selected item(s)?" +
                $"{Environment.NewLine}This might affect other items!", "Item Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result != DialogResult.Yes)
                return;

            foreach (var lvItem in listviewItems)
            {
                if (!(lvItem.Tag is Item item))
                    continue;

                if (m_itemchecker.DeleteItem(item.ItemID))
                    listview.Items.Remove(lvItem);
            }
        }

        private void BAdd_Click(object sender, EventArgs e)
            => AddNewItem(m_moditem);

        private void BFindItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbsearchname.Text))
                UpdateItemList(m_itemchecker.ItemList);
            else
                UpdateItemList(FindItem());
        }

        private void BClearSearch_Click(object sender, EventArgs e)
        {
            tbsearchname.Text = "";
            cbsearchtype.SelectedItem = ItemChecker.DefaultName;
            cbsearchmod.SelectedItem = ItemChecker.DefaultName;
            UpdateItemList(m_itemchecker.ItemList);
        }

        private void BAddSubItem_Click(object sender, EventArgs e)
            => TryAddSubItem();

        private void BRemoveSubItem_Click(object sender, EventArgs e)
            => TrySubtractSubItem();

        private void TryAddSubItem()
        {
            if (!lvitems.TryGetSelectedItem(out Item item))
            {
                GUIControl.InfoMessage("Select an item to add first.");
                return;
            }

            if (!tbAddAmount.Text.FractionToDouble(out double amount))
            {
                GUIControl.InfoMessage($"Enter a valid amount to add.{Environment.NewLine}Enter a positive integer, decimal or fraction");
                return;
            }

            if (amount <= 0)
            {
                GUIControl.InfoMessage("Amount to add must be greater than zero.");
                return;
            }

            if (item.ItemName.ToLower() == tbNewItemName.Text.ToLower())
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

            tbAddAmount.Text = "1";
        }
        private void TrySubtractSubItem()
        {
            if (!lvSubItems.TryGetSelectedItem(out KeyValuePair<Item, double> subItem))
            {
                GUIControl.InfoMessage("Select an item to remove first.");
                return;
            }

            if (!tbRemoveAmount.Text.FractionToDouble(out double amount))
            {
                GUIControl.InfoMessage($"Enter a valid amount to remove.{Environment.NewLine}Enter an integer, decimal or fraction");
                return;
            }

            amount = Math.Abs(amount);

            double newvalue = subItem.Value - amount;
            if (newvalue <= 0)
                m_subItems.Remove(subItem.Key);
            else
                m_subItems[subItem.Key] = subItem.Value - amount;

            UpdateSubItems(m_subItems);

            tbRemoveAmount.Text = "1";
        }
        private void ClearNewItem()
        {
            cbNewItemMod.SelectedItem = ItemChecker.DefaultName;
            cbNewItemType.SelectedItem = ItemChecker.DefaultName;

            tbNewItemName.Text = "";
            m_subItems.Clear();
            lvSubItems.Items.Clear();

            lmoditem.Visible = false;
            lmoditemname.Text = ItemChecker.DefaultName;
            lmoditemname.Visible = false;

            m_modifyingItem = false;
            m_moditem = null;
            bCreateItem.Text = "Create";
        }

        private void BClear_Click(object sender, EventArgs e)
            => ClearNewItem();

        private void LvSubItems_DeletePress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            if (!lvSubItems.TryGetSelectedItem(out KeyValuePair<Item, double> subItem))
            {
                GUIControl.InfoMessage("Select an item for deletion first.");
                return;
            }

            m_subItems.Remove(subItem.Key);
            UpdateSubItems(m_subItems);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
            => Close();

        private void Tbsearchname_DelayedTextChanged(object sender, EventArgs e)
            => BFindItem_Click(sender, e);

        private IEnumerable<Item> FindItem()
        {
            string itemName = tbsearchname.Text;
            string type = cbsearchtype.SelectedItem?.ToString();
            string mod = cbsearchmod.SelectedItem?.ToString();

            return m_itemchecker.FindItem(itemName, type, mod);
        }
        private void BImportModify_Click(object sender, EventArgs e)
        {
            if (!lvitems.TryGetSelectedItem(out Item item))
            {
                GUIControl.InfoMessage("Select an item to modify first.");
                return;
            }

            SetModificationItem(item);
        }

        private void SetModificationItem(Item item)
        {
            m_moditem = item ?? throw new ArgumentNullException(nameof(item));

            m_modifyingItem = true;
            m_subItems = new Dictionary<Item, double>(item.Recipe);

            // Set controls
            tbNewItemName.Text = item.ItemName;
            cbNewItemMod.SelectedItem = item.ModName;
            cbNewItemType.SelectedItem = item.Type;
            UpdateSubItems(item.Recipe);

            lmoditem.Visible = true;
            lmoditemname.Visible = true;
            lmoditemname.Text = m_moditem.ItemName;

            bCreateItem.Text = "Save";
        }

        private void Addmod()
        {

            if (string.IsNullOrWhiteSpace(tbmodname.Text))
            {
                GUIControl.InfoMessage("Enter a mod name first.");
                return;
            }

            if (!m_itemchecker.AddNewMod(tbmodname.Text))
            {
                GUIControl.InfoMessage("Mod is already present.");
                return;
            }

            UpdateModControls();
            tbmodname.Text = "";
            m_mainform.UpdateModControls();
        }
        private void BModDelete_Click(object sender, EventArgs e)
        {
            if (lbmods.SelectedItems.Count == 0)
            {
                GUIControl.InfoMessage("Select a mod for deletion first.");
                return;
            }

            if (lbmods.SelectedItems[0].ToString() == ItemChecker.DefaultName)
            {
                GUIControl.InfoMessage("Cannot delete default value.");
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to delete the selected mod?" +
                $"{Environment.NewLine}This will remove this mod from all items!", "Mod Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result != DialogResult.Yes)
                return;

            if (m_itemchecker.DeleteMod(lbmods.SelectedItem.ToString()))
            {
                UpdateModControls();
                m_mainform.UpdateModControls();
            }
        }
        private void BModAdd_Click(object sender, EventArgs e)
            => Addmod();

        private void AddType()
        {
            if (string.IsNullOrWhiteSpace(tbtype.Text))
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

            if (lbtype.SelectedItems[0].ToString() == ItemChecker.DefaultName)
            {
                GUIControl.InfoMessage("Cannot delete default value.");
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to delete the selected Item Type?" +
                $"{Environment.NewLine}This will remove this Item Type from all items!", "Item Type Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result != DialogResult.Yes)
                return;

            if (m_itemchecker.DeleteType(lbtype.SelectedItem.ToString()))
            {
                UpdateTypeControls();
                m_mainform.UpdateItemTypeControls();
            }
        }
        private void BAddType_Click(object sender, EventArgs e)
            => AddType();

        private void Lvitems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedTab == TabNewItem)
                BAddSubItem_Click(sender, e);
        }

        private void Tbsearchname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                BFindItem_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }
        private void TbAddAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                TryAddSubItem();
                e.SuppressKeyPress = true;
            }
        }
        private void TbRemoveAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                TrySubtractSubItem();
                e.SuppressKeyPress = true;
            }
        }
        private void TbNewItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                AddNewItem(m_moditem);
                e.SuppressKeyPress = true;
            }
        }
        private void TbModName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Addmod();
                e.SuppressKeyPress = true;
            }
        }
        private void Tbtype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                AddType();
                e.SuppressKeyPress = true;
            }
        }

        public enum Tabs
        {
            Items,
            ItemTypes,
            Mods
        }
    }
}

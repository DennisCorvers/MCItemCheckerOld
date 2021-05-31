using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using MCItemChecker.Utils;
using System.Threading.Tasks;

namespace MCItemChecker
{
    public partial class MainMenu : Form
    {
        private ItemChecker _itemchecker;
        private NewItem _newItemForm;
        private StartForm _startForm;

        public MainMenu(ItemChecker ItemC, StartForm startform)
        {
            _startForm = startform;
            _itemchecker = ItemC;

            InitializeComponent();
            Text = Path.GetFileName(Properties.Settings.Default.FilePath) + " - MCItemChecker";
            GUIControl.UpdateItemListView(lvitems, _itemchecker.ItemList);

            lvitems.ListViewItemSorter = new ListViewComparer();
            lvcalculateitems.ListViewItemSorter = new ListViewComparer();

            Initlvitems();
            Initlvsubitems();
            Initlvcalculateitems();

            UpdateModPackControls();
            UpdateItemTypeControls();
            cbfiltertype.SelectedItem = "-";
            cbsearchmodpack.SelectedItem = "-";
            cbsearchtype.SelectedItem = "-";

            litemname.Text = "";
            litemtype.Text = "";
            lmodpack.Text = "";
            GUIControl.Sort(lvitems, 0, SortOrder.Ascending);
        }

        public void UpdateModPackControls()
        {
            GUIControl.UpdateControl(_itemchecker.ModPacks, cbsearchmodpack);
        }

        public void UpdateItemTypeControls()
        {
            GUIControl.UpdateControl(_itemchecker.Types, cbsearchtype);
            GUIControl.UpdateControl(_itemchecker.Types, cbfiltertype);
        }

        private void UpdateSubItems(Item item)
        {
            lvsubitems.Items.Clear();
            if (item.Recipe != null)
            {
                foreach (KeyValuePair<Item, double> pair in item.Recipe)
                {
                    var Subitem = new ListViewItem(new[] { pair.Key.ItemID.ToString(), pair.Key.ItemName, pair.Value.ToString(), pair.Key.Type })
                    {
                        Tag = pair.Key
                    };
                    lvsubitems.Items.Add(Subitem);
                    item = null;
                }
            }
        }

        public void UpdateItemList(IEnumerable<Item> Items)
        {
            GUIControl.UpdateItemListView(lvitems, Items);
        }

        private void Initlvsubitems()
        {
            lvsubitems.Scrollable = true;
            lvsubitems.View = View.Details;

            var headers = lvsubitems.Columns;
            headers.Add("Name", 250, HorizontalAlignment.Left);
            headers.Add("Amount", 100, HorizontalAlignment.Left);
            headers.Add("Type", 100, HorizontalAlignment.Left);
        }
        private void Initlvitems()
        {
            lvitems.Scrollable = true;
            lvitems.View = View.Details;

            var headers = lvitems.Columns;
            headers.Add("Name", 275, HorizontalAlignment.Left);
            headers.Add("Type", 125, HorizontalAlignment.Left);
            headers.Add("ModPack", 125, HorizontalAlignment.Left);
        }
        private void Initlvcalculateitems()
        {
            lvcalculateitems.Scrollable = true;
            lvcalculateitems.View = View.Details;

            var headers = lvcalculateitems.Columns;
            headers.Add("Name", 250, HorizontalAlignment.Left);
            headers.Add("Amount", 100, HorizontalAlignment.Left);
            headers.Add("Type", 100, HorizontalAlignment.Left);
        }

        private void LoadItemInfo(ListView listview)
        {
            var item = listview.GetSelectedMCItem();

            litemname.Text = item.ItemName;
            litemtype.Text = item.Type;
            lmodpack.Text = item.ModPack;
            UpdateSubItems(item);
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataStream.SaveFile(_itemchecker, Properties.Settings.Default.FilePath);
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _startForm.UpdateItemC(_itemchecker);
            Close();
            _startForm.Show();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _startForm.UpdateItemC(_itemchecker);
            SaveToolStripMenuItem_Click(sender, e);
            _startForm.Show();
        }
        private void LvItems_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (sender is ListView listView)
                GUIControl.Sort(listView, e.Column);
        }

        private void ManageItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _newItemForm = new NewItem(_itemchecker, this, "Items");
            _newItemForm.ShowDialog();
        }
        private void ManageModPackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _newItemForm = new NewItem(_itemchecker, this, "Modpack");
            _newItemForm.ShowDialog();
        }
        private void ManageItemTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _newItemForm = new NewItem(_itemchecker, this, "Types");
            _newItemForm.ShowDialog();
        }

        private void LvSubItems_DoubleClick(object sender, EventArgs e)
            => LoadItemInfo(lvsubitems);
        private void BFindItem_Click(object sender, EventArgs e)
            => FindItem();

        private void TbSearchNname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                FindItem();
        }
        private void TbSearchId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                FindItem();
        }

        private void FindItem()
        {
            string name = tbsearchname.Text;
            string type = cbsearchtype.SelectedItem?.ToString();
            string modpack = cbsearchmodpack.SelectedItem?.ToString();

            var foundItmes = _itemchecker.FindItem(name, type, modpack);

            GUIControl.UpdateItemListView(lvitems, foundItmes);
        }

        private void BClearSearch_Click(object sender, EventArgs e)
        {
            tbsearchname.Text = "";
            cbsearchtype.SelectedItem = "-";
            cbsearchmodpack.SelectedItem = "-";

            GUIControl.UpdateItemListView(lvitems, _itemchecker.ItemList);
        }
        private void DeleteItem(object sender, EventArgs e)
        {
            if (lvitems.SelectedItems.Count == 0)
            {
                GUIControl.InfoMessage("Select an item for deletion first.");
                return;
            }

            var item = lvitems.GetSelectedMCItem();

            if (_itemchecker.DeleteItem(item.ItemID))
                lvitems.Items.Remove(lvitems.SelectedItems[0]);
        }
        private void LvItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Item Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (result != DialogResult.Yes)
                    return;

                DeleteItem(sender, e);
            }
        }

        private void TbSearchName_TextChanged(object sender, EventArgs e)
            => FindItem();
        private void LvCalculateItems_Click(object sender, EventArgs e)
        {
            if (lvitems.SelectedItems.Count <= 0)
                return;


            double amount = numAmount.Value == 0 ? 1 : (double)numAmount.Value;

            if (tabControl.SelectedTab == TabItemInfo)
            {
                LoadItemInfo(lvitems);
                return;
            }

            if (tabControl.SelectedTab == TabCalculate)
            {
                var item = lvitems.GetSelectedMCItem();
                lcalcitemname.Text = item.ItemName;
                lvcalculateitems.Items.Clear();

                foreach (var itemPair in _itemchecker.CalculateRecipe(item, amount, cbBase.Checked))
                {
                    var lvitem = new ListViewItem(new[] { itemPair.Key.ItemID.ToString(), itemPair.Key.ItemName, itemPair.Key.Type, Math.Round(itemPair.Value, 3).ToString() })
                    {
                        Tag = itemPair.Key
                    };
                    lvcalculateitems.Items.Add(lvitem);
                }

                GUIControl.Sort(lvcalculateitems, 0, SortOrder.Ascending);
            }
        }
        private void NumAmount_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                LvCalculateItems_Click(sender, e);
        }

        private void BCalculateClear_Click(object sender, EventArgs e)
        {
            lcalcitemname.Text = "";
            cbfiltertype.SelectedItem = "-";
            lvcalculateitems.Items.Clear();
            numAmount.Value = 1;
        }
        private void BFilter_Click(object sender, EventArgs e)
            => LvCalculateItems_Click(sender, e);

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            LvCalculateItems_Click(sender, e);
        }
        private void ExportToTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task task = new Task(() =>
            {
                var exporter = new RecipeExporter();
                exporter.WriteToFile(_itemchecker.ItemList);
            });

            task.Start();
        }
        private void CbBase_CheckStateChanged(object sender, EventArgs e)
        {
            LvCalculateItems_Click(sender, e);
        }
    }
}
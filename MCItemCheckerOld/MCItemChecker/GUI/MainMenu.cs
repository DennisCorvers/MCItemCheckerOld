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

        public MainMenu(ItemChecker ItemC)
        {
            _itemchecker = ItemC;

            InitializeComponent();
            Text = Path.GetFileName(Properties.Settings.Default.FilePath) + " - MCItemChecker";

            lvItems.ListViewItemSorter = new ListViewComparer();
            lvCalculatedItems.ListViewItemSorter = new ListViewComparer();

            Initlvitems();
            Initlvsubitems();
            Initlvcalculateitems();

            UpdateModPackControls();
            UpdateItemTypeControls();
            cbfiltertype.SelectedItem = ItemChecker.DefaultName;
            cbSearchModpack.SelectedItem = ItemChecker.DefaultName;
            cbSearchType.SelectedItem = ItemChecker.DefaultName;

            litemname.Text = "";
            litemtype.Text = "";
            lmodpack.Text = "";

            UpdateItemList(_itemchecker.ItemList);
            GUIControl.Sort(lvItems, 0, SortOrder.Ascending);
        }

        public void UpdateModPackControls()
        {
            GUIControl.UpdateControl(_itemchecker.ModPacks, cbSearchModpack);
        }

        public void UpdateItemTypeControls()
        {
            GUIControl.UpdateControl(_itemchecker.Types, cbSearchType);
            GUIControl.UpdateControl(_itemchecker.Types, cbfiltertype);
        }

        private void UpdateSubItems(Item item)
        {
            lvsubitems.Items.Clear();

            if (item.Recipe != null)
            {
                lvsubitems.InsertCollection(item.Recipe, (x) =>
                { return new ListViewItem(new[] { x.Key.ItemName, Math.Round(x.Value, 2).ToString(), x.Key.Type }); });
            }
        }

        private void UpdateItemList()
            => UpdateItemList(_itemchecker.ItemList);

        private void UpdateItemList(IEnumerable<Item> items)
        {
            lvItems.Items.Clear();

            lvItems.InsertCollection(items, (i) =>
            { return new ListViewItem(new[] { i.ItemName, i.Type, i.ModPack }); });
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
            lvItems.Scrollable = true;
            lvItems.View = View.Details;

            var headers = lvItems.Columns;
            headers.Add("Name", 275, HorizontalAlignment.Left);
            headers.Add("Type", 125, HorizontalAlignment.Left);
            headers.Add("ModPack", 125, HorizontalAlignment.Left);
        }
        private void Initlvcalculateitems()
        {
            lvCalculatedItems.Scrollable = true;
            lvCalculatedItems.View = View.Details;

            var headers = lvCalculatedItems.Columns;
            headers.Add("Name", 250, HorizontalAlignment.Left);
            headers.Add("Amount", 100, HorizontalAlignment.Left);
            headers.Add("Type", 100, HorizontalAlignment.Left);
        }

        private void LoadItemInfo(Item item)
        {
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
            Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToolStripMenuItem_Click(sender, e);
        }
        private void LvItems_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (sender is ListView listView)
                GUIControl.Sort(listView, e.Column);
        }

        private void ManageItemsToolStripMenuItem_Click(object sender, EventArgs e)
            => DisplayNewItemForm("Items");
        private void ManageModPackToolStripMenuItem_Click(object sender, EventArgs e)
            => DisplayNewItemForm("Modpack");
        private void ManageItemTypeToolStripMenuItem_Click(object sender, EventArgs e)
            => DisplayNewItemForm("Types");

        private void DisplayNewItemForm(string tab)
        {
            var newItemForm = new NewItem(_itemchecker, this, tab);

            Hide();

            newItemForm.Location = Location;
            newItemForm.ShowDialog();

            Show();
            Location = newItemForm.Location;

            UpdateItemList();
        }

        private void LvSubItems_DoubleClick(object sender, EventArgs e)
        {
            if (lvsubitems.SelectedItems.Count == 0)
                throw new InvalidOperationException();

            var item = (KeyValuePair<Item, double>)lvsubitems.SelectedItems[0].Tag;
            LoadItemInfo(item.Key);
        }

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
            string name = tbSearchName.Text;
            string type = cbSearchType.SelectedItem?.ToString();
            string modpack = cbSearchModpack.SelectedItem?.ToString();

            UpdateItemList(_itemchecker.FindItem(name, type, modpack));
        }

        private void CalculateRecipe()
        {
            if (lvItems.SelectedItems.Count == 0)
                return;

            var baseItem = lvItems.GetSelectedMCItem();
            double amount = numAmount.Value == 0 ? 1 : (double)numAmount.Value;

            lCalculatedItemName.Text = baseItem.ItemName;
            lvCalculatedItems.Items.Clear();

            var selectedType = cbfiltertype.SelectedItem.ToString();
            IEnumerable<KeyValuePair<Item, double>> calculatedItems = _itemchecker.CalculateRecipe(baseItem, amount, cbBase.Checked);

            if (selectedType != ItemChecker.DefaultName)
                calculatedItems = calculatedItems.Where(x => x.Key.Type == selectedType);

            lvCalculatedItems.InsertCollection(calculatedItems, (x) =>
            {
                return new ListViewItem(new string[] { x.Key.ItemName, Math.Round(x.Value, 2).ToString(), x.Key.Type });
            });

            GUIControl.Sort(lvCalculatedItems, 0, SortOrder.Ascending);
        }

        private void BClearSearch_Click(object sender, EventArgs e)
        {
            tbSearchName.Text = "";
            cbSearchType.SelectedItem = ItemChecker.DefaultName;
            cbSearchModpack.SelectedItem = ItemChecker.DefaultName;

            UpdateItemList(_itemchecker.ItemList);
        }

        private void TbSearchName_TextChanged(object sender, EventArgs e)
            => FindItem();
        private void LvCalculateItems_Click(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count == 0)
                return;

            if (tabControl.SelectedTab == TabCalculate)
                CalculateRecipe();

            var item = lvItems.GetSelectedMCItem();
            LoadItemInfo(item);
        }

        private void NumAmount_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                CalculateRecipe();
        }

        private void BCalculateReset_Click(object sender, EventArgs e)
        {
            cbfiltertype.SelectedItem = ItemChecker.DefaultName;
            numAmount.Value = 1;

            CalculateRecipe();
        }
        private void BFilter_Click(object sender, EventArgs e)
            => CalculateRecipe();

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == TabCalculate && lvItems.SelectedItems.Count > 0)
                CalculateRecipe();
        }
        private void ExportToTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task task = new Task(() =>
            {
                RecipeExporter.WriteToFile(_itemchecker.ItemList);
            });

            task.Start();
        }
        private void CbBase_CheckStateChanged(object sender, EventArgs e)
            => CalculateRecipe();
    }
}
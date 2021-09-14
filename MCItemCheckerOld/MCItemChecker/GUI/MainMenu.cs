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
        private ItemChecker m_itemChecker;

        public MainMenu(ItemChecker itemChecker)
        {
            m_itemChecker = itemChecker;

            InitializeComponent();
            Text = Path.GetFileName(MySettings.Properties.FilePath) + " - MCItemChecker";

            lvItems.ListViewItemSorter = new ListViewComparer();

            itemCalculation.Initialize(m_itemChecker);

            Initlvitems();
            Initlvsubitems();

            UpdateModPackControls();
            UpdateItemTypeControls();

            cbSearchModpack.SelectedItem = ItemChecker.DefaultName;
            cbSearchType.SelectedItem = ItemChecker.DefaultName;

            litemname.Text = "";
            litemtype.Text = "";
            lmodpack.Text = "";

            UpdateItemList(m_itemChecker.ItemList);
            GUIControl.Sort(lvItems, 0, SortOrder.Ascending);
        }

        public void UpdateModPackControls()
        {
            GUIControl.UpdateControl(m_itemChecker.ModPacks, cbSearchModpack);
        }

        public void UpdateItemTypeControls()
        {
            GUIControl.UpdateControl(m_itemChecker.Types, cbSearchType);
            itemCalculation.UpdateTypes(m_itemChecker.Types);
        }

        private void UpdateSubItems(Item item)
        {
            lvsubitems.Items.Clear();

            if (item.Recipe != null)
            {
                lvsubitems.InsertCollection(item.Recipe, (x) =>
                { return new ListViewItem(new[] { x.Key.ItemName, x.Value.ToString(2), x.Key.Type }); });
            }
        }

        private void UpdateItemList()
            => UpdateItemList(m_itemChecker.ItemList);

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

        private void LoadItemInfo(Item item)
        {
            litemname.Text = item.ItemName;
            litemtype.Text = item.Type;
            lmodpack.Text = item.ModPack;
            UpdateSubItems(item);
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
            => DataStream.SaveFile(m_itemChecker, MySettings.Properties.FilePath);
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
            => Close();
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            => SaveToolStripMenuItem_Click(sender, e);
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
            var newItemForm = new NewItem(m_itemChecker, this, tab);

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

        private void FindItem()
        {
            string name = tbSearchName.Text;
            string type = cbSearchType.SelectedItem?.ToString();
            string modpack = cbSearchModpack.SelectedItem?.ToString();

            UpdateItemList(m_itemChecker.FindItem(name, type, modpack));
        }

        private void BClearSearch_Click(object sender, EventArgs e)
        {
            tbSearchName.Text = "";
            cbSearchType.SelectedItem = ItemChecker.DefaultName;
            cbSearchModpack.SelectedItem = ItemChecker.DefaultName;

            UpdateItemList(m_itemChecker.ItemList);
        }

        private void TbSearchName_TextChanged(object sender, EventArgs e)
            => FindItem();

        private void LvCalculateItems_Click(object sender, EventArgs e)
        {
            if (lvItems.TryGetSelectedItem(out Item i))
                LoadItemInfo(i);
        }

        private void BCalculateReset_Click(object sender, EventArgs e)
            => itemCalculation.Reset();

        private void BCalculate_Click(object sender, EventArgs e)
        {
            if (lvItems.TryGetSelectedItem(out Item i))
                itemCalculation.CalculateItem(i);
            else
                itemCalculation.CalculateItem();
        }

        private void ExportToTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task task = new Task(() =>
            {
                RecipeExporter.WriteToFile(m_itemChecker.ItemList);
            });

            task.Start();
        }

        private void TbSearchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                FindItem();
                e.SuppressKeyPress = true;
            }
        }

        private void lvItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tabControl.SelectedTab == TabCalculate)
                itemCalculation.CalculateItem(lvItems.GetSelectedItem<Item>());
        }
    }
}
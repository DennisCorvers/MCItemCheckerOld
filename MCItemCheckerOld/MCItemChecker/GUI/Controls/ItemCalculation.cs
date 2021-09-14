using MCItemChecker.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MCItemChecker.GUI.Controls
{
    public partial class ItemCalculation : UserControl
    {
        private ItemChecker m_itemChecker;
        private CalculationInfo m_lastItem;

        public ItemCalculation()
        {
            InitializeComponent();
        }

        public void Initialize(ItemChecker itemChecker)
        {
            m_itemChecker = itemChecker;

            cbfiltertype.SelectedItem = ItemChecker.DefaultName;

            lvCalculatedItems.ListViewItemSorter = new ListViewComparer();
            lvCalculatedItems.Scrollable = true;
            lvCalculatedItems.View = View.Details;

            var headers = lvCalculatedItems.Columns;
            headers.Add("Name", 250, HorizontalAlignment.Left);
            headers.Add("Amount", 100, HorizontalAlignment.Left);
            headers.Add("Type", 100, HorizontalAlignment.Left);
        }

        public void CalculateItem(Item baseItem)
        {
            if (baseItem == null)
                throw new ArgumentNullException(nameof(baseItem));

            m_lastItem = new CalculationInfo(baseItem);

            lCalculatedItemName.Text = baseItem.ItemName;
            lvCalculatedItems.Items.Clear();

            var amount = numAmount.Value == 0 ? 1 : (double)numAmount.Value;
            var selectedType = cbfiltertype.SelectedItem.ToString();
            IEnumerable<KeyValuePair<Item, double>> calculatedItems = m_itemChecker.CalculateRecipe(baseItem, amount, cbBase.Checked);

            if (selectedType != ItemChecker.DefaultName)
                calculatedItems = calculatedItems.Where(x => x.Key.Type == selectedType);

            lvCalculatedItems.InsertCollection(calculatedItems, (x) =>
            {
                return new ListViewItem(new string[] { x.Key.ItemName, x.Value.ToString(2), x.Key.Type });
            });

            GUIControl.Sort(lvCalculatedItems, 0, SortOrder.Ascending);
        }

        public void CalculateItem()
        {
            if (!m_lastItem.HasValue)
            {
                GUIControl.InfoMessage("Please select an item to calculate first.");
                return;
            }

            CalculateItem(m_lastItem.Item);
        }

        public void UpdateTypes(IEnumerable<string> types)
            => GUIControl.UpdateControl(types, cbfiltertype);

        public void Reset()
        {
            lCalculatedItemName.Text = string.Empty;

            cbfiltertype.SelectedItem = ItemChecker.DefaultName;
            lvCalculatedItems.Items.Clear();

            numAmount.Value = 1;

            m_lastItem = default;
        }

        private void MarkItemAsDone()
        {
            if (lvCalculatedItems.SelectedItems.Count == 0)
                return;

            var selectedItems = lvCalculatedItems.GetSelectedListViewItems();
            if (selectedItems.All(x => x.BackColor == Colour.SelectedDone))
            {
                PaintItems(Colour.Transparent);
            }
            else
            {
                PaintItems(Colour.SelectedDone);
            }

            void PaintItems(Colour newColour)
            {
                foreach (var item in selectedItems)
                    item.BackColor = newColour;

                selectedItems.Clear();
            }
        }

        private void CbBase_CheckStateChanged(object sender, EventArgs e)
            => CalculateItem();

        private void NumAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                CalculateItem();
                e.SuppressKeyPress = true;
            }
        }

        private void LvCalculatedItems_MouseDoubleClick(object sender, MouseEventArgs e)
            => MarkItemAsDone();

        private void LvCalculatedItems_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                    {
                        MarkItemAsDone();
                        break;
                    }
                case Keys.Delete:
                    {
                        break;
                    }
                default:
                    return;
            }
        }


        private struct CalculationInfo
        {
            public Item Item
            { get; }

            public bool HasValue
                => Item != null;

            public CalculationInfo(Item item)
            {
                Item = item ?? throw new ArgumentNullException(nameof(item));
            }
        }
    }
}

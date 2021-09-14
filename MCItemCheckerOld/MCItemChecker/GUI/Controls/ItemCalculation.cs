using MCItemChecker.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Recipe = System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<MCItemChecker.Item, double>>;

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
            {
                if (m_lastItem.HasValue)
                    baseItem = m_lastItem.Item;
                else
                    GUIControl.InfoMessage("Select an item to calculate first.");
            }

            var amount = numAmount.Value == 0 ? 1 : (double)numAmount.Value;

            // Calculate the recipe for the given item.
            var calculatedItems = m_itemChecker.CalculateRecipe(baseItem, amount, cbBase.Checked);

            SetCalculatedInfo(new CalculationInfo(baseItem, calculatedItems));
        }

        private void SetCalculatedInfo(CalculationInfo info)
        {
            if (!info.HasValue)
                throw new ArgumentNullException(nameof(info));

            m_lastItem = info;
            lCalculatedItemName.Text = info.Item.ItemName;

            Recipe calculatedItems = info.Recipe;

            var selectedType = cbfiltertype.SelectedItem.ToString();
            if (selectedType != ItemChecker.DefaultName)
                calculatedItems = calculatedItems.Where(x => x.Key.Type == selectedType);

            // Display the items and sort
            lvCalculatedItems.Items.Clear();
            lvCalculatedItems.InsertCollection(calculatedItems, (x) =>
            {
                return new ListViewItem(new string[] { x.Key.ItemName, x.Value.ToString(2), x.Key.Type });
            });

            GUIControl.Sort(lvCalculatedItems, 0, SortOrder.Ascending);
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

        private void RemoveItem()
        {
            if (!m_lastItem.HasValue)
                return;

            if (lvCalculatedItems.SelectedItems.Count > 1)
                GUIControl.InfoMessage("Can only remove one item at a time.");

            if (!lvCalculatedItems.TryGetSelectedItem(out KeyValuePair<Item, double> subitem))
                GUIControl.InfoMessage("No item selected for removal.");

            // Calculate main item.
            var item = m_lastItem.Item;
            var mainRecipe = m_lastItem.Recipe;

            // Calculate item marked for deletion.
            var subRecipe = m_itemChecker.CalculateRecipe(subitem.Key, subitem.Value, cbBase.Checked);

            // Subtract the main sub item
            SubtractRecipe(mainRecipe, subitem);

            // Subtract the sub items
            SubtractRecipes(mainRecipe, subRecipe);

            // Display the results
            SetCalculatedInfo(new CalculationInfo(item, mainRecipe));
        }

        private void SubtractRecipes(Dictionary<Item, double> original, Dictionary<Item, double> subtraction)
        {
            foreach (var item in subtraction)
                SubtractRecipe(original, item);
        }

        private void SubtractRecipe(Dictionary<Item, double> original, KeyValuePair<Item, double> subtraction)
        {
            if (!original.TryGetValue(subtraction.Key, out double oldValue))
                return;

            var newValue = oldValue - subtraction.Value;
            if (newValue <= 0)
                original.Remove(subtraction.Key);
            else
                original[subtraction.Key] = newValue;
        }


        private void CbBase_CheckStateChanged(object sender, EventArgs e)
            => CalculateItem(m_lastItem.Item);

        private void NumAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                CalculateItem(m_lastItem.Item);
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
                        RemoveItem();
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

            public Dictionary<Item, double> Recipe
            { get; }

            public bool HasValue
                => Item != null;

            public CalculationInfo(Item item, Dictionary<Item, double> recipe)
            {
                Item = item ?? throw new ArgumentNullException(nameof(item));
                Recipe = recipe ?? throw new ArgumentNullException(nameof(recipe));
            }
        }
    }
}

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
        private readonly ContextMenu m_contextMenu;

        private ItemChecker m_itemChecker;
        private CalculationInfo m_lastItem;

        private bool HasLastItem
            => m_lastItem != null;

        public ItemCalculation()
        {
            InitializeComponent();

            var markMenuItem = new MenuItem("Mark");
            markMenuItem.Click += (object sender, EventArgs e) => MarkItemAsDone();

            var removeMenuItem = new MenuItem("Remove...");
            removeMenuItem.Click += RemoveItem_Click;

            var removeAllMenuItem = new MenuItem("Remove all");
            removeAllMenuItem.Click += (object sender, EventArgs e) => RemoveItem();

            m_contextMenu = new ContextMenu(new[] { markMenuItem, removeMenuItem, removeAllMenuItem });
        }

        public void Initialize(ItemChecker itemChecker)
        {
            m_itemChecker = itemChecker;

            cbfiltertype.SelectedItem = Constants.DefaultName;

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
                if (HasLastItem)
                    baseItem = m_lastItem.Item;
                else
                {
                    GUIControl.InfoMessage("Select an item to calculate first.");
                    return;
                }
            }

            var amount = numAmount.Value == 0 ? 1 : (double)numAmount.Value;

            // Calculate the recipe for the given item.
            var calculatedItems = RecipeCalculator.CalculateRecipe(baseItem, amount, cbBase.Checked);
            m_lastItem = new CalculationInfo(baseItem, calculatedItems);

            SetCalculatedInfo(m_lastItem);
        }

        public void AddItem(Item item, double amount)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var calcAmount = numAmount.Value == 0 ? 1 : (double)numAmount.Value;
            var isBaseItem = cbBase.Checked;
            Item shoppingList;

            if (HasLastItem)
            {
                // Re-use recipe, or create new shopping list
                if (m_lastItem.IsCustomItem)
                    shoppingList = m_lastItem.Item;
                else
                    shoppingList = CreateShoppingList(m_lastItem.Item.Recipe);

                shoppingList.Recipe.AddItem(new KeyValuePair<Item, double>(item, amount));
            }
            else
            {
                shoppingList = CreateShoppingList(new KeyValuePair<Item, double>(item, amount));
            }

            var calculatedItems = RecipeCalculator.CalculateRecipe(shoppingList, calcAmount, isBaseItem);
            m_lastItem = new CalculationInfo(shoppingList, calculatedItems, true);

            SetCalculatedInfo(m_lastItem);
        }

        private void SetCalculatedInfo(CalculationInfo info)
        {
            lCalculatedItemName.Text = info.Item.ItemName;

            Recipe calculatedItems = info.CalculatedRecipe;

            var selectedType = cbfiltertype.SelectedItem.ToString();
            if (selectedType != Constants.DefaultName)
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

            cbfiltertype.SelectedItem = Constants.DefaultName;
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
            if (!HasLastItem)
                return;

            if (lvCalculatedItems.SelectedItems.Count > 1)
            {
                GUIControl.InfoMessage("Can only remove one item at a time.");
                return;
            }

            if (!lvCalculatedItems.TryGetSelectedItem(out KeyValuePair<Item, double> subitem))
            {
                GUIControl.InfoMessage("No item selected for removal.");
                return;
            }

            RemoveItem(subitem);
        }

        private void RemoveItem(KeyValuePair<Item, double> subItem)
        {
            // Calculate main item.
            var mainRecipe = m_lastItem.CalculatedRecipe;

            // Calculate item marked for deletion.
            var subRecipe = RecipeCalculator.CalculateRecipe(subItem.Key, subItem.Value, cbBase.Checked);

            // Subtract the main sub item
            mainRecipe.SubtractItem(subItem);

            // Subtract the sub items
            mainRecipe.SubtractRecipes(subRecipe);

            // Display the results
            SetCalculatedInfo(m_lastItem);
        }


        public static Item CreateShoppingList(KeyValuePair<Item, double> item)
        {
            var recipe = new Dictionary<Item, double>(1)
            {
                { item.Key, item.Value }
            };
            return CreateShoppingList(recipe);
        }

        public static Item CreateShoppingList(Dictionary<Item, double> recipe)
        {
            return new Item("Shopping List", Constants.DefaultName, Constants.DefaultName, recipe.Copy());
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

        private void LvCalculatedItems_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = lvCalculatedItems.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    m_contextMenu.Show(lvCalculatedItems, e.Location);
                }
            }
        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            if (!lvCalculatedItems.TryGetSelectedItem(out KeyValuePair<Item, double> kvItem))
                return;

            var item = kvItem.Key;

            InputBox input = new InputBox("Enter amount...", $"Enter amount of \"{item.ItemName}\" to remove.");

            // Keep asking for valid input using the same WinForm...
            while (input.ShowDialog() == DialogResult.OK)
            {
                if (!input.Result.FractionToDouble(out double amountToRemove))
                {
                    GUIControl.InfoMessage($"Enter a valid amount to add.{Environment.NewLine}Enter a positive integer, decimal or fraction");
                    continue;
                }

                // Remove nothing...
                if (amountToRemove <= 0)
                    return;

                // Clamp entered amount to original amount.
                if (amountToRemove >= kvItem.Value)
                    amountToRemove = kvItem.Value;

                RemoveItem(new KeyValuePair<Item, double>(item, amountToRemove));
                break;
            }
        }


        private class CalculationInfo
        {
            public Item Item
            { get; }

            public Dictionary<Item, double> CalculatedRecipe
            { get; }

            public bool IsCustomItem
            { get; }

            public CalculationInfo(Item item, Dictionary<Item, double> recipe, bool isCustomItem = false)
            {
                Item = item ?? throw new ArgumentNullException(nameof(item));
                CalculatedRecipe = recipe ?? throw new ArgumentNullException(nameof(recipe));
                IsCustomItem = isCustomItem;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCItemChecker
{
    [Serializable]
    public class ItemChecker
    {
        public readonly Dictionary<int, Item> Items = new Dictionary<int, Item>();

        public readonly HashSet<string> ModPacks = new HashSet<string>();
        public readonly HashSet<string> Types = new HashSet<string>();

        private int m_lastItemId = 0;
        private readonly HashSet<string> m_itemNameLookup = new HashSet<string>();
        private Dictionary<Item, double> CraftingRecipe;

        public ItemChecker()
        {
            ModPacks.Add("-");
            Types.Add("-");
        }


        public bool AddNewType(string type)
        {
            if (Types.Contains(type))
            {
                return false;
            }
            Types.Add(type);
            return true;
        }

        public bool DeleteType(string type)
        {
            if (Types.Contains(type))
            {
                Types.Remove(type);
                return true;
            }
            return false;
        }


        public bool AddNewModPack(string modpack)
        {
            if (ModPacks.Contains(modpack))
            {
                return false;
            }
            ModPacks.Add(modpack);
            return true;
        }

        public bool DeleteModPack(string modpack)
        {
            if (ModPacks.Contains(modpack))
            {
                ModPacks.Remove(modpack);
                return true;
            }
            return false;
        }


        public bool AddNewItem(Item item)
        {
            if (m_itemNameLookup.Contains(item.ItemName.ToLower()))
                return false;

            item.ItemID = m_lastItemId++;
            Items.Add(m_lastItemId, item);

            m_itemNameLookup.Add(item.ItemName.ToLower());

            return true;
        }

        public bool DeleteItem(int itemId)
        {
            if (Items.TryGetValue(itemId, out Item value))
                m_itemNameLookup.Remove(value.ItemName.ToLower());

            return value != null;
        }

        public void EditItem(Item newItem, Item oldItem)
        {
            if (!m_itemNameLookup.Contains(oldItem.ItemName.ToLower()))
            {
                if (Items.ContainsKey(newItem.ItemID))
                    throw new InvalidOperationException("Old name doesn't exist but item is a known item.");
            }

            if (m_itemNameLookup.Contains(newItem.ItemName.ToLower()))
                throw new InvalidOperationException("Item name already exists.");

            m_itemNameLookup.Remove(oldItem.ItemName.ToLower());
            m_itemNameLookup.Add(newItem.ItemName.ToLower());
        }

        public IEnumerable<Item> FindItem(string itemname = null, string type = null, string modpack = null, Dictionary<Item, double> craftingneed = null)
        {
            IEnumerable<Item> result = Items.Values;

            if (!string.IsNullOrWhiteSpace(itemname))
                result = result.Where(x => x.ItemName.ToLower().Contains(itemname.ToLower()));

            if (!string.IsNullOrWhiteSpace(type) && type != "-")
                result = result.Where(x => x.Type == type);

            if (!string.IsNullOrWhiteSpace(modpack) && modpack != "-")
                result = result.Where(x => x.ModPack == modpack);

            if (craftingneed != null)
                result = result.Where(x => x.Craftingneed == craftingneed);

            return result;
        }

        private void CraftingList(Dictionary<Item, double> recipe, double amount, ref Dictionary<Item, double> CraftingRecipe)
        {
            double Tamount = 0;
            foreach (KeyValuePair<Item, double> pair in recipe)
            {
                if (CraftingRecipe.ContainsKey(pair.Key))
                {
                    CraftingRecipe[pair.Key] += pair.Value * amount;
                }
                else
                {
                    CraftingRecipe.Add(pair.Key, (pair.Value * amount));
                }

                if (pair.Key.Craftingneed.Count <= 0)
                    continue;

                Tamount = pair.Value * amount;
                CraftingList(pair.Key.Craftingneed, Tamount, ref CraftingRecipe);
            }
        }

        private void CraftingListBase(Dictionary<Item, double> recipe, double amount, ref Dictionary<Item, double> CraftingRecipe)
        {
            double Tamount = 0;
            foreach (KeyValuePair<Item, double> pair in recipe)
            {
                if (pair.Key.Craftingneed.Count <= 0)
                {
                    if (CraftingRecipe.ContainsKey(pair.Key))
                    {
                        CraftingRecipe[pair.Key] += pair.Value * amount;
                    }
                    else
                    {
                        CraftingRecipe.Add(pair.Key, pair.Value * amount);
                    }

                    continue;
                }
                Tamount = pair.Value * amount;
                CraftingListBase(pair.Key.Craftingneed, Tamount, ref CraftingRecipe);
            }
        }

        /// <summary>
        /// Creates a new dictionary and calls the CraftingList method for filling the dictionary.
        /// </summary>
        /// <param name="item">The item that needs to be calculated upon.</param>
        /// <param name="amount">The amount of the specified item.</param>
        /// <returns>Returns a dictionary filled with items needed to craft the required item.</returns>
        public Dictionary<Item, double> CalculateRecipe(Item item, double amount, bool returnbase = false)
        {
            CraftingRecipe = null;
            CraftingRecipe = new Dictionary<Item, double>();

            if (returnbase)
            {
                CraftingListBase(item.Craftingneed, amount, ref CraftingRecipe);
                return CraftingRecipe;
            }

            CraftingList(item.Craftingneed, amount, ref CraftingRecipe);
            return CraftingRecipe;
        }
    }
}

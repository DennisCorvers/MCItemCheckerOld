using MCItemChecker.Utils;
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
        public IEnumerable<Item> ItemList
            => m_items.Values;
        public IEnumerable<string> ModPacks
            => m_modpacks;
        public IEnumerable<string> Types
            => m_itemTypes;

        private readonly Dictionary<int, Item> m_items = new Dictionary<int, Item>();
        private readonly HashSet<string> m_modpacks = new HashSet<string>();
        private readonly HashSet<string> m_itemTypes = new HashSet<string>();

        private int m_lastItemId = 0;
        private readonly HashSet<string> m_itemNameLookup = new HashSet<string>();
        private Dictionary<Item, double> CraftingRecipe;

        public ItemChecker()
        {
            m_modpacks.Add("-");
            m_itemTypes.Add("-");
        }


        public bool AddNewType(string type)
        {
            if (m_itemTypes.Contains(type))
            {
                return false;
            }
            m_itemTypes.Add(type.ToFirstLetterUpperCase());
            return true;
        }

        public bool DeleteType(string type)
        {
            if (m_itemTypes.Contains(type))
            {
                m_itemTypes.Remove(type);
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

            m_modpacks.Add(modpack.ToFirstLetterUpperCase());
            return true;
        }

        public bool DeleteModPack(string modpack)
        {
            if (ModPacks.Contains(modpack))
            {
                m_modpacks.Remove(modpack);
                return true;
            }
            return false;
        }


        public bool AddNewItem(Item item)
        {
            if (m_itemNameLookup.Contains(item.ItemName.ToLower()))
                return false;

            item.ItemID = m_lastItemId++;
            m_items.Add(m_lastItemId, item);

            m_itemNameLookup.Add(item.ItemName.ToLower());

            return true;
        }

        public bool DeleteItem(int itemId)
        {
            if (m_items.TryGetValue(itemId, out Item value))
            {
                m_itemNameLookup.Remove(value.ItemName.ToLower());
                m_items.Remove(itemId);
            }

            return value != null;
        }

        public bool EditItem(Item newItem, Item oldItem)
        {
            if (!m_itemNameLookup.Contains(oldItem.ItemName.ToLower()))
            {
                if (m_items.ContainsKey(newItem.ItemID))
                    return false;
            }

            if (m_itemNameLookup.Contains(newItem.ItemName.ToLower()))
                return false;

            m_itemNameLookup.Remove(oldItem.ItemName.ToLower());
            m_itemNameLookup.Add(newItem.ItemName.ToLower());
            oldItem.CopyFrom(newItem);

            return true;
        }

        public IEnumerable<Item> FindItem(string itemname = null, string type = null, string modpack = null, Dictionary<Item, double> craftingneed = null)
        {
            IEnumerable<Item> result = m_items.Values;

            if (!string.IsNullOrWhiteSpace(itemname))
                result = result.Where(x => x.ItemName.ToLower().Contains(itemname.ToLower()));

            if (!string.IsNullOrWhiteSpace(type) && type != "-")
                result = result.Where(x => x.Type == type);

            if (!string.IsNullOrWhiteSpace(modpack) && modpack != "-")
                result = result.Where(x => x.ModPack == modpack);

            if (craftingneed != null)
                result = result.Where(x => x.Recipe == craftingneed);

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

                if (pair.Key.Recipe.Count <= 0)
                    continue;

                Tamount = pair.Value * amount;
                CraftingList(pair.Key.Recipe, Tamount, ref CraftingRecipe);
            }
        }

        private void CraftingListBase(Dictionary<Item, double> recipe, double amount, ref Dictionary<Item, double> CraftingRecipe)
        {
            double Tamount = 0;
            foreach (KeyValuePair<Item, double> pair in recipe)
            {
                if (pair.Key.Recipe.Count <= 0)
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
                CraftingListBase(pair.Key.Recipe, Tamount, ref CraftingRecipe);
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
                CraftingListBase(item.Recipe, amount, ref CraftingRecipe);
                return CraftingRecipe;
            }

            CraftingList(item.Recipe, amount, ref CraftingRecipe);
            return CraftingRecipe;
        }
    }
}

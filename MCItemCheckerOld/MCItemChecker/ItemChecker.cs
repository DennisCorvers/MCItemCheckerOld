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
        internal const string NonDefinedChar = "-";
        private const int MaxRecursionCount = 128;

        public IEnumerable<Item> ItemList
            => m_items.Values;
        public IEnumerable<string> ModPacks
            => m_modpacks;
        public IEnumerable<string> Types
            => m_itemTypes;

        private readonly Dictionary<int, Item> m_items = new Dictionary<int, Item>();
        private readonly HashSet<string> m_itemNameLookup = new HashSet<string>();
        private readonly HashSet<string> m_modpacks = new HashSet<string>();
        private readonly HashSet<string> m_itemTypes = new HashSet<string>();

        private int m_lastItemId = 0;

        public ItemChecker()
        {
            m_modpacks.Add(NonDefinedChar);
            m_itemTypes.Add(NonDefinedChar);
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

                foreach (var item in m_items.Values)
                {
                    if (item.Type == type)
                        item.Type = NonDefinedChar;
                }
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

                foreach (var item in m_items.Values)
                {
                    if (item.ModPack == modpack)
                        item.ModPack = NonDefinedChar;
                }

                return true;
            }
            return false;
        }


        public bool AddNewItem(Item item)
        {
            if (m_itemNameLookup.Contains(item.ItemName.ToLower()))
                return false;

            item.ItemID = m_lastItemId;
            m_items.Add(m_lastItemId, item);

            m_itemNameLookup.Add(item.ItemName.ToLower());

            m_lastItemId++;
            return true;
        }

        public bool DeleteItem(int itemId)
        {
            if (m_items.TryGetValue(itemId, out Item value))
            {
                m_itemNameLookup.Remove(value.ItemName.ToLower());
                m_items.Remove(itemId);

                foreach (var item in m_items.Values)
                    item.Recipe.Remove(value);
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

            if (newItem.ItemName != oldItem.ItemName && m_itemNameLookup.Contains(newItem.ItemName.ToLower()))
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

            if (!string.IsNullOrWhiteSpace(type) && type != NonDefinedChar)
                result = result.Where(x => x.Type == type);

            if (!string.IsNullOrWhiteSpace(modpack) && modpack != NonDefinedChar)
                result = result.Where(x => x.ModPack == modpack);

            if (craftingneed != null)
                result = result.Where(x => x.Recipe == craftingneed);

            return result;
        }


        private void CalculateItemRecipe(Item item, double amount, bool isBaseItem, Dictionary<Item, double> craftingRecipe, int recursionCount)
        {
            if (++recursionCount >= MaxRecursionCount)
                return;

            foreach (var pair in item.Recipe)
            {
                if (isBaseItem)
                {
                    if (pair.Key.Recipe.Count <= 0)
                    {
                        AddToRecipe(pair);
                        continue;
                    }
                }
                else
                {
                    AddToRecipe(pair);

                    if (pair.Key.Recipe.Count <= 0)
                        continue;
                }

                double tempAmount = amount * pair.Value;
                CalculateItemRecipe(pair.Key, tempAmount, isBaseItem, craftingRecipe, recursionCount);
            }

            void AddToRecipe(KeyValuePair<Item, double> recipeItem)
            {
                if (craftingRecipe.ContainsKey(recipeItem.Key))
                    craftingRecipe[recipeItem.Key] += recipeItem.Value * amount;
                else
                    craftingRecipe.Add(recipeItem.Key, recipeItem.Value * amount);
            }
        }

        /// <summary>
        /// Collects all the required items and their amounts to craft the requested item.
        /// </summary>
        /// <param name="item">The item to find the required items for.</param>
        /// <param name="amount">The start amount</param>
        /// <param name="returnbase">TRUE if only the last items in the chain should be collected.</param>
        public Dictionary<Item, double> CalculateRecipe(Item item, double amount = 1, bool returnbase = false)
        {
            var recipe = new Dictionary<Item, double>();

            CalculateItemRecipe(item, amount, returnbase, recipe, 0);

            return recipe;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using MCItemChecker.Utils;

namespace MCItemChecker
{
    [Serializable]
    [DebuggerDisplay("Name = {ItemName}")]
    public class Item : IEquatable<Item>
    {
#pragma warning disable IDE0032
        private int m_itemId;
        private string m_itemName;
        private string m_itemType;
        private string m_modpack;
        private Dictionary<Item, double> m_recipe;
#pragma warning restore

        public int ItemID
        {
            get => m_itemId;
            set => m_itemId = value;
        }
        public string ItemName
        {
            get => m_itemName;
            private set => m_itemName = value.ToFirstLetterUpperCase();
        }
        public string Type
            => m_itemType;
        public string ModPack
            => m_modpack;
        public Dictionary<Item, double> Recipe
            => m_recipe;

        public Item(string itemname, string type, string modpack)
        {
            ItemName = itemname;
            m_itemType = type;
            m_modpack = modpack;
            m_recipe = new Dictionary<Item, double>();
        }

        public Item(string itemname, string type, string modpack, Dictionary<Item, double> recipe)
        {
            if (recipe == null)
                throw new ArgumentException(nameof(recipe));

            ItemName = itemname;
            m_itemType = type;
            m_modpack = modpack;
            m_recipe = new Dictionary<Item, double>(recipe);
        }

        public void CopyFrom(Item other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            m_itemName = other.m_itemName;
            m_itemType = other.m_itemType;
            m_modpack = other.m_modpack;
            m_recipe = other.m_recipe;
        }

        public bool Equals(Item other)
        {
            if (other == null)
                return false;

            return other.ItemID == ItemID;
        }
    }
}

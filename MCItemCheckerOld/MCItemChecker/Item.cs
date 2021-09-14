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
        private string m_mod;
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
        {
            get => m_itemType;
            set => m_itemType = value;
        }
        public string ModName
        {
            get => m_mod;
            set => m_mod = value;
        }
        public Dictionary<Item, double> Recipe
            => m_recipe;

        public Item(string itemname, string type, string mod)
        {
            ItemName = itemname;
            m_itemType = type;
            m_mod = mod;
            m_recipe = new Dictionary<Item, double>();
        }

        public Item(string itemname, string type, string mod, Dictionary<Item, double> recipe)
        {
            if (recipe == null)
                throw new ArgumentException(nameof(recipe));

            ItemName = itemname;
            m_itemType = type;
            m_mod = mod;
            m_recipe = new Dictionary<Item, double>(recipe);
        }

        public void CopyFrom(Item other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            m_itemName = other.m_itemName;
            m_itemType = other.m_itemType;
            m_mod = other.m_mod;
            m_recipe = other.m_recipe;
        }


        public bool Equals(Item other)
        {
            if (ReferenceEquals(this, other))
                return true;

            if (other is null)
                return false;

            return other.ItemID == ItemID;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Item);
        }

        public override int GetHashCode()
        {
            return m_itemId;
        }

        public static bool operator ==(Item left, Item right)
        {
            if (left is null)
                return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(Item left, Item right)
        {
            return !(left == right);
        }
    }
}

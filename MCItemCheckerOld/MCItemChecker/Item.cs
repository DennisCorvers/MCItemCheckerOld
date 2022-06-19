using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using MCItemChecker.Utils;
using Newtonsoft.Json;
using ProtoBuf;

namespace MCItemChecker
{
    [Serializable]
    [DebuggerDisplay("Name = {ItemName}")]
    [ProtoContract]
    public class Item : IEquatable<Item>
    {
#pragma warning disable IDE0032
        [ProtoMember(1)]
        private int m_itemId;
        [ProtoMember(2)]
        private string m_itemName;
        [ProtoMember(3)]
        private string m_itemType;
        [ProtoMember(4)]
        private string m_mod;
        [ProtoMember(6)]
        private Dictionary<int, double> m_recipeReferences;
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
        public Dictionary<Item, double> Recipe { get; private set; }

        // Parameterless constructor required for serializers.
        private Item() { }

        public Item(string itemname, string type, string mod)
            : this(itemname, type, mod, new Dictionary<Item, double>(0))
        { }

        public Item(string itemname, string type, string mod, Dictionary<Item, double> recipe)
        {
            ItemName = itemname;
            m_itemType = type;
            m_mod = mod;
            Recipe = recipe ?? throw new ArgumentException(nameof(recipe));
        }

        public void CopyFrom(Item other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            m_itemName = other.m_itemName;
            m_itemType = other.m_itemType;
            m_mod = other.m_mod;
            Recipe = new Dictionary<Item, double>(other.Recipe);
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

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            m_recipeReferences = Recipe.ToDictionary(x => x.Key.m_itemId, x => x.Value);
        }

        internal void OnDeserializing(ItemChecker itemChecker)
        {
            if (m_recipeReferences != null)
            {
                Recipe = new Dictionary<Item, double>(m_recipeReferences.Count);
                foreach (var pair in m_recipeReferences)
                {
                    Recipe.Add(itemChecker.FindItem(pair.Key), pair.Value);
                }
            }
            else
            {
                Recipe = new Dictionary<Item, double>(0);
            }
        }
    }
}

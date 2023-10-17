using MCItemChecker.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using ProtoBuf;
using System.Runtime.CompilerServices;

namespace MCItemChecker
{
    [Serializable]
    [ProtoContract]
    public class ItemChecker
    {
        public IEnumerable<Item> ItemList
            => m_items.Values;
        public IEnumerable<string> Mods
            => m_modpacks;
        public IEnumerable<string> Types
            => m_itemTypes;
        public int LastUID
            => m_lastItemId;

        private HashSet<string> m_mods
            => m_modpacks;

        private readonly HashSet<string> m_itemNameLookup;

#pragma warning disable IDE0044 // Readonly modifier not possible with ProtoBuf
        [ProtoMember(1)]
        private HashSet<string> m_modpacks = new HashSet<string>();
        [ProtoMember(2)]
        private Dictionary<int, Item> m_items = new Dictionary<int, Item>();
        [ProtoMember(3)]
        private HashSet<string> m_itemTypes = new HashSet<string>();
        [ProtoMember(4)]
        private int m_lastItemId = 0;
#pragma warning restore IDE0044

        public ItemChecker()
        {
            m_mods.Add(Constants.DefaultName);
            m_itemTypes.Add(Constants.DefaultName);
            m_itemNameLookup = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            // Assemble item name lookup table
            foreach (var item in m_items)
            {
                item.Value.OnDeserializing(this);
                m_itemNameLookup.Add(item.Value.ItemName);
            }
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
                        item.Type = Constants.DefaultName;
                }
                return true;
            }
            return false;
        }


        public bool AddNewMod(string mod)
        {
            if (Mods.Contains(mod))
            {
                return false;
            }

            m_mods.Add(mod.ToFirstLetterUpperCase());
            return true;
        }

        public bool DeleteMod(string mod)
        {
            if (Mods.Contains(mod))
            {
                m_mods.Remove(mod);

                foreach (var item in m_items.Values)
                {
                    if (item.ModName == mod)
                        item.ModName = Constants.DefaultName;
                }

                return true;
            }
            return false;
        }


        public bool AddNewItem(Item item)
        {
            if (m_itemNameLookup.Contains(item.ItemName))
                return false;

            item.ItemID = m_lastItemId;
            m_items.Add(m_lastItemId, item);

            m_itemNameLookup.Add(item.ItemName);

            m_lastItemId++;
            return true;
        }

        public bool DeleteItem(int itemId)
        {
            if (m_items.TryGetValue(itemId, out Item value))
            {
                m_itemNameLookup.Remove(value.ItemName);
                m_items.Remove(itemId);

                foreach (var item in m_items.Values)
                    item.Recipe.Remove(value);
            }

            return value != null;
        }

        public bool UpdateItem(Item newItem, Item oldItem)
        {
            // Item has been renamed
            if (!string.Equals(newItem.ItemName, oldItem.ItemName, StringComparison.OrdinalIgnoreCase))
            {
                // New item name already exists
                if (m_itemNameLookup.Contains(newItem.ItemName))
                    return false;

                // Rename in the item lookup
                m_itemNameLookup.Remove(oldItem.ItemName);
                m_itemNameLookup.Add(newItem.ItemName);
            }

            oldItem.CopyFrom(newItem);

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Item FindItem(int itemId)
        {
            return m_items[itemId];
        }


        public IEnumerable<Item> FindItems(string itemname = null, string type = null, string mod = null, Dictionary<Item, double> craftingneed = null)
        {
            IEnumerable<Item> result = m_items.Values;

            if (!string.IsNullOrWhiteSpace(itemname))
                result = result.Where(x => x.ItemName.IndexOf(itemname, StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrWhiteSpace(type) && type != Constants.DefaultName)
                result = result.Where(x => x.Type == type);

            if (!string.IsNullOrWhiteSpace(mod) && mod != Constants.DefaultName)
                result = result.Where(x => x.ModName == mod);

            if (craftingneed != null)
                result = result.Where(x => x.Recipe == craftingneed);

            return result;
        }
    }
}

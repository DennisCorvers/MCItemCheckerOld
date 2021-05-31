using System;
using System.Collections.Generic;
using MCItemChecker.Utils;

namespace MCItemChecker
{
    [Serializable]
    public class Item : IEquatable<Item>
    {
        public int ItemID
        { get; set; }
        public string ItemName
        { get; private set; }
        public string Type
        { get; set; }
        public string ModPack
        { get; set; }
        public Dictionary<Item, double> Craftingneed
        { get; set; }

        public Item(string itemname, string type, string modpack)
        {
            ItemName = itemname;
            Type = type;
            ModPack = modpack;
            Craftingneed = new Dictionary<Item, double>();
        }

        public Item(string itemname, string type, string modpack, Dictionary<Item, double> craftingneed)
            : this(itemname, type, modpack)
        {
            Craftingneed = craftingneed;
        }

        public string SetItemName(string name)
        {
            return ItemName = name.ToFirstLetterUpperCase();
        }

        public bool Equals(Item other)
        {
            if (other == null) { return false; }
            return other.ItemID == ItemID;
        }
    }
}

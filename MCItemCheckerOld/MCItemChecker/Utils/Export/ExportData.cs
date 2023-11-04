using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace MCItemChecker.Export
{
    [Serializable]
    internal class ExportData
    {
        [JsonProperty("Recipes")]
        public IReadOnlyList<Recipe> Recipes { get; }

        [JsonProperty("Mods")]
        public IReadOnlyDictionary<int, string> ModLookup { get; }

        [JsonProperty("Items")]
        public IReadOnlyDictionary<int, Item> ItemLookup { get; }

        public ExportData(List<Recipe> recipes, Dictionary<int, string> mods, Dictionary<int, Item> items)
        {
            Recipes = recipes;
            ModLookup = mods;
            ItemLookup = items;
        }
    }

    [Serializable]
    internal class Item
    {
        [JsonProperty("Name")]
        public string Name { get; }

        [JsonProperty("ModID")]
        public int ModID { get; }

        public Item(string name, int modID)
        {
            Name = name;
            ModID = modID;
        }
    }

    [Serializable]
    internal class ItemStack
    {
        [JsonProperty("Amount")]
        public int Amount { get; }

        [JsonProperty("ItemID")]
        public int ItemID { get; }

        public ItemStack(int amount, int itemID)
        {
            Amount = amount;
            ItemID = itemID;
        }
    }

    [Serializable]
    internal class Recipe
    {
        [JsonProperty("In")]
        public IReadOnlyList<ItemStack> Input { get; set; }

        [JsonProperty("Out")]
        public ItemStack Output { get; set; }

        public Recipe(List<ItemStack> input, ItemStack output)
        {
            Input = input;
            Output = output;
        }
    }
}

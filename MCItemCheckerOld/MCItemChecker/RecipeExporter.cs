using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MCItemChecker.Utils;
using Newtonsoft.Json;
using System.Net.Configuration;
using ProtoBuf;
using System.Drawing.Text;

namespace MCItemChecker
{
    public static class RecipeExporter
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
        };

        public static void Export(ItemChecker itemDb, out string outputPath)
        {
            var items = itemDb.ItemList;

            // Index unique mods and itemtypes.
            var uniqueMods = GetDistinctProperty(items, x => x.ModName, StringComparer.OrdinalIgnoreCase)
                .Where(x => !string.Equals(x, Constants.DefaultName))
                .Select((x, i) => new ModEntity(i, x));

            var uniqueTypes = GetDistinctProperty(items, x => x.Type, StringComparer.OrdinalIgnoreCase)
                .Where(x => !string.Equals(x, Constants.DefaultName))
                .Select((x, i) => new ItemTypeEntity(i, x));

            // Create lookups to assign ids to Item's mod and itemtype properties
            var modLookup = uniqueMods.ToDictionary(k => k.Name, v => v, StringComparer.OrdinalIgnoreCase);
            var typeLookup = uniqueTypes.ToDictionary(k => k.Name, v => v, StringComparer.OrdinalIgnoreCase);

            var itemTable = items.Select(x => new ItemEntity(
                x.ItemID,
                x.ItemName,
                string.Equals(x.Type, Constants.DefaultName) ? -1 : typeLookup[x.Type].ID,
                string.Equals(x.ModName, Constants.DefaultName) ? -1 : modLookup[x.ModName].ID,
                x.Recipe.Count == 0 ? null : x.Recipe.ToDictionary(k => k.Key.ItemID, v => v.Value)
                ));

            var exportData = new ExportData(
                lastUID: items.Max(x => x.ItemID),
                items: itemTable.ToList(),
                mods: uniqueMods.ToList(),
                itemTypes: uniqueTypes.ToList());

            WriteToFile(exportData, out outputPath);
        }

        private static IEnumerable<T> GetDistinctProperty<T>(IEnumerable<Item> items, Func<Item, T> selector, IEqualityComparer<T> equalityComparer = null)
        {
            return items
                .Select(selector)
                .Where(x => x != null)
                .Distinct(equalityComparer ?? EqualityComparer<T>.Default)
                .OrderBy(x => x);
        }

        private static void WriteToFile<T>(T data, out string outputPath)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Path.GetDirectoryName(Settings.Properties.FilePath));
            sb.Append("\\");
            sb.Append(Path.GetFileNameWithoutExtension(Settings.Properties.FilePath));
            sb.Append(" Recipes.json");

            outputPath = sb.ToString();

            var stringData = JsonConvert.SerializeObject(data, typeof(T), JsonSerializerSettings);
            DataStream.WriteTextToFile(stringData, outputPath);
        }

        [Serializable]
        private class ExportData
        {
            [JsonConstructor]
            public ExportData(int lastUID, List<ItemEntity> items, List<ModEntity> mods, List<ItemTypeEntity> itemTypes)
            {
                LastUID = lastUID;
                Items = items;
                Mods = mods;
                ItemTypes = itemTypes;
            }

            public int LastUID { get; }

            public List<ItemEntity> Items { get; }

            public List<ModEntity> Mods { get; }

            public List<ItemTypeEntity> ItemTypes { get; }
        }

        [Serializable]
        private class ItemEntity
        {
            [JsonConstructor]
            public ItemEntity(int id, string name, int typeID, int modID, Dictionary<int, double> recipes)
            {
                ID = id;
                Name = name;
                TypeID = typeID;
                ModID = modID;
                Recipes = recipes;
            }

            public int ID { get; }

            public string Name { get; }

            public int TypeID { get; }

            public int ModID { get; }

            public Dictionary<int, double> Recipes { get; }
        }

        [Serializable]
        private class ModEntity
        {
            [JsonConstructor]
            public ModEntity(int iD, string name)
            {
                ID = iD;
                Name = name;
            }

            public int ID { get; }

            public string Name { get; }
        }

        [Serializable]
        private class ItemTypeEntity
        {
            [JsonConstructor]
            public ItemTypeEntity(int iD, string name)
            {
                ID = iD;
                Name = name;
            }

            public int ID { get; }

            public string Name { get; }
        }
    }
}

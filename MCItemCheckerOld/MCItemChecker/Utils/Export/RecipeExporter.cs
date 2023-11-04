using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MCItemChecker.Utils;
using Newtonsoft.Json;
using MCItemChecker.Export;
using MCItemChecker.Utils.Export;

namespace MCItemChecker
{
    public static partial class RecipeExporter
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.None,
            NullValueHandling = NullValueHandling.Ignore,
        };

        public static void Export(ItemChecker itemDb, out string outputPath)
        {
            var exportData = GetRecipes(itemDb);
            WriteToFile(exportData, out outputPath);
        }

        private static Export.ExportData GetRecipes(ItemChecker itemChecker)
        {
            var modLookup = new IndexedMap<string>();
            var itemLookup = new IndexedMap<Export.Item>(new ItemEqualityComparer());

            var exportItemFactory = new Func<Item, (int id, Export.Item item)>(x =>
            {
                var modName = x.ModName == Constants.DefaultName ? "N/A" : x.ModName;
                var exportItem = new Export.Item(x.ItemName, modLookup.GetId(modName));
                return itemLookup.GetOrAdd(exportItem);
            });

            var recipes = itemChecker.ItemList
                .Where(x => x.Recipe != null && x.Recipe.Count > 0)
                .Select(x => { return RecipeFactory(x, exportItemFactory); });

            return new ExportData(recipes.ToList(), modLookup.GetReversed(), itemLookup.GetReversed());
        }

        private static Export.Recipe RecipeFactory(Item parentItem, Func<Item, (int id, Export.Item item)> itemFactory)
        {
            var exportParentItem = itemFactory(parentItem);

            // Get least common denominator of all recipe input items.
            // Set lcd as output item count to turn fractional recipe into integer-based recipe.
            var lcd = parentItem.Recipe
                .Select(x => new Fraction(x.Value).Denominator)
                .Aggregate(Fraction.GetCommonDenominator);

            var outputItem = new Export.ItemStack((int)lcd, itemFactory(parentItem).id);

            var inputItems = parentItem.Recipe.Select(x => { return new Export.ItemStack((int)(lcd * x.Value), itemFactory(x.Key).id); });
            return new Export.Recipe(inputItems.ToList(), outputItem);
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


        private class IndexedMap<TValue>
        {
            private IDictionary<TValue, (int id, TValue value)> m_reverseLookup;

            private int m_index;

            public IndexedMap() : this(EqualityComparer<TValue>.Default) { }

            public IndexedMap(IEqualityComparer<TValue> equalityComparer)
                => m_reverseLookup = new Dictionary<TValue, (int, TValue)>(equalityComparer);

            public int GetId(TValue value)
            {
                if (m_reverseLookup.TryGetValue(value, out var keyValue))
                    return keyValue.id;

                keyValue = new ValueTuple<int, TValue>(m_index, value);
                m_reverseLookup[value] = keyValue;
                return m_index++;
            }

            public (int id, TValue value) GetOrAdd(TValue value)
            {
                if (m_reverseLookup.TryGetValue(value, out var keyValue))
                    return keyValue;

                keyValue = new ValueTuple<int, TValue>(m_index++, value);
                m_reverseLookup[value] = keyValue;
                return keyValue;
            }

            public Dictionary<int, TValue> GetReversed() => m_reverseLookup.ToDictionary(k => k.Value.id, v => v.Key);
        }

        private class ItemEqualityComparer : IEqualityComparer<Export.Item>
        {
            public bool Equals(Export.Item x, Export.Item y) => x.Name == y.Name && x.ModID == y.ModID;

            public int GetHashCode(Export.Item obj) => (obj.Name, obj.ModID).GetHashCode();
        }
    }
}

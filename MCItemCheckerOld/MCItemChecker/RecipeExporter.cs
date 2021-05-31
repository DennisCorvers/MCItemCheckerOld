using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MCItemChecker.Utils;

namespace MCItemChecker
{
    public class RecipeExporter
    {
        private const int MaxRecursionCount = 1024;
        private StringBuilder sb;

        public void WriteToFile(IEnumerable<Item> items)
        {
            //Creates a path with a file name
            StringBuilder sbPath = new StringBuilder();
            sbPath.Append(Path.GetDirectoryName(Properties.Settings.Default.FilePath));
            sbPath.Append("\\");
            sbPath.Append(Path.GetFileNameWithoutExtension(Properties.Settings.Default.FilePath));
            sbPath.Append(" Recipes.txt");

            string fulltextpath = sbPath.ToString();

            //Creates a new list that is sorted by name
            List<string> textList = new List<string>();
            var sortedList = items.OrderBy(x => x.ItemName);

            StringBuilder sb = new StringBuilder();

            int recursionCount = 0;
            foreach (Item item in sortedList)
            {
                textList.Add(item.ItemName.ToUpper());

                if (item.Craftingneed.Count > 0)
                {
                    recursionCount = 0;
                    textList.AddRange(GetSubItems(item, ref recursionCount));
                }

                textList.Add("");
            }

            DataStream.WriteTexttoFile(textList.ToArray(), fulltextpath);
            MessageBox.Show("Exported data to \n" + fulltextpath, "Exporting...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private List<string> GetSubItems(Item item, ref int count, double amount = 1)
        {
            List<string> Recipe = new List<string>();

            if (item.Craftingneed.Count <= 0)
                return Recipe;

            count++;

            //Adds Main item
            foreach (KeyValuePair<Item, double> subitems in item.Craftingneed)
            {
                //Adds a tab for every sub item
                for (int i = 0; i < count; i++)
                    sb.Append("\t");

                sb.Append(subitems.Key.ItemName);
                sb.Append(" ");
                sb.Append(Math.Round(subitems.Value * amount, 2).ToString());
                Recipe.Add(sb.ToString());
                sb.Clear();

                if (subitems.Key.Craftingneed.Count <= 0)
                    continue;

                if (count >= MaxRecursionCount)
                    continue;

                Recipe.AddRange(GetSubItems(subitems.Key, ref count, subitems.Value * amount));
                count--;
            }

            return Recipe;
        }
    }
}

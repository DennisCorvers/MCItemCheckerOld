using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MCItemChecker.Utils;

namespace MCItemChecker
{
    public static class RecipeExporter
    {
        private const int MaxRecursionCount = 128;

        public static void WriteToFile(IEnumerable<Item> items)
        {
            //Creates a path with a file name
            StringBuilder sb = new StringBuilder();
            sb.Append(Path.GetDirectoryName(Properties.Settings.Default.FilePath));
            sb.Append("\\");
            sb.Append(Path.GetFileNameWithoutExtension(Properties.Settings.Default.FilePath));
            sb.Append(" Recipes.txt");

            string fulltextpath = sb.ToString();

            sb.Clear();

            var sortedList = items.OrderBy(x => x.ItemName);

            foreach (Item item in sortedList)
            {
                sb.AppendLine(item.ItemName.ToUpper());

                if (item.Recipe.Count > 0)
                    GetSubItems(sb, item, 0);

                sb.AppendLine("");
            }

            try
            {
                DataStream.WriteTextToFile(sb.ToString(), fulltextpath);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Exported data to \n" + fulltextpath, "Exporting...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void GetSubItems(StringBuilder sb, Item item, int count, double amount = 1)
        {
            if (item.Recipe.Count <= 0)
                return;

            if (count++ >= MaxRecursionCount)
                return;

            //Adds Main item
            foreach (KeyValuePair<Item, double> subitems in item.Recipe)
            {
                //Adds a tab for every sub item
                for (int i = 0; i < count; i++)
                    sb.Append("\t");

                sb.Append(subitems.Key.ItemName);
                sb.Append(" ");
                sb.AppendLine(Math.Round(subitems.Value * amount, 2).ToString());

                if (subitems.Key.Recipe.Count <= 0)
                    continue;

                GetSubItems(sb, subitems.Key, count, subitems.Value * amount);
            }
        }
    }
}

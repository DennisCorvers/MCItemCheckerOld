using System.Collections.Generic;
using System.Windows.Forms;

namespace MCItemChecker.Utils
{
    internal static class ListViewExtensions
    {
        public static Item GetSelectedMCItem(this ListView listview)
        {
            ListView.SelectedListViewItemCollection listviewselect = listview.SelectedItems;
            return listviewselect[0].Tag as Item;
        }

        public static KeyValuePair<Item, double> GetSelectedMCSubItem(this ListView listview)
        {
            ListView.SelectedListViewItemCollection listviewselect = listview.SelectedItems;
            return (KeyValuePair<Item, double>)listviewselect[0].Tag;
        }

        public static IEnumerable<ListViewItem> GetSelectedListViewItems(this ListView listview)
        {
            var selectedItems = listview.SelectedItems;
            List<ListViewItem> lvItems = new List<ListViewItem>(selectedItems.Count);

            for (int i = selectedItems.Count - 1; i >= 0; i--)
                lvItems.Add(selectedItems[i]);

            return lvItems;
        }
    }
}

using System;
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

        public static void InsertCollection<T>(this ListView listview, IEnumerable<T> itemlist, Func<T, ListViewItem> listviewFactory)
        {
            if (listview == null)
                throw new ArgumentNullException(nameof(listview));

            foreach (var item in itemlist)
            {
                var lvItem = listviewFactory(item);
                lvItem.Tag = item;

                listview.Items.Add(lvItem);
            }
        }
    }
}

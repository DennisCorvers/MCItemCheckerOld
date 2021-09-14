using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MCItemChecker.Utils
{
    internal static class ListViewExtensions
    {
        public static T GetSelectedItem<T>(this ListView listview)
        {
            var listviewselect = listview.SelectedItems;
            return (T)listviewselect[0].Tag;
        }

        public static bool TryGetSelectedItem<T>(this ListView listview, out T item)
        {
            if (listview.SelectedItems.Count == 0)
            {
                item = default;
                return false;
            }

            item = listview.GetSelectedItem<T>();
            return true;
        }

        public static ICollection<ListViewItem> GetSelectedListViewItems(this ListView listview)
        {
            var selectedItems = listview.SelectedItems;
            var lvItems = new List<ListViewItem>(selectedItems.Count);

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

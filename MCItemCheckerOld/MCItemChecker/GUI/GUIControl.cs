using MCItemChecker.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCItemChecker
{
    public static class GUIControl
    {
        public static void Sort(ListView listView, int index)
        {
            if (listView == null) return;
            var comparer = (ListViewComparer)listView.ListViewItemSorter;

            comparer.SortOrderInvert();
            Sort(listView, index, comparer);
        }
        public static void Sort(ListView listView, int index, SortOrder sortOrder)
        {
            return;
            if (listView == null) return;
            var comparer = (ListViewComparer)listView.ListViewItemSorter;

            comparer.SortOrder = sortOrder;
            Sort(listView, index, comparer);
        }
        private static void Sort(ListView listView, int index, ListViewComparer comparer)
        {
            if (listView.Columns[index] == null) return;

            comparer.ColumnNumber = listView.Columns[index].Index;
            listView.Sort();
        }

        public static bool UpdateItemListView(ListView listview, IEnumerable<Item> itemlist = null)
        {
            if (listview != null)
            {
                listview.Items.Clear();
                if (itemlist != null)
                {
                    foreach (Item i in itemlist)
                    {
                        var item = new ListViewItem(new[] { i.ItemID.ToString(), i.ItemName, i.Type, i.ModPack })
                        { Tag = i };
                        listview.Items.Add(item);
                    }
                }
                else
                {
                    var item = new ListViewItem(new[] { "", "No Results", "", "" });
                    listview.Items.Add(item);
                    item = null;
                }
                return true;
            }

            return false;
        }

        public static void UpdateControl(IEnumerable<string> list, ListView listview)
        {
            listview.Items.Clear();
            foreach (string s in list)
                listview.Items.Add(s);
            listview.Items.RemoveByKey("-");
        }
        public static void UpdateControl(IEnumerable<string> list, ListBox listbox)
        {
            listbox.Items.Clear();
            foreach (string s in list)
                listbox.Items.Add(s);
            listbox.Items.Remove("-");
        }
        public static void UpdateControl(IEnumerable<string> list, ComboBox combobox)
        {
            combobox.Items.Clear();
            foreach (string s in list)
                combobox.Items.Add(s);
        }

        public static void InfoMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

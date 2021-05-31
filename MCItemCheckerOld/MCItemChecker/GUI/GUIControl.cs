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
                        var item = new ListViewItem(new[] { i.ItemName, i.Type, i.ModPack })
                        { Tag = i };
                        listview.Items.Add(item);
                    }
                }
                else
                {
                    var item = new ListViewItem(new[] { "No Results", "", "" });
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

        public static void ListViewSizeChanged(object sender, EventArgs e)
        {
            bool Resizing = false;
            // Don't allow overlapping of SizeChanged calls
            if (!Resizing)
            {
                // Set the resizing flag
                Resizing = true;

                ListView listView = sender as ListView;
                if (listView != null)
                {
                    float totalColumnWidth = 0;

                    // Get the sum of all column tags
                    for (int i = 0; i < listView.Columns.Count; i++)
                        totalColumnWidth += Convert.ToInt32(listView.Columns[i].Width);

                    // Calculate the percentage of space each column should 
                    // occupy in reference to the other columns and then set the 
                    // width of the column to that percentage of the visible space.
                    for (int i = 0; i < listView.Columns.Count; i++)
                    {
                        float colPercentage = (Convert.ToInt32(listView.Columns[i].Tag) / totalColumnWidth);
                        listView.Columns[i].Width = (int)(colPercentage * listView.ClientRectangle.Width);
                    }
                }
            }

            // Clear the resizing flag
            Resizing = false;
        }

        public static void InfoMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

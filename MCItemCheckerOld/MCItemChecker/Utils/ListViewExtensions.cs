﻿using System.Collections.Generic;
using System.Windows.Forms;

namespace MCItemChecker.Utils
{
    internal static class ListViewExtensions
    {
        public static Item GetSelectedMCItem(this ListView listview, int namecolumn = 1, int idcolumn = 0)
        {
            ListView.SelectedListViewItemCollection listviewselect = listview.SelectedItems;
            return listviewselect[0].Tag as Item;
        }

        public static KeyValuePair<Item, double> GetSelectedMCSubItem(this ListView listview, int namecolumn = 1, int idcolumn = 0)
        {
            ListView.SelectedListViewItemCollection listviewselect = listview.SelectedItems;
            return (KeyValuePair<Item, double>)listviewselect[0].Tag;
        }
    }
}

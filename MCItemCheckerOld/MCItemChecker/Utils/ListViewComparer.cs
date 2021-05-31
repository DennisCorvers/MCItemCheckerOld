using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCItemChecker.Utils
{
    public class ListViewComparer : System.Collections.IComparer
    {
        public int ColumnNumber
        { get; set; }
        public SortOrder SortOrder
        { get; set; }

        public ListViewComparer()
        {
            ColumnNumber = 0;
            SortOrder = SortOrder.Descending;
        }

        // Compare two ListViewItems.
        public int Compare(object objectx, object objecty)
        {
            // Get the objects as ListViewItems.
            ListViewItem itemx = (ListViewItem)objectx;
            ListViewItem itemy = (ListViewItem)objecty;

            // Compare them.
            int result = itemx.SubItems[ColumnNumber].Text.CompareTo(itemy.SubItems[ColumnNumber].Text);

            // Return the correct result depending on whether
            // we're sorting ascending or descending.
            if (SortOrder == SortOrder.Ascending)
            { return result; }
            else
            { return -result; }
        }

        public void SortOrderInvert()
        {
            if (SortOrder == SortOrder.Ascending)
            {
                SortOrder = SortOrder.Descending;
                return;
            }

            SortOrder = SortOrder.Ascending;
        }
    }
}

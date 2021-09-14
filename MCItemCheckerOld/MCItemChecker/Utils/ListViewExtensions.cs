using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

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

        public static ICollection<T> GetSelectedItems<T>(this ListView listview)
        {
            var selectedItems = listview.GetSelectedListViewItems();
            var retVal = new List<T>(selectedItems.Count);

            foreach (var item in selectedItems)
                retVal.Add((T)item.Tag);

            return retVal;
        }

        public static ICollection<ListViewItem> GetSelectedListViewItems(this ListView listview)
            => new SelectedListViewItems(listview);

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

        public static SelectedListViewItemCollectionEnumerator GetTypedEnumerator(this SelectedListViewItemCollection selectedListViewItems)
        {
            return new SelectedListViewItemCollectionEnumerator(selectedListViewItems);
        }

        internal struct SelectedListViewItemCollectionEnumerator : IEnumerator<ListViewItem>, IEnumerator
        {
            private readonly SelectedListViewItemCollection m_collection;
            private int m_index;
            private ListViewItem m_current;

            internal SelectedListViewItemCollectionEnumerator(SelectedListViewItemCollection collection)
            {
                m_collection = collection;
                m_index = 0;
                m_current = default;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if ((uint)m_index < (uint)m_collection.Count)
                {
                    m_current = m_collection[m_index++];
                    return true;
                }

                m_index = m_collection.Count + 1;
                m_current = default;

                return false;
            }

            public ListViewItem Current
                => m_current;

            object IEnumerator.Current
            {
                get
                {
                    if (m_index == 0 || (m_index == m_collection.Count + 1))
                        throw new InvalidOperationException();

                    return Current;
                }
            }

            public void Reset()
            {
                m_index = 0;
                m_current = default;
            }
        }

        internal struct SelectedListViewItems : ICollection<ListViewItem>
        {
            private readonly ListView m_listview;

            public SelectedListViewItems(ListView listView)
            {
                m_listview = listView;
            }

            public int Count
                => m_listview.SelectedItems.Count;

            public bool IsReadOnly
                => false;

            public void Clear()
                => m_listview.SelectedItems.Clear();

            void ICollection<ListViewItem>.Add(ListViewItem item)
                => throw new InvalidOperationException();

            public bool Contains(ListViewItem item)
                => m_listview.SelectedItems.Contains(item);

            public void CopyTo(ListViewItem[] array, int arrayIndex)
                => m_listview.SelectedItems.CopyTo(array, arrayIndex);

            public IEnumerator<ListViewItem> GetEnumerator()
                => new SelectedListViewItemCollectionEnumerator(m_listview.SelectedItems);

            public bool Remove(ListViewItem item)
                => throw new InvalidOperationException();

            IEnumerator IEnumerable.GetEnumerator()
                => new SelectedListViewItemCollectionEnumerator(m_listview.SelectedItems);
        }
    }
}

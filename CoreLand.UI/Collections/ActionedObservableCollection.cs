using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CoreLand.UI.Collections
{
    public class ActionedObservableCollection<T> : ObservableCollection<T>
    {
        public event EventHandler<NotifyCollectionChangedEventArgs> ItemAdded;
        public event EventHandler<NotifyCollectionChangedEventArgs> ItemRemoved;
        public event EventHandler<NotifyCollectionChangedEventArgs> ItemMoved;
        public event EventHandler<NotifyCollectionChangedEventArgs> ItemReplased;
        public event EventHandler<NotifyCollectionChangedEventArgs> ItemReseted;

        public ActionedObservableCollection()
        {
            CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    ItemAdded?.Invoke(this, e);
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    ItemRemoved?.Invoke(this, e);
                }
                else if (e.Action == NotifyCollectionChangedAction.Move)
                {
                    ItemMoved?.Invoke(this, e);
                }
                else if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    ItemReplased?.Invoke(this, e);
                }
                else if (e.Action == NotifyCollectionChangedAction.Reset)
                {
                    ItemReseted?.Invoke(this, e);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(e));
                }
            };
        }
    }
}

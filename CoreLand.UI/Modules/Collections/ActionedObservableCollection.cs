using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace CoreLand.UI.Modules.Collections
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
            this.CollectionChanged += (sender, e) =>
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

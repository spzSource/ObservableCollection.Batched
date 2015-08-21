using System.Collections.Generic;
using System.Collections.Specialized;

namespace BatchedObservableCollection.Batch.Strategies
{
    public class AddStrategy<T> : IBatchApplyingStrategy<T>
    {
        public void Apply(IBatchContext<T> batchContext, IList<T> sourceBatch)
        {
            batchContext.CheckReentrancyInternal();

            foreach (T item in sourceBatch)
            {
                batchContext.InternalItems.Add(item);
            }

            batchContext.RaisePropertyChanged("Count");
            batchContext.RaisePropertyChanged("Item[]");
            batchContext.RaiseCollectionChanged(
                new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Add, sourceBatch));
        }
    }
}
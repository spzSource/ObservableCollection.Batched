using System.Collections.Generic;
using System.Collections.Specialized;

namespace BatchedObservableCollection.Batch.Strategies
{
    public class RemoveStrategy<T> : IBatchApplyingStrategy<T>
    {
        public void Apply(IBatchContext<T> batchContext, IList<T> sourceBatch)
        {
            batchContext.CheckReentrancyInternal();

            foreach (T item in sourceBatch)
            {
                batchContext.InternalItems.Remove(item);
            }

            batchContext.RaisePropertyChanged("Count");
            batchContext.RaisePropertyChanged("Item[]");
            batchContext.RaiseCollectionChanged(
                new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Remove, sourceBatch));
        }
    }
}

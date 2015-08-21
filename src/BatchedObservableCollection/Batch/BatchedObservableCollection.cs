using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace BatchedObservableCollection.Batch
{
    public class BatchedObservableCollection<TData> : ObservableCollection<TData>, IBatchContext<TData>
    {
        public OperationBatch<TData, TBatchStrategy> StartBatch<TBatchStrategy>()
            where TBatchStrategy : IBatchApplyingStrategy<TData>, new()
        {
            return new OperationBatch<TData, TBatchStrategy>(this);
        }

        public IList<TData> InternalItems => Items;

        public void CheckReentrancyInternal()
        {
            CheckReentrancy();
        }

        public void ApplyBatch(IList<TData> batch, IBatchApplyingStrategy<TData> applyingStrategy)
        {
            applyingStrategy.Apply(this, batch);
        }

        public void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public void RaiseCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            OnCollectionChanged(args);
        }
    }
}

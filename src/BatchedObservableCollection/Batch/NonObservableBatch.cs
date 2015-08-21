using System;
using System.Collections.Generic;

namespace BatchedObservableCollection.Implementation
{
    public class NonObservableBatch<T> : IDisposable
    {
        private readonly IBatchContext<T> batchContext;
        private readonly IBatchApplyingStrategy<T> applyingStrategy;
        private readonly IList<T> batch = new List<T>();

        public NonObservableBatch(IBatchContext<T> batchContext, IBatchApplyingStrategy<T> applyingStrategy)
        {
            this.batchContext = batchContext;
            this.applyingStrategy = applyingStrategy;
        }

        public void Dispose()
        {
            batchContext.ApplyBatch(batch, applyingStrategy);
        }

        public void Add(T item)
        {
            batch.Add(item);
        }
    }
}
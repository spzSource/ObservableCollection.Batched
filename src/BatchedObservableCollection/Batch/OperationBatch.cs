using System;
using System.Collections.Generic;

namespace BatchedObservableCollection.Batch
{
    public class OperationBatch<TData, TOperationStrategy> : IDisposable
        where TOperationStrategy : IBatchApplyingStrategy<TData>, new()
    { 
        private readonly IBatchContext<TData> batchContext;
        private readonly IList<TData> internalBatch = new List<TData>();

        public OperationBatch(IBatchContext<TData> batchContext)
        {
            this.batchContext = batchContext;
        }

        public void AddToBatch(TData item)
        {
            internalBatch.Add(item);
        }

        public void Dispose()
        {
            batchContext.ApplyBatch(internalBatch, new TOperationStrategy());
        }
    }
}
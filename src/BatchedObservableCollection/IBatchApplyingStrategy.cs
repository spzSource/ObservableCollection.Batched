using System.Collections.Generic;

namespace BatchedObservableCollection
{
    public interface IBatchApplyingStrategy<T>
    {
        void Apply(IBatchContext<T> batchContext, IList<T> sourceBatch);
    }
}
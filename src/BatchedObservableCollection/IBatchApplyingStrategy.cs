using System.Collections.Generic;

namespace BatchedObservableCollection
{
    /// <summary>
    /// Provides a logic that determines how batch will be applied
    /// to current <see cref="IBatchContext{T}"/> context.
    /// </summary>
    /// <typeparam name="T">The type of items.</typeparam>
    public interface IBatchApplyingStrategy<T>
    {
        /// <summary>
        /// Applies batch <see cref="IList{T}"/> to passed context <see cref="IBatchContext{T}"/>.
        /// </summary>
        /// <param name="batchContext">The target context for batch applying.</param>
        /// <param name="sourceBatch">The items (batch) to be applied.</param>
        void Apply(IBatchContext<T> batchContext, IList<T> sourceBatch);
    }
}
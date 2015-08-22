using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace BatchedObservableCollection
{
    /// <summary>
    /// The target context for batch.
    /// </summary>
    /// <typeparam name="T">The type for batch items.</typeparam>
    public interface IBatchContext<T>
    {
        /// <summary>
        /// The internal collection of already existing elements in context.
        /// </summary>
        IList<T> InternalItems
        {
            get;
        }

        /// <summary>
        /// Prevent reentrancy. See <see cref="ObservableCollection{T}.CheckReentrancy"/> implementation.
        /// </summary>
        void CheckReentrancyInternal();

        /// <summary>
        /// Performs batch applying/
        /// </summary>
        /// <param name="batch">The batch of elements.</param>
        /// <param name="applyingStrategy">The strategy according to which batch will  be applied.</param>
        void ApplyBatch(IList<T> batch, IBatchApplyingStrategy<T> applyingStrategy);

        /// <summary>
        /// Raises <see cref="ObservableCollection{T}.PropertyChanged"/> event for specified property name.
        /// </summary>
        void RaisePropertyChanged(string propertyName);

        /// <summary>
        /// Raises <see cref="ObservableCollection{T}.CollectionChanged"/> event.
        /// </summary>
        void RaiseCollectionChanged(NotifyCollectionChangedEventArgs args);
    }
}
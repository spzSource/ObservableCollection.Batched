using System.Collections.Generic;
using System.Collections.Specialized;

namespace BatchedObservableCollection
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBatchContext<T>
    {
        /// <summary>
        /// 
        /// </summary>
        IList<T> InternalItems
        {
            get;
        } 

        /// <summary>
        /// 
        /// </summary>
        void CheckReentrancyInternal();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="applyingStrategy"></param>
        void ApplyBatch(IList<T> batch, IBatchApplyingStrategy<T> applyingStrategy);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        void RaisePropertyChanged(string propertyName);

        /// <summary>
        /// 
        /// </summary>
        void RaiseCollectionChanged(NotifyCollectionChangedEventArgs args);
    }
}
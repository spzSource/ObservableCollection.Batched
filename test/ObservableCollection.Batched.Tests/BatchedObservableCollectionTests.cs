using BatchedObservableCollection;
using BatchedObservableCollection.Batch;
using BatchedObservableCollection.Batch.Strategies;

using Xunit;

namespace ObservableCollection.Batched.Tests
{
    public class BatchedObservableCollectionTests
    {
        private const int TestableBatchSize = 5;
        private readonly BatchedObservableCollection<int> testableCollection;

        public BatchedObservableCollectionTests()
        {
            testableCollection = new BatchedObservableCollection<int>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void PropertyChangedCallCountTest(int expectedNumber)
        {
            int executionCounter = 0;

            testableCollection.CollectionChanged += (sender, args) => executionCounter++;

            for (int batchIndex = 0; batchIndex < expectedNumber; batchIndex++)
            {
                CreateTestableBatch<AddStrategy<int>>(testableCollection, TestableBatchSize);
            }

            Assert.True(executionCounter == expectedNumber);
        }

        [Fact]
        public void AddMethodTest()
        {
            CheckPropertyChangedAfterStrategyApplying<AddStrategy<int>>("Count");

            testableCollection.Clear();

            CheckPropertyChangedAfterStrategyApplying<AddStrategy<int>>("Item[]");

            Assert.True(testableCollection.Count == TestableBatchSize);
        }

        [Fact]
        public void RemoveMethodTest()
        {
            CreateTestableBatch<AddStrategy<int>>(testableCollection, TestableBatchSize);
            CheckPropertyChangedAfterStrategyApplying<RemoveStrategy<int>>("Count");

            testableCollection.Clear();

            CreateTestableBatch<AddStrategy<int>>(testableCollection, TestableBatchSize);
            CheckPropertyChangedAfterStrategyApplying<RemoveStrategy<int>>("Item[]");

            Assert.True(testableCollection.Count == 0);
        }

        private void CheckPropertyChangedAfterStrategyApplying<TStrategy>(string propertyName)
            where TStrategy : IBatchApplyingStrategy<int>, new()
        {
            Assert.PropertyChanged(testableCollection, propertyName,
                () => CreateTestableBatch<TStrategy>(testableCollection, TestableBatchSize));
        }

        private void CreateTestableBatch<TStrategy>(BatchedObservableCollection<int> testableSource, int batchSize)
            where TStrategy : IBatchApplyingStrategy<int>, new()
        {
            using (var batch = testableSource.StartBatch<TStrategy>())
            {
                for (int elementIndex = 0; elementIndex < batchSize; elementIndex++)
                {
                    batch.AddToBatch(elementIndex);
                }
            }
        }
    }
}

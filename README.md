# ObservableCollection.Batched
The ObservableCollection with ability to create a batch of elements without invoking CollectionChanged event for each of element.

Due to performance issue, sometimes not need to invoke CollectionChanged event for each of Added / Removed / etc. element.
To provide this we may to create a batch and after that to invoke CollectionChanged event.

# Example
```cs
 BatchedObservableCollection<int> observable = new BatchedObservableCollection<int>();
 
 using(var batch = observable.StartBatch<AddStrategy<int>>())
 {
      batch.AddToBatch(1);
      batch.AddToBatch(2);
      batch.AddToBatch(3);
      batch.AddToBatch(4);
      batch.AddToBatch(5);
 }
 // <-- CollectionChanged event invoked here
```

Current implementation contains two strategies for StartBatch method:
- AddStrategy<T> - used for elements adding; 
- RemoveStrategy<T> - used for elements removing. 

You can create additional strategies through implementation of IBatchApplyingStrategy interface.

# Installing

Installation via [nuget](https://www.nuget.org/packages/ObservableCollection.Batched/):
```cmd
PM> Install-Package ObservableCollection.Batched
```

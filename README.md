# ExtraLINQ
[![CI Build](https://github.com/kpol/ExtraLINQ/workflows/CI%20Build/badge.svg)](https://github.com/kpol/ExtraLINQ/actions)
[![Nuget](https://img.shields.io/nuget/v/ExtraEnumerable.svg?logo=nuget)](https://www.nuget.org/packages/ExtraEnumerable)

ExtraLINQ is a set of extension methods for `IEnumerable<T>`.   
Why do we actually need some extra `IEnumerable<T>` extensions? Imagine, you have a collection of Products and you need to get the most expensive product (the product with the highest price). Unfortunately for me, what I usually see in the code:
```csharp
var mostExpensiveProduct = products.OrderByDescending(p => p.Price).First();
```
Complexity of this code is `O(n log n)`.  
Better approach would be:
```csharp
var maxPrice = products.Max(p => p.Price);
var mostExpensiveProduct = products.First(p => p.Price == maxPrice);
```
which is `O(n)` but in the worst case might iterate twice.  
Obviously this operation can be done in true `O(n)`. For this operation ExtraLINQ has `MaxBy` method:
```csharp
var mostExpensiveProduct = products.MaxBy(p => p.Price);
```
Or imagine another case: you need to check whether sequence length is less than or equal to `5`. What you normally see is this:
```csharp
bool checkCount = products.Count() <= 5;
```
This code is `O(1)` if `products` is actually some sort of collection which implements `IReadOnlyCollection<T>` or `ICollection<T>`. But if it does not, the code above will iterate through all items, becoming `O(n)`.
If `products` doesn't implement these interfaces, better approach is iterate through first `6` items and check `Count()`, i.e.:
```csharp
bool checkCount = products.Take(6).Count() <= 5;
``` 
To omit these drawbacks ExtraLINQ has `AtMost` method:
```csharp
bool checkCount = products.AtMost(5);
```
Additionally ExtraLINQ provides overloads of some methods (e.g. `Sum`) for the most commonly used collections: `T[]` and `List<T>`. These methods work faster and allocate less than LINQ built-in methods. For benchmarks see [Benchmark](https://github.com/kpol/ExtraLINQ/tree/master/src/Benchmark) project.  

|                Method |          Mean |       Error |        StdDev |        Median |
|---------------------- |--------------:|------------:|--------------:|--------------:|
|          SumArrayLinq |  8,868.799 us | 647.1369 us | 1,897.9404 us |  8,311.950 us |
|     SumArrayExtraLinq |  1,027.563 us |  60.4231 us |   176.2571 us |    971.487 us |
|      AverageArrayLinq |  8,006.273 us | 243.3820 us |   666.2542 us |  7,839.090 us |
| AverageArrayExtraLinq |  1,141.601 us |  47.5776 us |   133.4128 us |  1,097.886 us |
|           SumListLinq | 10,215.340 us | 361.8532 us | 1,032.3874 us |  9,840.073 us |
|      SumListExtraLinq |  3,231.168 us |  64.2775 us |   177.0390 us |  3,193.271 us |
|               MaxLinq |  7,362.926 us | 146.3407 us |   367.1402 us |  7,237.511 us |
|        MaxOrderByLinq | 13,921.340 us | 268.3250 us |   237.8632 us | 13,831.188 us |
|        MaxByExtraLinq |  7,101.532 us | 174.6859 us |   495.5549 us |  7,093.998 us |
|           ExactlyLinq |      5.094 us |   0.2096 us |     0.6012 us |      4.925 us |
|      ExactlyExtraLinq |      6.925 us |   0.1935 us |     0.5551 us |      6.842 us |

*Summarizing:* all this sort of improvements are micro-optimizations, which can be very beneficial for a large enterprise project.

# List of methods
* [AtLeast](#atleast)
* [AtMost](#atmost)
* [Average](#average)
* [CountBetween](#countbetween)
* [DistinctBy](#distinctby)
* [Exactly](#exactly)
* [ExceptBy](#exceptby)
* [ForEach](#foreach)
* [IntersectBy](#intersectby)
* [MaxBy](#maxby)
* [MinBy](#minby)
* [OrderBy / ThenBy](#orderby--thenby)
* [Pairwise](#pairwise)
* [Random](#random)
* [RandomDouble](#randomdouble)
* [Shuffle](#shuffle)
* [Sum](#sum)
* [TakeLast](#takelast)
* [ToHashSet](#tohashset)
---
### AtLeast
Checks whether the number of elements is greater or equal to the given integer. Complexity is `O(1)` or `O(m)` where `m` is number supplied into the method.
```csharp
bool result = source.AtLeast(5);
```

### AtMost
Checks whether the number of elements is less or equal to the given integer. Complexity is `O(1)` or `O(m)` where `m` is number supplied into the method.
```csharp
bool result = source.AtMost(5);
```

### Average
Returns the average of a sequence of numeric values. Has overloads for `int`, `uint`, `long`, `ulong`, `float`, `double`, `decimal`, corresponding `Nullable<T>`, and overloads for `T[]` and `List<T>` which are faster than LINQ `Average()` method.
```csharp
var result = source.Average();
```

### CountBetween
Checks whether the number of elements is between an inclusive range of minimum and maximum integers. Complexity is `O(1)` or `O(max)` where `max` is the second parameter supplied into the method.
```csharp
bool result = source.CountBetween(4, 6);
```

### DistinctBy
Returns distinct elements of the given source using `keySelector` and comparer (can be `null`). Complexity is `O(n)` where `n` is number of elements in the sequence.
```csharp
var result = source.DistinctBy(p => p.Category);
```

### Exactly
Checks whether the number of elements in the source is equal to the given integer. Complexity is `O(1)` or `O(m)` where `m` is number supplied into the method.
```csharp
bool result = source.Exactly(5);
```

### ExceptBy
Returns the set of elements in the first sequence which aren't in the second sequence, according to a given key selector and comparer (can be `null`). Parameter `includeDuplicates` specifies whether to return duplicates from the first sequence. Complexity is `O(n)` where `n` is total number of elements in both sequences.
```csharp
var result = first.ExceptBy(second, i => i.Id);
```
`ExceptBy` has an overload which accepts sequences with different generic `T` types. In this case you need to specify two key selectors: one for the first sequence and another one for the second sequence. These two selectors must return the same type.
```csharp
var result = first.ExceptBy(firstItem => firstItem.Property, second, secondItem => secondItem.Property);
```

### ForEach
Performs the specified action on each element of the a sequence.
```csharp
source.ForEach((x, i) => { Console.WriteLine($"Item: {x}; Index: {i}"); });
```

### IntersectBy
Returns the set intersection of two sequences according to a given key selector and comparer (can be `null`). Complexity is `O(n)` where `n` is total number of elements in both sequences.
```csharp
var result = first.IntersectBy(second, i => i.Id);
```

### MaxBy
Returns the maximal element of the given source based on the given selector and comparer (can be `null`). Complexity is `O(n)` where `n` is number of elements in the sequence. Has overloads for `T[]` and `List<T>` which are faster than LINQ `Max()` method.
```csharp
var result = source.MaxBy(p => p.Price);
```

### MinBy
Returns the minimal element of the given source based on the given selector and comparer (can be `null`). Complexity is `O(n)` where `n` is number of elements in the sequence. Has overloads for `T[]` and `List<T>` which are faster than LINQ `Min()` method.
```csharp
var result = source.MinBy(p => p.Price);
```

### OrderBy / ThenBy
Sorts the elements of a sequence in ascending or descending order according to a key. Internaly uses standard LINQ `OrderBy`, `OrderByDescending`, `ThenBy` and `ThenByDescending`. Complexity is `O(n log n)` where `n` is number of elements in the sequence.
```csharp
var result = source.OrderBy(p => p.Price, SortOrder.Descending).ThenBy(p => p.Name, SortOrder.Ascending);
```

### Pairwise
Returns a sequence of each element in the input sequence and its predecessor, with the exception of the first element which is only returned as the predecessor of the second element. Complexity is `O(n)` where `n` is number of elements in the sequence.
```csharp
var result = source.Pairwise((first, second) => $"{first.Id} {second.Id}");
```

### Random
Returns an infinite sequence of random integers using the standard .NET random number generator. If `Random` instance is not supplied into the method, thread-safe implementation of `Random` is used.
```csharp
var result = ExtraEnumerable.Random(1, 10);
```

### RandomDouble
Returns an infinite sequence of random floating-point number that is greater than or equal to 0.0, and less than 1.0. If `Random` instance is not supplied into the method, thread-safe implementation of `Random` is used.
```csharp
var result = ExtraEnumerable.RandomDouble();
```

### Shuffle
Returns an infinite sequence of a random permutation of a finite sequence using [Fisher–Yates](https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle) algorithm. If `Random` instance is not supplied into the method, thread-safe implementation of `Random` is used. Complexity is `O(n)` where `n` is number of elements in the sequence.
```csharp
var result = source.Shuffle();
```

### Sum
Returns the sum of a sequence of numeric values. Has overloads for `int`, `uint`, `long`, `ulong`, `float`, `double`, `decimal`, corresponding `Nullable<T>`, and overloads for `T[]` and `List<T>` which are faster than LINQ `Sum()` method.
```csharp
var result = source.Sum();
```

### TakeLast
Returns a specified number of elements from the end of a sequence.
```csharp
var result = source.TakeLast(5);
```

### ToHashSet
Creates a `HashSet<T>` from an `IEnumerable<T>`.
```csharp
var result = source.ToHashSet();
```

# ExtraLINQ
[![Build status](https://ci.appveyor.com/api/projects/status/fn3jf7d0p25eo2rl?svg=true)](https://ci.appveyor.com/project/kpol/extralinq)

ExtraLINQ is a set of extension methods for `IEnumerable<T>`.   
Why do we actually need some extra `IEnumerable<T>` extensions? Imagine, you have a collection of Products and you need to get the most expensive product (the product with the highest price). Unfortunately for me, what I usually see in the code:
```csharp
var theMostExpensiveProduct = products.OrderByDescending(p => p.Price).FirstOrDefault();
```
Complexity of the code is `O(n log n)`.  
Slightly better solution:
```csharp
var maxPrice = products.Max(p => p.Price);
var theMostExpensiveProduct = products.FirstOrDefault(p => p.Price == maxPrice);
```
which is `O(n)` but in the worst case might iterate twice.  
Obviously this operation can be done in true `O(n)`. For this operation ExtraLINQ has `MaxBy` method:
```csharp
var theMostExpensiveProduct = products.MaxBy(p => p.Price);
```
Or imagine another case: you need to check whether sequence length is lesser than or equal to `5`. What you normally see is this:
```csharp
bool checkCount = products.Count() <= 5;
```
This code is `O(1)` if `products` is actually some sort of collection which implements `IReadOnlyCollection<T>` or `ICollection<T>`. But if it does not, the code above will iterate through all items, becoming `O(n)`.
What we actually need to do, is iterate through first `6` items, i.e.:
```csharp
bool checkCount = products.Take(6).Count() <= 5;
```
But at the same time, if the collection implements `IReadOnlyCollection<T>` or `ICollection<T>` this code won't run in `O(1)`.  
To omit these drawbacks ExtraLINQ has `AtMost` method:
```csharp
bool checkCount = products.AtMost(5);
```

Additionally ExtraLINQ provides overloads of some methods (e.g. `Sum`) for the most commonly used collections: `T[]` and `List<T>`. These methods work faster and allocate less than LINQ built-in methods. For benchmarks see [Benchmark](https://github.com/kpol/ExtraLINQ/tree/master/src/Benchmark) project.

# List of methods
**AtLeast**  
Checks whether the number of elements is greater or equal to the given integer.
```csharp
bool result = source.AtLeast(5);
```

**AtMost**  
Checks whether the number of elements is lesser or equal to the given integer.
```csharp
bool result = source.AtMost(5);
```

**CountBetween**  
Checks whether the number of elements is between an inclusive range of minimum and maximum integers.
```csharp
bool result = source.CountBetween(4, 6);
```

**Exactly**  
Checks whether the number of elements in the source is equal to the given integer.
```csharp
bool result = source.Exactly(5);
```

**DistinctBy**  
Returns distinct elements of the given source using `keySelector` and comparer (can be `null`).
```csharp
var result = source.DistinctBy(p => p.Category);
```

**MaxBy**  
Returns the maximal element of the given source based on the given selector and comparer (can be `null`).
```csharp
var result = source.MaxBy(p => p.Price);
```

**MinBy**  
Returns the minimal element of the given source based on the given selector and comparer (can be `null`).
```csharp
var result = source.MinBy(p => p.Price);
```

**Pairwise**  
Returns a sequence of each element in the input sequence and its predecessor, with the exception of the first element which is only returned as the predecessor of the second element.
```csharp
var result = source.Pairwise((first, second) => $"{first.Id} {second.Id}");
```

**Sum**  
Returns the sum of a sequence of numeric values. Has overloads for `int`, `uint`, `long`, `ulong`, `float`, `double`, `decimal`, corresponding `Nullable<T>`, and overloads for `T[]` and `List<T>`
```csharp
var result = source.Sum();
```

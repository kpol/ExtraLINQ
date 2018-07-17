using System;
using System.Collections.Generic;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> selector, IComparer<TKey> comparer = null)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (selector == null) throw Error.ArgumentNull(nameof(selector));

            comparer = comparer ?? Comparer<TKey>.Default;

            if (source is IList<TSource> list)
            {
                return GetExtremaList(selector, (x, y) => comparer.Compare(x, y), list.Count, i => list[i]);
            }

            if (source is IReadOnlyList<TSource> readOnlyList)
            {
                return GetExtremaList(selector, (x, y) => comparer.Compare(x, y), readOnlyList.Count, i => readOnlyList[i]);
            }

            return GetExtrema(source, selector, (x, y) => comparer.Compare(x, y));
        }

        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> selector, IComparer<TKey> comparer = null)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (selector == null) throw Error.ArgumentNull(nameof(selector));

            comparer = comparer ?? Comparer<TKey>.Default;

            if (source is IList<TSource> list)
            {
                return GetExtremaList(selector, (x, y) => comparer.Compare(y, x), list.Count, i => list[i]);
            }

            if (source is IReadOnlyList<TSource> readOnlyList)
            {
                return GetExtremaList(selector, (x, y) => comparer.Compare(y, x), readOnlyList.Count, i => readOnlyList[i]);
            }

            return GetExtrema(source, selector, (x, y) => comparer.Compare(y, x));
        }

        private static TSource GetExtrema<TSource, TKey>(IEnumerable<TSource> source,
            Func<TSource, TKey> selector, Func<TKey, TKey, int> funcComparer)
        {
            using (var sourceIterator = source.GetEnumerator())
            {
                if (!sourceIterator.MoveNext())
                {
                    throw Error.NoElements();
                }

                var extrema = sourceIterator.Current;
                var extremaKey = selector(extrema);

                while (sourceIterator.MoveNext())
                {
                    var candidate = sourceIterator.Current;
                    var candidateProjected = selector(candidate);

                    if (funcComparer(candidateProjected, extremaKey) > 0)
                    {
                        extrema = candidate;
                        extremaKey = candidateProjected;
                    }
                }

                return extrema;
            }
        }

        private static TSource GetExtremaList<TSource, TKey>(Func<TSource, TKey> selector, 
            Func<TKey, TKey, int> funcComparer, 
            int count,
            Func<int, TSource> getItem)
        {
            if (count == 0)
            {
                throw Error.NoElements();
            }

            var extrema = getItem(0);
            var extremaKey = selector(extrema);

            for (int i = 1; i < count; i++)
            {
                var candidate = getItem(i);
                var candidateProjected = selector(candidate);

                if (funcComparer(extremaKey, candidateProjected) < 0)
                {
                    extrema = candidate;
                    extremaKey = candidateProjected;
                }
            }

            return extrema;
        }
    }
}
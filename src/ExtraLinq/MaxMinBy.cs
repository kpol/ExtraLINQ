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

            return GetExtrema(source, selector, (x, y) => comparer.Compare(x, y));
        }

        public static TSource MaxBy<TSource, TKey>(this TSource[] source,
            Func<TSource, TKey> selector, IComparer<TKey> comparer = null)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (selector == null) throw Error.ArgumentNull(nameof(selector));

            comparer = comparer ?? Comparer<TKey>.Default;

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            return GetExtremaArray(source, selector, (x, y) => comparer.Compare(x, y));
        }

        public static TSource MinBy<TSource, TKey>(this TSource[] source,
            Func<TSource, TKey> selector, IComparer<TKey> comparer = null)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (selector == null) throw Error.ArgumentNull(nameof(selector));

            comparer = comparer ?? Comparer<TKey>.Default;

            if (source.Length == 0)
            {
                throw Error.NoElements();
            }

            return GetExtremaArray(source, selector, (x, y) => comparer.Compare(y, x));
        }

        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> selector, IComparer<TKey> comparer = null)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (selector == null) throw Error.ArgumentNull(nameof(selector));

            comparer = comparer ?? Comparer<TKey>.Default;

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

        private static TSource GetExtremaArray<TSource, TKey>(TSource[] source,
            Func<TSource, TKey> selector, Func<TKey, TKey, int> funcComparer)
        {
            var extrema = source[0];
            var extremaKey = selector(extrema);

            for (int i = 1; i < source.Length; i++)
            {
                var candidate = source[i];
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
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

            return MaxMinByImplementation(source, selector, comparer, 1);
        }

        public static TSource MaxBy<TSource, TKey>(this TSource[] source,
            Func<TSource, TKey> selector, IComparer<TKey> comparer = null)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (selector == null) throw Error.ArgumentNull(nameof(selector));

            comparer = comparer ?? Comparer<TKey>.Default;

            return GetExtremaArray(source, selector, comparer, 1);
        }

        public static TSource MaxBy<TSource, TKey>(this List<TSource> source,
            Func<TSource, TKey> selector, IComparer<TKey> comparer = null)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (selector == null) throw Error.ArgumentNull(nameof(selector));

            comparer = comparer ?? Comparer<TKey>.Default;

            return GetExtremaList(source, selector, comparer, 1);
        }

        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> selector, IComparer<TKey> comparer = null)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (selector == null) throw Error.ArgumentNull(nameof(selector));

            comparer = comparer ?? Comparer<TKey>.Default;

            return MaxMinByImplementation(source, selector, comparer, -1);
        }

        public static TSource MinBy<TSource, TKey>(this TSource[] source,
            Func<TSource, TKey> selector, IComparer<TKey> comparer = null)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (selector == null) throw Error.ArgumentNull(nameof(selector));

            comparer = comparer ?? Comparer<TKey>.Default;

            return GetExtremaArray(source, selector, comparer, -1);
        }

        public static TSource MinBy<TSource, TKey>(this List<TSource> source,
            Func<TSource, TKey> selector, IComparer<TKey> comparer = null)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (selector == null) throw Error.ArgumentNull(nameof(selector));

            comparer = comparer ?? Comparer<TKey>.Default;

            return GetExtremaList(source, selector, comparer, -1);
        }

        private static TSource MaxMinByImplementation<TSource, TKey>(IEnumerable<TSource> source,
            Func<TSource, TKey> selector, IComparer<TKey> comparer, int sign)
        {
            if (source is TSource[] array)
            {
                return GetExtremaArray(array, selector, comparer, sign);
            }

            if (source is List<TSource> list)
            {
                return GetExtremaList(list, selector, comparer, sign);
            }

            if (source is IList<TSource> listInterface)
            {
                return GetExtremaInterfaceList(selector, comparer, sign, listInterface.Count, i => listInterface[i]);
            }

            if (source is IReadOnlyList<TSource> readOnlyList)
            {
                return GetExtremaInterfaceList(selector, comparer, sign, readOnlyList.Count, i => readOnlyList[i]);
            }

            return GetExtrema(source, selector, comparer, sign);
        }

        private static TSource GetExtrema<TSource, TKey>(IEnumerable<TSource> source,
            Func<TSource, TKey> selector,
            IComparer<TKey> comparer,
            int sign)
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

                    if (sign * comparer.Compare(extremaKey, candidateProjected) < 0)
                    {
                        extrema = candidate;
                        extremaKey = candidateProjected;
                    }
                }

                return extrema;
            }
        }

        private static TSource GetExtremaInterfaceList<TSource, TKey>(Func<TSource, TKey> selector,
            IComparer<TKey> comparer,
            int sign,
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

                if (sign * comparer.Compare(extremaKey, candidateProjected) < 0)
                {
                    extrema = candidate;
                    extremaKey = candidateProjected;
                }
            }

            return extrema;
        }

        private static TSource GetExtremaArray<TSource, TKey>(TSource[] array, Func<TSource, TKey> selector,
            IComparer<TKey> comparer,
            int sign)
        {
            if (array.Length == 0)
            {
                throw Error.NoElements();
            }

            var extrema = array[0];
            var extremaKey = selector(extrema);

            for (int i = 1; i < array.Length; i++)
            {
                var candidate = array[i];
                var candidateProjected = selector(candidate);

                if (sign * comparer.Compare(extremaKey, candidateProjected) < 0)
                {
                    extrema = candidate;
                    extremaKey = candidateProjected;
                }
            }

            return extrema;
        }

        private static TSource GetExtremaList<TSource, TKey>(List<TSource> list, Func<TSource, TKey> selector,
            IComparer<TKey> comparer,
            int sign)
        {
            if (list.Count == 0)
            {
                throw Error.NoElements();
            }

            var extrema = list[0];
            var extremaKey = selector(extrema);

            for (int i = 1; i < list.Count; i++)
            {
                var candidate = list[i];
                var candidateProjected = selector(candidate);

                if (sign * comparer.Compare(extremaKey, candidateProjected) < 0)
                {
                    extrema = candidate;
                    extremaKey = candidateProjected;
                }
            }

            return extrema;
        }
    }
}
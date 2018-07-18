using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, 
            SortOrder sortOrder,
            IComparer<TKey> comparer = null)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (keySelector == null) throw Error.ArgumentNull(nameof(keySelector));

            return sortOrder == SortOrder.Ascending ? source.OrderBy(keySelector, comparer) : source.OrderByDescending(keySelector, comparer);
        }

        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
            this IOrderedEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            SortOrder sortOrder, 
            IComparer<TKey> comparer = null)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (keySelector == null) throw Error.ArgumentNull(nameof(keySelector));

            return sortOrder == SortOrder.Ascending ? source.ThenBy(keySelector, comparer) : source.ThenByDescending(keySelector, comparer);
        }
    }
}
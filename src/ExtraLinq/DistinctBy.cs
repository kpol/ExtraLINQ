using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, IEqualityComparer<TKey> keyComparer = null)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (keySelector == null) throw Error.ArgumentNull(nameof(keySelector));

            return _();

            IEnumerable<TSource> _()
            {
                var set = new HashSet<TKey>(keyComparer);

                return source.Where(item => set.Add(keySelector(item)));
            }
        }
    }
}
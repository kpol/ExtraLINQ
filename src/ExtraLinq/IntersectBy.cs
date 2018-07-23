using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static IEnumerable<TSource> IntersectBy<TSource, TKey>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second, 
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> keyComparer = null)
        {
            if (first == null) throw Error.ArgumentNull(nameof(first));
            if (second == null) throw Error.ArgumentNull(nameof(second));
            if (keySelector == null) throw Error.ArgumentNull(nameof(keySelector));

            return _();

            IEnumerable<TSource> _()
            {
                var keys = new HashSet<TKey>(second.Select(keySelector), keyComparer);

                foreach (var item in first)
                {
                    if (keys.Remove(keySelector(item)))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
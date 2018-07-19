using System.Collections.Generic;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer = null)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            return new HashSet<TSource>(source, comparer);
        }
    }
}
using System.Collections.Generic;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        private static int? TryGetCount<TSource>(this IEnumerable<TSource> source)
        {
            if (source is ICollection<TSource> collection)
            {
                return collection.Count;
            }

            if (source is IReadOnlyCollection<TSource> readOnlyCollection)
            {
                return readOnlyCollection.Count;
            }

            return null;
        }
    }
}
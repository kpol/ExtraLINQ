using System.Collections.Generic;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static bool AtMost<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            if (count < 0)
            {
                throw Error.CountIsNegative(nameof(count));
            }

            // ReSharper disable once PossibleMultipleEnumeration
            var totalCount = GetCount(source);

            if (totalCount.HasValue)
            {
                return totalCount <= count;
            }

            // ReSharper disable once PossibleMultipleEnumeration
            return CountBetweenImpl(source, 0, count);
        }
    }
}
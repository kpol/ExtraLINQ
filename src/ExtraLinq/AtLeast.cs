using System.Collections.Generic;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static bool AtLeast<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            if (count < 0)
            {
                throw Error.CountIsNegative(nameof(count));
            }

            // ReSharper disable once PossibleMultipleEnumeration
            var totalCount = TryGetCount(source);

            if (totalCount.HasValue)
            {
                return totalCount >= count;
            }

            // ReSharper disable once PossibleMultipleEnumeration
            return CountBetweenImpl(source, count, int.MaxValue);
        }
    }
}
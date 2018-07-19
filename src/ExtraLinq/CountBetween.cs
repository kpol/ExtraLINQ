using System.Collections.Generic;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static bool CountBetween<TSource>(this IEnumerable<TSource> source, int minInclusive, int maxInclusive)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            if (minInclusive < 0)
            {
                throw Error.CountIsNegative(nameof(minInclusive));
            }

            if (maxInclusive < 0)
            {
                throw Error.CountIsNegative(nameof(maxInclusive));
            }

            if (minInclusive > maxInclusive)
            {
                throw Error.MinIsGreaterThanMax(nameof(minInclusive), nameof(maxInclusive));
            }

            // ReSharper disable once PossibleMultipleEnumeration
            var count = source.TryGetCount();

            if (count.HasValue)
            {
                return count >= minInclusive && count <= maxInclusive;
            }

            // ReSharper disable once PossibleMultipleEnumeration
            return CountBetweenImpl(source, minInclusive, maxInclusive);
        }

        private static bool CountBetweenImpl<TSource>(IEnumerable<TSource> source, int min, int max)
        {
            int number = 0;

            using (var enumeratorSource = source.GetEnumerator())
            {
                // used in AtLeast
                if (max == int.MaxValue)
                {
                    while (enumeratorSource.MoveNext())
                    {
                        number++;

                        if (number >= min)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    while (enumeratorSource.MoveNext())
                    {
                        number++;

                        if (number > max)
                        {
                            return false;
                        }
                    }
                }
            }

            return number >= min && number <= max;
        }
    }
}

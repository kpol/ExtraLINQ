using System.Collections.Generic;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static bool CountBetween<TSource>(this IEnumerable<TSource> source, int min, int max)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            if (min < 0)
            {
                throw Error.CountIsNegative(nameof(min));
            }

            if (max < 0)
            {
                throw Error.CountIsNegative(nameof(max));
            }

            if (min > max)
            {
                throw Error.MinIsGreaterThanMax(nameof(min), nameof(max));
            }

            // ReSharper disable once PossibleMultipleEnumeration
            var count = source.TryGetCount();

            if (count.HasValue)
            {
                return count >= min && count <= max;
            }

            // ReSharper disable once PossibleMultipleEnumeration
            return CountBetweenImpl(source, min, max);
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

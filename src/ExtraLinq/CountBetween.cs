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
            var count = source.GetCount();

            if (count.HasValue)
            {
                return count >= min && count <= max;
            }

            int number = 0;

            // ReSharper disable once PossibleMultipleEnumeration
            using (var enumeratorSource = source.GetEnumerator())
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

            return number >= min && number <= max;
        }

        public static bool CountBetween<TSource>(this TSource[] source, int min, int max)
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

            return source.Length >= min && source.Length <= max;
        }

        public static bool CountBetween<TSource>(this List<TSource> source, int min, int max)
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

            return source.Count >= min && source.Count <= max;
        }
    }
}

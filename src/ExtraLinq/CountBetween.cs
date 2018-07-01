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

            if (source is ICollection<TSource> collection)
            {
                return collection.Count >= min && collection.Count <= max;
            }

            if (source is IReadOnlyCollection<TSource> readOnlyCollection)
            {
                return readOnlyCollection.Count >= min && readOnlyCollection.Count <= max;
            }

            int number = 0;

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

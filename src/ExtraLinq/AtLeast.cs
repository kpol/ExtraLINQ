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
            var totalCount = GetCount(source);

            if (totalCount.HasValue)
            {
                return totalCount >= count;
            }

            int number = 0;

            // ReSharper disable once PossibleMultipleEnumeration
            using (var enumeratorSource = source.GetEnumerator())
            {
                while (enumeratorSource.MoveNext())
                {
                    number++;

                    if (number >= count)
                    {
                        return true;
                    }
                }
            }

            return number >= count;
        }

        public static bool AtLeast<TSource>(this TSource[] source, int count)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            if (count < 0)
            {
                throw Error.CountIsNegative(nameof(count));
            }

            return source.Length >= count;
        }

        public static bool AtLeast<TSource>(this List<TSource> source, int count)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            if (count < 0)
            {
                throw Error.CountIsNegative(nameof(count));
            }

            return source.Count >= count;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second, Func<TSource, TKey> keySelector,
            bool includeDuplicates = false,
            IEqualityComparer<TKey> keyComparer = null)
        {
            if (first == null) throw Error.ArgumentNull(nameof(first));
            if (second == null) throw Error.ArgumentNull(nameof(second));
            if (keySelector == null) throw Error.ArgumentNull(nameof(keySelector));

            var keys = new HashSet<TKey>(second.Select(keySelector), keyComparer);

            return ExceptByImpl(first, keys, keySelector, includeDuplicates);
        }

        public static IEnumerable<TFirst> ExceptBy<TFirst, TSecond, TKey>(this IEnumerable<TFirst> first,
            Func<TFirst, TKey> keySelectorFirst,
            IEnumerable<TSecond> second,
            Func<TSecond, TKey> keySelectorSecond,
            bool includeDuplicates = false,
            IEqualityComparer<TKey> keyComparer = null)
        {
            if (first == null) throw Error.ArgumentNull(nameof(first));
            if (keySelectorFirst == null) throw Error.ArgumentNull(nameof(keySelectorFirst));
            if (second == null) throw Error.ArgumentNull(nameof(second));
            if (keySelectorSecond == null) throw Error.ArgumentNull(nameof(keySelectorSecond));

            var keys = new HashSet<TKey>(second.Select(keySelectorSecond), keyComparer);

            return ExceptByImpl(first, keys, keySelectorFirst, includeDuplicates);
        }

        private static IEnumerable<TSource> ExceptByImpl<TSource, TKey>(IEnumerable<TSource> source,
            HashSet<TKey> keys,
            Func<TSource, TKey> keySelector,
            bool includeDuplicates)
        {
            if (!includeDuplicates)
            {
                foreach (var item in source)
                {
                    if (keys.Add(keySelector(item)))
                    {
                        yield return item;
                    }
                }
            }
            else
            {
                foreach (var item in source)
                {
                    if (!keys.Contains(keySelector(item)))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
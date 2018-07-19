using System;
using System.Collections.Generic;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (action == null) throw Error.ArgumentNull(nameof(action));

            foreach (var item in source)
            {
                action(item);
            }
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (action == null) throw Error.ArgumentNull(nameof(action));

            var index = 0;

            foreach (var item in source)
            {
                action(item, index++);
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static IEnumerable<TResult> Pairwise<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, TResult> selector)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            if (selector == null) throw Error.ArgumentNull(nameof(selector));

            return _();

            IEnumerable<TResult> _()
            {
                using (var enumerator = source.GetEnumerator())
                {
                    if (!enumerator.MoveNext())
                    {
                        yield break;
                    }

                    var current = enumerator.Current;

                    while (enumerator.MoveNext())
                    {
                        yield return selector(current, enumerator.Current);
                        current = enumerator.Current;
                    }
                }
            }
        }
    }
}
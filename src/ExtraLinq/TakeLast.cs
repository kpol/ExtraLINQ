using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static IEnumerable<TSource> TakeLast<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            return _();

            IEnumerable<TSource> _()
            {
                if (count <= 0)
                {
                    return Enumerable.Empty<TSource>();
                }

                if (source is IReadOnlyList<TSource> readOnlyList)
                {
                    return ListImplementation(readOnlyList.Count, i => readOnlyList[i]);
                }

                if (source is IList<TSource> list)
                {
                    return ListImplementation(list.Count, i => list[i]);
                }

                return EnumerableImplementation();
            }

            IEnumerable<TSource> ListImplementation(int length, Func<int, TSource> getItem)
            {
                var c = count > length ? length : count;

                for (int i = length - c; i < length; i++)
                {
                    yield return getItem(i);
                }
            }

            IEnumerable<TSource> EnumerableImplementation()
            {
                var q = new Queue<TSource>(count);

                foreach (var item in source)
                {
                    if (q.Count == count)
                    {
                        q.Dequeue();
                    }

                    q.Enqueue(item);
                }

                foreach (var item in q)
                {
                    yield return item;
                }
            }
        }
    }
}
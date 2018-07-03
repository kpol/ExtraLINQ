using System.Collections.Generic;

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
                    yield break;
                }

                if (source is IReadOnlyList<TSource> list)
                {
                    var c = count > list.Count ? list.Count : count;

                    for (int i = list.Count - c; i < list.Count; i++)
                    {
                        yield return list[i];
                    }
                }
                else
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
}
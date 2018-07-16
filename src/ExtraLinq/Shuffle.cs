using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static IEnumerable<TSource> Shuffle<TSource>(this IEnumerable<TSource> source, Random random = null)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));
            random = random ?? GlobalRandom.Instance;

            return _();

            IEnumerable<TSource> _()
            {
                var array = source.ToArray();

                for (var i = array.Length - 1; i >= 0; i--)
                {
                    var index = random.Next(0, i + 1);

                    var tmp = array[i];
                    array[i] = array[index];
                    array[index] = tmp;
                }

                foreach (var item in array)
                {
                    yield return item;
                }
            }
        }
    }
}
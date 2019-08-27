using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ExtraLinq.Tests
{
    public class PairwiseTests
    {
        [Fact]
        public void PairwiseSourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => ((IEnumerable<int>) null).Pairwise((x, y) => new {x, y}));
        }

        [Fact]
        public void PairwiseSelectorIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => Enumerable.Range(1, 5).Pairwise((Func<int, int, int>) null));
        }

        [Fact]
        public void PairwiseSourceEmpty()
        {
            var result = Enumerable.Range(1, 0).Pairwise((x, y) => new Tuple<int, int>(x, y));

            Assert.Equal(Enumerable.Empty<Tuple<int, int>>().ToArray(), result.ToArray());
        }

        [Fact]
        public void PairwiseSourceOneItem()
        {
            var result = Enumerable.Range(1, 1).Pairwise((x, y) => new Tuple<int, int>(x, y));

            Assert.Equal(Enumerable.Empty<Tuple<int, int>>().ToArray(), result.ToArray());
        }

        [Fact]
        public void Pairwise()
        {
            var result = Enumerable.Range(1, 5).Pairwise((x, y) => new Tuple<int, int>(x, y));

            Assert.Equal(new[]
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(2, 3),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(4, 5),
            }, result.ToArray());
        }
    }
}
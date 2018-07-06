using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtraLinq.Tests
{
    [TestClass]
    public class PairwiseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PairwiseSourceIsNull()
        {
            var _ = ((IEnumerable<int>) null).Pairwise((x, y) => new {x, y});
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PairwiseSelectorIsNull()
        {
            var _ = Enumerable.Range(1, 5).Pairwise((Func<int, int, int>) null);
        }

        [TestMethod]
        public void PairwiseSourceEmpty()
        {
            var result = Enumerable.Range(1, 0).Pairwise((x, y) => new Tuple<int, int>(x, y));

            CollectionAssert.AreEquivalent(Enumerable.Empty<Tuple<int, int>>().ToArray(), result.ToArray());
        }

        [TestMethod]
        public void PairwiseSourceOneItem()
        {
            var result = Enumerable.Range(1, 1).Pairwise((x, y) => new Tuple<int, int>(x, y));

            CollectionAssert.AreEquivalent(Enumerable.Empty<Tuple<int, int>>().ToArray(), result.ToArray());
        }

        [TestMethod]
        public void Pairwise()
        {
            var result = Enumerable.Range(1, 5).Pairwise((x, y) => new Tuple<int, int>(x, y));

            CollectionAssert.AreEquivalent(new[]
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(2, 3),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(4, 5),
            }, result.ToArray());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtraLinq.Tests
{
    [TestClass]
    public class IntersectByTests
    {
        [TestMethod]
        public void IntersectByEnumearble()
        {
            var first = Enumerable.Range(1, 5).Select(x => new Data {Id = x, Text = (x * 10).ToString()});
            var second = Enumerable.Range(3, 5).Select(x => new Data { Id = x, Text = (x * 10).ToString() });

            var result = first.IntersectBy(second, x => x.Id).ToArray();

            Assert.AreEqual(3, result.Length);
            CollectionAssert.AreEquivalent(new[] {3, 4, 5}, result.Select(x => x.Id).ToArray());
            CollectionAssert.AreEquivalent(new[] { "30", "40", "50" }, result.Select(x => x.Text).ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IntersectBySourceIsNull()
        {
            var _ = ((IEnumerable<int>)null).IntersectBy(Enumerable.Range(1, 10), x => x);
        }

        private class Data
        {
            public int Id { get; set; }

            public string Text { get; set; }
        }
    }
}
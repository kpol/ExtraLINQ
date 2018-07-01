using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtraLinq.Tests
{
    [TestClass]
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public class CountTests
    {
        [TestMethod]
        public void AtLeast()
        {
            var array = Enumerable.Range(1, 5);

            Assert.IsTrue(array.AtLeast(0));
            Assert.IsTrue(array.AtLeast(1));
            Assert.IsTrue(array.AtLeast(4));
            Assert.IsTrue(array.AtLeast(5));
            Assert.IsFalse(array.AtLeast(6));
        }

        [TestMethod]
        public void AtLeastArray()
        {
            var array = Enumerable.Range(1, 5).ToArray();

            Assert.IsTrue(array.AtLeast(0));
            Assert.IsTrue(array.AtLeast(1));
            Assert.IsTrue(array.AtLeast(4));
            Assert.IsFalse(array.AtLeast(6));
        }

        [TestMethod]
        public void AtLeastCollection()
        {
            IEnumerable<int> array = Enumerable.Range(1, 5).ToArray();

            Assert.IsTrue(array.AtLeast(0));
            Assert.IsTrue(array.AtLeast(1));
            Assert.IsTrue(array.AtLeast(4));
            Assert.IsFalse(array.AtLeast(6));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AtLeastSourceIsNull()
        {
            IEnumerable<int> array = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var _ = array.AtLeast(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AtLeastCountIsNegative()
        {
            var array = Enumerable.Range(1, 5);

            var _ = array.AtLeast(-1);
        }

        [TestMethod]
        public void CountBetween()
        {
            var array = Enumerable.Range(1, 5);

            Assert.IsFalse(array.CountBetween(0, 0));
            Assert.IsFalse(array.CountBetween(0, 1));
            Assert.IsFalse(array.CountBetween(1, 4));

            Assert.IsTrue(array.CountBetween(2, 6));
            Assert.IsTrue(array.CountBetween(1, 10));

            Assert.IsFalse(array.CountBetween(6, 7));
        }

        [TestMethod]
        public void CountBetweenEmpty()
        {
            var array = Enumerable.Empty<int>();

            Assert.IsTrue(array.CountBetween(0, 0));

            Assert.IsTrue(array.CountBetween(0, 1));

            Assert.IsFalse(array.CountBetween(1, 4));
            Assert.IsFalse(array.CountBetween(2, 6));
            Assert.IsFalse(array.CountBetween(1, 10));

            Assert.IsFalse(array.CountBetween(6, 7));
        }

        [TestMethod]
        public void CountBetweenCollection()
        {
            IEnumerable<int> array = Enumerable.Range(1, 5).ToArray();

            Assert.IsFalse(array.CountBetween(0, 0));
            Assert.IsFalse(array.CountBetween(0, 1));
            Assert.IsFalse(array.CountBetween(1, 4));

            Assert.IsTrue(array.CountBetween(2, 6));
            Assert.IsTrue(array.CountBetween(1, 10));

            Assert.IsFalse(array.CountBetween(6, 7));
        }

        [TestMethod]
        public void CountBetweenCollectionEmpty()
        {
            IEnumerable<int> array = new int[0];

            Assert.IsTrue(array.CountBetween(0, 0));

            Assert.IsTrue(array.CountBetween(0, 1));

            Assert.IsFalse(array.CountBetween(1, 4));
            Assert.IsFalse(array.CountBetween(2, 6));
            Assert.IsFalse(array.CountBetween(1, 10));

            Assert.IsFalse(array.CountBetween(6, 7));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CountBetweenMinGreaterMax()
        {
            var array = Enumerable.Range(1, 5);

            var _ = array.CountBetween(5, 1);
        }

        [TestMethod]
        public void AtMost()
        {
            var array = Enumerable.Range(1, 5);

            Assert.IsFalse(array.AtMost(0));
            Assert.IsFalse(array.AtMost(1));
            Assert.IsFalse(array.AtMost(4));

            Assert.IsTrue(array.AtMost(5));
            Assert.IsTrue(array.AtMost(6));
            Assert.IsTrue(array.AtMost(int.MaxValue));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable PossibleMultipleEnumeration

namespace ExtraLinq.Tests
{
    [TestClass]
    public class ExactlyTests
    {
        [TestMethod]
        public void ExactlyArray()
        {
            var source = Enumerable.Range(1, 5).ToArray();

            Assert.IsTrue(source.Exactly(5));
            Assert.IsFalse(source.Exactly(0));
            Assert.IsFalse(source.Exactly(1));
            Assert.IsFalse(source.Exactly(6));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExactlySourceIsNull()
        {
            var _ = ((IEnumerable<int>)null).Exactly(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExactlyCountIsNegative()
        {
            int[] source = { 1, 2, 3, 4, 5 };

            var _ = source.Exactly(-2);
        }

        [TestMethod]
        public void ExactlyEnumerable()
        {
            var source = Enumerable.Range(1, 5);

            Assert.IsTrue(source.Exactly(5));
            Assert.IsFalse(source.Exactly(0));
            Assert.IsFalse(source.Exactly(1));
            Assert.IsFalse(source.Exactly(6));
        }

        [TestMethod]
        public void ExactlyEmpty()
        {
            var source = Enumerable.Empty<int>();

            Assert.IsTrue(source.Exactly(0));
            Assert.IsFalse(source.Exactly(1));
            Assert.IsFalse(source.Exactly(2));
            Assert.IsFalse(source.Exactly(100));
        }

        [TestMethod]
        public void ExactlyEmptyArray()
        {
            var source = Enumerable.Empty<int>().ToArray();

            Assert.IsTrue(source.Exactly(0));
            Assert.IsFalse(source.Exactly(1));
            Assert.IsFalse(source.Exactly(2));
            Assert.IsFalse(source.Exactly(100));
        }
    }
}
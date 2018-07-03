using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtraLinq.Tests
{
    [TestClass]
    public class TakeLastTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TakeLastSourceIsNull()
        {
            var _ = ((IEnumerable<int>) null).TakeLast(2);
        }

        [TestMethod]
        public void TakeLastCountEqualsZero()
        {
            var source = Enumerable.Range(0, 6);

            var result = source.TakeLast(0);

            var resultArray = result.ToArray();

            Assert.AreEqual(0, resultArray.Length);
        }

        [TestMethod]
        public void TakeLastCountLessThanZero()
        {
            var source = Enumerable.Range(0, 6);

            var result = source.TakeLast(-5);

            var resultArray = result.ToArray();

            Assert.AreEqual(0, resultArray.Length);
        }

        [TestMethod]
        public void TakeLastCount()
        {
            var source = Enumerable.Range(0, 6);

            var result = source.TakeLast(2);

            CollectionAssert.AreEquivalent(new[] { 4, 5 }, result.ToArray());
        }

        [TestMethod]
        public void TakeLastMoreThanCount()
        {
            var source = Enumerable.Range(0, 6);

            var result = source.TakeLast(100).ToArray();

            CollectionAssert.AreEquivalent(source.ToArray(), result.ToArray());
        }

        [TestMethod]
        public void TakeLastArrayCountEqualsZero()
        {
            var source = Enumerable.Range(0, 6).ToArray();

            var result = source.TakeLast(0);

            var resultArray = result.ToArray();

            Assert.AreEqual(0, resultArray.Length);
        }

        [TestMethod]
        public void TakeLastArrayCountLessThanZero()
        {
            var source = Enumerable.Range(0, 6).ToArray();

            var result = source.TakeLast(-5);

            var resultArray = result.ToArray();

            Assert.AreEqual(0, resultArray.Length);
        }

        [TestMethod]
        public void TakeLastArrayCount()
        {
            var source = Enumerable.Range(0, 6).ToArray();

            var result = source.TakeLast(2);

            CollectionAssert.AreEquivalent(new[] {4, 5}, result.ToArray());
        }

        [TestMethod]
        public void TakeLastArrayMoreThanCount()
        {
            var source = Enumerable.Range(0, 6).ToArray();

            var result = source.TakeLast(100);

            CollectionAssert.AreEquivalent(source, result.ToArray());
        }
    }
}
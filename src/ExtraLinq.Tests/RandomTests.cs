using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtraLinq.Tests
{
    [TestClass]
    public class RandomTests
    {
        [TestMethod]
        public void RandomNext()
        {
            var random = ExtraEnumerable.Random(1, 3).Take(50).ToArray();

            Assert.AreEqual(50, random.Length);
            Assert.IsTrue(random.All(n => n >= 1 && n <= 2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RandomMaxIsNegative()
        {
            var _ = ExtraEnumerable.Random(-3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RandomMinIsGreaterThanMax()
        {
            var _ = ExtraEnumerable.Random(5, 4);
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtraLinq.Tests
{
    [TestClass]
    public class DistinctByTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowsExceptionSource()
        {
            IEnumerable<int> test = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var result = test.DistinctBy(x => x);
        }

        private IEnumerable<Tuple<int, string>> GetTestData()
        {
            yield return new Tuple<int, string>(1, "a");
            yield return new Tuple<int, string>(2, "b");
            yield return new Tuple<int, string>(3, "c");
            yield return new Tuple<int, string>(1, "d");
        }
    }
}

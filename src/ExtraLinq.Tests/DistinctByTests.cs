using System;
using System.Collections.Generic;
using Xunit;

namespace ExtraLinq.Tests
{
    public class DistinctByTests
    {
        [Fact]
        public void ThrowsExceptionSource()
        {
            IEnumerable<int> test = null;

            Assert.Throws<ArgumentNullException>(() => test.DistinctBy(x => x));
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

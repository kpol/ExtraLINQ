using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ExtraLinq.Tests
{
    public class ExactlyTests
    {
        [Theory]
        [InlineData(5, true)]
        [InlineData(0, false)]
        [InlineData(1, false)]
        [InlineData(6, false)]
        public void ExactlyArray(int count, bool expected)
        {
            var source = Enumerable.Range(1, 5).ToArray();
            var result = source.Exactly(count);

            Assert.True(expected == result);
        }

        [Fact]
        public void ExactlySourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => ((IEnumerable<int>) null).Exactly(1));
        }

        [Fact]
        public void ExactlyCountIsNegative()
        {
            int[] source = { 1, 2, 3, 4, 5 };

            Assert.Throws<ArgumentOutOfRangeException>(() => source.Exactly(-2));
        }

        [Theory]
        [InlineData(5, true)]
        [InlineData(0, false)]
        [InlineData(1, false)]
        [InlineData(6, false)]
        public void ExactlyEnumerable(int count, bool expected)
        {
            var source = Enumerable.Range(1, 5);
            var result = source.Exactly(count);

            Assert.True(expected == result);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(2, false)]
        [InlineData(100, false)]
        public void ExactlyEmpty(int count, bool expected)
        {
            var source = Enumerable.Empty<int>();
            var result = source.Exactly(count);

            Assert.True(expected == result);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(2, false)]
        [InlineData(100, false)]
        public void ExactlyEmptyArray(int count, bool expected)
        {
            var source = Enumerable.Empty<int>().ToArray();
            var result = source.Exactly(count);

            Assert.True(expected == result);
        }
    }
}
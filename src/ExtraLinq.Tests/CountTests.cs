using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace ExtraLinq.Tests
{
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public class CountTests
    {
        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        public void AtLeast(int count, bool expected)
        {
            var array = Enumerable.Range(1, 5);

            var result = array.AtLeast(count);

            Assert.True(expected == result);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        public void AtLeastArray(int count, bool expected)
        {
            var array = Enumerable.Range(1, 5).ToArray();

            var result = array.AtLeast(count);

            Assert.True(expected == result);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        public void AtLeastCollection(int count, bool expected)
        {
            IEnumerable<int> array = Enumerable.Range(1, 5).ToArray();

            var result = array.AtLeast(count);

            Assert.True(expected == result);
        }


        [Fact]
        public void AtLeastSourceIsNull()
        {
            IEnumerable<int> array = null;

            Assert.Throws<ArgumentNullException>(() => array.AtLeast(1));
        }

        [Fact]
        public void AtLeastCountIsNegative()
        {
            var array = Enumerable.Range(1, 5);

            Assert.Throws<ArgumentOutOfRangeException>(() => array.AtLeast(-1));
        }

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, false)]
        [InlineData(1, 4, false)]
        [InlineData(2, 6, true)]
        [InlineData(1, 10, true)]
        [InlineData(6, 7, false)]
        public void CountBetween(int min, int max, bool expected)
        {
            var array = Enumerable.Range(1, 5);
            var result = array.CountBetween(min, max);
            Assert.True(expected == result);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(0, 1, true)]
        [InlineData(1, 4, false)]
        [InlineData(2, 6, false)]
        [InlineData(1, 10, false)]
        [InlineData(6, 7, false)]
        public void CountBetweenEmpty(int min, int max, bool expected)
        {
            var array = Enumerable.Empty<int>();
            var result = array.CountBetween(min, max);
            Assert.True(expected == result);
        }

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, false)]
        [InlineData(1, 4, false)]
        [InlineData(2, 6, true)]
        [InlineData(1, 10, true)]
        [InlineData(6, 7, false)]
        public void CountBetweenCollection(int min, int max, bool expected)
        {
            IEnumerable<int> array = Enumerable.Range(1, 5).ToArray();

            var result = array.CountBetween(min, max);
            Assert.True(expected == result);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(0, 1, true)]
        [InlineData(1, 4, false)]
        [InlineData(2, 6, false)]
        [InlineData(1, 10, false)]
        [InlineData(6, 7, false)]
        public void CountBetweenCollectionEmpty(int min, int max, bool expected)
        {
            IEnumerable<int> array = new int[0];
            var result = array.CountBetween(min, max);
            Assert.True(expected == result);
        }

        [Fact]
        public void CountBetweenMinGreaterMax()
        {
            var array = Enumerable.Range(1, 5);

            Assert.Throws<ArgumentOutOfRangeException>(() => array.CountBetween(5, 1));
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, false)]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6,  true)]
        [InlineData(int.MaxValue, true)]
        public void AtMost(int count, bool expected)
        {
            var array = Enumerable.Range(1, 5);
            var result = array.AtMost(count);
            Assert.True(expected == result);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
// ReSharper disable PossibleMultipleEnumeration

namespace ExtraLinq.Tests
{
    public class TakeLastTests
    {
        [Fact]
        public void TakeLastSourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => ((IEnumerable<int>) null).TakeLast(2));
        }

        [Fact]
        public void TakeLastCountEqualsZero()
        {
            var source = Enumerable.Range(0, 6);

            var result = source.TakeLast(0);

            var resultArray = result.ToArray();

            Assert.Empty(resultArray);
        }

        [Fact]
        public void TakeLastCountLessThanZero()
        {
            var source = Enumerable.Range(0, 6);

            var result = source.TakeLast(-5);

            var resultArray = result.ToArray();

            Assert.Empty(resultArray);
        }

        [Fact]
        public void TakeLastCount()
        {
            var source = Enumerable.Range(0, 6);

            var result = source.TakeLast(2);

            Assert.Equal(new[] { 4, 5 }, result.ToArray());
        }

        [Fact]
        public void TakeLastMoreThanCount()
        {
            var source = Enumerable.Range(0, 6);

            var result = source.TakeLast(100).ToArray();

            Assert.Equal(source.ToArray(), result.ToArray());
        }

        [Fact]
        public void TakeLastArrayCountEqualsZero()
        {
            var source = Enumerable.Range(0, 6).ToArray();

            var result = source.TakeLast(0);

            var resultArray = result.ToArray();

            Assert.Empty(resultArray);
        }

        [Fact]
        public void TakeLastArrayCountLessThanZero()
        {
            var source = Enumerable.Range(0, 6).ToArray();

            var result = source.TakeLast(-5);

            var resultArray = result.ToArray();

            Assert.Empty(resultArray);
        }

        [Fact]
        public void TakeLastArrayCount()
        {
            var source = Enumerable.Range(0, 6).ToArray();

            var result = source.TakeLast(2);

            Assert.Equal(new[] {4, 5}, result.ToArray());
        }

        [Fact]
        public void TakeLastArrayMoreThanCount()
        {
            var source = Enumerable.Range(0, 6).ToArray();

            var result = source.TakeLast(100);

            Assert.Equal(source, result.ToArray());
        }
    }
}
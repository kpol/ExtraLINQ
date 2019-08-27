using System;
using System.Linq;
using Xunit;

namespace ExtraLinq.Tests
{
    public class RandomTests
    {
        [Fact]
        public void RandomNext()
        {
            var random = ExtraEnumerable.Random(1, 3).Take(50).ToArray();

            Assert.Equal(50, random.Length);
            Assert.True(random.All(n => n >= 1 && n <= 2));
        }

        [Fact]
        public void RandomMaxIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ExtraEnumerable.Random(-3));
        }

        [Fact]
        public void RandomMinIsGreaterThanMax()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ExtraEnumerable.Random(5, 4));
        }
    }
}
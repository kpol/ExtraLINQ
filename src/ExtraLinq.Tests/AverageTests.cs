using System.Linq;
using Xunit;

// ReSharper disable InvokeAsExtensionMethod

namespace ExtraLinq.Tests
{
    public class AverageTests
    {
        [Fact]
        public void AverageInt()
        {
            var source = Enumerable.Range(-100, 450).ToArray();

            Assert.Equal(Enumerable.Average(source), ExtraEnumerable.Average(source));
        }

        [Fact]
        public void AverageUInt()
        {
            var source = Enumerable.Range(0, 4500).ToArray();

            Assert.Equal(Enumerable.Average(source), ExtraEnumerable.Average(source.Select(x => (uint)x).ToArray()));
        }

        [Fact]
        public void AverageNullableInt()
        {
            var source = Enumerable.Range(0, 4500).Select(x => (int?)x).Concat(new int?[] {null, null, null}).Shuffle().ToArray();

            Assert.Equal(Enumerable.Average(source), ExtraEnumerable.Average(source));
        }
    }
}
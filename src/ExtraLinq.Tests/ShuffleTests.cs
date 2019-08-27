using System.Linq;
using Xunit;

namespace ExtraLinq.Tests
{
    public class ShuffleTests
    {
        [Fact]
        public void ShuffleSource()
        {
            var source = Enumerable.Range(1, 5).ToArray();

            var shuffle = source.Shuffle().ToArray();

            Assert.Equal(source, shuffle.OrderBy(x => x));
        }
    }
}
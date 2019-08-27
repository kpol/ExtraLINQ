using System.Linq;
using System.Text;
using Xunit;

namespace ExtraLinq.Tests
{
    public class ForEachTests
    {
        [Fact]
        public void ForEachEnumerable()
        {
            var source = Enumerable.Range(1, 2);

            var sb = new StringBuilder();

            source.ForEach((x, i) => { sb.Append($"{{{x},{i}}}");});

            Assert.Equal("{1,0}{2,1}", sb.ToString());
        }
    }
}
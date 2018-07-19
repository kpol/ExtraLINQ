using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtraLinq.Tests
{
    [TestClass]
    public class ForEachTests
    {
        [TestMethod]
        public void ForEachEnumerable()
        {
            var source = Enumerable.Range(1, 2);

            var sb = new StringBuilder();

            source.ForEach((x, i) => { sb.Append($"{{{x},{i}}}");});

            Assert.AreEqual("{1,0}{2,1}", sb.ToString());
        }
    }
}
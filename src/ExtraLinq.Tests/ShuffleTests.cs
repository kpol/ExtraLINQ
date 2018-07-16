using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtraLinq.Tests
{
    [TestClass]
    public class ShuffleTests
    {
        [TestMethod]
        public void ShuffleSource()
        {
            var source = Enumerable.Range(1, 5).ToArray();

            var shuffle = source.Shuffle().ToArray();

            CollectionAssert.AreEquivalent(source, shuffle);
        }
    }
}
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InvokeAsExtensionMethod

namespace ExtraLinq.Tests
{
    [TestClass]
    public class AverageTests
    {
        [TestMethod]
        public void AverageInt()
        {
            var source = Enumerable.Range(-100, 450).ToArray();

            Assert.AreEqual(Enumerable.Average(source), ExtraEnumerable.Average(source));
        }

        [TestMethod]
        public void AverageUInt()
        {
            var source = Enumerable.Range(0, 4500).ToArray();

            Assert.AreEqual(Enumerable.Average(source), ExtraEnumerable.Average(source.Select(x => (uint)x).ToArray()));
        }

        [TestMethod]
        public void AverageNullableInt()
        {
            var source = Enumerable.Range(0, 4500).Select(x => (int?)x).Concat(new int?[] {null, null, null}).Shuffle().ToArray();

            Assert.AreEqual(Enumerable.Average(source), ExtraEnumerable.Average(source));
        }
    }
}
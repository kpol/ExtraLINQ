using System;
using System.Linq;
using Xunit;

namespace ExtraLinq.Tests
{
    public class MaxMinByTests
    {
        [Fact]
        public void MaxBy()
        {
            TestData[] source =
            {
                new TestData {Prop1 = 1, Prop2 = 10},
                new TestData {Prop1 = 2, Prop2 = 20},
                new TestData {Prop1 = 3, Prop2 = 30}
            };

            var max = source.Select(x => x).MaxBy(i => i.Prop1);

            Assert.Equal(3, max.Prop1);
            Assert.Equal(30, max.Prop2);
        }


        [Fact]
        public void MaxByArray()
        {
            TestData[] source =
            {
                new TestData {Prop1 = 1, Prop2 = 10},
                new TestData {Prop1 = 2, Prop2 = 20},
                new TestData {Prop1 = 3, Prop2 = 30}
            };

            var max = source.MaxBy(i => i.Prop1);

            Assert.Equal(3, max.Prop1);
            Assert.Equal(30, max.Prop2);
        }

        [Fact]
        public void MinBy()
        {
            TestData[] source =
            {
                new TestData {Prop1 = 1, Prop2 = 10},
                new TestData {Prop1 = 2, Prop2 = 20},
                new TestData {Prop1 = 3, Prop2 = 30}
            };

            var max = source.Select(x => x).MinBy(i => i.Prop1);

            Assert.Equal(1, max.Prop1);
            Assert.Equal(10, max.Prop2);
        }

        [Fact]
        public void MinByArray()
        {
            TestData[] source =
            {
                new TestData {Prop1 = 1, Prop2 = 10},
                new TestData {Prop1 = 2, Prop2 = 20},
                new TestData {Prop1 = 3, Prop2 = 30}
            };

            var max = source.MinBy(i => i.Prop1);

            Assert.Equal(1, max.Prop1);
            Assert.Equal(10, max.Prop2);
        }

        [Fact]
        public void MaxByNoElements()
        {
            Assert.Throws<InvalidOperationException>(() =>
                Enumerable.Empty<TestData>().Select(x => x).MaxBy(i => i.Prop1));
        }

        [Fact]
        public void MaxByArrayNoElements()
        {
            var source = new TestData[0];

            Assert.Throws<InvalidOperationException>(() => source.MaxBy(i => i.Prop1));
        }

        public class TestData
        {
            public int Prop1 { get; set; }

            public int Prop2 { get; set; }
        }
    }
}
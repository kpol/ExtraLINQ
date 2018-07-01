﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtraLinq.Tests
{
    [TestClass]
    public class MaxMinByTests
    {
        [TestMethod]
        public void MaxBy()
        {
            TestData[] source =
            {
                new TestData {Prop1 = 1, Prop2 = 10},
                new TestData {Prop1 = 2, Prop2 = 20},
                new TestData {Prop1 = 3, Prop2 = 30}
            };

            var max = source.MaxBy(i => i.Prop1);

            Assert.AreEqual(3, max.Prop1);
            Assert.AreEqual(30, max.Prop2);
        }

        [TestMethod]
        public void MinBy()
        {
            TestData[] source =
            {
                new TestData {Prop1 = 1, Prop2 = 10},
                new TestData {Prop1 = 2, Prop2 = 20},
                new TestData {Prop1 = 3, Prop2 = 30}
            };

            var max = source.MinBy(i => i.Prop1);

            Assert.AreEqual(1, max.Prop1);
            Assert.AreEqual(10, max.Prop2);
        }

        public class TestData
        {
            public int Prop1 { get; set; }

            public int Prop2 { get; set; }
        }
    }
}
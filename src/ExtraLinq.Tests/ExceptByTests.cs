using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ExtraLinq.Tests
{
    public class ExceptByTests
    {
        [Fact]
        public void ExceptBySimple()
        {
            var first = Enumerable.Range(1, 5).Select(i => new First { KeyFirst = i, ValueFirst = $"first_{i * 10}" });
            var second = Enumerable.Range(1, 2)
                .Concat(new[] { 4 })
                .Select(i => new First { KeyFirst = i, ValueFirst = $"first_{i * 10}" });

            var result = first.ExceptBy(second, k => k.KeyFirst).ToArray();

            Assert.Equal(new[] {3, 5}, result.Select(i => i.KeyFirst).OrderBy(x => x).ToArray());
            Assert.Equal(new[] { "first_30", "first_50" }, result.Select(i => i.ValueFirst).OrderBy(x => x).ToArray());
        }

        [Fact]
        public void ExceptBySimpleDuplicates()
        {
            var first = Enumerable.Range(1, 5)
                .Concat(new[] { 3 })
                .Select(i => new First { KeyFirst = i, ValueFirst = $"first_{i * 10}" });
            var second = Enumerable.Range(1, 2)
                .Concat(new[] { 4 })
                .Select(i => new First { KeyFirst = i, ValueFirst = $"first_{i * 10}" });

            var result = first.ExceptBy(second, k => k.KeyFirst).ToArray();

            Assert.Equal(new[] { 3, 5 }, result.Select(i => i.KeyFirst).OrderBy(x => x).ToArray());
            Assert.Equal(new[] { "first_30", "first_50" }, result.Select(i => i.ValueFirst).OrderBy(x => x).ToArray());
        }

        [Fact]
        public void ExceptBySimpleIncludeDuplicates()
        {
            var first = Enumerable.Range(1, 5)
                .Concat(new[] { 3 })
                .Select(i => new First { KeyFirst = i, ValueFirst = $"first_{i * 10}" });
            var second = Enumerable.Range(1, 2)
                .Concat(new[] { 4 })
                .Select(i => new First { KeyFirst = i, ValueFirst = $"first_{i * 10}" });

            var result = first.ExceptBy(second, k => k.KeyFirst, true).ToArray();

            Assert.Equal(new[] { 3, 3, 5 }, result.Select(i => i.KeyFirst).OrderBy(x => x).ToArray());
            Assert.Equal(new[] { "first_30", "first_30", "first_50" }, result.Select(i => i.ValueFirst).OrderBy(x => x).ToArray());
        }

        [Fact]
        public void ExceptByDifferentSources()
        {
            var first = Enumerable.Range(1, 5).Select(i => new First { KeyFirst = i, ValueFirst = $"first_{i * 10}" });
            var second = Enumerable.Range(1, 2)
                .Concat(new[] { 4 })
                .Select(i => new Second { KeySecond = i, ValueSecond = $"second_{i * 10}" });

            var result = first.ExceptBy(f => f.KeyFirst, second, s => s.KeySecond).ToArray();

            Assert.Equal(new[] { 3, 5 }, result.Select(i => i.KeyFirst).OrderBy(x => x).ToArray());
            Assert.Equal(new[] { "first_30", "first_50" }, result.Select(i => i.ValueFirst).OrderBy(x => x).ToArray());
        }

        [Fact]
        public void ExceptBySourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => ((IEnumerable<int>) null).ExceptBy(new int[0], i => i));
        }

        private class First
        {
            public int KeyFirst { get; set; }

            public string ValueFirst { get; set; }
        }

        private class Second
        {
            public int KeySecond { get; set; }

            public string ValueSecond { get; set; }
        }
    }
}
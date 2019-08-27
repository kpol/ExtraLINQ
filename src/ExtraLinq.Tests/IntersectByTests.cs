using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ExtraLinq.Tests
{
    public class IntersectByTests
    {
        [Fact]
        public void IntersectByEnumearble()
        {
            var first = Enumerable.Range(1, 5).Select(x => new Data {Id = x, Text = (x * 10).ToString()});
            var second = Enumerable.Range(3, 5).Select(x => new Data { Id = x, Text = (x * 10).ToString() });

            var result = first.IntersectBy(second, x => x.Id).ToArray();

            Assert.Equal(3, result.Length);
            Assert.Equal(new[] {3, 4, 5}, result.Select(x => x.Id).OrderBy(x => x).ToArray());
            Assert.Equal(new[] {"30", "40", "50"}, result.Select(x => x.Text).OrderBy(x => x).ToArray());
        }

        [Fact]
        public void IntersectBySourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                ((IEnumerable<int>) null).IntersectBy(Enumerable.Range(1, 10), x => x));
        }

        private class Data
        {
            public int Id { get; set; }

            public string Text { get; set; }
        }
    }
}
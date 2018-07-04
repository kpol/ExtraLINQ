using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ExtraLinq;

namespace Benchmark
{
    public class ExtraLinqBenchmark
    {
        private readonly IEnumerable<long> _source;

        private readonly long[] _data;

        private readonly List<long> _dataList;

        public ExtraLinqBenchmark()
        {
            const int count = 1000000;
            var random = new Random().Next(5000);
            _source = Enumerable.Range(random, random + count).Select(i => (long)i);
            _data = _source.ToArray();
            _dataList = _data.ToList();
        }

        [Benchmark]
        public long SumArrayLinq() => Enumerable.Sum(_data);

        [Benchmark]
        public long SumArrayExtraLinq() => ExtraEnumerable.Sum(_data);

        [Benchmark]
        public long SumListLinq() => Enumerable.Sum(_dataList);

        [Benchmark]
        public long SumListExtraLinq() => ExtraEnumerable.Sum(_dataList);

        [Benchmark]
        public long MaxLinq() => Enumerable.Max(_data);

        [Benchmark]
        public long MaxByExtraLinq() => ExtraEnumerable.MaxBy((IEnumerable<long>)_dataList, i => i);

        [Benchmark]
        public bool ExactlyLinq() => Enumerable.Take(_source, 501).Count() == 500;

        [Benchmark]
        public bool ExactlyExtraLinq() => ExtraEnumerable.Exactly(_source, 500);
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ExtraLinqBenchmark>();
        }
    }
}
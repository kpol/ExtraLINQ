using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ExtraLinq;

namespace Benchmark
{
    public class Md5VsSha256
    {
        private readonly long[] _data;

        private readonly List<long> _dataList;

        public Md5VsSha256()
        {
            const int count = 1000000;
            var random = new Random().Next(5000);
            _data = Enumerable.Range(random, random + count).Select(i => (long) i).ToArray();
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
        public long MaxByExtraLinq() => ExtraEnumerable.MaxBy(_data, i => i);
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Md5VsSha256>();
        }
    }
}
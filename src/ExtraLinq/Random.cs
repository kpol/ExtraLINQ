using System;
using System.Collections.Generic;
using System.Threading;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static IEnumerable<int> Random(Random random = null)
        {
            return RandomImplementation(random, r => r.Next());
        }

        public static IEnumerable<int> Random(int maxValueExclusive, Random random = null)
        {
            if (maxValueExclusive < 0)
            {
                throw Error.MaxValueLessThanZero(nameof(maxValueExclusive));
            }

            return RandomImplementation(random, r => r.Next(maxValueExclusive));
        }

        public static IEnumerable<int> Random(int minValueInclusive, int maxValueExclusive, Random random = null)
        {
            if (minValueInclusive > maxValueExclusive)
            {
                throw Error.MinIsGreaterThanMax(nameof(minValueInclusive), nameof(maxValueExclusive));
            }

            return RandomImplementation(random, r => r.Next(minValueInclusive, maxValueExclusive));
        }

        public static IEnumerable<double> RandomDouble(Random random = null)
        {
            return RandomImplementation(random, r => r.NextDouble());
        }

        private static IEnumerable<T> RandomImplementation<T>(Random random, Func<Random, T> next)
        {
            random = random ?? GlobalRandom.Instance;

            while (true)
            {
                yield return next(random);
            }
        }

        private class GlobalRandom : Random
        {
            private static int _seed = Environment.TickCount;

            private static readonly ThreadLocal<Random> ThreadRandom =
                new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref _seed)));

            private GlobalRandom() { }

            public static readonly Random Instance = new GlobalRandom();

            public override int Next() => ThreadRandom.Value.Next();

            public override int Next(int minValue, int maxValue) => ThreadRandom.Value.Next(minValue, maxValue);

            public override int Next(int maxValue) => ThreadRandom.Value.Next(maxValue);

            public override double NextDouble() => ThreadRandom.Value.NextDouble();

            public override void NextBytes(byte[] buffer) => ThreadRandom.Value.NextBytes(buffer);
        }
    }
}
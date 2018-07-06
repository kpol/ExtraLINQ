﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections.Generic;

namespace ExtraLinq
{
    public static partial class ExtraEnumerable
    {
        public static int Sum(this int[] source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            int sum = 0;

            foreach (var i in source)
            {
                checked
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static int? Sum(this int?[] source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            int sum = 0;

            foreach (var i in source)
            {
                if (i.HasValue)
                {
                    checked
                    {
                        sum += i.Value;
                    }
                }
            }

            return sum;
        }

        public static int Sum(this List<int> source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            int sum = 0;

            foreach (var i in source)
            {
                checked
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static int? Sum(this List<int?> source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            int sum = 0;

            foreach (var i in source)
            {
                if (i.HasValue)
                {
                    checked
                    {
                        sum += i.Value;
                    }
                }
            }

            return sum;
        }

        public static uint Sum(this uint[] source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            uint sum = 0;

            foreach (var i in source)
            {
                checked
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static uint? Sum(this uint?[] source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            uint sum = 0;

            foreach (var i in source)
            {
                if (i.HasValue)
                {
                    checked
                    {
                        sum += i.Value;
                    }
                }
            }

            return sum;
        }

        public static uint Sum(this List<uint> source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            uint sum = 0;

            foreach (var i in source)
            {
                checked
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static uint? Sum(this List<uint?> source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            uint sum = 0;

            foreach (var i in source)
            {
                if (i.HasValue)
                {
                    checked
                    {
                        sum += i.Value;
                    }
                }
            }

            return sum;
        }

        public static long Sum(this long[] source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            long sum = 0;

            foreach (var i in source)
            {
                checked
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static long? Sum(this long?[] source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            long sum = 0;

            foreach (var i in source)
            {
                if (i.HasValue)
                {
                    checked
                    {
                        sum += i.Value;
                    }
                }
            }

            return sum;
        }

        public static long Sum(this List<long> source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            long sum = 0;

            foreach (var i in source)
            {
                checked
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static long? Sum(this List<long?> source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            long sum = 0;

            foreach (var i in source)
            {
                if (i.HasValue)
                {
                    checked
                    {
                        sum += i.Value;
                    }
                }
            }

            return sum;
        }

        public static ulong Sum(this ulong[] source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            ulong sum = 0;

            foreach (var i in source)
            {
                checked
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static ulong? Sum(this ulong?[] source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            ulong sum = 0;

            foreach (var i in source)
            {
                if (i.HasValue)
                {
                    checked
                    {
                        sum += i.Value;
                    }
                }
            }

            return sum;
        }

        public static ulong Sum(this List<ulong> source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            ulong sum = 0;

            foreach (var i in source)
            {
                checked
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static ulong? Sum(this List<ulong?> source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            ulong sum = 0;

            foreach (var i in source)
            {
                if (i.HasValue)
                {
                    checked
                    {
                        sum += i.Value;
                    }
                }
            }

            return sum;
        }

        public static float Sum(this float[] source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            double sum = 0;

            foreach (var i in source)
            {
                sum += i;
            }

            return (float)sum;
        }

        public static float? Sum(this float?[] source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            double sum = 0;

            foreach (var i in source)
            {
                if (i.HasValue)
                {
                    sum += i.Value;
                }
            }

            return (float)sum;
        }

        public static float Sum(this List<float> source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            double sum = 0;

            foreach (var i in source)
            {
                sum += i;
            }

            return (float)sum;
        }

        public static float? Sum(this List<float?> source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            double sum = 0;

            foreach (var i in source)
            {
                if (i.HasValue)
                {
                    sum += i.Value;
                }
            }

            return (float)sum;
        }
        public static double Sum(this double[] source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            double sum = 0;

            foreach (var i in source)
            {
                sum += i;
            }

            return sum;
        }

        public static double? Sum(this double?[] source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            double sum = 0;

            foreach (var i in source)
            {
                if (i.HasValue)
                {
                    sum += i.Value;
                }
            }

            return sum;
        }

        public static double Sum(this List<double> source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            double sum = 0;

            foreach (var i in source)
            {
                sum += i;
            }

            return sum;
        }

        public static double? Sum(this List<double?> source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            double sum = 0;

            foreach (var i in source)
            {
                if (i.HasValue)
                {
                    sum += i.Value;
                }
            }

            return sum;
        }
        public static decimal Sum(this decimal[] source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            decimal sum = 0;

            foreach (var i in source)
            {
                sum += i;
            }

            return sum;
        }

        public static decimal? Sum(this decimal?[] source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            decimal sum = 0;

            foreach (var i in source)
            {
                if (i.HasValue)
                {
                    sum += i.Value;
                }
            }

            return sum;
        }

        public static decimal Sum(this List<decimal> source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            decimal sum = 0;

            foreach (var i in source)
            {
                sum += i;
            }

            return sum;
        }

        public static decimal? Sum(this List<decimal?> source)
        {
            if (source == null) throw Error.ArgumentNull(nameof(source));

            decimal sum = 0;

            foreach (var i in source)
            {
                if (i.HasValue)
                {
                    sum += i.Value;
                }
            }

            return sum;
        }
    }
}
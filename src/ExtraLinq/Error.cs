using System;

namespace ExtraLinq
{
    public static class Error
    {
        public static Exception ArgumentNull(string parameter)
        {
            return new ArgumentNullException(parameter);
        }

        public static Exception NoElements()
        {
            return new InvalidOperationException("Sequence contains no elements");
        }

        public static Exception CountIsNegative(string parameter)
        {
            return new ArgumentOutOfRangeException(parameter, $"Parameter {parameter} cannot be negative");
        }

        public static Exception MinIsGreaterThanMax(string min, string max)
        {
            return new ArgumentOutOfRangeException(min, $"Parameter {min} should be less or equal to parameter {max}");
        }

        public static Exception MaxValueLessThanZero(string parameter)
        {
            return new ArgumentOutOfRangeException(parameter, $"'{parameter}' must be greater than zero.");
        }
    }
}
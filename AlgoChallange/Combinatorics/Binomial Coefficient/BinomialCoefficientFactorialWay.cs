using System;

namespace AlgoChallange.Combinatorics
{
    public class BinomialCoefficientFactorialWay : IBinomialCoefficientCalculator
    {
        public uint Calculate(uint n, uint k)
        {
            if (n < k) throw new ArgumentException("N can't be less than K");

            return Factorial(n) / (Factorial(k) * Factorial((n - k)));
        }

        private uint Factorial(uint n)
        {
            if (n > 33) throw new ArgumentException("Arguments are to big");

            if (n == 0) return 1;
            if (n == 1 || n == 2) return n;

            int result = 2;
            for (int i = 3; i <= n; ++i)
                result *= i;

            return (uint)result;
        }
    }
}

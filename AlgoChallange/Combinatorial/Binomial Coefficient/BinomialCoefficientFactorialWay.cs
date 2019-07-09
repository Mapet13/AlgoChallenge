using System;

namespace AlgoChallange.Combinatorial
{
    public class BinomialCoefficientFactorialWay : IBinomialCoefficientCalculator
    {
        public ulong Calculate(ulong n, ulong k)
        {
            if (n < k) throw new ArgumentException("N can't be less than K");

            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        private ulong Factorial(ulong n)
        { 
            if (n > 20) throw new ArgumentException("Arguments are to big");
            if (n == 0) return 1;
            if (n == 1 || n == 2) return n;

            ulong result = 2;
            for (ulong i = 3; i <= n; ++i)
                result *= i;

            return result;
        }
    }
}

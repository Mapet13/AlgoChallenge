using System;

namespace AlgoChallange.Numerical
{
    public class FactorialLoopWay : IFactorialCalculator
    {

        public ulong Calculate(uint n)
        {
            if (n > 20) throw new ArgumentException("Arguments are to big");
            if (n == 0) return 1;
            if (n == 1 || n == 2) return n;

            return GetFactorial(n);
        }

        private ulong GetFactorial(uint n)
        {
            ulong result = 2;
            for (uint i = 3; i <= n; ++i)
                result *= i;

            return result;
        }

    }
}

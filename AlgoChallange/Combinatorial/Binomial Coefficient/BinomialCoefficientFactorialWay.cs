using System;
using AlgoChallange.Numerical;

namespace AlgoChallange.Combinatorial
{
    public class BinomialCoefficientFactorialWay : IBinomialCoefficientCalculator
    {
        public ulong Calculate(uint n, uint k)
        {
            if (n < k) throw new ArgumentException("N can't be less than K");

            return GetResult(n, k);
        }

        private ulong GetResult(uint n, uint k)
        {
            return GetFactorial(n) / (GetFactorial(k) * GetFactorial(n - k));
        }

        private ulong GetFactorial(uint n)
        {
            return Factorial.Calculate(n, factorialCalculator);
        }

        private readonly IFactorialCalculator factorialCalculator = new FactorialLoopWay();
    }
}

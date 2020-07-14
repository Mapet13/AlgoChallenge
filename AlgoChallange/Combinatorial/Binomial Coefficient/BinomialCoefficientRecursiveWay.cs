using System;

namespace AlgoChallange.Combinatorial
{
    public class BinomialCoefficientRecursiveWay : IBinomialCoefficientCalculator
    {
        public ulong Calculate(uint n, uint k)
        {
            if (n < k) throw new ArgumentException("N can't be less than K");
            if (k == 0 || k == n || n == 1) return 1;

            return Calculate(n - 1, k - 1) + Calculate(n - 1, k);
        }
    }
}
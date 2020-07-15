using System;

namespace AlgoChallenge.Numerical
{
    public class SieveOfEratosthenes : IPrimalityTester
    {
        public bool IsPrime(uint n) => GenerateSieve(n)[n];

        public bool[] GenerateSieve(uint length)
        {
            bool[] sieve = GenerateEmptySieve(length + 1);

            uint root = (uint)Math.Sqrt(length) + 1;
            for (uint i = 2; i < root; ++i)
            {
                if (sieve[i])
                {
                    for (uint k = 2; k * i <= length; ++k)
                    {
                        sieve[i * k] = false;
                    }
                }
            }

            return sieve;
        }

        private bool[] GenerateEmptySieve(uint length)
        {
            bool[] sieve = new bool[length];

            for (uint i = 2; i < length; ++i)
            {
                sieve[i] = true;
            }

            return sieve;
        }
    }
}
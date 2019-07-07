using System;
using System.Linq;

namespace AlgoChallange
{
    public class PrimeNumbers
    {
        public static bool[] SieveOfEratosthenes(uint length)
        {
            bool[] Sieve = GenerateEmptySieve(length + 1);

            uint root = (uint)Math.Sqrt(length) + 1;
            for (uint i = 2; i < root; ++i)
            {
                if (Sieve[i])
                {
                    for (uint k = 2; k*i <= length; ++k)
                    {
                        Sieve[i * k] = false;
                    }
                }
            }

            return Sieve;
        }

        private static bool[] GenerateEmptySieve(uint length)
        {
            bool[] Sieve = new bool[length];
            for (uint i = 2; i < length; ++i)
            {
                Sieve[i] = true;
            }
            return Sieve;
        }
    }
}

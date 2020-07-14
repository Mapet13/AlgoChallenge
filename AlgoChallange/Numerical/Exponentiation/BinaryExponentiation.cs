using System;

namespace AlgoChallange.Numerical
{
    public class BinaryExponentiation : IExponentiationCalculator
    {
        public ulong Calculate(uint n, uint power)
        {
            if (power < 0) throw new ArgumentException("Negative powers are not supported");
            if (power == 0) return 1;

            return Pow(n, power);
        }

        private ulong Pow(uint n, uint power)
        {
            if (power % 2 == 0)
            {
                ulong val = Pow(n, power / 2);
                return val * val;
            }
            return n * Calculate(n, power - 1);
        }
    }
}
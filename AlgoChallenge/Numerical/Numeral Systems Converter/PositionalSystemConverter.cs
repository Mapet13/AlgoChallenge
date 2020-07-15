using System;
using System.Text;

namespace AlgoChallenge.Numerical
{
    /// <summary>
    /// Supports system whose base is an integer from 2 to 16
    /// </summary>
    public class PositionalSystemConverter
    {
        /// <summary>
        /// Convert from decimal to any system
        /// </summary>
        public string Convert(int number, int outBase)
        {
            if (AreArgumentCorrect(outBase)) throw new ArgumentException(); //so many same throws

            return FromDecimal(number, outBase);
        }

        /// <summary>
        /// Convert from any system to decimal
        /// </summary>
        public int Convert(string number, int inBase)
        {
            if (AreArgumentCorrect(inBase)) throw new ArgumentException();

            return ToDecimal(number, inBase);
        }

        /// <summary>
        /// Convert from any system to any system
        /// </summary>
        public string Convert(string number, int inBase, int outBase)
        {
            number = DeleteNonsignificantZeroes(number);

            if (inBase == outBase) return number;
            if (number == "0") return "0";
            if (AreArgumentsCorrect(inBase, outBase)) throw new ArgumentException();

            return FromDecimal(ToDecimal(number, inBase), outBase);
        }

        private int ToDecimal(string number, int inBase)
        {
            number = DeleteNonsignificantZeroes(number);

            if (inBase == 10) return int.Parse(number);
            if (number == "0") return 0;

            int result = 0;
            int length = number.Length;
            for (int i = 0; i < length; ++i)
            {
                uint power = (uint)length - 1 - (uint)i;
                result += (int)Exponentiation.Calculate((uint)inBase, power, exponentiationCalculator) * signs.IndexOf(number[i]);
            }

            return result;
        }

        private string FromDecimal(int number, int outBase)
        {
            if (outBase == 10) return number.ToString();
            if (number == 0) return "0";

            StringBuilder result = new StringBuilder();
            int mod;
            while (number > 0)
            {
                mod = number % outBase;
                result.Insert(0, signs[mod]);
                number /= outBase;
            }

            return result.ToString();
        }

        private string DeleteNonsignificantZeroes(string number)
        {
            while (number.StartsWith("0") && number.Length > 1)
            {
                number = number.Substring(1);
            }

            return number;
        }

        private bool AreArgumentsCorrect(int inBase, int outBase)
        {
            return AreArgumentCorrect(inBase) || AreArgumentCorrect(outBase);
        }

        private bool AreArgumentCorrect(int arg)
        {
            return arg < 2 || arg > 16;
        }

        private readonly IExponentiationCalculator exponentiationCalculator = new BinaryExponentiation();
        private const string signs = "0123456789ABCDEF";
    }
}
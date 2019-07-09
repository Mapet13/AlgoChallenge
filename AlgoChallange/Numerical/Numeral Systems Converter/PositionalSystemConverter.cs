using System;

namespace AlgoChallange.Numerical
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
            if (inBase == outBase) return number;
            number = DeleteNonsignificantZeroes(number);
            if (number == "0") return "0";
            if (AreArgumentsCorrect(inBase, outBase)) throw new ArgumentException();

            return FromDecimal(ToDecimal(number, inBase), outBase);
        }

        private int ToDecimal(string number, int inBase) //How wto clean it???
        {
            if (inBase == 10) return int.Parse(number);
            number = DeleteNonsignificantZeroes(number);
            if (number == "0") return 0;

            int result = 0;
            int length = number.Length;
            for (int i = 0; i < length; ++i)
            {
                result += Pow(inBase, length - 1 - i) * signs.IndexOf(number[i]);
            }

            return result;
        }

        private string DeleteNonsignificantZeroes(string number)
        {
            while (number.StartsWith("0") && number.Length > 1)
            {
                number = number.Substring(1);
            }

            return number;
        }

        private string FromDecimal(int number, int outBase)
        {
            if (outBase == 10) return number.ToString();
            if (number == 0) return "0";

            return number.ToString(); ;
        }

        private bool AreArgumentsCorrect(int inBase, int outBase)
        {
            return AreArgumentCorrect(inBase) || AreArgumentCorrect(outBase);
        }
        private bool AreArgumentCorrect(int arg)
        {
            return arg < 2 || arg > 16;
        }

        public int Pow(int num, int power)
        {
            if (power < 0) throw new ArgumentException("Negative powers are not supported");
            if (power == 0) return 1;
            if (power % 2 == 0)
            {
                int val = Pow(num, power / 2);
                return val * val;
            }
            return num * Pow(num, power - 1);
        }

        private const string signs = "0123456789ABCDEF";

    }
}

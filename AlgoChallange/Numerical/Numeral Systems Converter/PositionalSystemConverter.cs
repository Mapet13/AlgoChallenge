using System;

namespace AlgoChallange.Numerical
{
    /// <summary>
    /// Supports system whose base is an integer from 2 to 16
    /// </summary>
    public class PositionalSystemConverter
    {
        public string Convert(int number, int outBase)
        {
            return Convert(number.ToString(), 10, outBase);
        }

        public int Convert(string number, int inBase)
        {
            return int.Parse(Convert(number, inBase, 10));
        }

        public string Convert(string number, int inBase, int outBase)
        {
            if (inBase == outBase) return number;
            if (number == "0") return "0";
            if (!AreArgumentsCorrect(inBase, outBase)) throw new ArgumentException("Unsuported base");

            return "0";
        }

        private static bool AreArgumentsCorrect(int inBase, int outBase)
        {
            return inBase < 2 || outBase < 2 || inBase > 16 || outBase > 16;
        }
    }
}

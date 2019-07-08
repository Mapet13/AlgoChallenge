using System;

namespace AlgoChallange.Numerical
{
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
            return "0";
        }
    }
}

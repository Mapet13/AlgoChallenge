namespace AlgoChallange.Combinatorics
{
    public class BinomialCoefficient
    {
        public static uint Calculate(uint n, uint k, IBinomialCoefficientCalculator calculator) => calculator.Calculate(n, k);
    }
}

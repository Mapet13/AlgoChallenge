namespace AlgoChallange.Combinatorial
{
    public class BinomialCoefficient
    {
        public static uint Calculate(uint n, uint k, IBinomialCoefficientCalculator calculator) => calculator.Calculate(n, k);
    }
}

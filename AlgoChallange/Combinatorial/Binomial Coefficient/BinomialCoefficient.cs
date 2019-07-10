namespace AlgoChallange.Combinatorial
{
    public class BinomialCoefficient
    {
        public static ulong Calculate(uint n, uint k, IBinomialCoefficientCalculator calculator) => calculator.Calculate(n, k);
    }
}

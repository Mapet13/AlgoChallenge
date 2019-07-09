namespace AlgoChallange.Combinatorial
{
    public class BinomialCoefficient
    {
        public static ulong Calculate(ulong n, ulong k, IBinomialCoefficientCalculator calculator) => calculator.Calculate(n, k);
    }
}

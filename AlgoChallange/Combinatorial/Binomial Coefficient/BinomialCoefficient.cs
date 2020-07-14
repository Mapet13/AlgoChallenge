namespace AlgoChallange.Combinatorial
{
    public static class BinomialCoefficient
    {
        public static ulong Calculate(uint n, uint k, IBinomialCoefficientCalculator calculator) => calculator.Calculate(n, k);
    }
}
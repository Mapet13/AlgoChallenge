namespace AlgoChallenge.Numerical
{
    public static class Exponentiation
    {
        public static ulong Calculate(uint n, uint power, IExponentiationCalculator calculator) => calculator.Calculate(n, power);
    }
}
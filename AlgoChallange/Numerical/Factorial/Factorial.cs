namespace AlgoChallange.Numerical
{
    public static class Factorial
    {
        public static ulong Calculate(uint n, IFactorialCalculator calculator) => calculator.Calculate(n);
    }
}
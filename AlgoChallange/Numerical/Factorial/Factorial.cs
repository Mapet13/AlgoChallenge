namespace AlgoChallange.Numerical
{
    public class Factorial
    {
        public static ulong Calculate(uint n, IFactorialCalculator calculator) => calculator.Calculate(n);
    }
}

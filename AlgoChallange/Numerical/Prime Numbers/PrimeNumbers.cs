namespace AlgoChallange.Numerical
{
    public class PrimeNumbers
    {
        public static bool IsPrime(uint n, IPrimalityTester isPrimeChecker) => isPrimeChecker.IsPrime(n);
    }
}

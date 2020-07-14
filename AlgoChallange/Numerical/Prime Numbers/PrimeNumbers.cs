namespace AlgoChallange.Numerical
{
    public static class PrimeNumbers
    {
        public static bool IsPrime(uint n, IPrimalityTester isPrimeChecker) => isPrimeChecker.IsPrime(n);
    }
}
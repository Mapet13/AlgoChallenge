namespace AlgoChallange.Numerical
{
    public class PrimeNumbers
    {
        public static bool IsPrime(uint n, IWayToCheckIfIsPrime isPrimeChecker) => isPrimeChecker.IsPrime(n);
    }
}

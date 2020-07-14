namespace AlgoChallange.Numerical
{
    public class PerfectNumber
    {
        public bool IsPerfect(ulong n)
        {
            if (IsOdd(n) || n == 0)
                return false;
            return IsEvenPerfect(n);
        }

        private bool IsEvenPerfect(ulong n)
        {
            ulong sum = 0;

            for (ulong i = 1; i * i <= n; ++i)
            {
                if (n % i == 0)
                {
                    sum += i;
                    if (i * i != n)
                        sum += n / i;
                }
            }

            return sum - n == n;
        }

        private bool IsOdd(ulong n) => n % 2 == 1;
    }
}
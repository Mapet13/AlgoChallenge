using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo = AlgoChallange.Numerical;

namespace AlgoTest.Numerical.PerfectNumber
{
    [TestClass]
    public class PerfectNumberTest 
    {
        [TestMethod]
        [DataRow(6u)]
        [DataRow(28u)]
        [DataRow(496u)]
        public void ReturedValueTest_CorrectPerfectNumbersUpTo1000(uint n)
        {
            perfectNumber = new Algo.PerfectNumber();
            Assert.IsTrue(perfectNumber.IsPerfect(n));
        }

        [TestMethod]
        public void ReturnedValueTest_RandomNotPerfectNumberUpTo1000()
        {
            int n;
            perfectNumber = new Algo.PerfectNumber();

            do n = new Random().Next(1, 1000);
            while (n == 6 || n == 28 || n == 496);

            Assert.IsFalse(perfectNumber.IsPerfect((ulong)n));
        }

        private Algo.PerfectNumber perfectNumber = new Algo.PerfectNumber();
    }
}

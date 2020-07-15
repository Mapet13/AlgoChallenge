using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Algo = AlgoChallenge.Numerical;

namespace AlgoTest.Numerical.PerfectNumber
{
    [TestClass]
    public class PerfectNumberTest
    {
        [TestInitialize]
        public void InitTest() => perfectNumber = new Algo.PerfectNumber();

        [TestMethod]
        [DataRow(6u)]
        [DataRow(28u)]
        [DataRow(496u)]
        public void ReturedValueTest_CorrectPerfectNumbersUpTo1000(uint n)
        {
            Assert.IsTrue(perfectNumber.IsPerfect(n));
        }

        [TestMethod]
        public void ReturnedValueTest_RandomNotPerfectNumberUpTo1000()
        {
            int n;

            do n = new Random().Next(1, 1000);
            while (n == 6 || n == 28 || n == 496);

            Assert.IsFalse(perfectNumber.IsPerfect((ulong)n));
        }

        Algo.PerfectNumber perfectNumber;
    }
}

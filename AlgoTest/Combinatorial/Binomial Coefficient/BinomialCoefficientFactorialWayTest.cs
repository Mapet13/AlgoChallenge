using AlgoChallenge.Combinatorial;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AlgoTest.Combinatorial.BinomialCoefficient
{
    [TestClass]
    public class BinomialCoefficientFactorialWayTest
        : BinomialCoefficientTest<BinomialCoefficientFactorialWay>
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IOTest_ArgumentBiggerThan20()
        {
            uint n = (uint)new Random().Next(23, 100);
            uint k = 21;

            binomialCoefficient.Calculate(n, k);
        }
    }
}

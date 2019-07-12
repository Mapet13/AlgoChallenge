using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoChallange.Combinatorial;
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
            binomialCoefficient = new BinomialCoefficientFactorialWay();
            uint n = (uint)new Random().Next(23, 100);
            uint k = 21;

            binomialCoefficient.Calculate(n, k);
        }

        BinomialCoefficientFactorialWay binomialCoefficient;
    }
}

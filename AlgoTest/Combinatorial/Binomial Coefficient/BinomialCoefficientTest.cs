using AlgoChallenge.Combinatorial;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AlgoTest.Combinatorial.BinomialCoefficient
{
    public class BinomialCoefficientTest<T>
        where T : IBinomialCoefficientCalculator, new()
    {
        [TestInitialize]
        public void InitTest() => binomialCoefficient = new T();

        [TestMethod]
        public void ReturnedValueTest_ForNand0()
        {
            uint n = (uint)new Random().Next(1, 20);

            Assert.AreEqual((ulong)1, binomialCoefficient.Calculate(n, 0));
        }

        [TestMethod]
        public void ReturnedValueTest_For8and3()
        {
            Assert.AreEqual((ulong)56, binomialCoefficient.Calculate(8, 3));
        }

        [TestMethod]
        public void ReturnedValueTest_recurrenceRelation()
        {
            uint n = (uint)new Random().Next(3, 20);
            uint k = (uint)new Random().Next(2, (int)n - 1);

            ulong expected = binomialCoefficient.Calculate(n, k);
            ulong actual = binomialCoefficient.Calculate(n - 1, k) + binomialCoefficient.Calculate(n - 1, k - 1);

            Assert.AreEqual(expected, actual);
        }

        protected IBinomialCoefficientCalculator binomialCoefficient = new T();
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoChallange.Combinatorial;

namespace AlgoTest.Combinatorial
{
    
    public class BinomialCoefficientTest<T> 
        where T: IBinomialCoefficientCalculator, new()
    {
        [TestMethod]
        public void ReturnedValueTest_ForNand0()
        {
            BinomialCoefficien = new BinomialCoefficientFactorialWay();
            uint n = (uint)new Random().Next(1, 20);

            Assert.AreEqual((ulong)1, BinomialCoefficien.Calculate(n, 0));
        }

        [TestMethod]
        public void ReturnedValueTest_For8and3()
        {
            BinomialCoefficien = new BinomialCoefficientFactorialWay();
            Assert.AreEqual((ulong)56, BinomialCoefficien.Calculate(8, 3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IOTest_ArgumentBiggerThan20()
        {
            BinomialCoefficien = new BinomialCoefficientFactorialWay();
            uint n = (uint)new Random().Next(23, 100);
            uint k = 21;

            BinomialCoefficien.Calculate(n, k);
        }

        [TestMethod]
        public void ReturnedValueTest_recurrenceRelation()
        {
            BinomialCoefficien = new BinomialCoefficientFactorialWay();
            uint n = (uint)new Random().Next(3, 20);
            uint k = (uint)new Random().Next(2, (int)n - 1);

            ulong expected = BinomialCoefficien.Calculate(n, k);
            ulong actual = BinomialCoefficien.Calculate(n - 1, k) + BinomialCoefficien.Calculate(n - 1, k - 1);

            Assert.AreEqual(expected, actual);
        }

        private IBinomialCoefficientCalculator BinomialCoefficien = new T();
    }
}

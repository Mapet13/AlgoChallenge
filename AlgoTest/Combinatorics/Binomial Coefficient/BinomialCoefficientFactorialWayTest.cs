using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoChallange.Combinatorics;

namespace AlgoTest.Combinatorics
{
    [TestClass]
    public class BinomialCoefficientFactorialWayTest
    {
        [TestMethod]
        public void ReturnedValueTest_ForNand0()
        {
            BinomialCoefficien = new BinomialCoefficientFactorialWay();
            uint n = (uint)new Random().Next(1, 33);

            Assert.AreEqual((uint)1, BinomialCoefficien.Calculate(n, 0));
        }

        [TestMethod]
        public void ReturnedValueTest_For8and3()
        {
            BinomialCoefficien = new BinomialCoefficientFactorialWay();
            Assert.AreEqual((uint)56, BinomialCoefficien.Calculate(8, 3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IOTest_ArgumentBiggerThan33()
        {
            BinomialCoefficien = new BinomialCoefficientFactorialWay();
            uint n = (uint)new Random().Next(33, int.MaxValue);

            BinomialCoefficien.Calculate(n, 0);
        }

        [TestMethod]
        public void ReturnedValueTest_recurrenceRelation()
        {
            BinomialCoefficien = new BinomialCoefficientFactorialWay();
            uint n = (uint)new Random().Next(1, 33);
            uint k = (uint)new Random().Next(1, (int)n);

            uint expected = BinomialCoefficien.Calculate(n, k);
            uint actual = BinomialCoefficien.Calculate(n - 1, k) + BinomialCoefficien.Calculate(n - 1, k - 1); ;
             
            Assert.AreEqual(expected, actual);
        }

        private BinomialCoefficientFactorialWay BinomialCoefficien;
    }
}

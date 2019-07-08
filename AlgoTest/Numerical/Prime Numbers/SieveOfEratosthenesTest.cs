using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoChallange.Numerical;

namespace AlgoTest.Numerical.PrimeNumbers
{
    [TestClass]
    public class SieveOfEratosthenesTest
    {
        [TestMethod]
        public void OITest_ReturnedTypeIsBoolArray()
        {
            sieve = new SieveOfEratosthenes();
            Assert.IsInstanceOfType(sieve.GenerateSieve(5), typeof(bool[]));
        }

        [TestMethod]
        public void OITest_LengthOfReturnedArray()
        {
            sieve = new SieveOfEratosthenes();
            Assert.AreEqual(6, sieve.GenerateSieve(5).Length);
        }

        [TestMethod]
        public void ReturnedValueTest_EqualityOfTheFirstElementsFrom2DifferentSieves()
        {
            sieve = new SieveOfEratosthenes();

            bool[] nineFromTen = new bool[10];
            bool[] nine = sieve.GenerateSieve(9);
            Array.Copy(sieve.GenerateSieve(10), nineFromTen, 10); //Get first 9 elements form SieveOfEratosthenes(10)

            Assert.IsTrue(nine.SequenceEqual(nineFromTen));
        }

        [TestMethod]
        public void ReturnedValueTest_ReturnsCorrectPrimesTo20()
        {
            sieve = new SieveOfEratosthenes();
            uint[] primesTo20 = new uint[] { 2, 3, 5, 7, 11, 13, 17, 19 };
            bool[] correctSieveOfEratosthenes = new bool[21];
            bool[] sieveOfEratosthenes = sieve.GenerateSieve(20);

            foreach (uint i in primesTo20)
            {
                correctSieveOfEratosthenes[i] = true;
            }


            Assert.IsTrue(correctSieveOfEratosthenes.SequenceEqual(sieveOfEratosthenes));
        }

        private SieveOfEratosthenes sieve;
    }
}

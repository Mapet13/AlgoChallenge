using AlgoChallenge.Numerical;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AlgoTest.Numerical.PrimeNumbers
{
    [TestClass]
    public class SieveOfEratosthenesTest
    {
        [TestInitialize]
        public void InitTest() => sieve = new SieveOfEratosthenes();

        [TestMethod]
        public void IOTest_ReturnedTypeIsBoolArray()
        {
            Assert.IsInstanceOfType(sieve.GenerateSieve(5), typeof(bool[]));
        }

        [TestMethod]
        public void IOTest_LengthOfReturnedArray()
        {
            Assert.AreEqual(6, sieve.GenerateSieve(5).Length);
        }

        [TestMethod]
        public void ReturnedValueTest_EqualityOfTheFirstElementsFrom2DifferentSieves()
        {
            bool[] nineFromTen = new bool[10];
            bool[] nine = sieve.GenerateSieve(9);
            Array.Copy(sieve.GenerateSieve(10), nineFromTen, 10); //Get first 9 elements form SieveOfEratosthenes(10)

            Assert.IsTrue(nine.SequenceEqual(nineFromTen));
        }

        [TestMethod]
        public void ReturnedValueTest_ReturnsCorrectPrimesTo20()
        {
            uint[] primesTo20 = new uint[] { 2, 3, 5, 7, 11, 13, 17, 19 };
            bool[] correctSieveOfEratosthenes = new bool[21];
            bool[] sieveOfEratosthenes = sieve.GenerateSieve(20);

            foreach (uint i in primesTo20)
                correctSieveOfEratosthenes[i] = true;


            Assert.IsTrue(correctSieveOfEratosthenes.SequenceEqual(sieveOfEratosthenes));
        }

        SieveOfEratosthenes sieve;
    }
}
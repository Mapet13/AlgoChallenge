using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoChallange;
using System;
using System.Linq;

namespace AlgoTest.PrimeNumbersTest
{
    [TestClass]
    public class SieveOfEratosthenesTest
    {
        [TestMethod]
        public void OITest_ReturnedTypeIsIntArray()
        {
            Assert.IsInstanceOfType(PrimeNumbers.SieveOfEratosthenes(5), typeof(bool[]));
        }

        [TestMethod]
        public void OITest_LengthOfReturnedArray()
        {
            Assert.AreEqual(6, PrimeNumbers.SieveOfEratosthenes(5).Length);
        }


        [TestMethod]
        public void ReturnedValueTest_EqualityOfTheFirstElementsFrom2DifferentSieves()
        {
            bool[] nineFromTen = new bool[10];
            bool[] nine = PrimeNumbers.SieveOfEratosthenes(9);
            Array.Copy(PrimeNumbers.SieveOfEratosthenes(10), nineFromTen, 10); //Get first 9 elements form SieveOfEratosthenes(10)

            Assert.IsTrue(nine.SequenceEqual(nineFromTen));
        }

        [TestMethod]
        public void ReturnedValueTest_CorrectedPrimesTo20()
        {
            uint[] primesTo20 = new uint[] { 2, 3, 5, 7, 11, 13, 17, 19 };
            bool[] correctSieveOfEratosthenes = new bool[21];
            bool[] sieveOfEratosthenes = PrimeNumbers.SieveOfEratosthenes(20);

            foreach(uint i in primesTo20)
            {
                correctSieveOfEratosthenes[i] = true;
            }


            Assert.IsTrue(correctSieveOfEratosthenes.SequenceEqual(sieveOfEratosthenes));
        }
    }
}

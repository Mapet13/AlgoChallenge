using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoChallange;
using System;
using System.Linq;

namespace AlgoTest.PrimaryNumbersTest
{
    [TestClass]
    public class SieveOfEratosthenesTest
    {
        [TestMethod]
        public void OITest_ReturnedTypeIsIntArray()
        {
            Assert.IsInstanceOfType(PrimaryNumbers.SieveOfEratosthenes(5), typeof(bool[]));
        }

        [TestMethod]
        public void OITest_LengthOfReturnedArray()
        {
            Assert.AreEqual(6, PrimaryNumbers.SieveOfEratosthenes(5).Length);
        }


        [TestMethod] // I should change this name, but no idea for what
        public void ReturnedValueTest_IsSameForEveryCall()
        {
            bool[] nineFromTen = new bool[10];
            bool[] nine = PrimaryNumbers.SieveOfEratosthenes(9);
            Array.Copy(PrimaryNumbers.SieveOfEratosthenes(10), nineFromTen, 10); //Get first 9 elements form SieveOfEratosthenes(10)

            Assert.IsTrue(nine.SequenceEqual(nineFromTen));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoChallange;

namespace AlgoTest.PrimaryNumbersTest
{
    [TestClass]
    public class SieveOfEratosthenesTest
    {
        [TestMethod]
        public void CorrectOITest_ReturnedTypeIsIntArray()
        {
            Assert.IsInstanceOfType(PrimaryNumbers.SieveOfEratosthenes(5), typeof(int[]));
        }

        [TestMethod]
        public void CorrectOITest_LengthOfReturnedArray()
        {
            Assert.AreEqual(5, PrimaryNumbers.SieveOfEratosthenes(5).Length);
        }
    }
}

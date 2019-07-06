using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoChallange;

namespace AlgoTest.PrimaryNumbersTest
{
    [TestClass]
    public class SieveOfEratosthenesTest
    {
        [TestMethod]
        public void CorrectOITest()
        {
            int length = 10;
            var result = PrimaryNumbers.SieveOfEratosthenes(length);

            Assert.IsTrue(result is int[]);
            Assert.IsTrue(result.Length == length);
        }

    }
}

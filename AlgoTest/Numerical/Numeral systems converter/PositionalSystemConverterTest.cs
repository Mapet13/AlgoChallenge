using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoChallange.Numerical;

namespace AlgoTest.Numerical.NumeralSystemsConverter
{
    [TestClass]
    public class PositionalSystemConverterTest
    {
        [TestMethod]
        public void OverloadingTest_returnCorrectInt()
        {
            converter = new PositionalSystemConverter();
            int n = new Random().Next(1, int.MaxValue);

            Assert.AreEqual(n, converter.Convert(n.ToString(), 10));
        }

        [TestMethod]
        public void OverloadingTest_returnCorrectStringFromDecimalInt()
        {
            converter = new PositionalSystemConverter();
            int n = new Random().Next(1, int.MaxValue);
            
            Assert.AreEqual(n.ToString(), converter.Convert(n, 10));
        }

        [TestMethod]
        public void ReturnedValueTest_BinaryToBinaryFakeConversion()
        {
            converter = new PositionalSystemConverter();
            string binary = GenerateRandomBinaryString();

            Assert.AreEqual(binary, converter.Convert(binary, 2, 2));
        }

        [TestMethod]
        public void ReturnedValueTest_ZeroIsAlwaysZero()
        {
            converter = new PositionalSystemConverter();
            int inBase = new Random().Next(1, int.MaxValue);
            int outBase = new Random().Next(1, int.MaxValue);

            Assert.AreEqual("0", converter.Convert("0", inBase, outBase));
        }

        [TestMethod]
        public void ReturnedValueTest_BinaryToDecimal()
        {
            converter = new PositionalSystemConverter();
            string binary = "011010";
            int dec = 26;

            Assert.AreEqual(dec.ToString(), converter.Convert(binary, 2, 10));
        }

        [TestMethod]
        public void ReturnedValueTest_OctalToDecimal()
        {
            converter = new PositionalSystemConverter();
            string oct = "32";
            int dec = 26;

            Assert.AreEqual(dec.ToString(), converter.Convert(oct, 8, 10));
        }

        [TestMethod]
        public void ReturnedValueTest_HexToDecimal()
        {
            converter = new PositionalSystemConverter();
            string hex = "1A";
            int dec = 26;

            Assert.AreEqual(dec.ToString(), converter.Convert(hex, 16, 10));
        }

        [TestMethod]
        public void ReturnedValueTest_DecimalToBinary()
        {
            converter = new PositionalSystemConverter();
            string binary = "11010";
            int dec = 26;

            Assert.AreEqual(binary, converter.Convert(dec.ToString(), 10, 2));
        }

        [TestMethod]
        public void ReturnedValueTest_DecimalToOctal()
        {
            converter = new PositionalSystemConverter();
            string oct = "32";
            int dec = 26;

            Assert.AreEqual(oct, converter.Convert(dec.ToString(), 10, 8));
        }

        [TestMethod]
        public void ReturnedValueTest_DecimalToHex()
        {
            converter = new PositionalSystemConverter();
            string hex = "1A";
            int dec = 26;

            Assert.AreEqual(hex, converter.Convert(dec.ToString(), 10, 16));
        }

        [TestMethod]
        public void ReturnedValueTest_OctToHex()
        {
            converter = new PositionalSystemConverter();
            string hex = "1A";
            string oct = "32";

            Assert.AreEqual(hex, converter.Convert(oct, 8, 16));
        }

        private string GenerateRandomBinaryString()
        {
            StringBuilder builder = new StringBuilder("1");
            Random random = new Random();
            int length = new Random().Next(1, 100);
            for (int i = 0; i < length; ++i)
            {
                builder.Append(random.Next(0, 2).ToString());
            }

            return builder.ToString();
        }

        private PositionalSystemConverter converter;
    }
}

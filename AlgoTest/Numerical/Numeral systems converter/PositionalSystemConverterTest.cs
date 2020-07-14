using AlgoChallange.Numerical;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace AlgoTest.Numerical.NumeralSystemsConverter
{
    [TestClass]
    public class PositionalSystemConverterTest
    {
        [TestInitialize]
        public void InitTest()
        {
            converter = new PositionalSystemConverter();
        }

        [TestMethod]
        public void OverloadingTest_returnCorrectInt()
        {
            int n = new Random().Next(1, int.MaxValue);

            Assert.AreEqual(n, converter.Convert(n.ToString(), 10));
        }

        [TestMethod]
        public void OverloadingTest_returnCorrectStringFromDecimalInt()
        {
            int n = new Random().Next(1, int.MaxValue);

            Assert.AreEqual(n.ToString(), converter.Convert(n, 10));
        }

        [TestMethod]
        public void ReturnedValueTest_BinaryToBinaryFakeConversion()
        {
            var binary = GenerateRandomBinaryString();

            Assert.AreEqual(binary, converter.Convert(binary, 2, 2));
        }

        [TestMethod]
        public void ReturnedValueTest_ZeroIsAlwaysZero()
        {
            int inBase = new Random().Next(1, int.MaxValue);
            int outBase = new Random().Next(1, int.MaxValue);

            Assert.AreEqual("0", converter.Convert("0", inBase, outBase));
        }

        [TestMethod]
        public void ReturnedValueTest_BinaryToDecimal()
        {
            var binary = "011010";
            int dec = 26;

            Assert.AreEqual(dec.ToString(), converter.Convert(binary, 2, 10));
        }

        [TestMethod]
        public void ReturnedValueTest_OctalToDecimal()
        {
            var oct = "32";
            int dec = 26;

            Assert.AreEqual(dec.ToString(), converter.Convert(oct, 8, 10));
        }

        [TestMethod]
        public void ReturnedValueTest_HexToDecimal()
        {
            var hex = "1A";
            int dec = 26;

            Assert.AreEqual(dec.ToString(), converter.Convert(hex, 16, 10));
        }

        [TestMethod]
        public void ReturnedValueTest_DecimalToBinary()
        {
            var binary = "11010";
            int dec = 26;

            Assert.AreEqual(binary, converter.Convert(dec.ToString(), 10, 2));
        }

        [TestMethod]
        public void ReturnedValueTest_DecimalToOctal()
        {
            var oct = "32";
            int dec = 26;

            Assert.AreEqual(oct, converter.Convert(dec.ToString(), 10, 8));
        }

        [TestMethod]
        public void ReturnedValueTest_DecimalToHex()
        {
            var hex = "1A";
            int dec = 26;

            Assert.AreEqual(hex, converter.Convert(dec.ToString(), 10, 16));
        }

        [TestMethod]
        public void ReturnedValueTest_OctToHex()
        {
            var hex = "1A";
            var oct = "32";

            Assert.AreEqual(hex, converter.Convert(oct, 8, 16));
        }

        [TestMethod]
        public void ReturnedValueTest_nontrivialBases_6and13()
        {
            var inNum_6 = "543";                         // 207 in decimal 
            var outNum_13 = "12C";

            Assert.AreEqual(outNum_13, converter.Convert(inNum_6, 6, 13));
        }

        string GenerateRandomBinaryString()
        {
            var builder = new StringBuilder("1");
            var random = new Random();
            int length = new Random().Next(1, 100);
            for (int i = 0; i < length; ++i)
                builder.Append(random.Next(0, 2).ToString());


            return builder.ToString();
        }

        PositionalSystemConverter converter;
    }
}
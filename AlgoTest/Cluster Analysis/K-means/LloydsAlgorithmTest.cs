using AlgoChallenge.Cluster_Analysis.K_means;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System;

namespace AlgoTest.Cluster_Analysis.K_means
{
    [TestClass]
    public class LloydsAlgorithmTest
    {
        [TestInitialize]
        public void InitTest() => partitioner = new LloydsAlgorithm();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowArgumentException_WhenPassDataWithADifferentNumberOfDimensions()
        {
            var data = new double[3][];
            data[0] = new double[1];
            data[1] = new double[2];
            data[2] = new double[3];

            _ = partitioner.PartitionToClusters(2, data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowArgumentException_WhenKIsEqualTo0()
        {
            var data = new double[3][];
            data[0] = new double[1];
            data[1] = new double[2];
            data[2] = new double[3];

            _ = partitioner.PartitionToClusters(0, data);
        }

        [TestMethod]
        public void ShouldRunCorrectly_WhenPassOneDimensionalData()
        {
            var data = new double[5][];
            data[0] = new double[] { 1 };
            data[2] = new double[] { 2 };
            data[1] = new double[] { 9 };
            data[3] = new double[] { 10 };
            data[4] = new double[] { 13 };

            var output = partitioner.PartitionToClusters(2, data);

            LogOutput(output);
        }

        [TestMethod]
        public void ShouldRunCorrectly_WhenPassTwoDimensionalData()
        {
            var data = new double[5][];
            data[0] = new double[] { 1, 1 };
            data[2] = new double[] { 2, 1 };
            data[1] = new double[] { 15, 15 };
            data[3] = new double[] { 16, 17 };
            data[4] = new double[] { 18, 18 };

            var output = partitioner.PartitionToClusters(2, data);

            LogOutput(output);
        }

        [TestMethod]
        public void ShouldRunCorrectly_WhenPassMultiDimensionalData()
        {
            var data = new double[5][];
            data[0] = new double[] { 1, 1, 1, 1, 1 };
            data[2] = new double[] { 2, 1, 2, 1, 2 };
            data[1] = new double[] { 15, 15, 15, 15, 15 };
            data[3] = new double[] { 16, 17, 16, 17, 16 };
            data[4] = new double[] { 18, 18, 18, 18, 18 };

            var output = partitioner.PartitionToClusters(2, data);

            LogOutput(output);
        }

        [TestMethod]
        public void ShouldReturnAllDataInOneCLuster_WhenKIsEqualToOne()
        {
            var data = new double[5][];
            data[0] = new double[] { 1, 1 };
            data[2] = new double[] { 2, 1 };
            data[1] = new double[] { 15, 15 };
            data[3] = new double[] { 16, 17 };
            data[4] = new double[] { 18, 18 };

            var output = partitioner.PartitionToClusters(1, data);

            foreach (var x in output)
                Assert.AreEqual(0u, x.Item1);
        }

        private void LogOutput(Tuple<uint, double[]>[] output)
        {
            Array.Sort(output, (x, y) => x.Item1.CompareTo(y.Item1));
            foreach (var x in output)
                Logger.LogMessage("{0}: {1}", x.Item1.ToString(), string.Join(",", x.Item2));
        }

        LloydsAlgorithm partitioner;
    }
}
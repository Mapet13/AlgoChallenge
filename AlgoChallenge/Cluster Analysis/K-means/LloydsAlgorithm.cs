using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoChallenge.Cluster_Analysis.K_means
{
    using ClusterType = Tuple<uint, double[]>;

    public class LloydsAlgorithm : IKMeansPartitioningMethod
    {
        public ClusterType[] PartitionToClusters(uint k, double[][] data, uint maxIterations = 100)
        {
            dimensionCount = data[0].Length;
            this.k = k;
            this.data = data;

            CheckIfKIsCorrect();
            CheckDataDimensionNumber();

            var centroids = InitializeCentroids();
            Clusters = new ClusterType[data.Length];

            var iterationCount = 0;
            do
            {
                iterationCount++;

                RetstartClusterState();
                var dataInClusters = AssignClustersToData(centroids);
                centroids = MoveCentroids(dataInClusters, centroids);
            } while (Converges() && iterationCount < maxIterations);

            return Clusters;
        }

        private void CheckIfKIsCorrect()
        {
            if (k == 0)
                throw new ArgumentException("K must be grater than 0");
        }

        private void RetstartClusterState()
        {
            OldClusters = Clusters;
            Clusters = new ClusterType[data.Length];
        }

        private void CheckDataDimensionNumber()
        {
            foreach (var dataPoint in data)
            {
                if (dataPoint.Length != dimensionCount)
                    throw new ArgumentException("The data has a different number of dimensions");
            }
        }

        private bool Converges() => !Enumerable.SequenceEqual(Clusters, OldClusters);

        private List<uint>[] AssignClustersToData(double[][] centroids)
        {
            List<uint>[] dataInClusters = CreateDataInClustersArray();

            for (uint i = 0; i < data.Length; i++)
            {
                uint clusterIndex = GetProperClusterToDataPoint(data[i], centroids);

                dataInClusters[clusterIndex].Add(i);
                Clusters[i] = (clusterIndex, data[i]).ToTuple();
            }

            return dataInClusters;
        }

        private List<uint>[] CreateDataInClustersArray()
        {
            var dataInClusters = new List<uint>[k];
            for (var i = 0; i < dataInClusters.Length; i++)
            {
                dataInClusters[i] = new List<uint>();
            }

            return dataInClusters;
        }

        private uint GetProperClusterToDataPoint(double[] dataPoint, double[][] centroids)
        {
            var maxDistance = double.MaxValue;
            uint currentCluster = 0;
            for (uint j = 0; j < k; j++)
            {
                double dist = CalculateEuclideanDistance(dataPoint, centroids[j]);
                if (dist <= maxDistance)
                {
                    maxDistance = dist;
                    currentCluster = j;
                }
            }

            return currentCluster;
        }

        private double CalculateEuclideanDistance(double[] dataPoint, double[] centroid)
        {
            var dist = 0.0;
            for (uint u = 0; u < dimensionCount; u++)
                dist += Math.Pow(dataPoint[u] - centroid[u], 2);

            return Math.Sqrt(dist);
        }

        private double[][] MoveCentroids(List<uint>[] dataInClusters, double[][] centorids)
        {
            double[][] newCentroids = CreateCentroidsArray();

            for (uint cluster = 0; cluster < dataInClusters.Length; cluster++)
            {
                for (uint dimension = 0; dimension < dimensionCount; dimension++)
                {
                    newCentroids[cluster][dimension] = CalculateCentroidValue(dataInClusters, centorids, cluster, dimension);
                }
            }

            return newCentroids;
        }

        private double CalculateCentroidValue(List<uint>[] dataInClusters, double[][] oldCentorids, uint clusterIndex, uint dimension)
        {
            var values = new List<double>();
            foreach (var index in dataInClusters[clusterIndex])
                values.Add(data[index][dimension]);

            return values.Count > 0 ? values.Average() : oldCentorids[clusterIndex][dimension];
        }

        private double[][] CreateCentroidsArray()
        {
            var centroids = new double[k][];
            for (uint i = 0; i < k; i++)
            {
                centroids[i] = new double[dimensionCount];
                Array.Fill(centroids[i], 0.0);
            }

            return centroids;
        }

        private double[][] InitializeCentroids()
        {
            var random = new Random();
            var dataInClusters = CreateDataInClustersArray();

            for (uint i = 0; i < data.Length; i++)
                dataInClusters[random.Next(0, (int)(k - 1))].Add(i);

            return MoveCentroids(dataInClusters, CreateCentroidsArray());
        }

        uint k;
        double[][] data;
        ClusterType[] OldClusters;
        ClusterType[] Clusters;
        int dimensionCount;
    }
}
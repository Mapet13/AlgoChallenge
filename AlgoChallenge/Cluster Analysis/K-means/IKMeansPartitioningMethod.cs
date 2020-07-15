using System;

namespace AlgoChallenge.Cluster_Analysis.K_means
{
    interface IKMeansPartitioningMethod
    {
        public Tuple<uint, double[]>[] PartitionToClusters(uint k, double[][] data, uint maxIterations = 100);
    }
}
using System;

namespace AlgoChallenge.Cluster_Analysis.K_means
{
    internal class KMeansPartitioner
    {
        public Tuple<uint, double[]>[] PartitionToClasters(IKMeansPartitioningMethod method, uint k, double[][] data, uint maxIterations = 100)
            => method.PartitionToClusters(k, data, maxIterations);
    }
}
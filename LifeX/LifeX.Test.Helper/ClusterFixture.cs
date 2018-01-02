using System;
using Orleans.TestingHost;

namespace LifeX.Test.Helper
{
    public class ClusterFixture : IDisposable 
    {
        public ClusterFixture()
        {
            this.Cluster = new TestCluster();
            this.Cluster.Deploy();
        }

        public void Dispose()
        {
            this.Cluster.StopAllSilos();
        }

        public TestCluster Cluster { get; private set; }
    }
}
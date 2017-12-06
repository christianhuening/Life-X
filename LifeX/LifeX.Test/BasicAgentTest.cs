using System;
using LifeX.Test.Helper;
using Orleans.TestingHost;
using WolfSheep.Model;
using Xunit;

namespace LifeX.Test
{
    [Collection(ClusterCollection.Name)]
    public class BasicAgentTest
    {
        private readonly TestCluster _cluster;

        public BasicAgentTest(ClusterFixture fixture)
        {
            _cluster = fixture.Cluster;
        }
        [Fact]
        public async void SetupTest()
        {
            var wolf = _cluster.GrainFactory.GetGrain<IWolf>(0);
            await wolf.Tick();
            Assert.Equal(true, true);
        }
    }
}
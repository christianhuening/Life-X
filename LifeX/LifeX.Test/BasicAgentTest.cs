using LifeX.Test.Helper;
using Orleans.TestingHost;
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
            var basicAgent = _cluster.GrainFactory.GetGrain<IBasicAgent>(0);
            await basicAgent.Tick();
            Assert.Equal(true, true);
        }
    }
}
using Orleans.TestKit;
using Xunit;
using LifeX.Test.Helper;

namespace LifeX.Test
{
    [Collection(SiloCollection.Name)]
    public class BasicAgentTest
    {
        private readonly TestKitSilo _silo;

        public BasicAgentTest(SiloFixture fixture)
        {
            _silo = fixture.Silo;
        }
        
        [Fact]
        public async void SetupTest()
        {
            var basicAgent = _silo.GrainFactory.GetGrain<IBasicAgent>(0);
            await basicAgent.Tick();
            Assert.Equal(true, true);
        }
    }
}
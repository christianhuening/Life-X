using Xunit;

namespace LifeX.Test.Helper
{
    [CollectionDefinition(ClusterCollection.Name)]
    public class ClusterCollection : ICollectionFixture<ClusterFixture>
    {    
        public const string Name = "ClusterCollection";
    }
}
using Xunit;
using LifeX.Test.Helper;

namespace LifeX.Test
{
    [CollectionDefinition(SiloCollection.Name)]
    public class SiloCollection : ICollectionFixture<SiloFixture>
    {    
        public const string Name = "SiloCollection";
    }
}
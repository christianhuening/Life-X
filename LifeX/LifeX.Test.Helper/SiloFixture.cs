using System;
using Orleans.TestKit;

namespace LifeX.Test.Helper
{
    public class SiloFixture : IDisposable 
    {
        public SiloFixture()
        {
            this.Silo = new TestKitSilo();
        }

        public void Dispose()
        {
            
        }

        public TestKitSilo Silo { get; private set; }
    }
}
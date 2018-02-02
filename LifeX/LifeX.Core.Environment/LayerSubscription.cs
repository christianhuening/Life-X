using System.Collections.Generic;

namespace LifeX.Core.Environment
{
    public class LayerSubscription<TLayer>
    {
        
        public LayerSubscription<TLayer> Memory(IEnumerable<TLayer> memory, int count)
        {
            return this;
        }
        
        public LayerSubscription<TLayer> Memory(TLayer memory)
        {
            return this;
        }
    }
}
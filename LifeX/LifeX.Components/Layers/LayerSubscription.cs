using System.Collections.Generic;

namespace LifeX.Components.Layers
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
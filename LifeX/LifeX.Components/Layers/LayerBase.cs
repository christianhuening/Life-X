using LifeX.API.Layer;
using Orleans;
using Orleans.Concurrency;

namespace LifeX.Components.Layers
{
    [Reentrant]
    public class LayerBase<T> : Grain<T>, ILayerBase 
        where T : LayerState, new()
    {

    }
}
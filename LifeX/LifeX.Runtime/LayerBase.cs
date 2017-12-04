using LifeX.API;
using Orleans;
using Orleans.Concurrency;

namespace LifeX.Runtime
{
    [Reentrant]
    public class LayerBase<T> : Grain<T>, ILayerBase 
        where T : LayerState, new()
    {

    }
}
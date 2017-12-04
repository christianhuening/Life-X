using Orleans;
using Orleans.Concurrency;

namespace LifeX.API
{
    [Reentrant]
    public class AgentBase<T> : Grain<T>, IAgentBase 
        where T : AgentState, new()
    {

        public ActionSubscription<TAction> SubscribeAction<TAction>() where TAction : Action
        {
            return new ActionSubscription<TAction>();
        }

        public LayerSubscription<TLayer> SubscribeLayer<TLayer>()
        {
            // TODO: Runtime ILayerValue<> casting / checking necessary or otherwise additonal generic parameter necessary
            return new LayerSubscription<TLayer>();
        }
    }
}
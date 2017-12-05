using System.Threading.Tasks;
using Orleans;
using Orleans.Concurrency;

namespace LifeX.API
{
    [Reentrant]
    public abstract class AgentBase<T> : Grain<T>, IAgentBase 
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
        
        public Task<bool> TryAction<TAction>(TAction action) where TAction : Action
        {
            if (action.Position == null)
            {
                action.Position = State.Position;
            }
            if (action.Source == null)
            {
                action.Source = (IAgent)this; // every child implemented IAgent otherwise this will cause a runtime panic! 
            }
            return Task.FromResult(true);
        }
    }
}
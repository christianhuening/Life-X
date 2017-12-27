using System.Threading.Tasks;
using LifeX.API.Action;
using LifeX.API.Agent;
using LifeX.Core.PubSub;
using Orleans;
using Orleans.Concurrency;

namespace LifeX.Runtime
{
    [Reentrant]
    public abstract class AgentBase<T> : Grain<T>, IAgentBase 
        where T : AgentState, new()
    {
        protected ActionSubscription<TAction> SubscribeAction<TAction>() where TAction : API.Action.Action
        {
            return new ActionSubscription<TAction>();
        }

        protected LayerSubscription<TLayer> SubscribeLayer<TLayer>()
        {
            // TODO: Runtime ILayerValue<> casting / checking necessary or otherwise additonal generic parameter necessary
            return new LayerSubscription<TLayer>();
        }
        
        protected Task<ActionState> TryAction<TAction>(TAction action) where TAction : API.Action.Action
        {
            if (action.Position == null)
            {
                action.Position = State.Position;
            }
            if (action.Source == null)
            {
                action.Source = (IAgent)this; // every child implemented IAgent otherwise this will cause a runtime panic! 
            }
            return Task.FromResult(ActionState.Success);
        }
    }
}
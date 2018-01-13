using System.Threading.Tasks;
using LifeX.API.Agent;
using LifeX.Components.Actions;
using LifeX.Components.Agents;
using LifeX.Runtime;

namespace LifeX.Test
{
    public interface IBasicAgent : IAgent
    {
        
    }
    
    public class BasicState : AgentState
    {
        public double Value;
        public Memory<MoveAction> Others;
    }

    public class BasicAgent : AgentBase<BasicState>, IBasicAgent {
        
        public async Task Initialize()
        {
            State.Value = 0.0;
            State.Others = new Memory<MoveAction>(3);
            
            SubscribeAction<MoveAction>()
                .From<IBasicAgent>()
                .Near(5.0)
                .Memory(State.Others, (old, recent) => State.Position.DistanceTo(old.Position) > State.Position.DistanceTo(recent.Position))
                .ForgetIf<OutOfSightAction>()
                .ForEach((action) => { 
                    // do domething...
                });
                
            await WriteStateAsync();
        }

        public async Task Tick()
        {
            // do something...
            await TryAction(new MoveAction(null));
        }
    }

}
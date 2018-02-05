using System.Threading.Tasks;
using LifeX.API.Agent;
using LifeX.Components.Actions;
using LifeX.Components.Agents;
using LifeX.Components.Memory;
using WolfSheep.Model.Interfaces;

namespace WolfSheep.Model.Implementation
{

    
    public enum WolfPlan
    {
        WalkAround,
        AttackSheep,
    }
    
    public class WolfState : AgentState
    {
        public double Hunger;
        public WolfPlan Plan;
        public ISheep Target;
        // public IWolf Leader;
        public Memory<MoveAction> Sheeps; // can get sheep instances from Action.GetSource<ISheep>()
        public double CurrentHeight;
        public double ReproductionProbability;
        public double GainFromFood;
    }

    public class WolfAgent : AgentBase<WolfState>, IWolf {
        
        public async Task Initialize(AgentConfig<IWolf> config)
        {
            State.Plan = WolfPlan.WalkAround;
            State.Sheeps = new Memory<MoveAction>(3, MemoryStrategy.FORGET_OUT_OF_DISTANCE);
            
            SubscribeAction<MoveAction>()
                .From<ISheep>()
                .Near(Parameter.Optional("WOLF_VIEW_RADIUS", 5.0d))
                .Memory(State.Sheeps, (old, recent) => State.Position.DistanceTo(old.Position) > State.Position.DistanceTo(recent.Position))
                //.ForgetIf<OutOfSightAction>() // both action types need to implement IForgettable action
                .ForEach((action) => { // instead of lambda member function is also possible
                    if (State.Hunger > 100)
                    {
                        State.Plan = WolfPlan.AttackSheep;
                    }
                });
                
            await WriteStateAsync();
        }

        public async Task Tick()
        {
            // do something
            if (State.Target != null)
            {
                if (await State.Target.TryKill())
                {
                    State.Hunger -= 100;
                }
            }

            await TryAction(new MoveAction(null));
        }
    }

}
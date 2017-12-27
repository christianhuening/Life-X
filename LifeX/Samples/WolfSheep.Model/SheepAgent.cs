using System.Threading.Tasks;
using LifeX.API;
using LifeX.API.Agent;
using LifeX.Runtime;

namespace WolfSheep.Model
{
    public interface ISheep : IAgent
    {
        Task<bool> TryKill();
    }
    
    public class SheepState : AgentState
    {
        public IGrass Grass;
    }

    public class SheepAgent : AgentBase<SheepState>, ISheep {
        public async Task Initialize()
        {
            SubscribeLayer<IGrass>().Memory(State.Grass);

            await WriteStateAsync();
        }

        public Task Tick()
        {
            State.Grass.EatBiomass(0.123);
            return Task.CompletedTask;
        }
        
        public Task<bool> TryKill()
        {
            return Task.FromResult(true);
        }
    }
}
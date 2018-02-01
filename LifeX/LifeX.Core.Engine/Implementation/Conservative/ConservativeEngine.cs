using System.Threading.Tasks;
using LifeX.API.Agent;
using LifeX.Config;
using LifeX.Core.Engine.Interfaces;
using Orleans;

namespace LifeX.Core.Engine.Implementation.Conservative
{
    /// <summary>
    /// A conservative executiopn engin
    /// </summary>
    public class ConservativeEngine : Grain<ConservativeEngineState>, IConservativeEngine 
    {

        
        
        public ConservativeEngine(SimulationConfig config)
        {
            State.TicksToSimulate = config.TicksToSimulate;
        }
        
        public Task<bool> Register(IAgent agent)
        {
            return Task.FromResult(State.Agents.Add(agent));
        }

        public async Task Start()
        {
            for (var i = 0; i < State.TicksToSimulate; i++)
            {
                foreach (var agent in State.Agents)
                {
                    // should result in sequential execution on single core
                    await agent.Tick();
                }
            }
        }
    }
}
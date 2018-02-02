using System;
using System.Threading.Tasks;
using LifeX.API.Agent;
using LifeX.Config;
using LifeX.Core.Engine.Interfaces;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Runtime;

namespace LifeX.Core.Engine.Implementation.Conservative
{
    /// <summary>
    /// A conservative executiopn engin
    /// </summary>
    public class ConservativeEngine : Grain<ConservativeEngineState>, IConservativeEngine 
    {
        private readonly ILogger<ConservativeEngine> _logger;

        public ConservativeEngine(ILogger<ConservativeEngine> logger)
        {
            _logger = logger;
        }
        
        public Task Initialize(SimulationConfig config)
        {
            State.TicksToSimulate = config.TicksToSimulate;
            _logger.Info("Initialized Conservative Engine succesfully!");
            return Task.CompletedTask;
        }
        
        public Task<bool> Register(IAgent agent)
        {
            return Task.FromResult(State.Agents.Add(agent));
        }

        public async Task Start()
        {
            _logger.Info($"Starting Simulation for {State.TicksToSimulate} ticks...");
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
using System;
using LifeX.API.Action;
using LifeX.API.Agent;
using LifeX.API.Engine;
using LifeX.Client.Interfaces;
using LifeX.Config;
using LifeX.Config.Engine;
using LifeX.Config.Environment;
using LifeX.Core.Engine;
using LifeX.Core.Engine.Implementation;
using LifeX.Core.PubSub;

namespace LifeX.Client
{    
    public class Simulation : ISimulation
    {
        private readonly IEngine _engine;
        
        public Simulation(SimulationConfig config)
        {
            switch (config.EngineConfig)
            {
                case ExactEngineConfig engineConfig:
                {
                    _engine = new ConservativeEngine(/* engineConfig */);
                    break;
                }
                case ElasticEngineConfig engineConfig:
                {
                    _engine = new ElasticEngine(engineConfig);
                    break;
                }
            }
        }

        public void AddAgent(IAgent agent)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            _engine.Start();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }
    }
}
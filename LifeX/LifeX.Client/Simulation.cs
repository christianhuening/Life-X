using System;
using LifeX.API.Action;
using LifeX.API.Engine;
using LifeX.Config;
using LifeX.Config.Engine;
using LifeX.Config.Environment;
using LifeX.Core.Engine;
using LifeX.Core.PubSub;

namespace LifeX.Client
{    
    public class Simulation
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
                    throw new NotImplementedException();
                }
            }
        }

        public void Start()
        {
            _engine.Start();
        }
    }
}
using System;
using LifeX.API.Action;
using LifeX.API.Config;
using LifeX.API.Engine;
using LifeX.Core.Engine;
using LifeX.Core.PubSub;

namespace LifeX.Runtime
{    
    public class Simulation
    {
        private IEngine _engine;
        private IPubSub _pubSub;
        
        public Simulation(SimulationConfig config)
        {
            switch (config.EngineConfig)
            {
                case ExactEngineConfig engineConfig:
                {
                    _engine = new ExactEngine(/* engineConfig */);
                    break;
                }
                case ElasticEngineConfig engineConfig:
                {
                    throw new NotImplementedException();
                }
            }
            switch (config.PubSubConfig)
            {
                case GridPubSubConfig pubSubConfig:
                {
                    _pubSub = new GridPubSub(/* pubSubConfig */);
                    break;
                }
                case VoronoiPubSubConfig pubSubConfig:
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
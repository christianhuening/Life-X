using System;
using LifeX.API;
using LifeX.API.Action;
using LifeX.API.Agent;
using LifeX.API.Config;
using LifeX.Core.Engine;
using LifeX.Core.PubSub;
using LifeX.Runtime.Data;

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

        public void DistributeLayerData<TLayer>(IDataAny dataGrid) 
        {
            // TODO: TLayer runtime casting and DataAny checks if they fit their `TValue` type necessary 
        }

        public void DistributeAgents<TAgent>(IVector[] positions) where TAgent : IAgent
        {
            TAgent[] agents = null; // TODO: create agents at positions
            foreach (var agent in agents)
            {
                _pubSub.Insert(agent);
                _engine.Register(agent);
            }
        }

        public void Start()
        {
            _engine.Start();
        }
    }
}
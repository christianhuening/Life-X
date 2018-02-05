using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LifeX.API;
using LifeX.API.Agent;
using LifeX.API.Engine;
using LifeX.Client.Interfaces;
using LifeX.Config;
using LifeX.Core.Engine.Implementation.Conservative;
using LifeX.Core.Engine.Implementation.Elastic;
using LifeX.Core.Engine.Interfaces;
using Orleans;

namespace LifeX.Client
{    
    public class Simulation : ISimulation
    {
        private readonly SimulationConfig _config;
        private readonly IEngine _engine;

        private readonly List<Task> _registerTasks;

        public Simulation(IClusterClient client, SimulationConfig config)
        {
            _config = config;
            _registerTasks = new List<Task>();
            switch (config.EngineConfig)
            {
                case ConservativeEngineConfig engineConfig:
                {
                    _engine = client.GetGrain<IConservativeEngine>(Guid.NewGuid());
                    break;
                }
                case ElasticEngineConfig engineConfig:
                {
                    _engine = client.GetGrain<IElasticEngine>(Guid.NewGuid());
                    break;
                }
            }
        }

        public void AddAgent(IAgent agent)
        {
            _registerTasks.Add(_engine.Register(agent));
        }

        public Task Initialize()
        {
            return _engine.Initialize(_config);
        }

        public Task Start()
        {
            Task.WaitAll(_registerTasks.ToArray());
            return _engine.Start();
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
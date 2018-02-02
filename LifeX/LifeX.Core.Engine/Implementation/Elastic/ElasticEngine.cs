using System.Threading.Tasks;
using LifeX.API.Agent;
using LifeX.Config;
using LifeX.Config.Engine;
using LifeX.Core.Engine.Interfaces;
using Microsoft.Extensions.Logging;
using Orleans;

namespace LifeX.Core.Engine.Implementation.Elastic
{
    public class ElasticEngine : Grain<ElasticEngineState>, IElasticEngine
    {
        private readonly ILogger<ElasticEngine> _logger;


        public ElasticEngine(ILogger<ElasticEngine> logger)
        {
            _logger = logger;
        }

        public Task Initialize(SimulationConfig config)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Register(IAgent agent)
        {
            throw new System.NotImplementedException();
        }

        public Task Start()
        {
            throw new System.NotImplementedException();
        }
    }
}
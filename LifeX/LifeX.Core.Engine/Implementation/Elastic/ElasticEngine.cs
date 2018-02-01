using System.Threading.Tasks;
using LifeX.API.Agent;
using LifeX.Config.Engine;
using LifeX.Core.Engine.Interfaces;

namespace LifeX.Core.Engine.Implementation.Elastic
{
    public class ElasticEngine : IElasticEngine
    {
        private ElasticEngineConfig _elasticEngineConfi;

        public ElasticEngine(ElasticEngineConfig elasticEngineConfi)
        {
            _elasticEngineConfi = elasticEngineConfi;
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
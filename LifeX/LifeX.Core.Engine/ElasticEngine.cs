using System.Threading.Tasks;
using LifeX.API.Agent;
using LifeX.API.Engine;
using LifeX.Config.Engine;

namespace LifeX.Core.Engine
{
    public class ElasticEngine : IEngine
    {
        private ElasticEngineConfig _elasticEngineConfi;

        public ElasticEngine(ElasticEngineConfig elasticEngineConfi)
        {
            _elasticEngineConfi = elasticEngineConfi;
        }

        public Task Register(IAgent agent)
        {
            throw new System.NotImplementedException();
        }

        public Task Start()
        {
            throw new System.NotImplementedException();
        }
    }
}
using LifeX.Config.Engine;
using LifeX.Config.Environment;

namespace LifeX.Config
{
    
    public class SimulationConfig
    {
        public EnvironmentConfig EnvironmentConfig;
        public PubSubConfig PubSubConfig;
        public EngineConfig EngineConfig;

        public SimulationConfig(EnvironmentConfig environmentConfig, PubSubConfig pubSubConfig, EngineConfig engineConfig)
        {
            EnvironmentConfig = environmentConfig;
            PubSubConfig = pubSubConfig;
            EngineConfig = engineConfig;
        }
        
        public static SimulationConfig FromDefault()
        {
            return new SimulationConfig(EnvironmentConfig.FromDefault(), GridPubSubConfig.FromDefault(), ElasticEngineConfig.FromDefault());
        }
    }
}
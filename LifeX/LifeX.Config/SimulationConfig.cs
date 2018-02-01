using LifeX.Config.Engine;
using LifeX.Config.Environment;

namespace LifeX.Config
{
    
    public class SimulationConfig
    {
        public EnvironmentConfig EnvironmentConfig;
        public PubSubConfig PubSubConfig;
        public EngineConfig EngineConfig;

        public int TicksToSimulate;

        public SimulationConfig(EnvironmentConfig environmentConfig, PubSubConfig pubSubConfig, EngineConfig engineConfig, int ticksToSimulate)
        {
            EnvironmentConfig = environmentConfig;
            PubSubConfig = pubSubConfig;
            EngineConfig = engineConfig;
            TicksToSimulate = ticksToSimulate;
        }
        
        public static SimulationConfig FromDefault()
        {
            return new SimulationConfig(EnvironmentConfig.FromDefault(), GridPubSubConfig.FromDefault(), ElasticEngineConfig.FromDefault(), 1);
        }
    }
}
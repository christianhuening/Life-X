namespace LifeX.API
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
            return new SimulationConfig(EnvironmentConfig.FromDefault(), GridPubSubConfig.FromDefault(), ExactEngineConfig.FromDefault());
        }
    }
}
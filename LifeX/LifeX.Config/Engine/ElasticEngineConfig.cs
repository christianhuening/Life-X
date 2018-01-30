namespace LifeX.Config.Engine
{
    public class ElasticEngineConfig : EngineConfig
    {
        public static ExactEngineConfig FromDefault()
        {
            var config = new ExactEngineConfig();
            return config;
        }
    }
}
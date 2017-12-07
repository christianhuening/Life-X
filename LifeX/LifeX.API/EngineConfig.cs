namespace LifeX.API
{
    public abstract class EngineConfig
    {
        
    }

    public class ExactEngineConfig : EngineConfig
    {
        public static ExactEngineConfig FromDefault()
        {
            var config = new ExactEngineConfig();
            return config;
        }
    } 

    public class ElasticEngineConfig : EngineConfig
    {
        public static ExactEngineConfig FromDefault()
        {
            var config = new ExactEngineConfig();
            return config;
        }
    } 
}
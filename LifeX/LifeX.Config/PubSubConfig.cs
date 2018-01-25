namespace LifeX.Config
{
    public abstract class PubSubConfig
    {
        
    }

    public class GridPubSubConfig : PubSubConfig
    {
        public static GridPubSubConfig FromDefault()
        {
            var config = new GridPubSubConfig();
            return config;
        }
    } 

    public class VoronoiPubSubConfig : PubSubConfig
    {
        public static VoronoiPubSubConfig FromDefault()
        {
            var config = new VoronoiPubSubConfig();
            return config;
        }
    } 
}
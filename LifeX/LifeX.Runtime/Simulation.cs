using LifeX.API;
using LifeX.Runtime.Data;

namespace LifeX.Runtime
{
    public enum PubSubMechanism
    {
        GridBased,
        VoronoiOverlay,
        Octree
    }
    
    public class SimulationConfig
    {
        public PubSubMechanism PubSubMechanism;
        
        public static SimulationConfig FromDefault()
        {
            return new SimulationConfig();
        }
    }
    
    public class Simulation
    {
        public Simulation(SimulationConfig config)
        {
        }

        public void DistributeLayerData<TLayer>(IDataAny dataGrid) 
        {
            // TODO: TLayer runtime casting and DataAny checks if they fit their `TValue` type necessary 
        }

        public void DistributeAgents<TAgent>(IVec[] positions)
        {
            
        }
    }
}
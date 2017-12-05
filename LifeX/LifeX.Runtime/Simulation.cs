using LifeX.API;
using LifeX.Core.Engine;
using LifeX.Runtime.Data;

namespace LifeX.Runtime
{
    public enum PubSubMechanism
    {
        GridBased,
        VoronoiOverlay,
        Octree
    }

    public enum TickMechanism
    {
        Exact, // every agent in same tick
        Elastic // every agent at maximum X ticks apart
    }
    
    public class SimulationConfig
    {
        public PubSubMechanism PubSubMechanism = PubSubMechanism.GridBased;
        public TickMechanism TickMechanism = TickMechanism.Exact;
        
        public static SimulationConfig FromDefault()
        {
            return new SimulationConfig();
        }
    }
    
    public class Simulation
    {
        private IEngine _engine;
        private IPubSub _pubSub;
        
        public Simulation(SimulationConfig config)
        {
            switch (config.TickMechanism)
            {
                case TickMechanism.Exact:
                {
                    _engine = new ExactEngine();
                    break;
                }
            }
            switch (config.PubSubMechanism)
            {
                case PubSubMechanism.GridBased:
                {
                    _pubSub = new GridPubSub();
                    break;
                }
            }
        }

        public void DistributeLayerData<TLayer>(IDataAny dataGrid) 
        {
            // TODO: TLayer runtime casting and DataAny checks if they fit their `TValue` type necessary 
        }

        public void DistributeAgents<TAgent>(IVec[] positions) where TAgent : IAgent
        {
            TAgent[] agents = null; // TODO: create agents at positions
            foreach (var agent in agents)
            {
                _pubSub.Insert(agent);
                _engine.Register(agent);
            }
        }

        public void Start()
        {
            _engine.Start();
        }
    }
}
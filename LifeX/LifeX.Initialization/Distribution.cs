using LifeX.API.Action;
using LifeX.API.Agent;
using LifeX.API.Data;
using LifeX.API.Engine;
using LifeX.API.Environment;

namespace LifeX.Initialization
{
    public static class Distribution
    {
        public static IVector[] RandomPositions2D(long count)
        {
            return null;
        }
        
        public static void DistributeLayerData<TLayer>(IDataGrid dataGrid) 
        {
            // TODO: TLayer runtime casting and DataAny checks if they fit their `TValue` type necessary 
        }

        public static void DistributeAgents<TAgent>(IVector[] positions, IPubSub pubSub, IEngine engine) where TAgent : IAgent
        {
            TAgent[] agents = null; // TODO: create agents at positions
            if (agents == null) return;
            foreach (var agent in agents)
            {
                pubSub.Insert(agent);
                engine.Register(agent);
            }
        }

    }
}
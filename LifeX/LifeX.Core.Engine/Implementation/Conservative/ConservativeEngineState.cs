using System.Collections.Generic;
using LifeX.API.Agent;

namespace LifeX.Core.Engine.Implementation.Conservative
{
    public class ConservativeEngineState
    {
        public HashSet<IAgent> Agents { get; set; }
        public int TicksToSimulate { get; set; }
    }
}
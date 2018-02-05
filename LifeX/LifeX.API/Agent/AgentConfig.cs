using System;
using System.Collections.Generic;

namespace LifeX.API.Agent
{
    public interface IAgentConfig<out TAgent> {}
    
    public class AgentConfig<TAgent> : IAgentConfig<TAgent> where TAgent : IAgent
    {
        public int AgentCount { get; private set; }
        public Func<List<TAgent>> InitFunction { get; private set; }
        
        public AgentConfig<TAgent> Count(int amountOfAgents)
        {
            AgentCount = amountOfAgents;
            return this;
        }

        public AgentConfig<TAgent> Init(Func<List<TAgent>> func)
        {
            InitFunction = func;
            return this;
        }
    }
}
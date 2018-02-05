using System;
using System.Collections.Generic;
using LifeX.API.Agent;
using LifeX.API.Engine;
using LifeX.Config.Environment;

namespace LifeX.API
{
    
    public class SimulationConfig
    {
        public EnvironmentConfig EnvironmentConfig;
        public PubSubConfig PubSubConfig;
        public EngineConfig EngineConfig;
        public int TicksToSimulate;
        private readonly Dictionary<Type, IAgentConfig<IAgent>> _agentConfigs;

        public SimulationConfig(EnvironmentConfig environmentConfig, PubSubConfig pubSubConfig, EngineConfig engineConfig,
            int ticksToSimulate)
        {
            EnvironmentConfig = environmentConfig;
            PubSubConfig = pubSubConfig;
            EngineConfig = engineConfig;
            TicksToSimulate = ticksToSimulate;
            _agentConfigs = new Dictionary<Type, IAgentConfig<IAgent>>();
            
        }
        
        public static SimulationConfig FromDefault()
        {
            return new SimulationConfig(EnvironmentConfig.FromDefault(), GridPubSubConfig.FromDefault(), ElasticEngineConfig.FromDefault(), 1);
        }
        
        public AgentConfig<TAgent> ConfigureAgentType<TAgent>() where TAgent : IAgent
        {
            var type = typeof(TAgent);
            IAgentConfig<TAgent> ac = new AgentConfig<TAgent>();
            _agentConfigs.Add(type, ac);
            return ac;
        }

        public AgentConfig<TResult> GetAgentConfig<out TResult>()
        {
            
        }
    }
}
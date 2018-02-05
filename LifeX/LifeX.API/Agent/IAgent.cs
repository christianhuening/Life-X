﻿using System.Threading.Tasks;

namespace LifeX.API.Agent
{
    public interface IAgent : Orleans.IGrainWithIntegerKey, IAgentBase
    {
        Task Initialize(AgentConfig config);
        Task Tick();
    }
}
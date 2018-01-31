using System.Threading.Tasks;
using LifeX.API.Agent;
using LifeX.API.Engine;
using Orleans;

namespace LifeX.Core.Engine.Implementation
{
    /// <summary>
    /// A conservative executiopn engin
    /// </summary>
    public class ConservativeEngine : Grain, IEngine 
    {
        
        
        
        public Task Register(IAgent agent)
        {
            throw new System.NotImplementedException();
        }

        public Task Start()
        {
            throw new System.NotImplementedException();
        }
    }
}
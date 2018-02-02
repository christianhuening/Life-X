using System.Threading.Tasks;
using LifeX.API.Agent;
using LifeX.Config;
using Orleans;

namespace LifeX.API.Engine
{
    public interface IEngine : IGrainWithGuidKey
    {
        Task Initialize(SimulationConfig config);
        Task<bool> Register(IAgent agent);
        Task Start();
    }
}
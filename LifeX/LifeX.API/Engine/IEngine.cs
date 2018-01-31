using System.Threading.Tasks;
using LifeX.API.Agent;
using Orleans;

namespace LifeX.API.Engine
{
    public interface IEngine : IGrainWithGuidKey
    {
        Task Register(IAgent agent);
        Task Start();
    }
}
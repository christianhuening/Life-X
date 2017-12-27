using System.Threading.Tasks;
using LifeX.API.Agent;

namespace LifeX.API
{
    public interface IEngine
    {
        Task Register(IAgent agent);
        Task Start();
    }
}
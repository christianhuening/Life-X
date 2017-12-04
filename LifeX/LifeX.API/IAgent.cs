using System.Threading.Tasks;

namespace LifeX.API
{
    public interface IAgent : Orleans.IGrainWithIntegerKey, IAgentBase
    {
        Task Initialize();
        Task Tick();
    }
}
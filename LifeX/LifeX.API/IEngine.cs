using System.Threading.Tasks;

namespace LifeX.API
{
    public interface IEngine
    {
        Task Register(IAgent agent);
        Task Start();
    }
}
using System.Threading.Tasks;
using LifeX.API.Agent;

namespace LifeX.API.Action
{
    public interface IPubSub
    {
        Task Insert(IAgent agent);
    }
}
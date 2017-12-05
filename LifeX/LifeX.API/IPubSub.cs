using System.Threading.Tasks;

namespace LifeX.API
{
    public interface IPubSub
    {
        Task Insert(IAgent agent);
    }
}
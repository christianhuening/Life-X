using System.Threading.Tasks;

namespace LifeX.API
{
    public interface ILayer : Orleans.IGrainWithIntegerKey, ILayerBase
    {
        Task Tick();
    }
}
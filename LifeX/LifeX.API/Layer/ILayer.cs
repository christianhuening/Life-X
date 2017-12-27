using System.Threading.Tasks;

namespace LifeX.API.Layer
{
    public interface ILayer : Orleans.IGrainWithIntegerKey, ILayerBase
    {
        Task Tick();
    }
}
using System.Threading.Tasks;
using LifeX.API;
using LifeX.API.Layer;
using LifeX.Components.Layers;
using LifeX.Runtime;

namespace WolfSheep.Model
{
    public interface IGrass : ILayer
    {
        Task<double> EatBiomass(double amount);
    }

    public class GrassState : LayerState
    {
        public double GrassHeight;
    }
    
    public class GrassLayer : LayerBase<GrassState>, IGrass
    {
        public async Task<double> EatBiomass(double amount)
        {
            State.GrassHeight -= amount; // simple, without checking if enough biomass
            await WriteStateAsync();
            return amount;
        }

        public Task Tick()
        {
            return Task.CompletedTask;
        }
    }
}
using System;
using System.Threading.Tasks;
using LifeX.API.Config;
using LifeX.Client;
using LifeX.Components.Agents;
using LifeX.Components.Data;
using LifeX.Config;
using LifeX.Initialization;
using LifeX.Runtime;
using WolfSheep.Model;
using WolfSheep.Model.Interfaces;

namespace WolfSheep.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Client setup
            var config = DefaultClient.DefaultConfiguration();
            try
            {
                DefaultClient.Initialize(config, new Type[]{typeof(IGrass),typeof(ISheep), typeof(IWolf)});
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Orleans client initialization failed due to {ex}");
            }
            
            // get simulation configuration parameters
            var heightMapFilename = Parameter.Required<string>("HEIGHT_MAP_FILE");
            var wolfCount = Parameter.Optional<long>("WOLF_COUNT", 10_000_000);
            var sheepCount = Parameter.Optional<long>("SHEEP_COUNT", 100_000_000);

            // load height data
            DataGrid<double> grassHeightGrid;
            using (var data = FileManager.Open(heightMapFilename))
            {
                // Import must handle all greyscale type datasets, not(!) semantic
                grassHeightGrid = Import.FromGreyscaleMap(data);
            }

            // create simulation runtime
            var simulationConfig = SimulationConfig.FromDefault();
            // optional: define values other than default, e.g. PubSub mechanism
            simulationConfig.PubSubConfig = GridPubSubConfig.FromDefault();
            var simulation = new Simulation(simulationConfig);

            // distribute height data across actors
            Distribution.DistributeLayerData<IGrass>(grassHeightGrid);

            //
            var wolfPositions = Distribution.RandomPositions2D(wolfCount);
            var sheepPositions = Distribution.RandomPositions2D(sheepCount);

            // create Agents automatically, or manually or however you like...

            // setup global rules and effects
            // simulation.AddRule(/* ... */)
            
            simulation.Start();
        }
    }
}
using System;
using LifeX.API.Config;
using LifeX.API.Environment;
using LifeX.Components.Data;
using LifeX.Initialization;
using LifeX.Runtime;
using WolfSheep.Model;

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
                DefaultClient.InitializeWithRetries(config, initializeAttemptsBeforeFailing: 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Orleans client initialization failed failed due to {ex}");
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
            IVector[] wolfPositions = Distribution.RandomPositions2D(wolfCount);
            IVector[] sheepPositions = Distribution.RandomPositions2D(sheepCount);

            //
            Distribution.PlaceAgents<WolfAgent>(wolfPositions);
            Distribution.PlaceAgents<SheepAgent>(sheepPositions);

            // setup global rules and effects
            // simulation.AddRule(/* ... */)
            
            simulation.Start();
        }
    }
}
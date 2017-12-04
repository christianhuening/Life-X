using System;
using System.IO;
using LifeX.API;
using LifeX.Runtime;
using LifeX.Runtime.Data;
using WolfSheep.Model;

namespace WolfSheep.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            // Client setup
            var config = Client.DefaultConfiguration();
            try
            {
                Client.InitializeWithRetries(config, initializeAttemptsBeforeFailing: 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Orleans client initialization failed failed due to {ex}");
            }
            
            // get simulation configuration parameters
            var heightMapFilename = Parameters.Required<string>("HEIGHT_MAP_FILE");
            var wolfCount = Parameters.Optional<long>("WOLF_COUNT", 10_000_000);
            var sheepCount = Parameters.Optional<long>("SHEEP_COUNT", 100_000_000);

            // load height data
            DataGrid<double> grassHeightGrid;
            using (FileStream data = FileManager.Open(heightMapFilename))
            {
                // Import must handle all greyscale type datasets, not(!) semantic
                grassHeightGrid = Import.FromGreyscaleMap(data);
            }

            // create simulation runtime
            var simulationConfig = SimulationConfig.FromDefault();
            // optional: define values other than default, e.g. PubSub mechanism
            simulationConfig.PubSubMechanism = PubSubMechanism.VoronoiOverlay;
            var simulation = new Simulation(simulationConfig);

            // distribute height data across actors
            simulation.DistributeLayerData<IGrass>(grassHeightGrid);

            //
            IVec[] wolfPositions = Distribution.RandomPositions2D(wolfCount);
            IVec[] sheepPositions = Distribution.RandomPositions2D(sheepCount);

            //
            simulation.DistributeAgents<WolfAgent>(wolfPositions);
            simulation.DistributeAgents<SheepAgent>(sheepPositions);

            // setup global rules and effects
            // simulation.AddRule(/* ... */)
        }
    }
}
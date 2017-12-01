using System;

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
            // optional: define PubSub mechanism
            simulationConfig.PubSub = new VoronoiPubSub(/* ... */);
            var simulation = new Simulation(simulationConfig);

            // distribute height data across actors
            simulation.DistributeLayerData<IGrass>(grassHeightGrid);

            //
            Vec2[] wolfPositions = Distribution.RandomPositions(wolfCount);
            Vec2[] sheepPositions = Distribution.RandomPositions(sheepCount);

            //
            simulation.DistributeAgents<WolfAgent>(wolfPositions);
            simulation.DistributeAgents<SheepAgent>(sheepPositions);

            // setup global rules and effects
            // simulation.AddRule(/* ... */)
        }
    }
}
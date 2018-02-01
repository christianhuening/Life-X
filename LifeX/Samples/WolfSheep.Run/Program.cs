using System;
using LifeX.Client;
using LifeX.Config;
using LifeX.Config.Environment;
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
                // This needs to be automated, i.e. have a LayerLoader equivalent
                var client = DefaultClient.Initialize(config, new[]{typeof(IGrass),typeof(ISheep), typeof(IWolf)});
                /*
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
                */
            

                // create simulation runtime
                var simulationConfig = SimulationConfig.FromDefault();

                var simulation = new Simulation(client, simulationConfig);

                // distribute height data across actors
                //Distribution.DistributeLayerData<IGrass>(grassHeightGrid);

                //
                //var wolfPositions = Distribution.RandomPositions2D(wolfCount);
                //var sheepPositions = Distribution.RandomPositions2D(sheepCount);

                // create Agents automatically, or manually or however you like...

                // setup global rules and effects
                // simulation.AddRule(/* ... */)
            
                simulation.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Orleans client initialization failed due to {ex}");
            }
        }
    }
}
using System;
using LifeX.Client;
using LifeX.Config;
using LifeX.Config.Environment;
using WolfSheep.Model;
using WolfSheep.Model.Interfaces;

namespace WolfSheep.Run
{
    static class Program
    {
        static void Main(string[] args)
        {
            
            // Client setup
            var config = DefaultClient.DefaultConfiguration();
            try
            {
                var client = DefaultClient.Initialize(config);

                var simulationConfig = SimulationConfig.FromDefault();

                var simulation = new Simulation(client, simulationConfig);
                
                simulation.Initialize().Wait();
                
                var simFinished = simulation.Start();
                
                Console.WriteLine("Simulation started...");
                
                simFinished.Wait();
                
                Console.WriteLine("Simulation finished!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Orleans client initialization failed due to {ex}");
            }
        }
    }
}
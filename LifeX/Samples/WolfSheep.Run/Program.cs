using System;
using System.Collections.Generic;
using LifeX.API;
using LifeX.Client;
using LifeX.Config;
using LifeX.Config.Environment;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WolfSheep.Model;
using WolfSheep.Model.Implementation;
using WolfSheep.Model.Interfaces;

namespace WolfSheep.Run
{
    static class Program
    {
        static void Main(string[] args)
        {
            
            // Client setup
            var config = DefaultClient.DefaultConfiguration();

            var client = DefaultClient.Initialize(config);

            // Simulation setup
            var simulationConfig = SimulationConfig.FromDefault();
            
            // configure Agents:
            simulationConfig
                .ConfigureAgentType<IWolf>()
                .Count(100)
                .Init(agentCount =>
                {
                    var wolves = new List<IWolf>();
                    for (var i = 0; i < agentCount; i++)
                    {
                        wolves.Add(new WolfAgent());
                    }

                    return wolves;
                });
                    
            simulationConfig
                .ConfigureAgentType<ISheep>()
                .Count(200);
            
           
            var simulation = new Simulation(client, simulationConfig);
            
            simulation.Initialize().Wait();
            
            var simFinished = simulation.Start();
            
            Console.WriteLine("Simulation started...");
            
            simFinished.Wait();
            
            Console.WriteLine("Simulation finished!");
        }
    }
}
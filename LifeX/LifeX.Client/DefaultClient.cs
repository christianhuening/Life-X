﻿using System;
using System.Reflection;
using System.Threading;
 using LifeX.Core.Engine.Implementation.Conservative;
 using LifeX.Core.Engine.Implementation.Elastic;
 using LifeX.Core.Engine.Interfaces;
 using Microsoft.CodeAnalysis;
using Orleans;
using Orleans.Runtime;
using Orleans.Runtime.Configuration;

namespace LifeX.Client
{
    public class DefaultClient
    {
        
        
        public static ClientConfiguration DefaultConfiguration()
        {
            return ClientConfiguration.LocalhostSilo();
        }
        
        public static IClusterClient Initialize(ClientConfiguration config, Type[] agents, int initializeAttemptsBeforeFailing=5)
        {
            var attempt = 0;
            IClusterClient client = null;
            while (attempt < initializeAttemptsBeforeFailing)
            {
                try
                {
                    

                    var builder = new ClientBuilder()
                        .UseConfiguration(config);
                    
                    foreach (var agentType in agents)
                    {
                        builder.ConfigureApplicationParts(parts => parts.AddApplicationPart(agentType.Assembly));
                    }

                    builder.ConfigureApplicationParts(parts =>
                        {
                            parts.AddApplicationPart(typeof(IConservativeEngine).Assembly).WithReferences();
                            parts.AddApplicationPart(typeof(IElasticEngine).Assembly).WithReferences();
                        }
                    );
                    
                    
                    client = builder.Build();
                    client.Connect().Wait();
                    Console.WriteLine("Client successfully connect to silo host");
                    break;

                }
                catch (SiloUnavailableException)
                {
                    attempt++;
                    Console.WriteLine($"Attempt {attempt} of {initializeAttemptsBeforeFailing} failed to initialize the Orleans client.");
                    if (attempt > initializeAttemptsBeforeFailing)
                    {
                        throw;
                    }
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }

                attempt++;
            }
            return client;
        }
    }
}
using System;
using System.Threading;
using Orleans;
using Orleans.Runtime;
using Orleans.Runtime.Configuration;

namespace LifeX.Runtime
{
    public class Client
    {
        public static ClientConfiguration DefaultConfiguration()
        {
            return ClientConfiguration.LocalhostSilo();
        }
        
        public static void InitializeWithRetries(ClientConfiguration config, int initializeAttemptsBeforeFailing)
        {
            int attempt = 0;
            while (true)
            {
                try
                {
                    GrainClient.Initialize(config);
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
            }
        }
    }
}
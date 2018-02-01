using System;
using System.Threading.Tasks;
using LifeX.Core.Engine.Interfaces;
using Serilog;
using Orleans;
using Orleans.Hosting;
using Orleans.Runtime.Configuration;
using WolfSheep.Model.Interfaces;

namespace LifeX.Host
{
    public class Program
    {
        public static int Main(string[] args)
        {
            return RunMainAsync().Result;
        }

        private static async Task<int> RunMainAsync()
        {
            try
            {
                var host = await StartSilo();
                Console.WriteLine("Press Enter to terminate...");
                Console.ReadLine();

                await host.StopAsync();

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 1;
            }
        }

        private static async Task<ISiloHost> StartSilo()
        {
            // define the cluster configuration
            var config = ClusterConfiguration.LocalhostPrimarySilo();
            config.AddMemoryStorageProvider();
            
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
            
            var builder = new SiloHostBuilder()
                .UseConfiguration(config)
                // TODO Exchange for automatic discovery of simulation assemblies!
                .ConfigureApplicationParts(parts =>
                {
                    parts.AddFromApplicationBaseDirectory();
                    /*
                    parts.AddApplicationPart(typeof(IGrass).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(ISheep).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IWolf).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IConservativeEngine).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IElasticEngine).Assembly).WithReferences();
                    */
                })
                .ConfigureLogging(logging => logging.AddSerilog(dispose: true));

            var host = builder.Build();
            await host.StartAsync();
            return host;
        }
        /*
        private static OrleansHostWrapper hostWrapper;

        public static int Main(string[] args)
        {
            int exitCode = StartSilo(args);

            Console.WriteLine("Press Enter to terminate...");
            Console.ReadLine();

            exitCode += ShutdownSilo();

            //either StartSilo or ShutdownSilo failed would result on a non-zero exit code. 
            return exitCode;
        }


        private static int StartSilo(string[] args)
        {
            // define the cluster configuration
            var config = ClusterConfiguration.LocalhostPrimarySilo();
            config.AddMemoryStorageProvider(providerName: "Default");
            // config.Defaults.DefaultTraceLevel = Orleans.Runtime.Severity.Verbose3;

            hostWrapper = new OrleansHostWrapper(config, args);
            return hostWrapper.Run();
        }

        private static int ShutdownSilo()
        {
            if (hostWrapper != null)
            {
                return hostWrapper.Stop();
            }
            return 0;
        }
        */
    }
}
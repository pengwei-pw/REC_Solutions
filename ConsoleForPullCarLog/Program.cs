using ConsoleForPullCarLog.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleForPullCarLog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var worker = ActivatorUtilities.CreateInstance<Work>(host.Services);
            worker.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, configuration) => { 
                    configuration.Sources.Clear();
                    configuration.AddJsonFile(@"Config/AppSettings.json", optional: true, reloadOnChange: true);
                    configuration.AddCommandLine(args);
                });
        }
    }
}
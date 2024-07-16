using ConsoleForPullCarLog.Repositorys;
using ConsoleForPullCarLog.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.Design;

namespace ConsoleForPullCarLog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var worker = ActivatorUtilities.CreateInstance<Work>(host.Services);
            worker.Run();
            Console.ReadKey();
        }


        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, configuration) =>
                {
                    configuration.Sources.Clear();
                    //var enviromentName = Environment.GetEnvironmentVariable("DOTNETCORE_ENVIRONMENT");
                    configuration.AddJsonFile(@"Config/AppSettings.json", optional: true, reloadOnChange: true);
                    //configuration.AddJsonFile($"Config/AppSettings.{enviromentName}.json", optional: true, reloadOnChange: true);
                    configuration.AddCommandLine(args);
                }).ConfigureServices((context, services) => {
                    services.AddScoped<ISampleRepository, SampleRepository>();
                });

        }
    }
}
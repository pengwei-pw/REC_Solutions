using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForPullCarLog.Services
{
    public class Work
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<Work> logger;


        public Work(IConfiguration configuration, ILogger<Work> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public void Run()
        {
            logger.LogInformation("hello, world!!!");
            var timeDump = configuration.GetConnectionString("TimeDump");
            Trace.WriteLine(timeDump);
            logger.LogInformation($"Pull Log During The {timeDump}");
            logger.LogInformation(configuration["key1"]);
            Console.ReadKey();
        }

    }
}

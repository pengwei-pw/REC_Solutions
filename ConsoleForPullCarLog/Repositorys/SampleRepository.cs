using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForPullCarLog.Repositorys
{
    public class SampleRepository:ISampleRepository
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<SampleRepository> logger;

        public SampleRepository(IConfiguration configuration, ILogger<SampleRepository> logger) {
            this.configuration = configuration;
            this.logger = logger;
        }

        public void DoSomething()
        {
            logger.LogInformation("this is di");
        }
    }
}

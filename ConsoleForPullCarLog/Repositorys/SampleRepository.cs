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
        /// <summary>
        /// dosomething
        /// </summary>
        /// <param name="index">work index</param>
        public void DoSomething(int index)
        {
            switch (index)
            {
                case 0:
                    CyclicPullLog();
                    return;
                case 1:
                    Console.WriteLine("test1");
                    return;
            }
        }

        /// <summary>
        /// pull log
        /// </summary>
        private void CyclicPullLog()
        {
            var timeDump = configuration.GetConnectionString("TimeDump");
            
        }
    }
}

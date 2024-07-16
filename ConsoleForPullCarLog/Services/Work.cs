using ConsoleForPullCarLog.Enums;
using ConsoleForPullCarLog.Repositorys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForPullCarLog.Services
{
    public class Work
    {
        private readonly ISampleRepository sampleRepository;
        private readonly IConfiguration configuration;
        private readonly ILogger<Work> logger;


        public Work(ISampleRepository sampleRepository, IConfiguration configuration, ILogger<Work> logger)
        {
            this.sampleRepository = sampleRepository;
            this.configuration = configuration;
            this.logger = logger;
        }

        public void Run()
        {
            int index = Selection();
            //var timeDump = configuration.GetConnectionString("TimeDump");
            //Appsettings.json中参数读取
            //logger.LogInformation($"Pull Log During The {timeDump}");
            //查看命令行参数
            //logger.LogInformation(configuration["key1"]);
            sampleRepository.DoSomething(index);
        }

        private int Selection()
        {
            logger.LogInformation("选择执行任务前序号");
            int index = 0;
            List<int> list = new List<int>();
            while (true)
            {
                foreach (var item in typeof(WorkEnum).GetEnumValues())
                {
                    Console.WriteLine($"{(int)item}: {GetDescriptionByEnum((WorkEnum)item)}");
                    list.Add((int)item);
                }
                bool isStr = int.TryParse(Console.ReadLine(), out index) && (list.Contains(index));
                if (isStr) break; else logger.LogInformation("请选择正确的任务序号"); ;
            }
            return index;
        }


        private string GetDescriptionByEnum(Enum enumValue)
        {
            string value = enumValue.ToString();
            System.Reflection.FieldInfo field = enumValue.GetType().GetField(value);
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);    //获取描述属性
            if (objs.Length == 0)    //当描述属性没有时，直接返回名称
                return value;
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
            return descriptionAttribute.Description;
        }
    }
}

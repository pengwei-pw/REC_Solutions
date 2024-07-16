using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForPullCarLog.Enums
{
    public enum WorkEnum
    {
        [Description("规定时间拉取日志")]
        ConsoleForPullCarLogIndex = 0,
        [Description("Monkey测试监控日志脚本")]
        MonkeyMonitor = 1,
    }
}

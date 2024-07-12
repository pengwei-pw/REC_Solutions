using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForPullCarLog.Utils
{
    [Serializable]
    public class ConfigEnumUtil
    {
        //键值对方式存储所有配置信息
        public static Dictionary<String,String> allConfigDictionary = new Dictionary<String,String>();
        //使用枚举便利
    }
}

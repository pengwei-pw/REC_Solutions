using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleForPullCarLog.Utils
{
    public class AdbUtil
    {
        /// <summary>
        /// 同步执行adb命令
        /// </summary>
        /// <param name="arguments">命令参数(adb除外)</param>
        /// <param name="ouputFunc">命令执行正确返回</param>
        /// <param name="errOuputFunc">命令执行错误返回</param>
        /// <returns>执行返回的正确返回和错误返回 格式：正确返回\r\n错误返回</returns>
        public string RunADB(string arguments, out Func<string> outputFunc, out Func<string> errOutputFunc)
        {
            string cmd = "\\adb-1.0.41\\adb.exe";
            Process p = new Process();
            p.StartInfo.FileName = cmd;           //设定程序名  
            p.StartInfo.Arguments = arguments;    //设定程式执行參數  
            p.StartInfo.UseShellExecute = false;        //关闭Shell的使用  
            p.StartInfo.RedirectStandardInput = true;   //重定向标准输入  
            p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出  
            p.StartInfo.RedirectStandardError = true;   //重定向错误输出  
            p.StartInfo.CreateNoWindow = true;          //设置不显示窗口  
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8; // 指定输出流编码为 UTF-8
            p.StartInfo.StandardErrorEncoding = Encoding.UTF8; // 指定错误输出流编码为 UTF-8
            p.Start();

            string result = p.StandardOutput.ReadToEnd(); // 正确输出
            var errOuput = p.StandardError.ReadToEnd(); // 错误输出
            p.Close();

            outputFunc = () => result;
            errOutputFunc = () => errOuput;
            return result + "\r\n" + errOuput;
        }

        /// <summary>
        /// 异步执行adb命令
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="dataReceivedEventHandler">命令执行正确结果返回回调</param>
        /// <param name="errorDataReceivedEventHandler">命令执行错误结果返回回调</param>
        public void AsyncRunADB(string arguments, DataReceivedEventHandler dataReceivedEventHandler, DataReceivedEventHandler errorDataReceivedEventHandler)
        {
            string cmd = "\\adb-1.0.41\\adb.exe";
            Process p = new Process();
            p.StartInfo.FileName = cmd;           //设定程序名  
            p.StartInfo.Arguments = arguments;    //设定程式执行參數  
            p.StartInfo.UseShellExecute = false;        //关闭Shell的使用  
            p.StartInfo.RedirectStandardInput = true;   //重定向标准输入  
            p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出  
            p.StartInfo.RedirectStandardError = true;   //重定向错误输出  
            p.StartInfo.CreateNoWindow = true;          //设置不显示窗口  
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8; // 指定输出流编码为 UTF-8
            p.StartInfo.StandardErrorEncoding = Encoding.UTF8; // 指定错误输出流编码为 UTF-8
            p.OutputDataReceived += dataReceivedEventHandler;
            p.ErrorDataReceived += errorDataReceivedEventHandler;
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.Close();
        }
    }
}

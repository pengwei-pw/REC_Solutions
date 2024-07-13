using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UItimateELibrary.BusinessLogic;

namespace UltimateE
{
    public class App
    {
        private readonly IMessages messages;

        public App(IMessages messages)
        {
            this.messages = messages;
        }
        //UItimateE.exe -lang=es
        public void Run(String[] args) {
            string lang = "en";
            for (int i = 0; i < args.Length; i++) {
               if (args[i].ToLower().StartsWith("-lang-")) {
                   lang = args[i].Substring(6);
                    break;
               }   
            }
            string message = messages.Greeting(lang);
            Console.WriteLine(message);
        }
    }
}

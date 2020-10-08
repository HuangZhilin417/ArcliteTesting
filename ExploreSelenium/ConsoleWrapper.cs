using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium
{
    class ConsoleWrapper : IConsole
    {
        public string askForInput(string request)
        {
            Console.WriteLine("end with the last one");
            Console.Write(request);
            return Console.ReadLine();
        }
    }
}

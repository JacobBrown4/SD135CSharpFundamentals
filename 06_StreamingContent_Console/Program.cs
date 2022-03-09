using _06_StreamingContent_Console.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_StreamingContent_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI(new RealConsole());
            ui.Run();
        }
    }
}

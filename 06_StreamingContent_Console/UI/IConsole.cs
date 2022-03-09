using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_StreamingContent_Console.UI
{
    public interface IConsole
    {
        void WriteLine(string s);
        void WriteLine(object o);
        void WriteLine();
        void Write(string s);

        void Clear();
        string ReadLine();
        ConsoleKeyInfo ReadKey();
    }
}

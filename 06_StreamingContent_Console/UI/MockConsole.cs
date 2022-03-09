using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06_StreamingContent_Console.UI
{
    public class MockConsole : IConsole
    {
        private readonly Random _random;

        public MockConsole()
        {
            _random = new Random();
        }
        public void Clear()
        {
            Console.Clear();

            Console.BackgroundColor = RndColor();
        }

        public ConsoleColor RndColor()
        {
            int colorIndex = _random.Next(0, 16);
            return (ConsoleColor)colorIndex;
        }

        public ConsoleKeyInfo ReadKey()
        {
            Console.Beep(100, 1);
            return Console.ReadKey();
        }

        public string ReadLine()
        {
            string input = Console.ReadLine();
            Console.WriteLine("Umm...");
            Thread.Sleep(1000);
            Console.WriteLine("You sure...?");
            Thread.Sleep(1500);
            Console.WriteLine(".....okay");
            return input;
        }

        public void Write(string s)
        {
            foreach (char letter in s)
            {
                Console.ForegroundColor = RndColor();
                Console.Write(letter);
            }
        }

        public void WriteLine(string s)
        {
            // sArCaStIc
            Console.ForegroundColor = RndColor();
            bool capitalize = false;
            foreach (char letter in s)
            {
                if (capitalize)
                {
                    Console.Write(char.ToUpper(letter));
                    capitalize = false;
                }
                else
                {
                    Console.Write(char.ToLower(letter));
                    capitalize = true;
                }

            }
            Thread.Sleep(50);
            Console.Write("\n");

        }

        public void WriteLine(object o)
        {
            Console.ForegroundColor = RndColor();
            Console.WriteLine(o);
        }

        public void WriteLine()
        {
            Console.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv\n" +
                "\n" +
                "^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
        }

        //Black 0//DarkBlue 1//DarkGreen 2//DarkCyan 3//DarkRed 4//DarkMagenta 5//DarkYellow 6//Gray 7//DarkGray 8//Blue 9//Green 10//Cyan 11//Red 12//Magenta 13//Yellow 14//White 15
    }
}

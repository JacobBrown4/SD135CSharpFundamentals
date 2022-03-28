using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Async
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to make meal");
            Console.ReadKey();

            Kitchen kitchen = new Kitchen();

            Potato potato = new Potato();

            // Synchronous method, single threaded
            // Code cannot continue until finished
            potato.Peel();

            // Asynchronous, multi-threaded
            var fries = kitchen.FryPototoesAsync(potato);

            Hamburger hamburger = kitchen.AssembleHamburger();

            if (!fries.IsCompleted) // Able to check the status of the Task
            {
                Console.WriteLine("We gotta wait for the fries!");
            }
            // Result demands an answer and essentially treats it as Syncrhonous from that point on.
            kitchen.ServeMeal(fries.Result, hamburger);

            Console.ReadKey();
        }
    }
}

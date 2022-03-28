using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Async
{
    public class Kitchen
    {
        public void PrettyPrint(string process, int color)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            Console.WriteLine(process);
            Console.ResetColor();
        }

        public async Task<Fries> FryPototoesAsync(Potato potato)
        {
            if (potato.IsPeeled)
            {
                PrettyPrint("Dropping the fries in the fryer", 14);
                await Task.Delay(5000);
                PrettyPrint("Fries are still cooking", 14);
                await Task.Delay(5000);
                PrettyPrint("DING! Fries are done!", 14);
                return new Fries(potato);
            }
            else
            {
                Console.WriteLine("This potato needs to be peeled first");
                return null;
            }
        }

        public Hamburger AssembleHamburger()
        {
            var time = 2000;
            PrettyPrint("Assembling the hamburger", 13);
            PrettyPrint("Setting the bun down", 4);
            Task.Delay(time).Wait();
            PrettyPrint("Placing the patty delicately", 12);
            Task.Delay(time).Wait();
            PrettyPrint("Place the cheese", 6);
            Task.Delay(time).Wait();
            PrettyPrint("Grab some lettuce", 10);
            Task.Delay(time).Wait();
            PrettyPrint("Throw down some pickles", 2);
            Task.Delay(time).Wait();
            PrettyPrint("Spray some Ketchup and Mustard", 12);
            Task.Delay(time).Wait();
            PrettyPrint("Slap the top bun", 4);
            PrettyPrint("Congrats, Burger assembled", 13);
            return new Hamburger();
        }

        public bool ServeMeal(Fries fries, Hamburger burger)
        {
            if(fries == null)
            {
                Console.WriteLine("The fries weren't cooked");
                return false;
            }
            Console.WriteLine("You put the fries with the burger. Meal is ready!");
            return true;
        }
    }
}

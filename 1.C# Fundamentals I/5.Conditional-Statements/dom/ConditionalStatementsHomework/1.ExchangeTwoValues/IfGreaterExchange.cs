//Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ExchangeTwoValues
{
    class IfGreaterExchange
    {
        static void Main(string[] args)
        {
            string input;
            int firstVar;
            int secondVar;

            do
            {
                Console.Write("First variable=");
                input = Console.ReadLine();
            } while (!int.TryParse(input,out firstVar));

            do
            {
                Console.Write("Second variable=");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out secondVar));

            if(firstVar>secondVar)
            {
                int temp;
                temp = firstVar;
                firstVar = secondVar;
                secondVar = temp;
                Console.WriteLine("\nThe values were exchanged!\nFirst variable={0}\nSecond Variable={1}",firstVar,secondVar);
            }
            else
            {
                Console.WriteLine("\nThe values were NOT exchanged!");
            }

        }
    }
}

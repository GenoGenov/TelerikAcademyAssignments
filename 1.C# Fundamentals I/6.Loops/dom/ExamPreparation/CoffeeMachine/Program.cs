using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int five = int.Parse(Console.ReadLine());
            int ten = int.Parse(Console.ReadLine());
            int twenty = int.Parse(Console.ReadLine());
            int fifty = int.Parse(Console.ReadLine());
            int hundred = int.Parse(Console.ReadLine());

            decimal amountPuted = decimal.Parse(Console.ReadLine());
            decimal price = decimal.Parse(Console.ReadLine());

            decimal amount = (0.05m * five + 0.1m * ten + 0.2m * twenty + 0.5m * fifty + 1.0m * hundred);
            if (amountPuted >= price && amount >= (amountPuted - price))
            {

                Console.WriteLine("Yes {0:0.00}", amount - (amountPuted - price));
            }

            if (amountPuted >= price && amount < (amountPuted - price))
            {
                Console.WriteLine("No {0:0.00}", ((amountPuted - price) - amount));
            }

            if (amountPuted < price)
            {
                Console.WriteLine("More {0:0.00}",(price-amountPuted));
            }

            
        }
    }
}

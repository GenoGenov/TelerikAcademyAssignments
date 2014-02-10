//Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2.SignOfTheProduct
{
    class ShowSign
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string input;
            double firstVar;
            double secondVar;
            double thirdVar;

            do
            {
                Console.Write("First variable=");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out firstVar));

            do
            {
                Console.Write("Second variable=");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out secondVar));

            do
            {
                Console.Write("Third variable=");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out thirdVar));

           int minusCount = 0;

            if (firstVar < 0)
            {
                minusCount++;
            }
            if (secondVar < 0)
            {
                minusCount++;
            }
            if (thirdVar < 0)
            {
                minusCount++;
            }
            if (minusCount % 2 == 0)
            {
                Console.WriteLine("The sign is \"+\".");
            }
            else
            {
                Console.WriteLine("The sign is \"-\".");
            }
        }
    }
}

//Write a program that finds the biggest of three integers using nested if statements.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TheBiggestOfThreeIntegers
{
    class FindTheBiggestNumber
    {
        static void Main(string[] args)
        {
            string input;
            int firstVar;
            int secondVar;
            int thirdVar;
            int? biggest = null;

            do
            {
                Console.Write("First variable=");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out firstVar));

            do
            {
                Console.Write("Second variable=");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out secondVar));

            do
            {
                Console.Write("Third variable=");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out thirdVar));

            if (firstVar > secondVar)
            {
                if (firstVar > thirdVar)
                {
                    biggest = firstVar;
                }
                else
                {
                    biggest = thirdVar;
                }
            }
            else if (secondVar > thirdVar)
            {
                biggest = secondVar;
            }
            else
            {
                biggest = thirdVar;
            }
            Console.WriteLine("The biggest is {0}.",biggest);
        }
    }
}

//Write a method GetMax() with two parameters that returns the bigger of two integers. Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BiggestInteger
{
    class GetMaxInteger
    {
        static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }
        static void Main(string[] args)
        {
            string input;
            int a, b, c;
            do
            {
                Console.Write("First integer:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out a));

            do
            {
                Console.Write("Second integer:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out b));

            do
            {
                Console.Write("Third integer:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out c));

            Console.WriteLine("The biggest integer of them is {0}",GetMax(a, GetMax(b, c))); 
        }
    }
}

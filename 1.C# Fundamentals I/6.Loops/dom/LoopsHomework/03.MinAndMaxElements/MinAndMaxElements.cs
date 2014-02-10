//Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MinAndMaxElements
{
    class MinAndMaxElements
    {
        static void Main(string[] args)
        {
            string input;
            int N;
            int MinElement = 0;
            int MaxElement = 0;
            int var;
            do
            {
                Console.Write("How many numbers would you like to input:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out N));
            for (int i = 0; i < N; i++)           //instead of using an array,we can just compare every value that the user inputs to the current min/max value.
            {
                do
                {
                    Console.Write("Number[{0}] = ", i+1);
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out var));

                if (var <= MinElement)
                {
                    MinElement = var;
                }
                if (var >= MaxElement)
                {
                    MaxElement = var;
                }
            }
            Console.WriteLine("Max element:{0}\nMin element:{1}",MaxElement,MinElement);
        }
    }
}

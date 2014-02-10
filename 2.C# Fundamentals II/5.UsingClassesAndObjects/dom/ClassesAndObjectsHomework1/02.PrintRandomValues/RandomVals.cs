//Write a program that generates and prints to the console 10 random values in the range [100, 200].

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PrintRandomValues
{
    class RandomVals
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Random values in the interval [100,200]:");
            Console.WriteLine(string.Join(", ",RandomGenerator.Generate(100,200)));
        }
    }
}

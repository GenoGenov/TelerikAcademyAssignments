//Write a program that reads a string, reverses it and prints the result at the console.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StringReverse
{
    class Reverse
    {
        static void Main(string[] args)
        {
            Console.Write("String:");
            string input = Console.ReadLine();
            input = string.Join("",input.ToCharArray().Reverse());
            Console.WriteLine(input);
        }
    }
}

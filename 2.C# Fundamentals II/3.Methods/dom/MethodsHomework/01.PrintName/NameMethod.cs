//Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”). Write a program to test this method.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PrintName
{
    class NameMethod
    {
        static void PrintName()
        {
            Console.Write("Your Name: ");
            string str = Console.ReadLine();
            Console.WriteLine("Hello, {0}", str);
        }
        static void Main(string[] args)
        {
            PrintName();
        }
    }
}

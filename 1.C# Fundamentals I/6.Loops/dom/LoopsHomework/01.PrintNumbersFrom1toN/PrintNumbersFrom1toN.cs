//Write a program that prints all the numbers from 1 to N.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PrintNumbersFrom1toN
{
    class PrintNumbersFrom1toN
    {
        static void Main(string[] args)
        {
            string input;
            int n;
            do
            {
                Console.Write("From 1 to which number would you like this program to print(whole number!):");
                input=Console.ReadLine();
            } while (!int.TryParse(input,out n));
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}

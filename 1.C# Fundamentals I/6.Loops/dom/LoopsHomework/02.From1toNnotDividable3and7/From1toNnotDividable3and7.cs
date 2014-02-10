//Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.From1toNnotDividable3and7
{
    class From1toNnotDividable3and7
    {
        static void Main(string[] args)
        {
            string input;
            int n;
            do
            {
                Console.Write("From 1 to which number would you like this program to print(whole number!):");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out n));
            for (int i = 1; i <= n; i++)
            {
                if (i % 21 != 0) //Numbers that are not divisible by 3 and by 7 at the same time is equivalent to numbers that are not divisible by 21(3*7)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}

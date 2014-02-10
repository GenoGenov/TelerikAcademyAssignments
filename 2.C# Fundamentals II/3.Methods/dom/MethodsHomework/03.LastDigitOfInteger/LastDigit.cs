//Write a method that returns the last digit of given integer as an English word.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LastDigitOfInteger
{
    class LastDigit
    {
        static string GetLastDigit(int a)
        {
            int digit = a % 10;
            switch (digit)
            {
                case 0: return "Zero";
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
                default: return "Unknown Error!";
            }
        }
        static void Main(string[] args)
        {
            string input;
            int a;
            do
            {
                Console.Write("Integer:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out a));

            Console.WriteLine("The last digit is {0}",GetLastDigit(a));
        }
    }
}

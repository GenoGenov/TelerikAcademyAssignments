//Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.IsLeapYear
{
    class LeapYear
    {
        static void Main(string[] args)
        {
            DateTime date = new DateTime();
            uint year;
            string input;
            do
            {
                Console.Write("Year to check: ");
                input = Console.ReadLine();
            } while (!uint.TryParse(input, out year));

            date = date.AddYears((int)year - 1);
            Console.WriteLine("{0:yyyy} is leap year : {1}", date, DateTime.IsLeapYear(date.Year));
        }
    }
}

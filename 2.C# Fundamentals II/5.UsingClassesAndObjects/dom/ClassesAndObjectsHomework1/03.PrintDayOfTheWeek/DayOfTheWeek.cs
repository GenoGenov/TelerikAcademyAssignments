//Write a program that prints to the console which day of the week is today. Use System.DateTime.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PrintDayOfTheWeek
{
    class DayOfTheWeek
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.Now;
            Console.WriteLine("Today is {0}", date.DayOfWeek);
        }
    }
}

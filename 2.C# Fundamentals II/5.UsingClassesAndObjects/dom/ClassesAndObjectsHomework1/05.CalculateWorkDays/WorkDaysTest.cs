//Write a method that calculates the number of workdays between today and given date, passed as parameter. Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CalculateWorkDays
{
    class WorkDaysTest
    {
        static void Main(string[] args)
        {
            WorkDays w;
            Console.Write("Year:");
            string syear=Console.ReadLine();
            Console.Write("Month:");
            string smonth=Console.ReadLine();
            Console.Write("Day:");
            string sday=Console.ReadLine();

            uint year = 0;
            uint month = 0;
            uint day = 0;
            try
            {
                year = uint.Parse(syear);
                month = uint.Parse(smonth);
                day = uint.Parse(sday);
                w = new WorkDays(new DateTime((int)year, (int)month, (int)day));
                w.GetWorkDays();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid input! The date must not have passed!");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Input!");
            }
        }
    }
}

//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. 

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _16.DaysCount
{
    class DateTimeDays
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            DateTime first;
            DateTime second;

            Console.Write("Enter first date: ");
            string fDate=Console.ReadLine();

            string[] dateComponents1 = fDate.Split('.');
            dateComponents1[0] = dateComponents1[0].PadLeft(2, '0');
            dateComponents1[1] = dateComponents1[1].PadLeft(2, '0');
            dateComponents1[2] = "1000";
            fDate = string.Join(".", dateComponents1.Reverse());

            Console.Write("Enter second date: ");
            string sDate=Console.ReadLine();

            string[] dateComponents2 = sDate.Split('.');
            dateComponents2[0] = dateComponents2[0].PadLeft(2, '0');
            dateComponents2[1] = dateComponents2[1].PadLeft(2, '0');
            dateComponents2[2] = "1000";
            sDate = string.Join(".", dateComponents2.Reverse());

            string format = "yyyy.MM.dd";

            first = DateTime.ParseExact(fDate, format,CultureInfo.InvariantCulture);
            second = DateTime.ParseExact(sDate, format, CultureInfo.InvariantCulture);



            int difference = Math.Abs(first.Subtract(second).Days);

            Console.WriteLine("Distance: {0} days",difference);
        }
    }
}

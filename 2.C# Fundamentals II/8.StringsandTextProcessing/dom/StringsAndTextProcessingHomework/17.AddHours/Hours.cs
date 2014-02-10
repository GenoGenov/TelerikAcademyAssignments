//Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.AddHours
{
    class Hours
    {
        static void Main(string[] args)
        {
            DateTime first;
            DateTime second;

            Console.Write("Enter first date: ");
            string fDate = Console.ReadLine();

            string[] dateComponents1 = fDate.Split('.',' ');

            fDate = string.Join(".", dateComponents1[2],dateComponents1[1],dateComponents1[0]);
            fDate = fDate + " " + dateComponents1[3];

            string format = "yyyy.MM.dd HH:mm:ss";

            first = DateTime.ParseExact(fDate, format, CultureInfo.InvariantCulture);

            first = first.AddHours(6);
            first = first.AddMinutes(30);

            string[] output = first.ToString().Split(' ');

            string day=string.Empty;

            switch (first.DayOfWeek)
            {
                case DayOfWeek.Friday: day = "Петък";
                    break;
                case DayOfWeek.Monday: day = "Понеделник";
                    break;
                case DayOfWeek.Saturday: day = "Събота";
                    break;
                case DayOfWeek.Sunday: day = "Неделя";
                    break;
                case DayOfWeek.Thursday: day = "Сряда";
                    break;
                case DayOfWeek.Tuesday: day = "Вторник";
                    break;
                case DayOfWeek.Wednesday: day = "Четвъртък";
                    break;
                default:
                    break;
            }

            Console.WriteLine("Now is {0:d.MM.yyyy HH:mm:ss} , {1}", first,day);


        }
    }
}

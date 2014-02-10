//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. Display them in the standard date format for Canada.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.ExtractDates
{
    class CanadianDates
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String :");
            string text = Console.ReadLine();

            string[] words = text.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine();
            Console.WriteLine("dates:");
            DateTime d=new DateTime();
            for (int i = 0; i < words.Length; i++)
            {
                if (DateTime.TryParse(words[i],out d))
                {
                    CultureInfo c = new CultureInfo("en-CA");
                    string date = d.ToString(c);
                    Console.WriteLine(date);
                }
            }

        }
    }
}

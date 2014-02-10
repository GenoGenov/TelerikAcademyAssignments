//Write a program that reads two arrays from the console and compares them element by element.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02.CompareTwoArrays
{
    class ArraysCompare
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            List<decimal> firstList = new List<decimal>();
            List<decimal> secondList = new List<decimal>();

            Console.Write("Length of the first Array:");
            int l1 = int.Parse(Console.ReadLine());

            Console.Write("Length of the second Array:");
            int l2 = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 0; i < l1; i++)
            {
                Console.Write("Element {0} of the first array:",i);
                firstList.Add(decimal.Parse(Console.ReadLine()));
            }

            Console.WriteLine();

            for (int i = 0; i < l2; i++)
            {
                Console.Write("Element {0} of the second array:",i);
                secondList.Add(decimal.Parse(Console.ReadLine()));
            }

            Console.WriteLine();

            for (int i = 0; i < Math.Min(l1,l2); i++)
            {
                if (firstList.ElementAt(i) == secondList.ElementAt(i))
                {
                    Console.WriteLine("Elements [{0}] - Equal",i);
                }
                else
                {
                    Console.WriteLine(firstList.ElementAt(i) > secondList.ElementAt(i) ? "Elements [{0}] - First Is bigger" : "Elements [{0}] - Second is bigger",i);
                }
            }

        

        }
    }
}

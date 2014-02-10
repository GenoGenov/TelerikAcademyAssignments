//Sort 3 real values in descending order using nested if statements.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace _4.SortInDescendingOrder
{
    class DescendSort
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string input;
            double firstVar;
            double secondVar;
            double thirdVar;
            double? biggest=null;
            double? second=null;
            double? third=null;
            do
            {
                Console.Write("First variable=");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out firstVar));

            do
            {
                Console.Write("Second variable=");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out secondVar));

            do
            {
                Console.Write("Third variable=");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out thirdVar));

            if (firstVar > secondVar)
            {
                if (firstVar > thirdVar)
                {
                    biggest = firstVar;
                    if (secondVar > thirdVar)
                    {
                        second = secondVar;
                        third = thirdVar;
                    }
                    else
                    {
                        second = thirdVar;
                        third = secondVar;
                    }
                }
                else
                {
                    biggest = thirdVar;
                    second = firstVar;
                    third = secondVar;
                }
            }
            else if (secondVar > thirdVar)
            {
                biggest = secondVar;
                if (firstVar > thirdVar)
                {
                    second = firstVar;
                    third = thirdVar;
                }
                else
                {
                    second = thirdVar;
                    third = firstVar;
                }
            }
            else
            {
                biggest = thirdVar;
                second = secondVar;
                third = firstVar;
            }
            Console.WriteLine("Biggest: {0}\nSecond: {1}\nThird: {2}",biggest,second,third);
        }
    }
}

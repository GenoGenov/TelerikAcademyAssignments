//Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. If an invalid number or non-number text is entered, the method should throw an exception. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.NumbersInRange
{
    class Range
    {
        public static int NumsInRange(int start, int end)
        {
            Console.Write("Enter a number in the range {0}< x <{1} : ",start,end);
            string input = Console.ReadLine();

            try
            {
                int num = int.Parse(input);
                if (num<=start || num>=end)
                {
                    throw new FormatException();
                }
                return num;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number");
                
                return start;
            }
        }
        static void Main(string[] args)
        {
            int a = NumsInRange(1, 100);
            for (int i = 0; i < 9; i++)
            {
                a = NumsInRange(a, 100);
            }
        }
    }
}

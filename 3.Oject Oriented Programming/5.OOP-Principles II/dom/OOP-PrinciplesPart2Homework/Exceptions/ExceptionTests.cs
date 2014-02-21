using System;
using System.Linq;

namespace Exceptions
{
    public class ExceptionTests
    {
        private static void Main(string[] args)
        {
            Console.Write("Number in the range [1..100]:");
            int num = int.Parse(Console.ReadLine());
            if (num > 100 || num < 1)
            {
                throw new InvalidRangeException<int>(1,100);
            }

            Console.WriteLine("Date in the range [1.1.1980 … 31.12.2013]:");
            DateTime d = DateTime.Parse(Console.ReadLine());
            if (d < new DateTime(1980,1,1) || d > new DateTime(2013,12,31))
            {
                throw new InvalidRangeException<DateTime>(new DateTime(1980,1,1), new DateTime(2013,12,31));
            }
        }
    }
}
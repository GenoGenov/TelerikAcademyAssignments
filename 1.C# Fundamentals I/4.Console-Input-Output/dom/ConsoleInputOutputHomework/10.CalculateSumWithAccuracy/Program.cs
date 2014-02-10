using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _10.CalculateSumWithAccuracy
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            double sum = 1.0;
            double numerator = -1.0;
            int i = 2;

            do
            {
                numerator = -numerator;
                sum += numerator / i;
                i++;
            } while (i <= 10000);
    
            Console.WriteLine("The sum is {0:0.000}",sum);

        }
    }
}

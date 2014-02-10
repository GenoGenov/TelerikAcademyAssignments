using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _8.TrapezoidArea
{
    class AreaCalc
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string input1;
            string input2;
            string input3;
            decimal a;
            decimal b;
            decimal h;
            do
            {
                Console.Write("a:");
                input1 = Console.ReadLine();
               
                
            } while (!decimal.TryParse(input1, out a));

            do
            {
                Console.Write("b:");
                input2 = Console.ReadLine();


            } while (!decimal.TryParse(input2, out b));

            do
            {
                Console.Write("h:");
                input3 = Console.ReadLine();


            } while (!decimal.TryParse(input3, out h));

            decimal area = ((a + b) * h) / 2;
            Console.WriteLine("Area: {0}",area);
        }
    }
}

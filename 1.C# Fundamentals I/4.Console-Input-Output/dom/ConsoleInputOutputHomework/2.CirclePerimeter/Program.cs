using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2.CirclePerimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            decimal radius;
            string input;
            
            do
            {
                Console.Write("Radius:");
                input = Console.ReadLine();   
            } while (!decimal.TryParse(input,out radius));

            decimal C=2*(decimal)Math.PI*radius;
            decimal A = (decimal)Math.PI * radius * radius;

            Console.WriteLine("Perimeter = {0} or just {1}*PI\nArea = {2} or just {3}*PI",C,2*radius,A,radius*radius);

        }
    }
}

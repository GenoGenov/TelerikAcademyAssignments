using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _6.QuadraticEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string input;
            double a;
            double b;
            double c;

            do
            {
                Console.Write("a=");
                input = Console.ReadLine();
            } while (!double.TryParse(input,out a));

            do
            {
                Console.Write("b=");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out b));

            do
            {
                Console.Write("c=");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out c));

            double D = b * b - 4 * a * c;
            double root1 = (-b + Math.Sqrt(D)) / 2.0 * a;
            double root2 = (-b - Math.Sqrt(D)) / 2.0 * a;

            Console.WriteLine("First root: {0}\nSecond root: {1}",root1,root2);
        }
    }
}

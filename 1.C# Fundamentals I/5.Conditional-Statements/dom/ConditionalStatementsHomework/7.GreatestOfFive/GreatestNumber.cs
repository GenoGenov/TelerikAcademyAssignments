//Write a program that finds the greatest of given 5 variables.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _7.GreatestOfFive
{
    class GreatestNumber
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string input;        
            double[] vars=new double[5];

            do
            {
                Console.Write("First variable=");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out vars[0]));

            do
            {
                Console.Write("Second variable=");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out vars[1]));

            do
            {
                Console.Write("Third variable=");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out vars[2]));

            do
            {
                Console.Write("Fourth variable=");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out vars[3]));

            do
            {
                Console.Write("Fifth variable=");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out vars[4]));

            Console.WriteLine("The greatest number is {0}.",vars.Max());
        }
    }
}

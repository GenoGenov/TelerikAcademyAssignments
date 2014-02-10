//Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X^2 + … + N!/X^N
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06.CalculateSumAccordingToFormula
{
    class CalculateSum
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string input;
            int N;
            int X;
            decimal S = 1;
            long Nfact = 1;
            long Xpowered;

            Console.WriteLine("This Program calculates the sum S = 1 + 1!/X + 2!/X^2 + ... + N!/X^N");

            do
            {
                Console.Write("N = ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out N));

            do
            {
                Console.Write("X = ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out X));

            for (int i = 1; i <= N; i++)
            {
                Nfact = Nfact * i;
                Xpowered = (long)Math.Pow(X, i);
                decimal div = (decimal)Nfact / (decimal)Xpowered;
                S += div;
            }

            Console.WriteLine("S = {0:0.000000000000000}",S);
        }
    }
}

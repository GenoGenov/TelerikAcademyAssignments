//Write a program to calculate the Nth Catalan number by given N.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _10.NthCatalanNumber
{
    class NthCatalanNumber
    {
        public static BigInteger factorial(uint x)
        {
            BigInteger result = x;
            if (x > 1)
            {
                result = x * factorial(x - 1);
            }
            return result;
        }
        static void Main(string[] args)
        {
            uint n;
            string input;
            BigInteger nFact = 1;
            BigInteger nFactTimes2 = 1;
            BigInteger nFactPlus1 = 1;

            Console.WriteLine("This program calculates the Nth catalan number for given number \"N\".");

            do
            {
                Console.Write("N = ");
                input = Console.ReadLine();
            } while (!uint.TryParse(input, out n));

            nFact = factorial(n);
            nFactTimes2 = factorial(2 * n);
            nFactPlus1 = factorial(n + 1);

            BigInteger R = nFactTimes2 / (nFactPlus1 * nFact);

            Console.WriteLine("{0}th Catalan number = {1}",n,R);

        }
    }
}

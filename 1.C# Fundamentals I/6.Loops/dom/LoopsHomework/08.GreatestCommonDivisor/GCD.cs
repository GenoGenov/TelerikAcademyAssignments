//Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet).
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _08.GreatestCommonDivisor
{
    class GCD
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string input;
            decimal FirstNum;
            decimal SecondNum;
            decimal A;
            decimal B;
            decimal i;
            decimal q;

            Console.WriteLine("This program calculates the greatest common divisor(GSD) of given two numbers A,B");

            do
            {
                Console.Write("A = ");
                input = Console.ReadLine();
            } while (!decimal.TryParse(input, out FirstNum));

            do
            {
                Console.Write("B = ");
                input = Console.ReadLine();
            } while (!decimal.TryParse(input, out SecondNum));

            A = (decimal)Math.Max(FirstNum, SecondNum);
            B = (decimal)Math.Min(FirstNum, SecondNum);
            do
            {
                i = 1.0M;
                q = 1.0M;
                while ((A - B * i) > B)
                {
                    i++;
                }

                A = A - B * i;

                while ((B - A * q) > A)
                {
                    q++;
                }

                B = B - A * q;
               
            } while (A>0 && B>0);

            decimal result = (decimal)Math.Max(A, B);

            Console.WriteLine("The greatest common dividor is {0:0.0} .",result);
            
           
        }
    }
}

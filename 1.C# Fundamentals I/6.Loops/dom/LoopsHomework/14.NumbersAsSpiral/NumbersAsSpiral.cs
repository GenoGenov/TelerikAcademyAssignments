//* Write a program that reads a positive integer number N (N < 20) from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.NumbersAsSpiral
{
    class NumbersAsSpiral
    {
        static void Main(string[] args)
        {
            int n;
            string input;
            int value = 1;
            int j;
            int g;

            Console.WriteLine();
            do
            {
                Console.Write("N = ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out n) || n>=20);

            int[,] spiral = new int[n,n];

            for (int i = 0; i <= n/2-1; i++)
            {
                for (j = i; j < n-i; j++)
                {
                    spiral[i, j] = value++;
                }
                for (int k = i+1; k <j ; k++)
                {
                    spiral[k, j-1] = value++;
                }
                for (g = j-1; g > i; g--)
                {
                    spiral[j-1, g-1] = value++;
                }
                for (int t = j-2; t >=i+1 ; t--)
                {
                    spiral[t, g] = value++;
                }
            }
            if (n % 2 != 0)
            {
                spiral[n / 2, n / 2] = value++;
            }

            for (int h = 0; h < n; h++)
            {
                for (int l = 0; l < n; l++)
                {
                    Console.Write("{0,4}",spiral[h,l]);
                }
                Console.WriteLine();
            }
        
        }
    }
}

//Write a program to calculate n! for each n in the range [1..100]. Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _10.Nfactorial
{
    class Factorial
    {
        static BigInteger NFact(int n)
        {
            if (n > 1)
            {
                return n * NFact(n - 1);
            }
            else
            {
                return 1;
            }
        }
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(NFact(i));
            }
        }
    }
}

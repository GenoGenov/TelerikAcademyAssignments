using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _9.Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] Fibonacci;
            Fibonacci = new BigInteger[100];
            Fibonacci[0] = 0;
            Fibonacci[1] = 1;

            for (int i = 2; i < Fibonacci.Length; i++)
            {
                Fibonacci[i] = Fibonacci[i - 1] + Fibonacci[i - 2];
            }

            for (int i = 0; i < Fibonacci.Length; i++)
            {
                Console.WriteLine(Fibonacci[i]);
            }

        }
    }
}

//Write a program that reads a number N and calculates the sum of the first N members of the sequence of Fibonacci:
//0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377,...
//Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _07.FirstNfromFibonacci
{
    class FirstNfromFibonacci
    {
        static void Main(string[] args)
        {
            int N;
            string input;
            BigInteger S = 0;
            List<BigInteger> sequence=new List<BigInteger>();
            sequence.Add(0);
            sequence.Add(1);
            sequence.Add(1);

            Console.WriteLine("This program calculates the sum of the first N members of the sequence of Fibonacci");

            do
            {
                Console.Write("N = ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out N));

            for (int i = 3; i < N; i++)
            {

                    sequence.Add(sequence.ElementAt(i-1)+sequence.ElementAt(i-2));

            }

            for (int i = 0; i < N; i++)
            {
                S += sequence.ElementAt(i);
            }
            Console.WriteLine("S = {0}",S);
        }
    }
}

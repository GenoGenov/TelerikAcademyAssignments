//Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Combinations
{
    class Combinations
    {
        static void Main(string[] args)
        {
            string input;
            uint N;
            uint K;
            ulong Nfact = 1;
            ulong Kfact = 1;
            ulong KNfact = 1;
            Console.WriteLine("This Program calculates N!*K!/(K-N)! (1<N<K) .");
            do
            {
                Console.Write("N = ");
                input = Console.ReadLine();
            } while (!uint.TryParse(input, out N) || N <= 1);

            do
            {
                Console.Write("K = ");
                input = Console.ReadLine();
            } while (!uint.TryParse(input, out K) || K <= N);

            for (int i = 2; i <= N; i++)
            {
                Nfact = Nfact * (ulong)i;
            }

            for (int j = 2; j <= K; j++)
            {
                Kfact = Kfact * (ulong)j;
            }

            for (int h = 2; h <= (K-N); h++)
            {
                KNfact = KNfact * (ulong)h;
            }

            decimal solution = Nfact * Kfact/KNfact;
            Console.WriteLine("{0}!*{1}!/{2}! = {3}", N, K, KNfact,solution);
        }
    }
}

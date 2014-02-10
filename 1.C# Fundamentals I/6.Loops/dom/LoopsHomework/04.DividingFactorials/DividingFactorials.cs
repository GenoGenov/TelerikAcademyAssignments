//Write a program that calculates N!/K! for given N and K (1<K<N).
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.DividingFactorials
{
    class DividingFactorials
    {
        static void Main(string[] args)
        {
            string input;
            uint N;
            uint K;
            ulong Nfact = 1;
            ulong Kfact = 1;
            Console.WriteLine("This Program calculates N!/K! (1<K<N) .");
            do
            {
                Console.Write("K = ");
                input = Console.ReadLine();
            } while (!uint.TryParse(input, out K) || K <= 1);

            do
            {
                Console.Write("N = ");
                input = Console.ReadLine();
            } while (!uint.TryParse(input, out N) || N <= K);

            for (int i = 2; i <= N; i++)
            {
                Nfact =Nfact*(ulong)i;
            }

            for (int j = 2; j <= K; j++)
            {
                Kfact = Kfact * (ulong)j;
            }
            decimal solution = Nfact / Kfact;
            Console.WriteLine("{0}!/{1}! = {2}",N,K,solution);
        }
    }
}

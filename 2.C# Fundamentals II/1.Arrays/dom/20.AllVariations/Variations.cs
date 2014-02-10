//Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N].

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.AllVariations
{
    class Variations
    {
        private static int[] numbers;
        private static int n;
        private static int k;

        private static void Print(int i)
        {
            for (int j = 0; j <= i - 1; j++)
            {
                Console.Write("{0} ", numbers[j] + 1);
            }

            Console.WriteLine();
        }

        private static void Variate(int i)
        {
            if (i >= k)
            {
                Print(i);
                return;
            }

            for (int j = 0; j < n; j++)
            {
                numbers[i] = j;
                Variate(i + 1);
            }
        }

        static void Main()
        {
            string numberN;

            do
            {
                Console.Write("N: ");
                numberN = Console.ReadLine();
            }
            while (!Int32.TryParse(numberN, out n) || n <= 0);

            string numberK;

            do
            {
                Console.Write("Enter K: ");
                numberK = Console.ReadLine();
            }
            while (!Int32.TryParse(numberK, out k) || k <= 0 || k > n);

            numbers = new int[n];

            Console.WriteLine("V({0}, {1}):", n, k);

            Variate(0);
        }
    }
}

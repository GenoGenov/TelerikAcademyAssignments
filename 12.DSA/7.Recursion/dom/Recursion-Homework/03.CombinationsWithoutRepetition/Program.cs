using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CombinationsWithoutRepetition
{
    class Program
    {
        private static void GenerateCombinations(int[] array, int maxNumber, int start, int level)
        {
            if (level == array.Length)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            for (int i = start; i < maxNumber; i++)
            {
                array[level] = i + 1;
                GenerateCombinations(array, maxNumber, i + 1, level + 1);
            }
        }

        private static void Main()
        {
            int n = 5;
            int k = 3;
            int[] array = new int[k];
            GenerateCombinations(array, n, 0, 0);
        }
    }
}

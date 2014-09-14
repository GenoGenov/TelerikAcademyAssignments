using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AllPermitations
{
    class Program
    {
        //private static void GeneratePermutations(int[] array, bool[] used, int position)
        //{
        //    if (position == array.Length)
        //    {
        //        Console.WriteLine(string.Join(" ", array));
        //        return;
        //    }

        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        if (!used[i])
        //        {
        //            used[i] = true;
        //            array[position] = i + 1;
        //            GeneratePermutations(array, used, position + 1);
        //            used[i] = false;
        //        }
        //    }
        //}

        private static void GeneratePermutations(int[] items, int position)
        {
            if (position == 0)
            {
                Console.WriteLine(string.Join(" ", items));
                return;
            }

            GeneratePermutations(items, position - 1);

            for (int i = 0; i < position; i++)
            {
                int temp = items[i];
                items[i] = items[position];
                items[position] = temp;

                GeneratePermutations(items, position - 1);

                temp = items[i];
                items[i] = items[position];
                items[position] = temp;
            }
        }

        private static void Main()
        {
            int n = 3;
            var array = new int[n];
            var used = new bool[n];

            //GeneratePermutations1(array, used, 0);

            var items = new int[n];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = i + 1;
            }

            GeneratePermutations(items, n - 1);
        }
    }
}

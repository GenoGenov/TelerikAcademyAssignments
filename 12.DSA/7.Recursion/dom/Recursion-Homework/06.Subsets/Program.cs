using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Subsets
{
    class Program
    {
        private static string[] items = new string[] { "a", "b", "c", "d" };

        private static void PrintSelectedItems(int[] indices)
        {
            List<string> selectedItems = new List<string>();

            foreach (int index in indices)
            {
                selectedItems.Add(items[index]);
            }

            Console.WriteLine("({0})", string.Join(" ", selectedItems));
        }

        private static void GenerateSubsets(int[] indices, int itemsCount, int start, int position)
        {
            if (position == indices.Length)
            {
                PrintSelectedItems(indices);
                return;
            }

            for (int i = start; i < itemsCount; i++)
            {
                indices[position] = i;
                GenerateSubsets(indices, itemsCount, i + 1, position + 1);
            }
        }

        private static void Main()
        {
            int k = 2;
            int[] indices = new int[k];
            GenerateSubsets(indices, items.Length, 0, 0);
        }
    }
}

namespace _01.SimulateNestedLoops
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void FillArray(int index, int[] result)
        {
            if (index == -1)
            {
                Console.WriteLine(string.Join(" ", result.Reverse()));
                return;
            }

            for (int i = 0; i < result.Length; i++)
            {
                result[index] = i + 1;
                FillArray(index - 1, result);
            }
        }

        private static void Main(string[] args)
        {
            SimulateNestedLoops(2);
        }

        private static void SimulateNestedLoops(int n)
        {
            FillArray(n - 1, new int[n]);
        }
    }
}
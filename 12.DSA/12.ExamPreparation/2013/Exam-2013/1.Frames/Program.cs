using System;
using System.Collections.Generic;

internal class CombinationGenerator
{
    private static Tuple<int, int>[] frames;

    private static SortedSet<string> result;

    private static int n;

    private static void GeneratePermutations<T>(T[] arr, int k)
    {
        if (k >= arr.Length)
        {
            var el = string.Join(" | ", arr);
            result.Add(el);
        }
        else
        {
            for (int i = k; i < arr.Length; i++)
            {
                Swap(ref arr[k], ref arr[i]);
                GeneratePermutations(arr, k + 1);
                var t = frames[k];
                frames[k] = new Tuple<int, int>(t.Item2, t.Item1);
                GeneratePermutations(arr, k + 1);
                frames[k] = t;
                Swap(ref arr[k], ref arr[i]);
            }
        }
    }

    private static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }

    private static void Main()
    {
        n = int.Parse(Console.ReadLine());
        frames = new Tuple<int, int>[n];
        for (int i = 0; i < n; i++)
        {
            var vals = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int x = int.Parse(vals[0]);
            int y = int.Parse(vals[1]);
            frames[i] = new Tuple<int, int>(x, y);
        }

        result = new SortedSet<string>();
        GeneratePermutations(frames, 0);

        Console.WriteLine(result.Count);

        foreach (var x in result)
        {
            Console.WriteLine(x);
        }
    }
}
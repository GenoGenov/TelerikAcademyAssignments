namespace _4.SortingAlgorithmsPerformance
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class CompareSortingExecPerformance
    {
        private const string Chars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789~`!@#$%^&*()-_=+[{]}\\|;:'\",<.>/?";

        private static readonly Random Rnd = new Random();

        private static string GetRandomString(int size)
        {
            char[] buffer = new char[size];
            int length = Chars.Length;

            for (int i = 0; i < size; i++)
            {
                buffer[i] = Chars[Rnd.Next(length)];
            }

            return new string(buffer);
        }

        private static int[] GetRandomIntArray(int length)
        {
            int[] value = new int[length];

            for (int i = 0; i < value.Length; i++)
            {
                value[i] = Rnd.Next(int.MinValue, int.MaxValue);
            }

            return value;
        }

        private static double[] GetRandomDoubleArray(int length)
        {
            double[] value = new double[length];

            for (int i = 0; i < value.Length; i++)
            {
                int sign = Rnd.Next(0, 2);
                if (sign == 0)
                {
                    value[i] = Rnd.NextDouble() * double.MaxValue;
                }
                else
                {
                    value[i] = Rnd.NextDouble() * double.MinValue;
                }
            }

            return value;
        }

        private static string[] GetRandomStringArray(int length, int stringMaxSize)
        {
            string[] value = new string[length];

            for (int i = 0; i < value.Length; i++)
            {
                value[i] = GetRandomString(Rnd.Next(1, stringMaxSize + 1));
            }

            return value;
        }

        private static void DisplaySortingExecutionTime<T>(T[] arr, Action<T[]> action, bool sort, string message, Comparison<T> comparer = null) where T : IComparable<T>
        {
            Console.WriteLine(message);
            T[] newArr = (T[])arr.Clone();
            if (sort)
            {
                Array.Sort(newArr, comparer);
            }

            Stopwatch watch = Stopwatch.StartNew();
            action(newArr);
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            Console.WriteLine();
        }

        private static void QuickSort<T>(T[] array) where T : IComparable<T>
        {
            SortingAlgorithms.Quicksort(array, 0, array.Length - 1);
        }

        private static void Main(string[] args)
        {
            int[] intArr = GetRandomIntArray(10000);
            double[] doubleArr = GetRandomDoubleArray(10000);
            string[] stringArr = GetRandomStringArray(10000, 50);

            Console.WriteLine("*****************************Unsorted Arrays Sorting****************************".ToUpper());
            Console.WriteLine();
            DisplaySortingExecutionTime(intArr, SortingAlgorithms.InsertionSort, false, "Insertion Sort for integers:");
            DisplaySortingExecutionTime(intArr, QuickSort, false, "Quick Sort for integers:");
            DisplaySortingExecutionTime(intArr, SortingAlgorithms.SelectionSort, false, "Selection Sort for integers:");
            Console.WriteLine();
            DisplaySortingExecutionTime(doubleArr, SortingAlgorithms.InsertionSort, false, "Insertion Sort for doubles:");
            DisplaySortingExecutionTime(doubleArr, QuickSort, false, "Quick Sort for doubles:");
            DisplaySortingExecutionTime(doubleArr, SortingAlgorithms.SelectionSort, false, "Selection Sort for doubles:");
            Console.WriteLine();
            DisplaySortingExecutionTime(stringArr, SortingAlgorithms.InsertionSort, false, "Insertion Sort for strings:");
            DisplaySortingExecutionTime(stringArr, QuickSort, false, "Quick Sort for strings:");
            DisplaySortingExecutionTime(stringArr, SortingAlgorithms.SelectionSort, false, "Selection Sort for strings:");
            Console.WriteLine();

            Console.WriteLine("**********************Sorted Ascending Arrays Sorting*************************".ToUpper());
            Console.WriteLine();
            DisplaySortingExecutionTime(intArr, SortingAlgorithms.InsertionSort, true, "Insertion Sort for integers:", (a, b) => a.CompareTo(b));
            DisplaySortingExecutionTime(intArr, QuickSort, true, "Quick Sort for integers:", (a, b) => a.CompareTo(b));
            DisplaySortingExecutionTime(intArr, SortingAlgorithms.SelectionSort, true, "Selection Sort for integers:", (a, b) => a.CompareTo(b));
            Console.WriteLine();
            DisplaySortingExecutionTime(doubleArr, SortingAlgorithms.InsertionSort, true, "Insertion Sort for doubles:", (a, b) => a.CompareTo(b));
            DisplaySortingExecutionTime(doubleArr, QuickSort, true, "Quick Sort for doubles:", (a, b) => a.CompareTo(b));
            DisplaySortingExecutionTime(doubleArr, SortingAlgorithms.SelectionSort, true, "Selection Sort for doubles:", (a, b) => a.CompareTo(b));
            Console.WriteLine();
            DisplaySortingExecutionTime(stringArr, SortingAlgorithms.InsertionSort, true, "Insertion Sort for strings:", (a, b) => a.CompareTo(b));
            DisplaySortingExecutionTime(stringArr, QuickSort, true, "Quick Sort for strings:", (a, b) => a.CompareTo(b));
            DisplaySortingExecutionTime(stringArr, SortingAlgorithms.SelectionSort, true, "Selection Sort for strings:", (a, b) => a.CompareTo(b));
            Console.WriteLine();

            Console.WriteLine("*****************************Sorted Descending Arrays Sorting************************".ToUpper());
            Console.WriteLine();
            DisplaySortingExecutionTime(intArr, SortingAlgorithms.InsertionSort, true, "Insertion Sort for integers:", (a, b) => b.CompareTo(a));
            DisplaySortingExecutionTime(intArr, QuickSort, true, "Quick Sort for integers:", (a, b) => a.CompareTo(b));
            DisplaySortingExecutionTime(intArr, SortingAlgorithms.SelectionSort, true, "Selection Sort for integers:", (a, b) => b.CompareTo(a));
            Console.WriteLine();
            DisplaySortingExecutionTime(doubleArr, SortingAlgorithms.InsertionSort, true, "Insertion Sort for doubles:", (a, b) => b.CompareTo(a));
            DisplaySortingExecutionTime(doubleArr, QuickSort, true, "Quick Sort for doubles:", (a, b) => a.CompareTo(b));
            DisplaySortingExecutionTime(doubleArr, SortingAlgorithms.SelectionSort, true, "Selection Sort for doubles:", (a, b) => b.CompareTo(a));
            Console.WriteLine();
            DisplaySortingExecutionTime(stringArr, SortingAlgorithms.InsertionSort, true, "Insertion Sort for strings:", (a, b) => b.CompareTo(a));
            DisplaySortingExecutionTime(stringArr, QuickSort, true, "Quick Sort for strings:", (a, b) => a.CompareTo(b));
            DisplaySortingExecutionTime(stringArr, SortingAlgorithms.SelectionSort, true, "Selection Sort for strings:", (a, b) => b.CompareTo(a));
            Console.WriteLine();
        }
    }
}
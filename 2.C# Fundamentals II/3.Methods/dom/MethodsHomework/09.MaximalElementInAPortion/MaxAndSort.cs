//Write a method that return the maximal element in a portion of array of integers starting at given index. Using it write another method that sorts an array in ascending / descending order.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.MaximalElementInAPortion
{
    class MaxAndSort
    {
        static int GetMax(int start, ICollection<int> arr)
        {
            int result = int.MinValue;
            for (int i = start; i < arr.Count; i++)
            {
                if (result < arr.ElementAt(i))
                {
                    result = arr.ElementAt(i);
                }
            }
            return result;
        }

        static void SortAscending(ref List<int> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                int index=arr.IndexOf(GetMax(i,arr));
                int swap = arr[i];
                arr[i] = arr[index];
                arr[index] = swap;
     
            }
            arr.Reverse();
        }

        static void SortDescending(ref List<int> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                int index = arr.IndexOf(GetMax(i, arr));
                int swap = arr[i];
                arr[i] = arr[index];
                arr[index] = swap;

            }
        }
        static void Main(string[] args)
        {
            int n;
            string input;
            do
            {
                Console.Write("Array Length(>2):");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out n) || n < 3);

            List<int> arr = new List<int>(n);
            for (int i = 0; i < n; i++)
            {
                int g;
                do
                {
                    Console.Write("Element at [{0}]:", i);
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out g));
                arr.Add(g);
            }
            SortAscending(ref arr);
            Console.WriteLine(string.Join(", ",arr));
            SortDescending(ref arr);
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}

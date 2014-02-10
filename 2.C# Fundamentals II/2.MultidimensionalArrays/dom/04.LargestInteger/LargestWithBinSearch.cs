//Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.LargestInteger
{
    class LargestWithBinSearch
    {
        static void Main(string[] args)
        {
            int n, k;
            string input;
            do
            {
                Console.Write("N = ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out n));

            do
            {
                Console.Write("K = ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out k));

            int[] arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Element at[{0}]:", i);
                    arr[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(arr);
            int index = Array.BinarySearch(arr, k);
            if (index >= 0)
            {
                Console.WriteLine("There is such element - {0}",arr[index]);
            }
            else
            {
                index = ~index - 1;
                if (index >= 0)
                {
                    Console.WriteLine("There is such element - {0}", arr[index]);

                }
                else
                {
                    Console.WriteLine("There is no such element");
                }
            }
        }
    }
}

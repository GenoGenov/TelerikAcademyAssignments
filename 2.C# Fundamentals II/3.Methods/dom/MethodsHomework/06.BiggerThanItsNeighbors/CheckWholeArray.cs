//Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BiggerThanItsNeighbors
{
    class CheckWholeArray
    {
        static int GetIndex(ICollection<int> arr)
        {
            for (int i = 1; i < arr.Count-1; i++)
            {
                if (arr.ElementAt(i) > arr.ElementAt(i - 1) && arr.ElementAt(i) > arr.ElementAt(i + 1))
                {
                    return i;
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int n;
            string input;
            do
            {
                Console.Write("Array Length(>2):");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out n) || n<3);

            //int[] arr = new int[n];
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
                //arr[i] = g;
            }
            if (GetIndex(arr) != -1)
            {
                Console.WriteLine("The index of the first element that is bigger than its neighbors is {0} .", GetIndex(arr));
            }
            else
            {
                Console.WriteLine("No such element exists");
            }
        }
    }
}

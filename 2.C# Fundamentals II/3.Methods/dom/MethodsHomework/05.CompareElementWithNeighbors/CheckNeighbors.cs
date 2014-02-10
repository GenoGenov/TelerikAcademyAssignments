//Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CompareElementWithNeighbors
{
    class CheckNeighbors
    {
        static bool IsBigger(ICollection<int> arr ,int position)
        {
            if (position <= 0 || position >= arr.Count-1)
            {
                throw new IndexOutOfRangeException("THE NUMBER AT SPECIFIED INDEX DOES NOT HAVE TWO NEIGHBORS OR INDEX IS OUT OF RANGE!");
            }
            return (arr.ElementAt(position) > arr.ElementAt(position - 1) && arr.ElementAt(position) > arr.ElementAt(position + 1));
        }
        static void Main(string[] args)
        {
            int n, number;
            string input;
            do
            {
                Console.Write("Array Length:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out n));

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

            do
            {
                Console.Write("Position to check:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out number));

            Console.WriteLine("The number is {0} bigger than its neighbors.",IsBigger(arr,number)? "":"NOT");
        }
    }
}

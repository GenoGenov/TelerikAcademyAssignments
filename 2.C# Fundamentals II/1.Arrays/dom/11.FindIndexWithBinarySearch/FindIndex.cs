//Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.FindIndexWithBinarySearch
{
    class FindIndex
    {
        static void Main(string[] args)
        {
            List<int> firstArr = new List<int>();
            int num = 1;
            int l1 = 0;
            
            Console.Write("Element {0} of the array(write some bad input to finish):", l1);
            l1++;
            while (int.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Element {0} of the array(write some bad input to finish):", l1);
                firstArr.Add(num);
                l1++;
            }

            Console.Write("Element:");
            int element = int.Parse(Console.ReadLine());

            firstArr.TrimExcess();
            firstArr.Sort();
            Console.WriteLine();
            Console.WriteLine();
            DateTime start = DateTime.Now;
            int index = firstArr.BinarySearch(element);
            DateTime stop = DateTime.Now;
            Console.WriteLine("The index of the element found with Binary Search: {0}",index);
            Console.WriteLine("It took {0} milliseconds",stop-start);
        }
    }
}

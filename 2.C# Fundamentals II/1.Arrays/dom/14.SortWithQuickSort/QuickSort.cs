//Write a program that sorts an array of strings using the quick sort algorithm

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.SortWithQuickSort
{
    class QuickSort
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

            firstArr.TrimExcess();
            Console.WriteLine();
            Console.WriteLine();

            SortIt(firstArr);
            Console.WriteLine("The sorted array:");
            Console.WriteLine(string.Join(", ", firstArr));
        }

        public static void SortIt(List<int> elements)
        {
            Quicksort(elements, 0, elements.Count - 1);
        }
        public static void Quicksort(List<int> elements, int left, int right)
        {
            int i = left, j = right;
            int pivot = elements[(left + right) / 2];
 
            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }
 
                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }
 
                if (i <= j)
                {
                    // Swap
                    int tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;
 
                    i++;
                    j--;
                }
            }
 
            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }
 
            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }

    }
}

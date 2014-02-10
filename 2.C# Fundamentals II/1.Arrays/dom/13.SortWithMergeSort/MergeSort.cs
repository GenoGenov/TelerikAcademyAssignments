//* Write a program that sorts an array of integers using the merge sort algorithm

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.SortWithMergeSort
{
    class MergeSort
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

            int[] sorted = MSort(firstArr.ToArray());

            Console.WriteLine("The sorted array:");
            Console.WriteLine(string.Join(", ",sorted));
        }

        public static int[] MSort(int[] a)
        {
            if (a.Length == 1)
                return a;
            int middle = a.Length / 2;
            int[] left = new int[middle];
            for (int i = 0; i < middle; i++)
            {
                left[i] = a[i];
            }
            int[] right = new int[a.Length - middle];
            for (int i = 0; i < a.Length - middle; i++)
            {
                right[i] = a[i + middle];
            }
            left = MSort(left);
            right = MSort(right);

            int leftptr = 0;
            int rightptr = 0;

            int[] sorted = new int[a.Length];
            for (int k = 0; k < a.Length; k++)
            {
                if (rightptr == right.Length || ((leftptr < left.Length) && (left[leftptr] <= right[rightptr])))
                {
                    sorted[k] = left[leftptr];
                    leftptr++;
                }
                else if (leftptr == left.Length || ((rightptr < right.Length) && (right[rightptr] <= left[leftptr])))
                {
                    sorted[k] = right[rightptr];
                    rightptr++;
                }
            }
            return sorted;
        }
    }
}

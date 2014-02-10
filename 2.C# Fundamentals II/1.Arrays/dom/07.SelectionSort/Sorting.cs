//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SelectionSort
{
    class Sorting
    {
        static void Main(string[] args)
        {
            int[] arr;
            int l1 = 0;
            int num;

            Console.Write("Number of elements:");
            l1 = int.Parse(Console.ReadLine());

            arr = new int[l1];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Element {0}:",i);
                arr[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < arr.Length-1; i++) //SelectionSort algorithm - find the smallest,move it at the first position
            {                                    //find the second smallest,move it to second position,etc..
                int min = i;                                 
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    int swap = arr[i];
                    arr[i] = arr[min];
                    arr[min] = swap;
                }
            }

            Console.WriteLine("Sorted:");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}

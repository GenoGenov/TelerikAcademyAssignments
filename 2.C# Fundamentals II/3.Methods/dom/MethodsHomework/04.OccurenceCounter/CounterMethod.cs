//Write a method that counts how many times given number appears in given array. Write a test program to check if the method is working correctly.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.OccurenceCounter
{
    class CounterMethod
    {
        //Works with both fixed size array and list.
        static int GetCount(ICollection<int> a,int num)
        {
            int count = 0;
            for (int i = 0; i < a.Count; i++)
            {
                if (a.ElementAt(i) == num)
                {
                    count++;
                }
            }

            return count;
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
                Console.Write("Element at [{0}]:",i);
                input = Console.ReadLine();
            } while (!int.TryParse(input, out g));
                arr.Add(g);
                //arr[i] = g;
            }

            do
            {
                Console.Write("Number to check:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out number));

            Console.WriteLine("The number occurs int the array {0} times.",GetCount(arr,number));
        }
    }
}

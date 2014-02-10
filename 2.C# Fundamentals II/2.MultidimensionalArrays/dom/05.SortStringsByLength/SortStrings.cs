//You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SortStringsByLength
{

    class SortStrings
    {
        public static void Print(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
        public static void SortStringsByLength(ref List<string> list)
        {
            list.Sort();
            list.Sort((x, y) => x.Length.CompareTo(y.Length));
        }
        static void Main(string[] args)
        {

             int n;
            string input;
            do
            {
                Console.Write("N = ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out n));

            List<string> arr = new List<string>();
            for (int i = 0; i < n; i++)
            {
                 Console.Write("Element at[{0}]:", i);
                 arr.Add(Console.ReadLine());
            }


            SortStringsByLength(ref arr);
            Print(arr);
        }
    }
}

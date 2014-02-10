//* Write a program that reads an array of integers and removes from it a minimal number of elements in such way that the remaining array is sorted in increasing order. Print the remaining sorted array. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.RemoveMinimalForProgression
{
    class RemMinimal
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
            List<int> secondArr = firstArr;
            for (int i = 0; i < secondArr.Count-1; i++)
            {
                int[] g = new int[firstArr.Count];
                secondArr.CopyTo(g,0);
                List<int> newl1 = g.ToList();
                List<int> newl2 = g.ToList();
                if (secondArr[i] > secondArr[i + 1])
                {

                    if (DelEl(newl1, i, new List<int>()).Count < DelEl(newl2, i + 1, new List<int>()).Count)
                    {
                        secondArr.RemoveAt(i);
                        i -= 1;
                    }
                    else
                    {
                        secondArr.RemoveAt(i + 1);
                        i -= 1;
                    }
                }
            }
            Console.WriteLine(string.Join(", ",secondArr));

        }

        public static List<int> DelEl(List<int> a,int index, List<int> l)
        {
            l.Add(a[index]);
            a.RemoveAt(index);
            for (int i = 0; i < a.Count-1; i++)
            {
                if (a[i] > a[i + 1])
                {
                   return DelEl(a, i + 1, l);
                }
            }
            return l;
        }

    }
}

//Write a program that finds the maximal sequence of equal elements in an array.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MaximalEqualSequence
{
    class MaximalSequence
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

            int max = 0;
            int element=0;
            int l = 0;
            for (int i = 0; i < firstArr.Count; i++)
            {
                int number = firstArr.ElementAt(i);
                int count=0;
                for (int j = i+1; j < firstArr.Count; j++)
                {
                    if (firstArr.ElementAt(j) == number && firstArr.ElementAt(j) == firstArr.ElementAt(j - 1))
                    {
                        count++;
                        element=firstArr.ElementAt(j);
                    }
                }
                if (count > max)
                {
                    max = count+1;
                    l=element;
                }
            }
            int[] newSet=new int[max];
            for (int i = 0; i < newSet.Length; i++)
			{
			 newSet[i]=l;
			}
            Console.WriteLine("The maximal count of equal elements of the array is {0} ->({1})",max,string.Join(", ",newSet));
        }
    }
}

//* Write a program that reads three integer numbers N, K and S and an array of N elements from the console. Find in the array a subset of K elements that have sum S or indicate about its absence.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.FixedSubsedFixedSum
{
    class SubsedSum
    {
        static void Main(string[] args)
        {
            Console.Write("K:");
            int K = int.Parse(Console.ReadLine());
            Console.Write("S:");
            int S = int.Parse(Console.ReadLine());
            Console.Write("N:");
            int N = int.Parse(Console.ReadLine());

            int[] nums = new int[N];
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write("Element[{0}]:",i);
                nums[i] = int.Parse(Console.ReadLine());
            }
         
            bool flag = false;
            for (int i = 0; i < nums.Length; i++)
            {
                int train = 0;
                int[] elements = new int[K];
                int g = 0;
                for (int j = i; j < K+i; j++)
                {
                    train += nums[j];
                    elements[g] = nums[j];
                    g++;
                }

                if (train == S)
                {
                    flag = true;
                    Console.WriteLine("Yes ({0})",string.Join(", ",elements));
                    break;
                }
            }

            if (!flag)
            {
                Console.WriteLine("No such subsequence exists");
            }
        }
    }
}

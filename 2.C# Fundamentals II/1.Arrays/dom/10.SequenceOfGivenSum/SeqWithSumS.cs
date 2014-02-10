//Write a program that finds in given array of integers a sequence of given sum S (if present). 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SequenceOfGivenSum
{
    class SeqWithSumS
    {
        static void Main(string[] args)
        {
            List<int> firstArr = new List<int>();
            int num = 1;
            int l1 = 0;
            Console.Write("Sum:");
            int S = int.Parse(Console.ReadLine());

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
            bool flag = false;
            int? startIndex=null;
            int? endIndex=null;
            int sum = 0;
            for (int i = 0; i < firstArr.Count; i++)
            {
                for (int j = i+1; j < firstArr.Count; j++)
                {
                    sum += firstArr[j];
                    if (firstArr[i] + sum > S)
                    {
                        break;
                    }
                    else if (firstArr[i] + sum==S)
                    {
                        flag = true;
                        startIndex=i;
                        endIndex=j;
                        goto Exit;
                    }
                }
                sum = 0;
            }
            Exit:
            if (flag)
            {
                int[] result = new int[(int)(endIndex - startIndex) + 1];
                int k = 0;
                for (int i = (int)startIndex; i <= endIndex; i++)
                {
                    result[k] = firstArr[i];
                    k++;
                }
                Console.WriteLine("({0})",string.Join(", ",result));
            }
            else
            {
                Console.WriteLine("No such subsequence exist!");
            }
            
        }
    }
}

//* We are given an array of integers and a number S. Write a program to find if there exists a subset of the elements of the array that has a sum S. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.SubsetOfGivenSum
{
    class Program
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
            int sum = 0;
            int index = 0;
            int[] set = new int[firstArr.Count];
            for (int i = 0; i < firstArr.Count; i++)
            {
                set = new int[firstArr.Count];
                index = 0;
                set[index] = firstArr[i];
                index++;
                for (int j = 0; j < firstArr.Count; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    sum += firstArr[j];
                    if (firstArr[i] + sum > S)
                    {
                        if (firstArr[i] + firstArr[j] <= S)
                        {
                            if (firstArr[i] + firstArr[j] == S)
                            {
                                flag = true;
                                set = new int[firstArr.Count];
                                index = 0;
                                set[index] = firstArr[i];
                                index++;
                                set[index] = firstArr[j];
                                index++;
                                goto Exit;
                            }
                            sum = firstArr[j];
                            set = new int[firstArr.Count];
                            index = 0;
                            set[index] = firstArr[i];
                            index++;
                            set[index] = firstArr[j];
                            index++;
                            continue;
                        }
                        sum -= firstArr[j];
                    }
                    else if (firstArr[i] + sum == S)
                    {
                        flag = true;
                        set[index] = firstArr[j];
                        index++;
                        goto Exit;
                    }
                    else if (firstArr[i] + sum < S)
                    {
                        set[index] = firstArr[j];
                        index++;
                    }
                }
                sum = 0;
            }
        Exit:
            if (flag)
            {
                
                Console.WriteLine("yes ({0})", string.Join(", ", set.Take(index)));
            }
            else
            {
                Console.WriteLine("No such subset exist!");
            }
        }
    }
}

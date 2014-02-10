//Write a program that reads two integer numbers N and K and an array of N elements from the console. Find in the array those K elements that have maximal sum.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MaximalSumOfKElements
{
    class MaxSum
    {
        static void Main(string[] args)
        {
            int N;
            int K;
            
            Console.Write("N:");
            N = int.Parse(Console.ReadLine());
            Console.Write("K:");
            K = int.Parse(Console.ReadLine());
            int[] values = new int[K];
            int[] arr = new int[N];

            for (int i = 0; i < N; i++)
            {
                Console.Write("Element {0}:",i);
                arr[i] = int.Parse(Console.ReadLine());
            }

            int result = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = i+1; j < N; j++)
                {
                    int[] temp = new int[K];
                    int c = 0;
                    int sum = arr[i] + arr[j];
                    temp[c] = arr[i];
                    c++;
                    temp[c] = arr[j];
                    c++;
                    for (int k = j+1; k < K+j-1; k++)
                    {
                        int d;
                        if (k >= N)
                        {
                           d = k - N;
                        }
                        else
                        {
                            d = k;
                        }

                        temp[c] = arr[d];
                        c++;
                        sum += arr[d];
                    }
                    if (sum > result)
                    {
                        result = sum;
                        values=temp.ToArray();
                    }
                    
                }
                
            }
            
            Console.WriteLine("Maximal sum:{0}->{1}", result, string.Join(", ", values));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] arr = new long[n][];
            bool[][] used = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                string[] digits = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                arr[i] = new long[digits.Length];
                used[i] = new bool[digits.Length];
                for (int j = 0; j < digits.Length; j++)
                {
                    arr[i][j] = int.Parse(digits[j]);
                    used[i][j] = false;
                }
            }

            

            bool flag = false;
            long temp = 0;
            long path = 0;
            long value = 0;
            for (int i = 0; i < arr[0].Length; i++)
            {
                if (arr[0][i] >= 0 && arr.GetLength(0)>1)
                {
                    used[0][i] = true;
                    int j = 1;
                    long k = arr[0][i];
                    path++;
                    while (arr[j][k]>=0 && used[j][k]==false)
                    {
                        used[j][k]=true;
                        flag = true;
                        path++;
                        k = arr[j][k];
                        j++;
                        if (j == arr.GetLength(0))
                        {
                            j = 0;
                        }
                    }
                    long num=arr[j][k];
                  
                    if (!flag)
                    {
                        if (i < arr[0].Length)
                            num = arr[0][i + 1];
                        else
                            num = arr[1][0];
                    }
                    else
                    {
                        path++;
                    }
                   temp=Math.Abs(num)+path;
                   if (used[j][k])
                   {
                       temp = -1;
                   }
                }
                else
                {
                    temp = Math.Abs(arr[0][i])+1;
                }
                if (temp > value)
                {
                    value = temp;
                }
                temp = 0;
                path = 0;
                for (int a1 = 0; a1 < used.GetLength(0); a1++)
                {
                    for (int a2 = 0; a2 < used[a1].Length; a2++)
                    {
                        used[a1][a2] = false;
                    }
                }
            }

            Console.WriteLine(value);
        }
    }
}

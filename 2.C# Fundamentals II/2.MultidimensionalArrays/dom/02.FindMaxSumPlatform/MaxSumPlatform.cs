//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.FindMaxSumPlatform
{
    class MaxSumPlatform
    {
        static void Main(string[] args)
        {
            int n, m;
            string input;
            do
            {
                Console.Write("N = ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out n) || n < 3);

            do
            {
                Console.Write("M = ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out m) || m < 3);
            int[,] arr = new int[n, m];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("Element at[{0}][{1}]:",i,j);
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int sum = int.MinValue;
            int col = 0;
            int row = 0;
            for (int i = 0; i < arr.GetLength(0)-2; i++)
            {
                for (int j = 0; j < arr.GetLength(1)-2; j++)
                {
                    int platform = 0;
                    for (int g = i; g < i+3; g++)
                    {
                        for (int k = j; k < j+3; k++)
                        {
                            platform += arr[g, k];
                        }
                    }

                    if (platform > sum)
                    {
                        sum = platform;
                        col = i;
                        row = j;
                    }
                }
            }
                for (int i = col; i < col + 3; i++)
                {
                    for (int j = row; j < row + 3; j++)
                    {
                        Console.Write(arr[i,j]+" ");
                    }
                    Console.WriteLine();
                }
        }
    }
}

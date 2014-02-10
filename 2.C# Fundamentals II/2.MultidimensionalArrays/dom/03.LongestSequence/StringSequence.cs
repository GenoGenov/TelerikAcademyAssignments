//We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal. Write a program that finds the longest sequence of equal strings in the matrix. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LongestSequence
{
    class StringSequence
    {

        static public int SeqLength(string[,] arr, int col, int row)
        {
            List<int> results = new List<int>();
            int result;
            string check = arr[col, row];
            int j=0;
            int index = 0;
            results.Add(1);
            //check the row
            while (j<arr.GetLength(1)-1)
            {
                if (arr[col, j]==check && arr[col,j+1]==check)
                {
                    results[index]++;
                }
                else
                {
                    index++;
                    results.Add(1);
                }
                j++;
            }
            result = results.Max();
            //Check the col
            results = new List<int>();
            int i = 0;
            index = 0;
            results.Add(1);
            while (i < arr.GetLength(0) - 1)
            {
                if (arr[i, row] == check && arr[i+1, row] == check)
                {
                    results[index]++;
                }
                else
                {
                    index++;
                    results.Add(1);
                }
                i++;
            }
            if (result < results.Max())
            {
                result = results.Max();
            }
            //check the diagonals
            results = new List<int>();
            results.Add(1);
            index = 0;
            i = col;
            j = row;
            while (i!=0 && j!=0)
            {
                i--;
                j--;
            }

            while (i < arr.GetLength(0) - 1 && j<arr.GetLength(1)-1)
            {
                if (arr[i, j] == check && arr[i + 1, j+1] == check)
                {
                    results[index]++;
                }
                else
                {
                    index++;
                    results.Add(1);
                }
                i++;
                j++;
            }
            if (result < results.Max())
            {
                result = results.Max();
            }
            i = col;
            j = row;
            while (i != 0 && j != arr.GetLength(1)-1)
            {
                i--;
                j++;
            }

            while (i < arr.GetLength(0) - 1 && j >0)
            {
                if (arr[i, j] == check && arr[i + 1, j - 1] == check)
                {
                    results[index]++;
                }
                else
                {
                    index++;
                    results.Add(1);
                }
                i++;
                j--;
            }
            if (result < results.Max())
            {
                result = results.Max();
            }

            return result;
        }
        static void Main(string[] args)
        {
            int n, m;
            string input;
            do
            {
                Console.Write("N = ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out n));

            do
            {
                Console.Write("M = ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out m));

            string[,] arr = new string[n, m];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("Element at[{0}][{1}]:", i, j);
                    arr[i, j] = Console.ReadLine();
                }
            }
            int count = 0;
            string str=string.Empty;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (SeqLength(arr, i, j) > count)
                    {
                        count = SeqLength(arr, i, j);
                        str = arr[i, j];
                    }
                }
            }
            for (int i = 0; i < count; i++)
            {
                Console.Write(str+", ");
            }
            Console.WriteLine();
        }
    }
}

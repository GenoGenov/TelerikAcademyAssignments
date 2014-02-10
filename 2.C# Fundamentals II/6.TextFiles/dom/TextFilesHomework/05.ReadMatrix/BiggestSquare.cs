//Write a program that reads a text file containing a square matrix of numbers and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements. The first line in the input file contains the size of matrix N. Each of the next N lines contain N numbers separated by space. The output should be a single number in a separate text file.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ReadMatrix
{
    class Program
    {
        static StreamReader rdr;
        static int biggest = int.MinValue;
        static void Main(string[] args)
        {
            string content = "..\\..\\Content";

            try
            {
                rdr = new StreamReader(content + "\\first.txt", Encoding.GetEncoding("utf-8"));

                string line1 = rdr.ReadLine();
                int n = int.Parse(line1[0].ToString());
                int[,] matrix = new int[n, n];
                line1 = rdr.ReadLine();
                List<string> inputs = new List<string>();
                inputs.Add(line1);
                while (line1 != null)
                {
                    line1 = rdr.ReadLine();
                    inputs.Add(line1);
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    string[] nums=inputs.ElementAt(i).Split(' ');
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {

                        matrix[i, j] = int.Parse(nums[j]);
                    }
                }

                for (int i = 0; i < matrix.GetLength(0)-1; i++)
                {
                    for (int j = 0; j < matrix.GetLength(1)-1; j++)
                    {
                        int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                        if (sum > biggest)
                        {
                            biggest = sum;
                        }
                    }
                }
                Console.WriteLine("Success! The biggest square of numbers is {0}", biggest);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                rdr.Close();
            }
        }
    }
}

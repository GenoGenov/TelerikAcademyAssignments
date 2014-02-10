//* Write a class Matrix, to holds a matrix of integers. Overload the operators for adding, subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ClassMatrix
{
    class MainClass
    {
        static void Main(string[] args)
        {
            int[,] m1 = { { 1, 2, 3}, { 6, 7, 8}};
            int[,] m2 = { { 2, 2 }, { 2, 2 }, { 2, 2 } };
            //Example of multiplication
            int[,] m3 =Matrix.Multiply(m1,m2);

            Console.WriteLine(Matrix.ToString(m3)); 
        }
    }
}

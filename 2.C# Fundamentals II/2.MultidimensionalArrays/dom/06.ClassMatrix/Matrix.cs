using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ClassMatrix
{
    class Matrix
    {
        public static bool AreSameSize(int[,] matrix1, int[,] matrix2)
        {
            return (matrix1.GetLength(0) == matrix2.GetLength(0) && matrix1.GetLength(1) == matrix2.GetLength(1) && matrix1.Rank ==2 && matrix2.Rank==2);
          
        }
        public static int[,] Add(int[,] matrix1,int[,]matrix2)
        {
            if (!AreSameSize(matrix1,matrix2))
            {
                throw new InvalidOperationException("Matrices are not the same size!");
            }

            int[,] result = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

        public static int[,] Substract(int[,] matrix1, int[,] matrix2)
        {
            if (!AreSameSize(matrix1, matrix2))
            {
                throw new InvalidOperationException("Matrices are not the same size!");
            }

            int[,] result = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return result;
        }

        public static int[,] Multiply(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.Rank != 2 || matrix2.Rank != 2 || matrix1.GetLength(1)!=matrix2.GetLength(0))
            {
                throw new InvalidOperationException("Matrices are not two dimensional or are not proper sizes!");
            }

            int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            int row=0;
            int col=0;
            int sum = 0;
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        checked
                        {
                            result[i, j] += matrix1[i, k] * matrix2[i, j];
                        }
                    }
                }
            }

            return result;
        }

        public static int ElementAt(int[,] matrix,int row,int col)
        {
            return matrix[row,col];
        }

        public static string ToString(int[,] matrix)
        {
            string str = string.Empty;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    str = str + matrix[i, j] + " ";
                }
                str = str + "\n";
            }
            return str;
        }

        
    }
}

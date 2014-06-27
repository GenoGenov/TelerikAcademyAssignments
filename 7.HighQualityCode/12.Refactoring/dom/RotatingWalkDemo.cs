using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WalkInMatrix
{
    public class RotatingWalkDemo
    {
        public static int ReadMatrixDimensions()
        {
            string input = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || n < 2 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct number");
                //For Test purposes
                return 0;
                input = Console.ReadLine();
            }

            return n;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException("The input array is not a matrix !");
            }

            int n = matrix.GetLength(0);

            for (int p = 0; p < n; p++)
            {
                for (int q = 0; q < n; q++)
                {
                    Console.Write("{0,3}", matrix[p, q]);
                }
                Console.WriteLine();
            }
        }

        public static void TraverseMatrix(int[,] matrix, int n)
        {
            int step = n;
            int visitedValue = 1;
            int i = 0;
            int j = 0;
            int directionX = 1;
            int directionY = 1;

            while (RotatingWalkInMatrix.IsNextStepAvailable(matrix, i, j))
            {
                matrix[i, j] = visitedValue;

                RotatingWalkInMatrix.FillAvailableCellsOnCurrentPath(matrix, i, j, ref directionX, ref directionY);

                i += directionX; j += directionY; visitedValue++;

                
            }
            matrix[i, j] = visitedValue;
            directionX = 1;
            directionY = 1;
            RotatingWalkInMatrix.FindNextAvailableCell(matrix, out i, out j);
            visitedValue++;
            while (RotatingWalkInMatrix.IsNextStepAvailable(matrix, i, j))
            {
                matrix[i, j] = visitedValue;

                RotatingWalkInMatrix.FillAvailableCellsOnCurrentPath(matrix, i, j, ref directionX, ref directionY);

                i += directionX; j += directionY; visitedValue++;


            }
            matrix[i, j] = visitedValue;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Enter the matrix size: ");
            int n = ReadMatrixDimensions();
            int[,] matrix = new int[n, n];
            TraverseMatrix(matrix, n);
            PrintMatrix(matrix);
        }
    }
}
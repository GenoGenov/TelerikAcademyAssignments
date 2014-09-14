using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.EightQueensPuzzle
{
    class Program
    {
        private static int size = 11;
        private static bool[] colFree;
        private static bool[] primaryDiagonalFree;
        private static bool[] secondaryDiagonalFree;
        private static int[] occupiedCol;
        private static int solutions = 0;

        private static void PlaceQueenInRow(int row)
        {
            if (row == size)
            {
                solutions++;
                return;
            }

            for (int col = 0; col < size; col++)
            {
                if (colFree[col] &&
                    primaryDiagonalFree[row + col] &&
                    secondaryDiagonalFree[size + row - col])
                {
                    colFree[col] = false;
                    primaryDiagonalFree[row + col] = false;
                    secondaryDiagonalFree[size + row - col] = false;
                    occupiedCol[row] = col;
                    PlaceQueenInRow(row + 1);
                    colFree[col] = true;
                    primaryDiagonalFree[row + col] = true;
                    secondaryDiagonalFree[size + row - col] = true;
                }
            }
        }

        private static void Main()
        {
            occupiedCol = new int[size];
            colFree = new bool[size];
            primaryDiagonalFree = new bool[2 * size - 1];
            secondaryDiagonalFree = new bool[2 * size];

            int i;
            for (i = 0; i < size; i++)
            {
                colFree[i] = true;
            }

            for (i = 0; i < (2 * size - 1); i++)
            {
                primaryDiagonalFree[i] = true;
            }

            for (i = 0; i < 2 * size; i++)
            {
                secondaryDiagonalFree[i] = true;
            }

            PlaceQueenInRow(0);

            if (solutions > 0)
            {
                Console.WriteLine("Number of distinct solutions: " + solutions);
            }
            else
            {
                Console.WriteLine("No solution found!");
            }
        }
    }
}

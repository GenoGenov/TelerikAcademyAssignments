namespace WalkInMatrix
{
    using System;

    public static class RotatingWalkInMatrix
    {
        private static readonly int[] DirectionsY =
        {
            1,
            0,
            -1,
            -1,
            -1,
            0,
            1,
            1
        };

        private static readonly int[] DirectionsX =
        {
            1,
            1,
            1,
            0,
            -1,
            -1,
            -1,
            0
        };

        private const int DirectionsCount = 8;

        public static void ChangeDirection(ref int directionX, ref int directionY)
        {
            int[] directionsX = (int[])DirectionsX.Clone();
            int[] directionsY = (int[])DirectionsY.Clone();

            for (int i = 0; i < DirectionsCount; i++)
            {
                if (i == 7)
                {
                    directionX = directionsX[0];
                    directionY = directionsY[0];
                    return;
                }

                if (directionsX[i] == directionX && directionsY[i] == directionY)
                {
                    directionX = directionsX[i + 1];
                    directionY = directionsY[i + 1];
                    return;
                }
            }
        }

        public static bool IsNextStepAvailable(int[,] matrix, int x, int y)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException("Array is not a matrix !");
            }

            int[] directionsX = (int[])DirectionsX.Clone();
            int[] directionsY = (int[])DirectionsY.Clone();
            for (int i = 0; i < 8; i++)
            {
                if (x + directionsX[i] >= matrix.GetLength(0) || x + directionsX[i] < 0)
                {
                    directionsX[i] = 0;
                }

                if (y + directionsY[i] >= matrix.GetLength(0) || y + directionsY[i] < 0)
                {
                    directionsY[i] = 0;
                }
            }

            for (int i = 0; i < DirectionsCount; i++)
            {
                if (matrix[x + directionsX[i], y + directionsY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static void FindNextAvailableCell(int[,] matrix, out int x, out int y)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException("Array is not a matrix !");
            }

            x = 0;
            y = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }
        }

        public static bool IsNextCellAvailable(int[,] matrix, int i, int j, int directionX, int directionY)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException("Array is not a matrix !");
            }

            int n = matrix.GetLength(0);

            return i + directionX >= n ||
                   i + directionX < 0 ||
                   j + directionY >= n ||
                   j + directionY < 0 ||
                   matrix[i + directionX, j + directionY] != 0;
        }

        public static void FillAvailableCellsOnCurrentPath(
            int[,] matrix,
            int i,
            int j,
            ref int directionX,
            ref int directionY)
        {
            while (RotatingWalkInMatrix.IsNextCellAvailable(matrix, i, j, directionX, directionY))
            {
                RotatingWalkInMatrix.ChangeDirection(ref directionX, ref directionY);
            }
        }
    }
}
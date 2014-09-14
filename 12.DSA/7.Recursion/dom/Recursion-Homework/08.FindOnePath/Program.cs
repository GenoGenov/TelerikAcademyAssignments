namespace _08.FindOnePath
{
    using System;

    internal class Program
    {
        private static char[,] labyrinth;

        private static void PrintPath()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    Console.Write(labyrinth[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void FindPath(int row, int col)
        {
            if ((col < 0) || (row < 0) || (col >= labyrinth.GetLength(1)) || (row >= labyrinth.GetLength(0)))
            {
                return;
            }

            if (labyrinth[row, col] == 'e')
            {
                Console.WriteLine("Exit found!");
                Environment.Exit(0);
            }

            if (labyrinth[row, col] != ' ')
            {
                return;
            }

            labyrinth[row, col] = 's';

            FindPath(row, col - 1);
            FindPath(row - 1, col);
            FindPath(row, col + 1);
            FindPath(row + 1, col);
        }

        private static void Main()
        {
            int size = 100;
            labyrinth = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    labyrinth[row, col] = ' ';
                }
            }

            labyrinth[size - 1, size - 1] = 'e';

            FindPath(0, 0);

            Console.WriteLine("No path to the exit!");
        }
    }
}
namespace _10.AllPassableCells
{
    using System;

    internal class Program
    {
        private static char[,] labyrinth =
            {
                { ' ', ' ', ' ', '#', ' ', ' ', ' ' },
                { '#', '#', ' ', '#', ' ', '#', ' ' },
                { ' ', '#', ' ', '#', ' ', '#', ' ' },
                { ' ', '#', '#', '#', '#', '#', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', 'e' }
            };

        private static bool[,] visited;

        private static int FindConnectedArea(int row, int col)
        {
            if ((col < 0) || (row < 0) || (col >= labyrinth.GetLength(1)) || (row >= labyrinth.GetLength(0)))
            {
                return 0;
            }

            if (labyrinth[row, col] != ' ')
            {
                return 0;
            }

            if (visited[row, col])
            {
                return 0;
            }

            visited[row, col] = true;
            int count = 0;

            count += FindConnectedArea(row, col - 1);
            count += FindConnectedArea(row - 1, col);
            count += FindConnectedArea(row, col + 1);
            count += FindConnectedArea(row + 1, col);

            return 1 + count;
        }

        private static void Main()
        {
            int rowsCount = labyrinth.GetLength(0);
            int colsCount = labyrinth.GetLength(1);

            visited = new bool[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    if (labyrinth[row, col] == ' ' && !visited[row, col])
                    {
                        int count = FindConnectedArea(row, col);

                        Console.WriteLine("Connected area containing {0} empty cells.", count);
                    }
                }
            }
        }
    }
}
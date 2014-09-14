using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PathBetweenCells
{
    class Program
    {
        private static char[,] labyrinth = 
    {
        {' ', ' ', ' ', '#', ' ', ' ', ' '},
        {'#', '#', ' ', '#', ' ', '#', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', '#', '#', '#', '#', '#', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', 'e'}
    };

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
            if ((col < 0) ||
                (row < 0) ||
                (col >= labyrinth.GetLength(1)) ||
                (row >= labyrinth.GetLength(0)))
            {

                return;
            }


            if (labyrinth[row, col] == 'e')
            {
                Console.WriteLine("Exit found!");
                PrintPath();
                return;
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

            labyrinth[row, col] = ' ';
        }

        private static void Main()
        {
            FindPath(0, 0);
        }
    }
}

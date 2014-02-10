using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    class Program
    {
        static string[,] cube = { { "RED", "BLUE", "RED" }, { "BLUE", "GREEN", "BLUE" }, { "RED", "BLUE", "RED" } };
        static void Move(string direction,ref int row,ref int col)
        {
            if (direction == "L")
            {
                if (col == 0)
                {
                    col = 2;
                }
                else
                {
                    col--;
                }
            }
            else if (direction == "R")
            {
                if (col == 2)
                {
                    col = 0;
                }
                else
                {
                    col++;
                }
            }
            else if (direction == "UP")
            {
                if (row == 0)
                {
                    row = 2;
                }
                else
                {
                    row--;
                }
            }
            else if (direction == "DOWN")
            {
                if (row == 2)
                {
                    row = 0;
                }
                else
                {
                    row++;
                }
            }
        }

        static void ChangeDirection(ref string direction, string input)
        {
            switch (input)
            {
                case "R": if (direction == "UP")
                    {
                        direction = "R";
                    }
                    else if (direction == "R")
                    {
                        direction = "DOWN";
                    }
                    else if (direction == "DOWN")
                    {
                        direction = direction = "L";
                    }
                    else if (direction == "L")
                    {
                        direction = "UP";
                    }break;
                case "L": if (direction == "UP")
                    {
                        direction = "L";
                    }
                    else if (direction == "R")
                    {
                        direction = "UP";
                    }
                    else if (direction == "DOWN")
                    {
                        direction = direction = "R";
                    }
                    else if (direction == "L")
                    {
                        direction = "DOWN";
                    } break;
            }
        }
        static void Main(string[] args)
        {
            

            int kukataRow = 1;
            int kukataCol = 1;
            string direction = "UP";

            int n = int.Parse(Console.ReadLine());
            StringBuilder results = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'R')
                    {
                        ChangeDirection(ref direction, "R");
                    }
                    else if (input[j] == 'L')
                    {
                        ChangeDirection(ref direction, "L");
                    }
                    else if (input[j] == 'W')
                    {
                        Move(direction, ref kukataRow, ref kukataCol);
                    }
                }
                results.Append(cube[kukataRow,kukataCol]+'\n');
                kukataCol = 1;
                kukataRow = 1;
            }

            Console.WriteLine(results.ToString());
        }
    }
}

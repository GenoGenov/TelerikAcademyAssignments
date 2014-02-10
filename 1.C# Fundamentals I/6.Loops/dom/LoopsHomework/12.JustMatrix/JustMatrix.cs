//Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.JustMatrix
{
    class JustMatrix
    {
        static void Main(string[] args)
        {
            int n;
            string input;

            do
            {
                Console.Write("N = ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out n));

            Console.WriteLine();
            Console.WriteLine();

            int spaceX = 7;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(i+spaceX, j+3);
                    Console.Write(j+i+1);
                    
                }
                spaceX = spaceX + 2;
            }

            Console.WriteLine();
        }

    }
}

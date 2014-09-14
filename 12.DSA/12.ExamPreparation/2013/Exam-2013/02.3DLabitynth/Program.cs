using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._3DLabitynth
{
    class Program
    {
        static void Main(string[] args)
        {
            var startPost = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var startLevel = int.Parse(startPost[0]);
            var startRow = int.Parse(startPost[1]);
            var startCol = int.Parse(startPost[2]);

            var dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var L = int.Parse(dimensions[0]);
            var R = int.Parse(dimensions[1]);
            var C = int.Parse(dimensions[2]);

            var lab = new char[L, R, C];
            for (int i = 0; i < L; i++)
            {

                for (int j = 0; j < R; j++)
                {
                    var row = Console.ReadLine();
                    for (int k = 0; k < C; k++)
                    {
                        lab[i, j, k] = row[k];
                    }
                }
            }


            var currentLevel = startLevel;
            var currentRow = startRow;
            var currentCol = startCol;

            while (true)
            {
                
            }
        }
    }
}

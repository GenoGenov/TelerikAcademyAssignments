using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.BatGoikoTower
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int front = height-1;
            int back = height;
            List<int> rows = new List<int>();
            int row=1;
            int c=2;
            while (row <= height)
            {
                rows.Add(row);
                row += c;
                c++;
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height*2; j++)
                {
                    if (!rows.Contains(i))
                    {
                        if (j != front && j!=back)
                        {
                            Console.Write(".");
                        }
                        if (j == front)
                        {
                            Console.Write("/");
                        }
                        if (j == back)
                        {
                            Console.Write("\\");
                        }
                    }
                    else
                    {
                        if (j < front)
                        {
                            Console.Write(".");
                        }
                        if (j == front)
                        {
                            Console.Write("/");
                        }
                        if (j > front && j < back)
                        {
                            Console.Write("-");
                        }
                        if (j == back)
                        {
                            Console.Write("\\");
                        }
                        if (j > back)
                        {
                            Console.Write(".");
                        }
                    }
                }
                front--;
                back++;
                Console.WriteLine();
            }
        }
    }
}

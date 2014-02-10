using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firestart = n / 2;
            int firestop = n / 2 + 1;
            for (int i = 0; i < (n/4)*3; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j+1 != firestart && j+1 != firestop)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                if ((firestop - firestart == n - 1 || i>n/2-1) && i!=n/2-1 )
                {
                    firestart++; firestop--;
                }
                else if(i!=n/2-1)
                {
                    firestart--; firestop++;
                }
                Console.WriteLine();
            }

            Console.Write(new String('-',n));
            Console.WriteLine();

            int retreat = 0;

            for (int i = 0; i < n/2; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j + 1 <= retreat || j + 1 > n - retreat)
                    {
                        Console.Write(".");
                    }
                    else if(j+1<=n/2)
                    {
                        Console.Write("\\");
                    }
                    else
                    {
                        Console.Write("/");
                    }     
                }
                retreat++;
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class MatrixTest
    {
        private static Random rand = new Random();

        public static void Main(string[] args)
        {
            var m1 = new Matrix<int>(4, 4);
            var m2 = new Matrix<int>(4, 4);

            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m1.Col; j++)
                {
                    m1[i, j] = rand.Next(-10, +11);
                    m2[i, j] = rand.Next(-10, +11);
                }
            }

            Console.WriteLine("Matrix 1:");
            Console.WriteLine(m1);
            Console.WriteLine("Matrix 2:");
            Console.WriteLine(m2);
            Console.WriteLine("+:");
            Console.WriteLine(m1 + m2);
            Console.WriteLine("-:");
            Console.WriteLine(m1 - m2);
            Console.WriteLine("*:");
            Console.WriteLine(m1*m1);
            var m4 = new Matrix<int>(4, 4);
            Console.WriteLine("Matrix 4:");
            Console.WriteLine(m4);
            Console.WriteLine("Matrix 4 contains non zero elements:");
            Console.WriteLine(m4 ? true : false);
        }
    }
}
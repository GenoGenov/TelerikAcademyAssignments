//Write a program that can solve these tasks:
//Reverses the digits of a number
//Calculates the average of a sequence of integers
//Solves a linear equation a * x + b = 0

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _13.SolveTasks
{
    class Tasks
    {
        static void PrintMenu(out int a)
        {
            Console.WriteLine("1 for digit reverse");
            Console.WriteLine("2 for average of sequence calculation");
            Console.WriteLine("3 for solving a linear equation");
            Console.WriteLine();
            Console.Write("the system awaits your input:");
            string input;
            do
            {
                input = Console.ReadLine();
            } while (!int.TryParse(input,out a));

        }

        static void Inverse()
        {
            decimal d;
            string input;
            do
            {
                Console.Write("Decimal number:");
                input = Console.ReadLine();
            } while (!decimal.TryParse(input, out d) || d<0);

            char[] digits = d.ToString().ToCharArray();
            string result = string.Join("", digits.Reverse());
            d = decimal.Parse(result);
            Console.WriteLine("Your new number: {0}",d);
        }

        static void CalcAverage()
        {

            int n;
            string input;
            do
            {
                Console.Write("Array Length(>0):");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out n) || n < 1);

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                int g;
                do
                {
                    Console.Write("Element at [{0}]:", i);
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out g));
                arr[i] = g;
            }

            Console.WriteLine("The average of all elements is {0}",arr.Average());
        }

        static void SolveEquation()
        {
            decimal a,b;
            string input;
            do
            {
                Console.Write("a(!=0):");
                input = Console.ReadLine();
            } while (!decimal.TryParse(input, out a) || a ==0);

            do
            {
                Console.Write("b:");
                input = Console.ReadLine();
            } while (!decimal.TryParse(input, out b));

            Console.WriteLine("The answer to the equasion {0}*X+({1}) is {2}",a,b,-b/a);

        }
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int response;
            PrintMenu(out response);
            switch (response)
            {
                case 1: Inverse(); break;
                case 2: CalcAverage(); break;
                case 3: SolveEquation(); break;
            }
        }
    }
}

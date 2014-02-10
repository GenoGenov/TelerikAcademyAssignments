//Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.CalculationsOnSetOfIntegers
{
    class Calcs
    {
        static int CalcMin(params int[] set)
        {
            int min = int.MaxValue;
            foreach (var item in set)
            {
                if (min > item)
                {
                    min = item;
                }
            }

            return min;
        }

        static int CalcMax(params int[] set)
        {
            int max = int.MinValue;
            foreach (var item in set)
            {
                if (max < item)
                {
                    max = item;
                }
            }

            return max;
        }

        static int CalcAverage(params int[] set)
        {
            int sum = 0;
            for (int i = 0; i < set.Length; i++)
            {
                sum += set[i];
            }

            int average = sum / set.Length;

            return average;
        }

        static int CalcSum(params int[] set)
        {
            int sum = 0;
            for (int i = 0; i < set.Length; i++)
            {
                sum += set[i];
            }

            return sum;
        }

        static int CalcProduct(params int[] set)
        {
            int product = 1;
            for (int i = 0; i < set.Length; i++)
            {
                product *= set[i];
            }

            return product;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Numbers im gonna use are 1,2,3,4,5,-5");
            Console.WriteLine("Calc Min - "+CalcMin(1,2,3,4,5,-5));
            Console.WriteLine("Calc Max - "+CalcMax(1,2,3,4,5,-5));
            Console.WriteLine("Calc Average - "+CalcAverage(1,2,3,4,5,-5));
            Console.WriteLine("Calc Sum - "+CalcSum(1,2,3,4,5,-5));
            Console.WriteLine("Calc Product - "+CalcProduct(1,2,3,4,5,-5));
        }
    }
}

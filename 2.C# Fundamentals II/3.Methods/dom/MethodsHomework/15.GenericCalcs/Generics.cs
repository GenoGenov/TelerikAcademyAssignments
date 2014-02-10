//* Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.). Use generic method (read in Internet about generic methods in C#).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _15.GenericCalcs
{
    class Generics
    {

        public static T Add<T>(T t1, T t2)
        {
            dynamic a = t1, b = t2;
            return a + b;
        }

        public static T Divide<T>(T t1, int t2)
        {
            dynamic a = t1, b = t2;
            return a / b;
        }

        public static T Mult<T>(T t1, T t2)
        {
            dynamic a = t1, b = t2;
            return a * b;
        }
        public static T CalcMin<T>(params T[] set) where T : IComparable
        {
            T min = set[0];
            foreach (T item in set)
            {
                if (min.CompareTo(item)>0)
                {
                    min = item;
                }
            }

            return min;
        }

        static T CalcMax<T>(params T[] set) where T : IComparable
        {
            T max = set[0];
            foreach (var item in set)
            {
                if (max.CompareTo(item)<0)
                {
                    max = item;
                }
            }

            return max;
        }

        static T CalcAverage<T>(params T[] set)
        {
            T sum = set[0];
            for (int i = 1; i < set.Length; i++)
            {
                sum =Add(sum,set[i]);
            }
            
            T average = Divide(sum,set.Length);

            return average;
        }

        static T CalcSum<T>(params T[] set)
        {
            T sum = set[0];
            for (int i = 1; i < set.Length; i++)
            {
                sum = Add(sum,set[i]);
            }

            return sum;
        }

        static T CalcProduct<T>(params T[] set)
        {
            T product = set[0];
            for (int i = 1; i < set.Length; i++)
            {
                product = Mult(product,set[i]);
            }

            return product;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Calc Min - " + CalcMin(1, 2.77, 3, 4, 5, -5.346363463463476437437437437347));
            Console.WriteLine("Calc Max - " + CalcMax(1, 2, 3.546, 4, 5, -5));
            Console.WriteLine("Calc Average - " + CalcAverage(1.76532, 2, 3, 4, 5, -5));
            Console.WriteLine("Calc Sum - " + CalcSum(1, 2, 3.34m, 4, 5, -5));
            Console.WriteLine("Calc Product - " + CalcProduct(1, 2, 3.765, 4, 5, -5));
        }
    }
}

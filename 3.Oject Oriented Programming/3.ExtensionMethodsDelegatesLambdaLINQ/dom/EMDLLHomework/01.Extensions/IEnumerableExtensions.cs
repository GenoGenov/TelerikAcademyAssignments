using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T Sum<T>(this IEnumerable<T> enumerable)
        {
            var enumeration = enumerable as T[] ?? enumerable.ToArray();
            return enumeration.Aggregate(default(T), (current, t) => (T) (current + (dynamic) t));
        }

        public static T Product<T>(this IEnumerable<T> enumerable)
            where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            var enumeration = enumerable as T[] ?? enumerable.ToArray();
            T product = enumeration[0];
            for (int i = 1; i < enumeration.Length; i++)
            {
                product *= (dynamic) enumeration[i];
            }
            return product;
        }

        public static T Min<T>(this IEnumerable<T> enumerable) where T : IComparable
        {
            var enumeration = enumerable as T[] ?? enumerable.ToArray();
            T min = enumeration[0];
            foreach (var t in enumeration)
            {
                if (min.CompareTo(t) >= 0)
                {
                    min = t;
                }
            }
            return min;
        }

        public static T Max<T>(this IEnumerable<T> enumerable) where T : IComparable
        {
            var enumeration = enumerable as T[] ?? enumerable.ToArray();
            T max = enumeration[0];
            foreach (var t in enumeration)
            {
                if (max.CompareTo(t) <= 0)
                {
                    max = t;
                }
            }
            return max;
        }

        public static decimal Average<T>(this IEnumerable<T> enumerable)
        {
            var enumeration = enumerable as T[] ?? enumerable.ToArray();
            T average = enumeration[0];
            for (int i = 1; i < enumeration.Length; i++)
            {
                average += (dynamic) enumeration[i];
            }
            return ((dynamic) average)/(decimal) enumeration.Length;
        }
    }
}
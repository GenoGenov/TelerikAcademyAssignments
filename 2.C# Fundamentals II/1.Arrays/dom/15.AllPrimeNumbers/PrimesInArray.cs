//Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.AllPrimeNumbers
{
    class PrimesInArray
    {
        static void Main(string[] args)
        {
            Console.Write("Upper limit:");
            int limit = int.Parse(Console.ReadLine());
            List<int> numbers = Enumerable.Range(1, limit).ToList();
            numbers.TrimExcess();
            int i = 1;
            while (i<numbers.Count)
            {
                if (numbers[i] == 0)
                {
                    i++;
                    continue;
                }
                for (int j = i+numbers[i]; j < numbers.Count; j+=numbers[i])
                {
                    numbers[j] = 0;
                }
                i++;
            }
            numbers.RemoveAll(x => x == 0);
            numbers.TrimExcess();
            Console.WriteLine("Prime numbers in the range[1,{0}]:",limit);
            Console.WriteLine(string.Join(", ",numbers));

        }
    }
}

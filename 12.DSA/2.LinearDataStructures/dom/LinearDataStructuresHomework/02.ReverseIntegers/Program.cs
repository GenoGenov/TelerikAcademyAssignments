namespace _02.ReverseIntegers
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var values = new Stack<int>();
            Console.WriteLine("How many numbers would you like to enter:");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Ok, start entering {0} numbers each followed by new line now",N);
            for (int i = 0; i < N; i++)
            {
                values.Push(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine("Values reversed:\n"+string.Join(",",values));
        }
    }
}
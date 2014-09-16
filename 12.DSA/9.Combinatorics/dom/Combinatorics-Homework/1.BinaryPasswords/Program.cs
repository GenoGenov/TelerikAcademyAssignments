namespace _1.BinaryPasswords
{
    using System;
    using System.Linq;
    using System.Numerics;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var starsCount = input.Count(x => x.Equals('*'));

            Console.WriteLine(starsCount > 0 ? (BigInteger)Math.Pow(2, starsCount) : 1);
        }
    }
}
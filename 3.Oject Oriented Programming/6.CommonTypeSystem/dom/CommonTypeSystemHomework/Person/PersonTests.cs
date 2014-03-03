using System;
using System.Linq;

namespace Person
{
    public class PersonTests
    {
        private static void Main(string[] args)
        {
            Person first = new Person("Ivan",32);
            Person second = new Person("Pesho",null);

            Console.WriteLine(first);
            Console.WriteLine();
            Console.WriteLine(second);
        }
    }
}
namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int i = 0;
            int[] array = new int[1000];
            int expectedValue = 5;
            bool isValueFound = false;

            for (i = 0; i < 100; i++)
            {
                Console.WriteLine(array[i]);

                if (i % 10 == 0 && array[i] == expectedValue)
                {
                    isValueFound = true;
                    break;
                }
            }

            if (isValueFound)
            {
                Console.WriteLine("Value Found");
            }

            // More code here
        }
    }
}
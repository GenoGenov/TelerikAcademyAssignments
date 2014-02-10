using System;

namespace _8.YearsCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            String input;
            int Valid;
            Console.Write("Enter your age:");
            input = Console.ReadLine();
            if (!int.TryParse(input, out Valid))
            {

                do
                {
                    Console.WriteLine("Bad Input! Numbers Only!");
                    input = Console.ReadLine();

                } while (!int.TryParse(input, out Valid));
            }
            Valid = Convert.ToInt32(input);
            Console.WriteLine("In 10 years you will be {0} years old!", Valid + 10);
        }
    }
}
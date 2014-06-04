namespace _3.MathOperationsComparison
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class CompareMathExecTime
    {
        private static void DisplayExecutionTime(Action action, string message)
        {
            Console.WriteLine(message);
            Stopwatch watch = Stopwatch.StartNew();
            action();
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            Console.WriteLine();
        }

        private static void Main(string[] args)
        {
            DisplayExecutionTime(
                () =>
                {
                    float num = 12345.123f;
                    for (int i = 1000000; i >= 0; i--)
                    {
                        Math.Sqrt(num);
                    }
                },
                "Square root for floats");

            DisplayExecutionTime(
                () =>
                {
                    double num = 12345.123;
                    for (int i = 1000000; i >= 0; i--)
                    {
                        Math.Sqrt(num);
                    }
                },
                "Square root for doubles");

            DisplayExecutionTime(
                () =>
                {
                    decimal num = 12345.123m;
                    for (int i = 1000000; i >= 0; i--)
                    {
                        Math.Sqrt((double)num);
                    }
                },
                "Square root for decimals");

            DisplayExecutionTime(
                () =>
                {
                    float num = 12345.123f;
                    for (int i = 1000000; i >= 0; i--)
                    {
                        Math.Log(num);
                    }
                },
                "Natural logarithm for floats");

            DisplayExecutionTime(
                () =>
                {
                    double num = 12345.123;
                    for (int i = 1000000; i >= 0; i--)
                    {
                        Math.Log(num);
                    }
                },
                "Natural logarithm for doubles");

            DisplayExecutionTime(
                () =>
                {
                    decimal num = 12345.123m;
                    for (int i = 1000000; i >= 0; i--)
                    {
                        Math.Log((double)num);
                    }
                },
                "Natural logarithm for decimals");

            DisplayExecutionTime(
                () =>
                {
                    float num = 12345.123f;
                    for (int i = 1000000; i >= 0; i--)
                    {
                        Math.Sin(num);
                    }
                },
                "Sine for floats");

            DisplayExecutionTime(
                () =>
                {
                    double num = 12345.123;
                    for (int i = 1000000; i >= 0; i--)
                    {
                        Math.Sin(num);
                    }
                },
                "Sine for doubles");

            DisplayExecutionTime(
                () =>
                {
                    decimal num = 12345.123m;
                    for (int i = 1000000; i >= 0; i--)
                    {
                        Math.Sin((double)num);
                    }
                },
                "Sine for decimals");
        }
    }
}
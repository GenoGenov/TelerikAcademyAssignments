namespace OperatorsComparison
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class CompareExecTime
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
                    int sum = 0;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum += 1 + 7;
                    }
                },
                "Adding integers");

            DisplayExecutionTime(
                () =>
                {
                    long sum = 0;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum += 1L + 7L;
                    }
                },
                "Adding Longs");

            DisplayExecutionTime(
                () =>
                {
                    float sum = 0;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum += 1f + 7f;
                    }
                },
                "Adding floats");

            DisplayExecutionTime(
                () =>
                {
                    double sum = 0.1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum += 1.1 + 7.1;
                    }
                },
                "Adding doubles");

            DisplayExecutionTime(
                () =>
                {
                    decimal sum = 0.1m;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum += 1.1m + 7.1m;
                    }
                },
                "Adding decimals");

            DisplayExecutionTime(
                () =>
                {
                    int sum = 0;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum = 7 - 1;
                    }
                },
                "Subtracting integers");

            DisplayExecutionTime(
                () =>
                {
                    long sum = 0;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum = 7L - 1L;
                    }
                },
                "Subtracting longs");

            DisplayExecutionTime(
                () =>
                {
                    float sum = 0f;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum = 7f - 1f;
                    }
                },
                "Subtracting floats");

            DisplayExecutionTime(
                () =>
                {
                    double sum = 0.1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum = 7.1 - 1.1;
                    }
                },
                "Subtracting doubles");

            DisplayExecutionTime(
                () =>
                {
                    decimal sum = 0.1m;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum = 7.1m - 1.1m;
                    }
                },
                "Subtracting decimals");

            DisplayExecutionTime(
                () =>
                {
                    int sum = 0;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum++;
                    }
                },
                "Incrementing integers");

            DisplayExecutionTime(
                () =>
                {
                    long sum = 0;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum++;
                    }
                },
                "Incrementing longs");

            DisplayExecutionTime(
                () =>
                {
                    long sum = 1L;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum++;
                    }
                },
                "Incrementing longs");

            DisplayExecutionTime(
                () =>
                {
                    float sum = 0.7f;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum++;
                    }
                },
                "Incrementing floats");

            DisplayExecutionTime(
                () =>
                {
                    double sum = 0.7;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum++;
                    }
                },
                "Incrementing doubles");

            DisplayExecutionTime(
                () =>
                {
                    decimal sum = 0.7m;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum++;
                    }
                },
                "Incrementing decimals");

            DisplayExecutionTime(
                () =>
                {
                    int sum = 0;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum += 1 * 7;
                    }
                },
                "Miltiplying integers");

            DisplayExecutionTime(
                () =>
                {
                    long sum = 0;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum += 1L * 7L;
                    }
                },
                "Miltiplying Longs");

            DisplayExecutionTime(
                () =>
                {
                    float sum = 0.1f;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum += 1.1f * 7.1f;
                    }
                },
                "Miltiplying floats");

            DisplayExecutionTime(
                () =>
                {
                    double sum = 0.1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum += 1.1 * 7.1;
                    }
                },
                "Miltiplying doubles");

            DisplayExecutionTime(
                () =>
                {
                    decimal sum = 0.1m;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum += 1.1m * 7.1m;
                    }
                },
                "Miltiplying decimals");

            DisplayExecutionTime(
                () =>
                {
                    int sum = 0;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum = 7 / 3;
                    }
                },
                "Dividing integers");

            DisplayExecutionTime(
                () =>
                {
                    long sum = 0;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum = 7L / 3L;
                    }
                },
                "Dividing Longs");

            DisplayExecutionTime(
                () =>
                {
                    float sum = 0.1f;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum = 7.1f / 1.1f;
                    }
                },
                "Dividing floats");

            DisplayExecutionTime(
                () =>
                {
                    double sum = 0.1;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum = 7.1 / 1.1;
                    }
                },
                "Dividing doubles");

            DisplayExecutionTime(
                () =>
                {
                    decimal sum = 0.1m;
                    for (int i = 0; i < 1000000; i++)
                    {
                        sum = 7.1m / 1.1m;
                    }
                },
                "Dividing decimals");
        }
    }
}
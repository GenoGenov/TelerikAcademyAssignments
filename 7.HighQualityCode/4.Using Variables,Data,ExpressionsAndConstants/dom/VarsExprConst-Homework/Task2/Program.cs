namespace Task2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        public void PrintStatistics(double[] arr, int count)
        {
            double max = int.MinValue;
            double min = int.MaxValue;
            int sumOfElements = 0;
            for (int i = 0; i < count; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }

                if (arr[i] < min)
                {
                    min = arr[i];
                }

                sumOfElements += arr[i];
            }

            int averageOfAllElements = sumOfElements / count;
            this.PrintMax(max);
            this.PrintMin(max);
            this.PrintAvg(averageOfAllElements);
        }

        private static void Main(string[] args)
        {
        }

        private void PrintAvg(double avg)
        {
            throw new NotImplementedException();
        }

        private void PrintMin(double max)
        {
            throw new NotImplementedException();
        }

        private void PrintMax(double max)
        {
            throw new NotImplementedException();
        }
    }
}
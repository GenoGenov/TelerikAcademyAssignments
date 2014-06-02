namespace Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class ExceptionsHomework
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (arr == null || arr.Length < 2)
            {
                throw new ArgumentException("The input array cannot be null or have less than 2 elements!");
            }

            if (startIndex >= arr.Length - 2 || startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex must be in range [0 ... arr.length-2] !");
            }

            if (count == 0)
            {
                throw new ArgumentException("The count cannot be zero!");
            }

            int endIndex = count + startIndex - 1;

            if (endIndex > arr.Length - 1)
            {
                throw new ArgumentException("the given startindex + count exceeds the range of the array!");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i <= endIndex; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (count > str.Length || count < 1)
            {
                throw new ArgumentException("the count cannot be bigger than the length of the string or less than 1 !");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static void CheckPrime(int number)
        {
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    Console.WriteLine(string.Format("The number {0} is not prime!", number));
                    return;
                }
            }

            Console.WriteLine(string.Format("The number {0} is prime!", number));
        }

        // Uncomment each test to see the resulting exception(if any).
        private static void Main()
        {
            // var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            // Console.WriteLine(substr);
            // var subarr = Subsequence(new int[]
            // {
            //    -1,
            //    3,
            //    2,
            //    1
            // }, 0, 2);
            // Console.WriteLine(String.Join(" ", subarr));
            // var allarr = Subsequence(new int[]
            // {
            //    -1,
            //    3,
            //    2,
            //    1
            // }, 0, 4);
            // Console.WriteLine(String.Join(" ", allarr));
            // var emptyarr = Subsequence(new int[]
            // {
            //    -1,
            //    3,
            //    2,
            //    1
            // }, 0, 0);
            // Console.WriteLine(String.Join(" ", emptyarr));
            // Console.WriteLine(ExtractEnding("I love C#", 2));
            // Console.WriteLine(ExtractEnding("Nakov", 4));
            // Console.WriteLine(ExtractEnding("beer", 4));
            // Console.WriteLine(ExtractEnding("Hi", 100));
            CheckPrime(23);
            CheckPrime(33);

            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}
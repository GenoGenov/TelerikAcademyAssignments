namespace Methods
{
    using System;

    internal class Methods
    {
        private static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0 || (a + b <= c || a + c <= b || b + c <= a))
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        private static string DigitToString(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentException("The input value is not a valid digit!");
            }
        }

        private static int FindMaxElement(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("The input elements collection must not be null or empty !");
            }

            int currentMax = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > currentMax)
                {
                    currentMax = elements[i];
                }
            }

            return currentMax;
        }

        private static void PrintNumber(double value, int decimalDigits)
        {
            if (decimalDigits < 0)
            {
                throw new ArgumentOutOfRangeException("the decimal digits parameter must not be a negative value");
            }

            Console.WriteLine("{0:F" + decimalDigits + "}", value);
        }

        private static void PrintPercent(double value, int decimalDigits)
        {
            if (decimalDigits < 0)
            {
                throw new ArgumentOutOfRangeException("the decimal digits parameter must not be a negative value");
            }

            Console.WriteLine("{0:P" + decimalDigits + "}", value);
        }

        private static void PrintAligned(double value, int totalWidth)
        {
            Console.WriteLine("{0," + totalWidth + "}", value);
        }

        private static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        private static bool ArePointsHorizontal(double y1, double y2)
        {
            return y1 == y2;
        }

        private static bool ArePointsVertical(double x1, double x2)
        {
            return x1 == x2;
        }

        private static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(DigitToString(5));
            
            Console.WriteLine(FindMaxElement(5, -1, 3, 2, 14, 2, 3));
            
            PrintNumber(1.3, 5);
            PrintPercent(0.75, 2);
            PrintAligned(2.30, 20);

            bool areHorizontal = ArePointsHorizontal(-1, 2.5);
            bool areVertical = ArePointsVertical(-1, 2.5);
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine(string.Format("Horizontal? {0}", areHorizontal));
            Console.WriteLine(string.Format("Vertical? {0}", areVertical));

            Student peter = new Student()
            {
                FirstName = "Peter",
                LastName = "Ivanov"
            };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student()
            {
                FirstName = "Stella",
                LastName = "Markova"
            };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine(
                              "{0} older than {1} -> {2}",
                              peter.FirstName,
                              stella.FirstName,
                              peter.IsOlderThan(stella));
        }
    }
}
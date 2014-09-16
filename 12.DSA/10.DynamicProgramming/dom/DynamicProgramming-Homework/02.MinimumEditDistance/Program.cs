namespace _02.MinimumEditDistance
{
    using System;

    internal class Program
    {
        public static int[,] common;

        private static void Main(string[] args)
        {
            Console.Write("Initial Word: ");
            var initialWord = Console.ReadLine();
            Console.Write("TargetWord: ");
            var targetWord = Console.ReadLine();
            var matrix = BuildLongestCommonSetMatrix(initialWord, targetWord);
            var cost = CalcTransformCost(matrix, targetWord, initialWord);
            Console.WriteLine("The transform cost is {0}", cost);
        }

        private static int[,] BuildLongestCommonSetMatrix(string firstWord, string secondWord)
        {
            var maxLength = Math.Max(firstWord.Length, secondWord.Length);
            common = new int[maxLength + 1, maxLength + 1];

            int m = firstWord.Length;
            int n = secondWord.Length;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (firstWord[i - 1] == secondWord[j - 1])
                    {
                        common[i, j] = common[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        common[i, j] = Math.Max(common[i, j - 1], common[i - 1, j]);
                    }
                }
            }
            return common;
        }

        private static double CalcTransformCost(int[,] matrix, string targetWord, string initialWord)
        {
            double transformCost = 0;

            int currentX = matrix.GetLength(0) - 1;
            int currentY = matrix.GetLength(1) - 1;

            while (currentX != 0 && currentY != 0)
            {
                if (targetWord[currentX - 1] == initialWord[currentY - 1])
                {
                    currentX--;
                    currentY--;
                }
                else if (matrix[currentX - 1, currentY] == matrix[currentX, currentY - 1])
                {
                    transformCost += 1;
                    currentX--;
                    currentY--;
                }
                else if (matrix[currentX - 1, currentY] > matrix[currentX, currentY - 1])
                {
                    transformCost += 0.8;
                    currentX--;
                }
                else
                {
                    transformCost += 0.9;
                    currentY--;
                }
            }

            if (currentX > 0)
            {
                transformCost += currentX * 0.8;
            }

            if (currentY > 0)
            {
                transformCost += currentY * 0.9;
            }

            return transformCost;
        }
    }
}
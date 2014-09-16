namespace RandomGenerator
{
    using System;
    using System.Collections.Generic;

    public class RandomGenerator : IRandomGenerator
    {
        private const string AllLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static RandomGenerator instance;

        private Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static RandomGenerator GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RandomGenerator();
                }

                return instance;
            }
        }

        public int GenerateRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public double GenerateRandomDouble(double min, double max)
        {
            return this.random.NextDouble() * (max - min) + min;
        }

        public IEnumerable<string> GenerateUniqueStringsWithRandomLength(int min, int max, int count)
        {
            var result = new HashSet<string>();

            while (result.Count != count)
            {
                result.Add(this.GenerateRandomStringWithRandomLength(min, max));
            }

            return result;
        }

        public IEnumerable<string> GenerateUniqueStrings(int length, int count)
        {
            var result = new HashSet<string>();

            while (result.Count != count)
            {
                result.Add(this.GenerateRandomString(length));
            }

            return result;
        }

        public string GenerateRandomString(int length)
        {
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = AllLetters[this.GenerateRandomNumber(0, AllLetters.Length - 1)];
            }
            return new string(result);
        }

        public string GenerateRandomStringWithRandomLength(int minLength, int maxLength)
        {
            return this.GenerateRandomString(this.GenerateRandomNumber(minLength, maxLength));
        }

        public bool IsInFavour(int percent)
        {
            return this.GenerateRandomNumber(0, 100) <= percent;
        }
    }
}
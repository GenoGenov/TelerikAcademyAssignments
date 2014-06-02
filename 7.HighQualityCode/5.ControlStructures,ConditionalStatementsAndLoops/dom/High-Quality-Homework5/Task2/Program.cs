namespace Task2
{
    using System;
    using System.Linq;

    internal class Program
    {
        public const int MinX = -1;
        public const int MaxX = 1;
        public const int MinY = -2;
        public const int MaxY = 2;

        private static void Main(string[] args)
        {
            Potato potato = null;

            // ... 
            if (potato != null &&
                potato.HasBeenPeeled &&
                potato.IsFresh)
            {
                Cook(potato);
            }

            int x = 0;
            int y = 0;
            bool shouldVisitCell = true;
            if (AreCoordinatesInRange(x, y) && shouldVisitCell)
            {
                VisitCell();
            }
        }
 
        private static bool AreCoordinatesInRange(int x, int y)
        {
            bool result = x >= MinX && x <= MaxX && y >= MinY && y <= MaxY;

            return result;
        }

        private static void VisitCell()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
 
        private static void Cook(Potato potato)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public class Potato
        {
            public bool HasBeenPeeled { get; set; }

            public bool IsFresh { get; set; }
        }
    }
}
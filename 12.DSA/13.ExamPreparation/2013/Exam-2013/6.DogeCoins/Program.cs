namespace _6.DogeCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static List<long> results = new List<long>();

        private static HashSet<Coord> visited = new HashSet<Coord>();

        private static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];

            var lab = new int[rows, cols];

            var coinsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < coinsCount; i++)
            {
                var coords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                lab[coords[0], coords[1]] = 1;
            }
            var coord = new Coord(0, 0);
            var target = new Coord(rows - 1, cols - 1);
            DFS(coord, target, 0, lab);
            Console.WriteLine(results.Max());
        }

        private static void DFS(Coord coord, Coord target, long sum, int[,] lab)
        {
            //if (!visited.Contains(coord))
            //{
                visited.Add(coord);

                if (coord.Equals(target))
                {
                    results.Add(sum);
                    return;
                }

                if (lab[coord.X, coord.Y] == 1)
                {
                    sum += 1;
                }

                if (coord.X + 1 < lab.GetLength(0))
                {
                    

                    DFS(new Coord(coord.X + 1, coord.Y), target, sum, lab);
                }
                if (coord.Y + 1 < lab.GetLength(1))
                {

                    DFS(new Coord(coord.X, coord.Y + 1), target, sum, lab);
                }
            //}
        }

        private class Coord
        {
            public Coord(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public int X { get; set; }

            public int Y { get; set; }

            public override int GetHashCode()
            {
                return 23 + this.X ^ this.Y * this.X & this.Y;
            }

            public override bool Equals(object obj)
            {
                var other = obj as Coord;
                return this.X == other.X && this.Y == other.Y;
            }
        }
    }
}
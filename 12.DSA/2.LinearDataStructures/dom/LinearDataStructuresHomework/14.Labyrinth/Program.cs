namespace _14.Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void BFS(ref string[,] arr, AllowedCoords start)
        {
            var queue = new Queue<AllowedCoords>();
            var set = new HashSet<AllowedCoords>();
            int depth = 1;
            queue.Enqueue(start);
            set.Add(start);
            while (queue.Count > 0)
            {
                var coords = queue.Dequeue();
                if (arr[coords.Row, coords.Col] == "0")
                {
                    arr[coords.Row, coords.Col] = depth.ToString();
                }

                var neighbors = coords.GetAdjacent();
                for (int i = 0; i < neighbors.Count; i++)
                {
                    var coordinates = neighbors[i];
                    if (!set.Contains(coordinates))
                    {
                        depth++;
                        set.Add(coordinates);
                        queue.Enqueue(coordinates);
                    }
                }
                
            }
        }

        private static void Main(string[] args)
        {
            Console.Write("N=");
            int n = int.Parse(Console.ReadLine());

            var arr = new string[n, n];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("[{0}][{1}]=", i, j);
                    string input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input))
                    {
                        arr[i, j] = input;
                    }
                }
            }

            Console.WriteLine("Your matrix:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }

            Console.Write("Start X=");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Start Y=");
            int y = int.Parse(Console.ReadLine());

            BFS(ref arr, new AllowedCoords(x, y, arr));

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == "0")
                    {
                        arr[i, j] = "U";
                    }
                }
            }

            Console.WriteLine("Filled:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j].PadLeft(5));
                }
                Console.WriteLine();
            }
        }

        public struct AllowedCoords
        {
            private static Random rand=new Random();

            public int Col;

            public int Row;

            private string[,] arr;

            private int maxCol;

            private int maxRow;

            public AllowedCoords(int row, int col, string[,] arr)
            {
                this.Row = row;
                this.Col = col;
                this.maxRow = arr.GetLength(0);
                this.maxCol = arr.GetLength(1);
                this.arr = arr;
            }

            public List<AllowedCoords> GetAdjacent()
            {
                var result = new List<AllowedCoords>();
                if (this.Col - 1 >= 0 && this.arr[this.Row, this.Col - 1] != "x"
                    && this.arr[this.Row, this.Col - 1] != "*")
                {
                    result.Add(new AllowedCoords(this.Row, this.Col - 1, this.arr));
                }
                if (this.Col + 1 < this.maxCol && this.arr[this.Row, this.Col + 1] != "x"
                    && this.arr[this.Row, this.Col + 1] != "*")
                {
                    result.Add(new AllowedCoords(this.Row, this.Col + 1, this.arr));
                }
                if (this.Row - 1 >= 0 && this.arr[this.Row - 1, this.Col] != "x"
                    && this.arr[this.Row - 1, this.Col] != "*")
                {
                    result.Add(new AllowedCoords(this.Row - 1, this.Col, this.arr));
                }
                if (this.Row + 1 < this.maxRow && this.arr[this.Row + 1, this.Col] != "x"
                    && this.arr[this.Row + 1, this.Col] != "*")
                {
                    result.Add(new AllowedCoords(this.Row + 1, this.Col, this.arr));
                }

                return result;
            }

            public override int GetHashCode()
            {
                return (this.Row * 15 >> 17 + this.Col * 7 << 17)*rand.Next();
            }
        }
    }
}
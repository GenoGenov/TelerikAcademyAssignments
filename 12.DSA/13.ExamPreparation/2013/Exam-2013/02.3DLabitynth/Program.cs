namespace _2._3DLabitynth
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var startPost = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var startLevel = int.Parse(startPost[0]);
            var startRow = int.Parse(startPost[1]);
            var startCol = int.Parse(startPost[2]);

            var dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var L = int.Parse(dimensions[0]);
            var R = int.Parse(dimensions[1]);
            var C = int.Parse(dimensions[2]);

            var lab = new char[L, R, C];
            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < R; j++)
                {
                    var row = Console.ReadLine();
                    for (int k = 0; k < C; k++)
                    {
                        lab[i, j, k] = row[k];
                    }
                }
            }

            var currentLevel = startLevel;
            var currentRow = startRow;
            var currentCol = startCol;

            var visited = new HashSet<Cell>();
            var queue = new Queue<Cell>();
            var current = new Cell(currentLevel, currentRow, currentCol, 0);
            queue.Enqueue(current);
            visited.Add(current);

            var test = new int[L, R, C];

            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();
                
                if (cell.Level >= L || cell.Level < 0)
                {
                    Console.WriteLine(cell.Depth);
                    break;
                }
                var next = new Cell(cell.Level, cell.Row - 1, cell.Col, cell.Depth + 1);
                if (next.Row >= 0 && lab[next.Level, next.Row, next.Col] != '#' && !visited.Contains(next)) //up
                {
                    queue.Enqueue(next);
                    visited.Add(next);
                    test[next.Level, next.Row, next.Col] = next.Depth;
                }
                next = new Cell(cell.Level, cell.Row + 1, cell.Col, cell.Depth + 1);
                if (next.Row < R && lab[next.Level, next.Row, next.Col] != '#' && !visited.Contains(next)) //down
                {
                    queue.Enqueue(next);
                    visited.Add(next);
                    test[next.Level, next.Row, next.Col] = next.Depth;
                }
                next = new Cell(cell.Level, cell.Row, cell.Col + 1, cell.Depth + 1);
                if (next.Col < C && lab[next.Level, next.Row, next.Col] != '#' && !visited.Contains(next)) //right
                {
                    queue.Enqueue(next);
                    visited.Add(next);
                    test[next.Level, next.Row, next.Col] = next.Depth;
                }
                next = new Cell(cell.Level, cell.Row, cell.Col - 1, cell.Depth + 1);
                if (next.Col >= 0 && lab[next.Level, next.Row, next.Col] != '#' && !visited.Contains(next)) //left
                {
                    queue.Enqueue(next);
                    visited.Add(next);
                    test[next.Level, next.Row, next.Col] = next.Depth;
                }
                if (lab[cell.Level, cell.Row, cell.Col] == 'U') //floor up
                {
                    next = new Cell(cell.Level + 1, cell.Row, cell.Col, cell.Depth + 1);
                    if (next.Level >= L)
                    {
                        Console.WriteLine(next.Depth);
                        break;
                    }
                    queue.Enqueue(next);
                    visited.Add(next);
                    test[next.Level, next.Row, next.Col] = next.Depth;
                }

                if (lab[cell.Level, cell.Row, cell.Col] == 'D') //floor down
                {
                    next = new Cell(cell.Level - 1, cell.Row, cell.Col, cell.Depth + 1);
                    if (next.Level < 0)
                    {
                        Console.WriteLine(next.Depth);
                        break;
                    }
                    queue.Enqueue(next);
                    visited.Add(next);
                }
            }

            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < R; j++)
                {
                    for (int k = 0; k < C; k++)
                    {
                        Console.Write("{0}".PadRight(7),test[i,j,k]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        private class Cell
        {
            public Cell(int level, int row, int col, int depth)
            {
                this.Level = level;
                this.Row = row;
                this.Col = col;
                this.Depth = depth;
            }

            public int Level { get; set; }

            public int Row { get; set; }

            public int Col { get; set; }

            public int Depth { get; set; }

            public override int GetHashCode()
            {
                return this.Level ^ this.Row ^ this.Col;
            }

            public override bool Equals(object obj)
            {
                var other = obj as Cell;
                return this.Level == other.Level && this.Row == other.Row && this.Col == other.Col;
            }
        }
    }
}
namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class MinesweeperGame
    {
        private const int MAX_POINTS = 35;

        /// <summary>
        /// afgjwhegekwhfkjwehfgjklwehgfklew
        /// </summary>
        /// <param name="args">wegwegwegew</param>
        private static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] field = CreateGameField();
            char[,] mines = PlaceMines();
            int playerPointsCounter = 0;
            bool isBombExploded = false;
            List<PointsRecord> topRecords = new List<PointsRecord>(6);
            int row = 0;
            int column = 0;
            bool isFirstGameSinceLaunch = true;
            bool gameWon = false;

            do
            {
                if (isFirstGameSinceLaunch)
                {
                    Console.WriteLine("Lets play Minesweeper!. Try to find the fields without mines. The command 'top' shows the rankings list, 'restart' starts new game, 'exit' exits the game.");
                    DrawField(field);
                    isFirstGameSinceLaunch = false;
                }

                Console.Write("Please enter row and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= field.GetLength(0) && column <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        DrawRanking(topRecords);
                        break;
                    case "restart":
                        field = CreateGameField();
                        mines = PlaceMines();
                        DrawField(field);
                        isBombExploded = false;
                        isFirstGameSinceLaunch = false;
                        break;
                    case "exit":
                        Console.WriteLine("bye,bye!");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                ProcessPlayerTurn(field, mines, row, column);
                                playerPointsCounter++;
                            }

                            if (MAX_POINTS == playerPointsCounter)
                            {
                                gameWon = true;
                            }
                            else
                            {
                                DrawField(field);
                            }
                        }
                        else
                        {
                            isBombExploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! invalid command\n");
                        break;
                }

                if (isBombExploded)
                {
                    DrawField(mines);
                    Console.Write("\nHrrrrrr! Your game is over with {{0}} points. Enter your nickname: ", playerPointsCounter);
                    string nickName = Console.ReadLine();
                    PointsRecord newRecord = new PointsRecord(nickName, playerPointsCounter);
                    if (topRecords.Count < 5)
                    {
                        topRecords.Add(newRecord);
                    }
                    else
                    {
                        for (int i = 0; i < topRecords.Count; i++)
                        {
                            if (topRecords[i].Points < newRecord.Points)
                            {
                                topRecords.Insert(i, newRecord);
                                topRecords.RemoveAt(topRecords.Count - 1);
                                break;
                            }
                        }
                    }

                    topRecords.Sort((PointsRecord r1, PointsRecord r2) => r2.Name.CompareTo(r1.Name));
                    topRecords.Sort((PointsRecord r1, PointsRecord r2) => r2.Points.CompareTo(r1.Points));
                    DrawRanking(topRecords);

                    field = CreateGameField();
                    mines = PlaceMines();
                    playerPointsCounter = 0;
                    isBombExploded = false;
                    isFirstGameSinceLaunch = true;
                }

                if (gameWon)
                {
                    Console.WriteLine("\nCongratulations! You stepped on 35 cells without exploding!");
                    DrawField(mines);
                    Console.WriteLine("Please enter your nickname, f*cker: ");
                    string playerName = Console.ReadLine();
                    PointsRecord playerPoints = new PointsRecord(playerName, playerPointsCounter);
                    topRecords.Add(playerPoints);
                    DrawRanking(topRecords);
                    field = CreateGameField();
                    mines = PlaceMines();
                    playerPointsCounter = 0;
                    gameWon = false;
                    isFirstGameSinceLaunch = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void DrawRanking(List<PointsRecord> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ranking is empty!\n");
            }
        }

        private static void ProcessPlayerTurn(char[,] field, char[,] mines, int row, int column)
        {
            char minesCount = GetSurroundingMinesCount(mines, row, column);
            mines[row, column] = minesCount;
            field[row, column] = minesCount;
        }

        private static void DrawField(char[,] field)
        {
            int fieldRows = field.GetLength(0);
            int fieldCols = field.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < fieldRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < fieldCols; j++)
                {
                    Console.Write(string.Format("{0} ", field[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceMines()
        {
            int rows = 5;
            int columns = 10;
            char[,] gameField = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> randomValuesList = new List<int>();
            while (randomValuesList.Count < 15)
            {
                Random random = new Random();
                int randomInteger = random.Next(50);
                if (!randomValuesList.Contains(randomInteger))
                {
                    randomValuesList.Add(randomInteger);
                }
            }

            foreach (int randomValue in randomValuesList)
            {
                int col = randomValue / columns;
                int row = randomValue % columns;
                if (row == 0 && randomValue != 0)
                {
                    col--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                gameField[col, row - 1] = '*';
            }

            return gameField;
        }

        private static void InsertMinesCountInFieldBox(char[,] field)
        {
            int col = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char minesCount = GetSurroundingMinesCount(field, i, j);
                        field[i, j] = minesCount;
                    }
                }
            }
        }

        private static char GetSurroundingMinesCount(char[,] mines, int row, int column)
        {
            int minesCount = 0;
            int rows = mines.GetLength(0);
            int cols = mines.GetLength(1);

            if (row - 1 >= 0)
            {
                if (mines[row - 1, column] == '*')
                { 
                    minesCount++; 
                }
            }

            if (row + 1 < rows)
            {
                if (mines[row + 1, column] == '*')
                { 
                    minesCount++; 
                }
            }

            if (column - 1 >= 0)
            {
                if (mines[row, column - 1] == '*')
                { 
                    minesCount++;
                }
            }

            if (column + 1 < cols)
            {
                if (mines[row, column + 1] == '*')
                { 
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (mines[row - 1, column - 1] == '*')
                { 
                    minesCount++; 
                }
            }

            if ((row - 1 >= 0) && (column + 1 < cols))
            {
                if (mines[row - 1, column + 1] == '*')
                { 
                    minesCount++; 
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (mines[row + 1, column - 1] == '*')
                { 
                    minesCount++; 
                }
            }

            if ((row + 1 < rows) && (column + 1 < cols))
            {
                if (mines[row + 1, column + 1] == '*')
                { 
                    minesCount++; 
                }
            }

            return char.Parse(minesCount.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        public class PointsRecord
        {
            /// <summary>
            /// 
            /// </summary>
            public PointsRecord()
            {
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="name"></param>
            /// <param name="points"></param>
            public PointsRecord(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }

            /// <summary>
            /// 
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int Points { get; set; }
        }
    }
}
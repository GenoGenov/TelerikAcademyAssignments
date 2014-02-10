using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11.FallingRocks
{
    class Game
    {
        //Maximum count of rocks falling down at the same time.
        public static int RocksMaxCount = 4;

        //Game speed(changes according to points gained).
        public static int Sleep = 250;

        //Random number generator.
        public static Random generator = new Random();

        //Generator for the number of the falling rocks
        public static int Spawn = generator.Next(1, RocksMaxCount);

        //Rocks shapes
        public static string[] RocksType = new string[] { "^", "@", "*", "&", "+", "-", "%", "$", "#", "!", ".", ";"};

        //List containing all the rocks
        public static List<Rocks> rocks = new List<Rocks>();

        //Initial positions of the dwarf on the screen.Used when starting a new game.
        public static Point InitialPoint = new Point(Console.WindowWidth/2-5, Console.WindowHeight);

        //Creates the dwarf with its appearance and initial point.
        public static Dwarf dwarf = new Dwarf(InitialPoint);

        //This is my idea of a score counter which is visible during the course of the game, but when i add it, other elements of the game such as the dwarf,the rocks,etc
        //start to blink and the game gets really laggy

       // public static void ScoreBox(int s)
      //  {
       //     Console.ForegroundColor = ConsoleColor.Red;
      //      Console.SetCursorPosition(0,0);
      //      Console.Write(s);
      //  }

      //  public static void updateScoreBox(int s)
       // {
      //      ScoreBox(s);
      //  }

        public static void SetConsole()
        {
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.BufferHeight;
        }

        public static void DrawDwarf()
        {
            Console.ForegroundColor = dwarf.color;
            Console.SetCursorPosition(dwarf.player.X, dwarf.player.Y);
            Console.Write(dwarf.looks);
        }

        public static void CreateRock()
        {
            int xCoord = generator.Next(Console.WindowWidth);
            int Type = generator.Next(RocksType.Length);

            //Generates the size of the rock(1,2 or 3).
            int size = generator.Next(1,4);
            int color=generator.Next(1,16);

            //Creates rocks with count [size] and concatenates them(xCoord+i).
            for (int i = size-1; i >=0; i--)
            {
                if (xCoord + i <= Console.WindowWidth-1 )
                {

                    Rocks rock = new Rocks(new Point(xCoord+i, 0), RocksType[Type], (ConsoleColor)color);
                    rocks.Add(rock);
                }
            }
            
        }

        public static void InsertRocks(int n)
        {
            for (int i = 0; i < n; i++)
            {
                CreateRock();
            }
        }

        public static int RemoveRock()
        {
            int n = 0;
            for (int i = rocks.Count-1;i>=0 ; i--)
            {
                if (rocks[i].location.Y > Console.WindowHeight-1)
                {
                    rocks.RemoveAt(i);
                    n++;
                }
            }
            return n;
        }

        public static void DeleteRocks()
        {
            rocks.Clear();
        }

        public static void DrawRock(Rocks rock)
        {
            Console.SetCursorPosition(rock.location.X, rock.location.Y);
            Console.ForegroundColor = rock.color;
                Console.Write(rock.type);
            
        }

        private static bool UpdateRocksLocation()
        {
            foreach (Rocks rock in rocks)
            {
                rock.UpdateLocation();
                if (rock.location.Y == Console.WindowHeight &&
                    rock.location.X >= dwarf.player.X &&
                    rock.location.X <= dwarf.player.X + 2)
                {
                    return false;
                }
            }

            return true;
        }

        public static void DrawRocks()
        {
            foreach (Rocks rock in rocks)
            {
                DrawRock(rock);
            }
        }

        static void Main(string[] args)
        {
            int points = 1;
            SetConsole();
            DrawDwarf();
            InsertRocks(Spawn);
            DrawRocks();

            //The controlls with the keyboard keys are on a different thread, so they are a bit more responsive and dont lag if the user pushes a button for too long
            //Not responsive enough tho...
            Thread t = new Thread(MoveControlls);
            t.Start();
            while (true)
            {
                
                if (UpdateRocksLocation())
                {
                    points+=RemoveRock();
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Game Over!\nYou got {0} points!\nPress \"space\" key for a new game..",points*100);
                    ConsoleKeyInfo keyinfoo;
                    do
                    {
                        keyinfoo = Console.ReadKey();
                        
                    } 
                    while (keyinfoo.Key!=ConsoleKey.Spacebar);

                    dwarf = new Dwarf(InitialPoint);
                    DrawDwarf();
                    DeleteRocks();
                    points = 0;
                    Sleep = 250;
                }

               Console.Clear();
                DrawDwarf();
                DrawRocks();
                Spawn = generator.Next(1, RocksMaxCount);
                InsertRocks(Spawn);
                if (Sleep - points/50 > 150)
                {
                    if(Sleep<200)
                    {
                        if(Sleep<150)
                        {
                            Sleep = Sleep - points / 2000;
                        }
                        Sleep = Sleep - points / 500;
                    }
                    Sleep = Sleep-points/50;
                }
                Thread.Sleep(Sleep);
            }
        }

        static void MoveControlls()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyinfo = Console.ReadKey();
                    if (keyinfo.Key == ConsoleKey.LeftArrow)
                    {
                        dwarf.MoveLeft();
                    }
                    if (keyinfo.Key == ConsoleKey.RightArrow)
                    {
                        dwarf.MoveRight();
                    }
                }
            }
        }

    }
}

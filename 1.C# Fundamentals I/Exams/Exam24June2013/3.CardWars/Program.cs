using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _3.CardWars
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger numberOfGames = int.Parse(Console.ReadLine());
            List<string> playerAhands = new List<string>();
            List<string> playerBhands = new List<string>();

            BigInteger playerAscore = 0;
            BigInteger playerAtemp = 0;
            BigInteger playerBtemp = 0;
            BigInteger playerBscore = 0;
            BigInteger gamesAwon = 0;
            BigInteger gamesBwon = 0;
            bool playerAflag = false;
            bool playerBflag = false;
            do
            {
                playerAhands.Add(Console.ReadLine());
                playerAhands.Add(Console.ReadLine());
                playerAhands.Add(Console.ReadLine());

                playerBhands.Add(Console.ReadLine());
                playerBhands.Add(Console.ReadLine());
                playerBhands.Add(Console.ReadLine());



                numberOfGames--;
            } while (numberOfGames != 0);

            for (int i = 0; i < playerAhands.Count; i++)
            {
                switch (playerAhands.ElementAt(i))
                {
                    case "2": playerAtemp += 10; break;
                    case "3": playerAtemp += 9; break;
                    case "4": playerAtemp += 8; break;
                    case "5": playerAtemp += 7; break;
                    case "6": playerAtemp += 6; break;
                    case "7": playerAtemp += 5; break;
                    case "8": playerAtemp += 4; break;
                    case "9": playerAtemp += 3; break;
                    case "10": playerAtemp += 2; break;
                    case "A": playerAtemp += 1; break;
                    case "J": playerAtemp += 11; break;
                    case "Q": playerAtemp += 12; break;
                    case "K": playerAtemp += 13; break;
                    case "Z": playerAscore = playerAscore * 2; break;
                    case "Y": playerAscore -= 200; break;
                    case "X": playerAflag = true; break;
                }

                switch (playerBhands.ElementAt(i))
                {
                    case "2": playerBtemp += 10; break;
                    case "3": playerBtemp += 9; break;
                    case "4": playerBtemp += 8; break;
                    case "5": playerBtemp += 7; break;
                    case "6": playerBtemp += 6; break;
                    case "7": playerBtemp += 5; break;
                    case "8": playerBtemp += 4; break;
                    case "9": playerBtemp += 3; break;
                    case "10": playerBtemp += 2; break;
                    case "A": playerBtemp += 1; break;
                    case "J": playerBtemp += 11; break;
                    case "Q": playerBtemp += 12; break;
                    case "K": playerBtemp += 13; break;
                    case "Z": playerBscore = playerBscore * 2; break;
                    case "Y": playerBscore -= 200; break;
                    case "X": playerBflag = true; break;
                }
                if ((i + 1) % 3 == 0)
                {
                    if (playerAflag ^ playerBflag)
                    {
                        break;
                    }
                    else if (playerAflag && playerBflag)
                    {
                        playerAscore += 50;
                        playerBscore += 50;
                        playerAflag = false;
                        playerBflag = false;
                    }
                    {
                        if (playerAtemp > playerBtemp)
                        {
                            gamesAwon++;
                            playerAscore += playerAtemp;
                            if (playerAtemp < 0)
                            {
                                playerBscore += playerBtemp;
                            }
                           
                        }
                        else if (playerBtemp > playerAtemp)
                        {
                            gamesBwon++;
                            playerBscore += playerBtemp;
                            if (playerBtemp < 0)
                            {
                                playerAscore += playerAtemp;
                            }
                            
                        }
                        playerBtemp = 0;
                        playerAtemp = 0;

                    }
                }

            }
            if (playerAflag || playerBflag)
            {
                if (playerAflag && !playerBflag)
                {
                    Console.WriteLine("X card drawn! Player one wins the match!");
                }
                else if (!playerAflag && playerBflag)
                {
                    Console.WriteLine("X card drawn! Player two wins the match!");
                }
            }
            else
            {


                if (playerAscore > playerBscore)
                {
                    Console.WriteLine("First player wins!");
                    Console.WriteLine("Score: {0}", playerAscore);
                    Console.WriteLine("Games won: {0}", gamesAwon);
                }
                else if (playerBscore > playerAscore)
                {
                    Console.WriteLine("Second player wins!");
                    Console.WriteLine("Score: {0}", playerBscore);
                    Console.WriteLine("Games won: {0}", gamesBwon);
                }
                else if (playerAscore == playerBscore)
                {
                    Console.WriteLine("It's a tie!");
                    Console.WriteLine("Score: {0}", playerAscore);
                }
            }

        }
    }
}

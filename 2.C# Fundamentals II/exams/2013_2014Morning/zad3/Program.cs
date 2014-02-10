using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            int X = int.Parse(input[0]);
            int Y = int.Parse(input[1]);
            int Z = int.Parse(input[2]);
            

            string firstCommands = Console.ReadLine();
            string secondCommands = Console.ReadLine();
            char[] commands = (firstCommands + secondCommands).ToCharArray();
            int redX = X / 2;
            int redY = Y / 2;
            int redZ = 0;
            string directionRed = "Xneg";

            int blueX = X / 2;
            int blueY = Y / 2;
            int blueZ = Z-1;
            string directionBlue = "Xneg";

            int[, ,] cube = new int[X, Y, Z];

            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    for (int k = 0; k < Z; k++)
                    {
                        if (i == 0 && (j != 0 || k != 0))
                        {
                            cube[i, j, k] = 1;
                        }
                        else
                        {
                            cube[i, j, k] = 0;
                        }
                    }
                }
            }

            for (int i = 0; i < commands.Length-1; i++)
            {
                char first = commands[i];
                char second = commands[i + 1];
                if (cube[redX, redY, redZ]==1 && cube[blueX, blueY, blueZ]==1)
                {
                    Console.WriteLine("Draw");
                    
                    break;
                }
                if (cube[redX, redY, redZ] == 1 && cube[blueX, blueY, blueZ] == 0)
                {
                    Console.WriteLine("BLUE");
                    break;
                }
                if (cube[redX, redY, redZ] == 0 && cube[blueX, blueY, blueZ] == 1)
                {
                    Console.WriteLine("RED");
                    Console.WriteLine(Math.Abs(X/2-redX)+Math.Abs(Y/2-redY)+Math.Abs(0-redZ));
                    break;
                }
                cube[redX, redY, redZ] = 1;
                cube[blueX, blueY, blueZ] = 1;
                
                if (first == 'M')
                {
                    if (directionRed == "Xneg")
                    {
                        if (redX - 1 < 0)
                        {
                            redZ++;
                        }
                        else
                        {
                            redX--;
                        }
                    }
                    else if (directionRed == "Xpos")
                    {
                        if (redX + 1 > X)
                        {
                            redZ++;
                        }
                        else
                        {
                            redX++;
                        }
                    }
                    else if (directionRed == "Ypos")
                    {
                        if (redY + 1 > Y)
                        {
                            redZ++;
                            directionRed = "Zpos";
                        }
                        else
                        {
                            redY++;
                        }
                    }
                    else if (directionRed == "Yneg")
                    {
                        if (redY - 1 < Y)
                        {
                            redZ++;
                            directionRed = "Zpos";
                        }
                        else
                        {
                            redY--;
                        }
                    }
                    else if (directionRed == "Zpos")
                    {
                        if (redZ + 1 > Z)
                        {
                            if (redY == 0)
                            {
                                redY++;
                                directionRed = "Ypos";
                            }
                            else
                            {
                                redY--;
                                directionRed = "Yneg";
                            }
                            
                        }
                        else
                        {
                            redZ++;
                        }
                    }
                    else if (directionRed == "Zneg")
                    {
                        if (redZ - 1 < 0)
                        {
                            redY--;
                            directionRed = "Yneg";
                        }
                        else
                        {
                            redZ--;
                        }
                    }
                }


                if (second == 'M')
                {
                    if (directionBlue == "Xneg")
                    {
                        if (blueX - 1 < 0)
                        {
                            blueZ--;
                        }
                        else
                        {
                            blueX--;
                        }
                    }
                    else if (directionBlue == "Xpos")
                    {
                        if (blueX + 1 > X)
                        {
                            blueZ--;
                        }
                        else
                        {
                            blueX++;
                        }
                    }
                    else if (directionBlue == "Ypos")
                    {
                        if (blueY + 1 > Y)
                        {
                            blueZ--;
                            directionBlue = "Zpos";
                        }
                        else
                        {
                            blueY++;
                        }
                    }
                    else if (directionBlue == "Yneg")
                    {
                        if (blueY - 1 < Y)
                        {
                            blueZ--;
                            directionBlue = "Zpos";
                        }
                        else
                        {
                            blueY--;
                        }
                    }
                    else if (directionBlue == "Zpos")
                    {
                        if (blueZ - 1 < 0)
                        {
                            if (blueY == 0)
                            {
                                blueY++;
                                directionBlue = "Ypos";
                            }
                            else
                            {
                                blueY--;
                                directionBlue = "Yneg";
                            }
                           
                        }
                        else
                        {
                            blueZ--;
                        }
                    }
                    else if (directionBlue == "Zneg")
                    {
                        if (blueZ + 1 > Z)
                        {
                            if (blueY == 0)
                            {
                                blueY++;
                                directionBlue = "Ypos";
                            }
                            else
                            {
                                blueY--;
                                directionBlue = "Yneg";
                            }
                        }
                        else
                        {
                            blueZ++;
                        }
                    }
                }

                if (first == 'L')
                {
                    if (directionRed == "Xneg" || directionRed == "Xpos")
                    {
                        directionRed = "Ypos";
                        i--;
                    }
                    else if (directionRed == "Yneg" || directionRed == "Ypos")
                    {
                        directionRed = "Xneg";
                        i--;
                    }
                    else if (directionRed == "Zneg" || directionRed == "Zpos")
                    {
                        directionRed = "Xneg";
                        i--;
                    }
                }
                if (second == 'L')
                {
                    if (directionBlue == "Xneg" || directionBlue == "Xpos")
                    {
                        directionBlue = "Ypos";
                        i--;
                    }
                    else if (directionBlue == "Yneg" || directionBlue == "Ypos")
                    {
                        directionBlue = "Xneg";
                        i--;
                    }
                    else if (directionBlue == "Zneg" || directionBlue == "Zpos")
                    {
                        directionRed = "Xpos";
                        i--;
                    }
                }
                if (first == 'R')
                {
                    if (directionRed == "Xneg" || directionRed == "Xpos")
                    {
                        directionRed = "Yneg";
                        i--;
                    }
                    else if (directionRed == "Yneg" || directionRed == "Ypos")
                    {
                        directionRed = "Xpos";
                        i--;
                    }
                    else if (directionRed == "Zneg" || directionRed == "Zpos")
                    {
                        directionRed = "Xpos";
                        i--;
                    }
                }
                if (second == 'R')
                {
                    if (directionBlue == "Xneg" || directionBlue == "Xpos")
                    {
                        directionBlue = "Yneg";
                        i--;
                    }
                    else if (directionBlue == "Yneg" || directionBlue == "Ypos")
                    {
                        directionBlue = "Xpos";
                        i--;
                    }
                    else if (directionBlue == "Zneg" || directionBlue == "Zpos")
                    {
                        directionRed = "Xneg";
                        i--;
                    }
                }
            }


        }
    }
}

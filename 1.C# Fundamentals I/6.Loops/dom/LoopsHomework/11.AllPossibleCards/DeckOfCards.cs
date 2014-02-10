//Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). 
//The cards should be printed with their English names. Use nested for loops and switch-case.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.AllPossibleCards
{
    class DeckOfCards
    {
        static void Main(string[] args)
        {
            int[,] deck=new int[13,4];  //13 different kinds of cards(2,3,4...Ace),4 types of cads(spades,clubs,hearts,diamonds)

            for (int i = 0; i < deck.GetLength(0); i++) //deck.GetLength(0) gets the number of elements in the first dimension of the array(in our case - 13).
            {
                
                for (int j = 0; j < deck.GetLength(1); j++)
                {
                    switch (i)
                    {
                        default: break;
                        case 0: Console.Write("Two of "); break;
                        case 1: Console.Write("Three of "); break;
                        case 2: Console.Write("Four of "); break;
                        case 3: Console.Write("Five of "); break;
                        case 4: Console.Write("Six of "); break;
                        case 5: Console.Write("Seven of "); break;
                        case 6: Console.Write("Eight of "); break;
                        case 7: Console.Write("Nine of "); break;
                        case 8: Console.Write("Ten of "); break;
                        case 9: Console.Write("Jack of "); break;
                        case 10: Console.Write("Queen of "); break;
                        case 11: Console.Write("King of "); break;
                        case 12: Console.Write("Ace of "); break;
                    }
                    switch (j)
                    {
                        default:break;
                        case 0: Console.WriteLine("Clubs"); break;
                        case 1: Console.WriteLine("Diamonds"); break;
                        case 2: Console.WriteLine("Hearts"); break;
                        case 3: Console.WriteLine("Spades"); break;
                    }
                }
            }
        }
       
    }
}

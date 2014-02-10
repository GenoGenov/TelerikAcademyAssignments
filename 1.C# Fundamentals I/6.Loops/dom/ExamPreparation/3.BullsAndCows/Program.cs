using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int bulls = int.Parse(Console.ReadLine());
            int cows = int.Parse(Console.ReadLine());

            int cowCompare = 0;
            int bullCompare = 0;
            
            bool Match = false;

            for (int i = 1000; i <= 9999; i++)
            {
                char[] num = number.ToString().ToCharArray();
                cowCompare = 0;
                bullCompare = 0;
                char[] guess = i.ToString().ToCharArray();
                if (guess[0] == '0' || guess[1] == '0' || guess[2] == '0' || guess[3] == '0')
                {
                    continue;
                }
                for (int j = 0; j < guess.Length; j++)
                {
                    if (guess[j] == num[j])
                    {
                        bullCompare++; num[j] = '*'; guess[j] = '#';
                    }
                }
                for (int g = 0; g < guess.Length; g++)
                {
                    for (int h = 0; h < num.Length; h++)
                    {
                        if (guess[g] == num[h])
                        {
                            cowCompare++; num[h] = '&'; 
                            guess[g] = '@';
                        }
                    }  
                }

                if (cows == cowCompare && bulls == bullCompare)
                {
                    Console.Write(i + " "); Match = true;
                }  
            }
            if (!Match)
            {
                Console.WriteLine("No");
            }
        }
    }
}

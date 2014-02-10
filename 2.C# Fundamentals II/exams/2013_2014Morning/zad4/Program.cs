using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad4
{
    class Program
    {
        static string Decrypt(string message, string cypher)
        {
            StringBuilder result = new StringBuilder();
            if (message.Length > cypher.Length)
            {
                int counter = 0;
                for (int i = 0; i < message.Length; i++)
                {
                    if (counter >= cypher.Length)
                    {
                        counter = 0;
                    }
                    char first = message[i];
                    char second = cypher[counter];

                    char final = (char)(((first-'A') ^ (second-'A')) + 'A');
                    result.Append(final);
                    counter++;
                }
            }
            else
            {
                int counter = message.Length;
                for (int i = 0; i < message.Length; i++)
                {
                    char first = message[i];
                    char second = cypher[i];
                    char final = (char)(((first - 'A') ^ (second - 'A')) + 'A');
                    if (counter < cypher.Length)
                    {
                        final = (char)(((final - 'A') ^ (cypher[counter] - 'A')) + 'A');
                        counter++;
                    }
                    result.Append(final);
                }
            }
            return result.ToString();
        }

        static string Decode(string encrypted,out string cypher)
        {
            StringBuilder number = new StringBuilder();
            StringBuilder message = new StringBuilder(encrypted);
            int l = encrypted.Length - 1;
            int num;
            while (int.TryParse(encrypted[l].ToString(),out num))
            {
                number.Insert(0, encrypted[l]);
                message.Remove(l, 1);
                l--;
            }
            num = int.Parse(number.ToString());
            int length = num;
           
            for (int i = message.Length-1; i >= 0; i--)
            {
                if (int.TryParse(message[i].ToString(), out num))
                {
                    number = new StringBuilder();
                    l = i;
                    while (l>=0 && int.TryParse(message[l].ToString(), out num))
                    {
                        number.Insert(0, message[l]);
                        message.Remove(l, 1);
                        l--;
                    }
                    int toAdd = int.Parse(number.ToString());
                    char next=message[l+1];
                    message.Insert(l+1, next.ToString(), toAdd-1);
                    i = l;
                }
            }
            cypher = message.ToString().Substring(message.Length - length, length);
            message.Remove(message.Length - length, length);
            return message.ToString();
        }
        static void Main(string[] args)
        {
            string cypher;
            string input = Console.ReadLine();
            Console.WriteLine(Decrypt(Decode(input, out cypher), cypher));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad4
{
    class Program
    {
        static string Encode(string str)
        {
            StringBuilder b = new StringBuilder();
            int count = 1;
            char prev = str[0];
            for (int i = 1; i < str.Length; i++)
            {
                if (prev == str[i])
                {
                    count++;
                }
                else
                {
                    if (count > 2)
                    {
                        b.Append(count);
                        b.Append(prev);
                    }
                    else
                    {
                        if(count==2)
                        {
                            b.Append(prev, 2);
                        }
                        else
                        {
                            b.Append(prev);
                        }
                    }
                    count = 1;
                }
                prev = str[i];
            }
            if (count > 2)
            {
                b.Append(count);
                b.Append(prev);
            }
            else
            {
                if (count == 2)
                {
                    b.Append(prev, 2);
                }
                else
                {
                    b.Append(prev);
                }
            }
            return b.ToString();
        }
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string cypher = Console.ReadLine();
            StringBuilder encrypted = new StringBuilder();
            if (message.Length > cypher.Length)
            {
                int count = 0;
                for (int i = 0; i < message.Length; i++)
                {
                    if (count >= cypher.Length)
                    {
                        count = 0;
                    }
                    char letter = (char)(((message[i]-'A') ^ (cypher[count]-'A')) + 'A');
                    encrypted.Append(letter);
                    count++;
                }
            }
            else
            {
                int diff = cypher.Length-message.Length;
                int count = message.Length;
                for (int i = 0; i < message.Length; i++)
                {
                    char letter = (char)(((message[i] - 'A') ^ (cypher[i] - 'A')) + 'A');
                    char result = letter;

                    if (diff != 0)
                    {
                        result = (char)(((letter - 'A') ^ (cypher[count] - 'A')) + 'A');
                        count++;
                        diff--;
                    }
                    encrypted.Append(result);       
                }
            }

            Console.WriteLine(Encode(encrypted.ToString()+cypher)+cypher.Length);
        }
    }
}

//Write a program that reverses the words in given sentence.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.ReverseSentence
{
    class RevSen
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String :");
            string text = Console.ReadLine();
            char expressionSign = text[text.Length - 1];
            int flag = 0;
            int index = 0;
            string[] textParts = text.Split(new[] { ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder b = new StringBuilder();
            for (int i = textParts.Length - 1; i >= 0; i--)
            {
                List<string> words = textParts[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> prevwords = textParts[index].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                for (int k = words.Count - 1; k >= 0; k--)
                {
                    if (flag == prevwords.Count)
                    {
                        b.Append(",");
                        flag = 0;
                        index++;
                        prevwords = textParts[index].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    }
                    else
                    {
                        flag++;
                    }
                    b.Append(words[k] + " ");
                }

            }
            Console.WriteLine();
            b.Append(expressionSign);
            Console.WriteLine(b.ToString());

        }

    }
}

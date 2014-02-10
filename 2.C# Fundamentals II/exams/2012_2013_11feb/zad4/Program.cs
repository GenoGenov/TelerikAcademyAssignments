using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> openTags = new List<string>();
            List<string> closingTags = new List<string>();
            List<int> openIndeces = new List<int>();
            List<int> closeIndeces = new List<int>();

            int n = int.Parse(Console.ReadLine());
            List<string> lines = new List<string>();
            for (int i = 0; i < n; i++)
            {
                lines.Add(Console.ReadLine());
            }

            for (int i = 0; i < lines.Count; i++)
            {
                StringBuilder currentLine = new StringBuilder(lines[i]);
                for (int j = 0; j < currentLine.Length; j++)
                {
                    char currentSymbol = currentLine[j];

                    if (currentSymbol == '<')
                    {
                        int endindex = lines[i].IndexOf('>');
                        string tag = lines[i].Substring(j, endindex - j + 1);
                        if(tag.Contains('/'))
                        {
                            if (openTags.Count == closingTags.Count)
                            {
                                closingTags.Add(tag);
                                closeIndeces.Insert(0,j - 1);
                            }
                            else
                            {
                                closingTags.Add(tag);
                                closeIndeces.Add(j - 1);
                            }
                            
                        }
                        else
                        {
                            openTags.Add(tag);
                            openIndeces.Add(j);
                        }
                        currentLine.Remove(j, tag.Length);
                        j--;
                        lines[i] = currentLine.ToString();
                    }
                }
                int index = 0;
                for (int k = openTags.Count - 1; k >= 0; k--)
                {
                    string tag = openTags[k];
                    int length = closeIndeces[index] - openIndeces[k] + 1;
                    if (tag == "<upper>")
                    {                      
                        string piece = lines[i].Substring(openIndeces[k], length);
                        currentLine.Remove(openIndeces[k], length);
                        piece = piece.ToUpper();
                        currentLine.Insert(openIndeces[k], piece);
                        lines[i] = currentLine.ToString();
                    }
                    else if (tag == "<lower>")
                    {
                        string piece = lines[i].Substring(openIndeces[k], length);
                        currentLine.Remove(openIndeces[k], length);
                        piece = piece.ToLower();
                        currentLine.Insert(openIndeces[k], piece);
                        lines[i] = currentLine.ToString();
                    }
                    else if (tag == "<toggle>")
                    {
                        string piece = lines[i].Substring(openIndeces[k], length);
                        currentLine.Remove(openIndeces[k], length);
                        char[] letters = piece.ToCharArray();
                        for (int u = 0; u < letters.Length; u++)
                        {
                            if (char.IsLower(letters[u]))
                            {
                                letters[u] = char.ToUpper(letters[u]);
                            }
                            else if (char.IsUpper(letters[u]))
                            {
                                letters[u] = char.ToLower(letters[u]);
                            }
                        }
                        piece = string.Join("", letters);
                        currentLine.Insert(openIndeces[k], piece);
                        lines[i] = currentLine.ToString();
                    }
                    else if (tag == "<del>")
                    {
                        currentLine.Remove(openIndeces[k], length);
                        lines[i] = currentLine.ToString();
                    }
                    else if (tag == "<rev>")
                    {
                        string piece = lines[i].Substring(openIndeces[k], length);
                        currentLine.Remove(openIndeces[k], length);
                        piece = string.Join("",piece.Reverse());
                        currentLine.Insert(openIndeces[k], piece);
                        lines[i] = currentLine.ToString();
                    }
                    index++;
                }
                openIndeces.Clear();
                openTags.Clear();
                closeIndeces.Clear();
                closingTags.Clear();
                Console.WriteLine(lines[i]);
            }

            
        }
    }
}

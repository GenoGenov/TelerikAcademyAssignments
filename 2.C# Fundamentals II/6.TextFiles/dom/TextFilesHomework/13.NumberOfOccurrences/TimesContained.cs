//Write a program that reads a list of words from a file words.txt and finds how many times each of the words is contained in another file test.txt. The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order. Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.NumberOfOccurrences
{
    class TimesContained
    {
        static void Main(string[] args)
        {
            string content = "..\\..\\Content";
            try
            {
                StreamReader rdr = new StreamReader(content + "\\words.txt");

                Console.WriteLine("Working..");
                string line = rdr.ReadToEnd();

                string[] words = line.Split(new[] { " ", ",", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                rdr.Close();

                rdr = new StreamReader(content + "\\test.txt");

                StreamWriter wrt = new StreamWriter(content + "\\result.txt", false, Encoding.GetEncoding("utf-8"));

                Dictionary<string,int> occurr=new Dictionary<string,int>();

                string line1 = rdr.ReadLine();

                while (line1 != null)
                {
                    List<string> words1 = line1.Split(new[]{' ', ','},StringSplitOptions.RemoveEmptyEntries).ToList();
                    for (int i = words1.Count - 1; i >= 0; i--)
                    {
                        if (words.Contains(words1[i]))
                        {
                            if(occurr.ContainsKey(words1[i]))
                            {
                                occurr[words[i]]++;
                            }
                            else
                            {
                                occurr.Add(words[i],1);
                            }
                        }
                    }
                    line1 = rdr.ReadLine();
                    
                }
                rdr.Close();
               List<KeyValuePair<string, int>> sorted = occurr.ToList();

               sorted.Sort((x,y) =>{return y.Value.CompareTo(x.Value);});

                for (int i = 0; i < sorted.Count; i++)
                {
                    wrt.WriteLine(sorted.ElementAt(i).Key + " " + sorted.ElementAt(i).Value.ToString());
                    wrt.Flush();
                }
                wrt.Close();

                Console.WriteLine("Success!");
			 
			}
            catch (DirectoryNotFoundException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (EndOfStreamException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
               
            }

        }
    }
}

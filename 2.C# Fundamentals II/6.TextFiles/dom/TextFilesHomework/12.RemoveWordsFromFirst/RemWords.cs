//Write a program that removes from a text file all words listed in given another text file. Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.RemoveWordsFromFirst
{
    class RemWords
    {
        static void Main(string[] args)
        {
            //Path to content folder


            string content = "..\\..\\Content";
            try
            {
                StreamReader rdr = new StreamReader(content + "\\first.txt");
                Console.WriteLine("Working..");
                string line = rdr.ReadToEnd();

                string[] words = line.Split(new[] { " ", ",","\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                rdr.Close();


                rdr = new StreamReader(content + "\\final.txt");
                StreamWriter wrt = new StreamWriter(content + "\\temp.txt", false, Encoding.GetEncoding("utf-8"));
                string line1 = rdr.ReadLine();
                while (line1 != null)
                {
                    List<string> words1 = line1.Split(new[]{' ', ','},StringSplitOptions.RemoveEmptyEntries).ToList();
                    StringBuilder b = new StringBuilder();
                    for (int i = words1.Count - 1; i >= 0; i--)
                    {
                        if (words.Contains(words1[i]))
                        {
                            words1.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < words1.Count; i++)
                    {
                        b.Append(words1[i] + " ");
                    }
                    wrt.WriteLine(b.ToString());
                    wrt.Flush();
                    line1 = rdr.ReadLine();
                }
                wrt.Close();
                rdr.Close();
                string name = Path.GetFullPath(content + "\\final.txt");
                File.Delete(content + "\\final.txt");
                File.Move(content + "\\temp.txt", name);

                Console.WriteLine("Success! go check the new file :)");


            }
            catch (DirectoryNotFoundException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch(FileNotFoundException ex)
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
        }
    }
}

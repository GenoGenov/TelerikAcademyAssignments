//Write a program that deletes from a text file all words that start with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _11.DeleteWordsWithPrefix
{
    class DeleteWords
    {
        static void Main(string[] args)
        {
            //Path to content folder

           
            string content = "..\\..\\Content";
            try
            {
                string pattern = @"\stest\w+";
                Regex r = new Regex(pattern);
                StreamReader rdr = new StreamReader(content + "\\first.txt");
                StreamWriter wrt = new StreamWriter(content + "\\final.txt", false, Encoding.GetEncoding("utf-8"));
                Console.WriteLine("Working..");
                string line = rdr.ReadLine();
                while (line != null)
                {
                    string[] words = line.Split(new[]{' ', ','},StringSplitOptions.RemoveEmptyEntries);
                    StringBuilder b=new StringBuilder();
                    foreach (var word in words)
                    {
                        if (word.Length<=4 || word.Substring(0, 4) != "test")
                        {
                            b.Append(word + " ");
                        }
                    }
                   
                    wrt.WriteLine(b.ToString());
                    wrt.Flush();
                    line = rdr.ReadLine();
                }
                wrt.Close();
                rdr.Close();
                
                Console.WriteLine("Success! go check the new file :)");



            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}

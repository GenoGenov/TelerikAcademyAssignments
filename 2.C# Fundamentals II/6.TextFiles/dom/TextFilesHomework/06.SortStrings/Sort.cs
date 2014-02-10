//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SortStrings
{
    class Sort
    {
        static StreamReader rdr;
        static StreamWriter wrt;
        static void Main(string[] args)
        {
            //Path to content folder
            string content = "..\\..\\Content";
            try
            {
                rdr = new StreamReader(content + "\\first.txt", Encoding.GetEncoding("utf-8"));
                wrt = new StreamWriter(content + "\\final.txt", false, Encoding.GetEncoding("utf-8"));

                string line = rdr.ReadLine();
                List<string> input = new List<string>();
                input.Add(line);

                while (line != null)
                {
                    line = rdr.ReadLine();
                    input.Add(line);
                }

                input.Sort();

                for (int i = 0; i < input.Count; i++)
                {
                    wrt.WriteLine(input[i]);
                }
                Console.WriteLine("Success! go check the new file :)");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                rdr.Close();
                wrt.Close();
            }
        }
    }
}

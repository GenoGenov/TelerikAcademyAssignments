//Write a program that concatenates two text files into another text file.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ConcatTwoTXT
{
    class ConcatTXT
    {
        static StreamReader rdr;
        static void Main(string[] args)
        {
            //Path to content folder
            string content = "..\\..\\Content";
            
            StreamWriter wrt = new StreamWriter(content + "\\final.txt");
            using (rdr)
            {
                try
                {
                    

                    Console.WriteLine("Reading first file..");
                    rdr = new StreamReader(content + "\\first.txt");
                    string first = rdr.ReadToEnd();
                    Console.WriteLine("Success!");

                    Console.WriteLine("Reading second file..");
                    rdr = new StreamReader(content + "\\second.txt");
                    string second = rdr.ReadToEnd();
                    Console.WriteLine("Success!");

                    Console.WriteLine("Writing final file..");
                    StringBuilder b = new StringBuilder(first);
                    b.Append("\n" + second);

                    using (wrt)
                    {
                        wrt.WriteLine(b.ToString());
                    }
                    Console.WriteLine("Success!");
                }
                catch (Exception)
                {

                    Console.WriteLine("Error! Possible wrong file path or format!");
                }
                
            }

        }
    }
}

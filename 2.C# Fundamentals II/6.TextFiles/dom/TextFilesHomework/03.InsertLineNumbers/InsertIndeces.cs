//Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.InsertLineNumbers
{
    class InsertIndeces
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
                wrt = new StreamWriter(content + "\\final.txt",false, Encoding.GetEncoding("utf-8"));

                string line = rdr.ReadLine();
                StringBuilder b;
                int i = 1;

                while (line!=null)
                {
                    b=new StringBuilder(line);
                    b.Insert(0, i + ".");
                    i++;
                    line = rdr.ReadLine();
                    wrt.WriteLine(b.ToString());
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
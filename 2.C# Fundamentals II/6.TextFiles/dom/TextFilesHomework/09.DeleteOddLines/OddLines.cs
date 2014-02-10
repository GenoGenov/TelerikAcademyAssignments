//Write a program that deletes from given text file all odd lines. The result should be in the same file.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.DeleteOddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            //Path to content folder

            //Tested and working on 220MB txt file.
            string content = "..\\..\\Content";
            try
            {
                StreamReader rdr = new StreamReader(content + "\\first.txt");
                StreamWriter wrt = new StreamWriter(content + "\\temp.txt", false, Encoding.GetEncoding("utf-8"));
                Console.WriteLine("Working..");
                string line = rdr.ReadLine();
                int i = 1;
                while (line != null)
                {

                    if (i % 2 == 0)
                    {
                        wrt.WriteLine(line);
                        wrt.Flush();
                    }
                    line = rdr.ReadLine();
                    i++;
                }
                wrt.Close();
                rdr.Close();
                string name = Path.GetFullPath(content + "\\first.txt");
                File.Delete(content + "\\first.txt");
                File.Move(content + "\\temp.txt", name);


                Console.WriteLine("Success! go check the new file :)");



            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


    }
}

//Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PrintOddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            //Path to content folder
            string content="..\\..\\Content";
            StreamReader rdr = new StreamReader(content+"\\drundrun.txt");

            using (rdr)
            {
                int lineNumber = 0;
                string line = rdr.ReadLine();
                while (line != null)
                {
                    
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    lineNumber++;
                    line = rdr.ReadLine();
                }

            }
        }
    }
}

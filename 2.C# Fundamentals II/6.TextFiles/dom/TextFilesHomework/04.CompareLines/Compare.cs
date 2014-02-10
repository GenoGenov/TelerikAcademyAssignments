//Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different. Assume the files have equal number of lines.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CompareLines
{
    class Program
    {
        static StreamReader rdr1;
        static StreamReader rdr2;
        static int sameLines = 0;
        static int differentLines = 0;
        static void Main(string[] args)
        {
            string content = "..\\..\\Content";

            try
            {
                rdr1 = new StreamReader(content + "\\first.txt", Encoding.GetEncoding("utf-8"));
                rdr2 = new StreamReader(content + "\\second.txt", Encoding.GetEncoding("utf-8"));

                string line1 = rdr1.ReadLine();
                string line2 = rdr2.ReadLine();
                int i = 1;

                while (line1 != null || line2!=null)
                {
                    if (line1 == line2)
                    {
                        sameLines++;
                    }
                    else
                    {
                        differentLines++;
                    }
                    line1 = rdr1.ReadLine();
                    line2 = rdr2.ReadLine();
                }
                Console.WriteLine("Success! The same lines are {0} and the different are {1} ",sameLines,differentLines);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                rdr1.Close();
                rdr2.Close();
            }
        }
    }
}

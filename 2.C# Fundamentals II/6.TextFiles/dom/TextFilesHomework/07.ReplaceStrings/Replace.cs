//Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.ReplaceStrings
{
    class Replace
    {
         
        static void Main(string[] args)
        {
            //Path to content folder

            //Tested and working on 220MB txt file.
            string content = "..\\..\\Content";
            try
            {
                StreamReader rdr = new StreamReader(content + "\\first.txt");
                StreamWriter wrt = new StreamWriter(content + "\\temp.txt",false,Encoding.GetEncoding("utf-8"));
                Console.WriteLine("Working..");
                string line = rdr.ReadLine();
                while (line != null)
                {
                    
                    wrt.WriteLine(line.Replace("start", "finish"));
                    wrt.Flush();
                    line = rdr.ReadLine();
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

//Modify the solution of the previous problem to replace only whole words (not substrings).

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.ReplaceWholeWords
{
    class Words
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
                while (line != null)
                {
                    
                    //Tested and working! Check the file.Notice the column which is "startstart" all the way down
                    wrt.WriteLine(Regex.Replace(line, @"\bstart\b", "finish"));
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

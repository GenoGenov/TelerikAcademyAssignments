using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FileTree
{

    class Program
    {
        static void Main(string[] args)
        {
            const string RootDir = @"c:\windows";
            Console.WriteLine("Populating folders, please wait..");
            var folder = new Folder(RootDir);
            Console.WriteLine("Done!");

            Console.WriteLine("The sum of the filesizes in folder {0} is {1}", RootDir, Folder.GetFilesSizesSum(folder));

            for (int i = 0; i < folder.ChildFolders.Length; i++)
            {
                if (folder.ChildFolders[i].Name == "c:\\windows\\System32")
                {
                    long size = Folder.GetFilesSizesSum(folder.ChildFolders[i]);
                    Console.WriteLine("The sum of the filesizes in folder {0} is {1}", folder.ChildFolders[i].Name, size);
                }
            }
        }
    }
}

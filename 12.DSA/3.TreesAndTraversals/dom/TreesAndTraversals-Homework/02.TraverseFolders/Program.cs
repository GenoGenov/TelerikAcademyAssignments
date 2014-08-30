using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.TraverseFolders
{
    using System.IO;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var root = @"c:\windows";

            TravereDirectores(root);
        }

        static void TravereDirectores(string root)
        {
            foreach (var directory in Directory.GetDirectories(root))
            {
                

                try
                {
                    var path = Path.Combine(root, directory);
                    var filenames = Directory.GetFiles(path, "*.exe");
                    if (filenames.Length>0)
                    {
                        Console.WriteLine(string.Join(", ", filenames.Select(Path.GetFileName)));
                    }

                    TravereDirectores(path);
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("No access allowed to folder "+directory);
                }
                
               
            }
        }
    }

}

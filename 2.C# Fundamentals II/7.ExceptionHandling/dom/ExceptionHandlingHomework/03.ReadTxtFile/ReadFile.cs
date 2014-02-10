//Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace _03.ReadTxtFile
{
    class ReadFile
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the path to the txt file:");
            string path = Console.ReadLine();
            try
            {
                string txt = File.ReadAllText(path);

                Console.WriteLine("Contents of the file:");
                Console.WriteLine(txt);
            }
            catch (ArgumentException)
            {

                Console.WriteLine("Your path seems to be invalid.Recheck it and try again.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Your path seems to be too long.Recheck it and try again.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The directory you specified cannot be found");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file could not be found");
            }
            catch (IOException)
            {
                Console.WriteLine("The file could not be oppened.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("The file could not be oppened,or the path specified is a directory");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Path is in an invalid format.");
            }
            catch (SecurityException)
            {
                Console.WriteLine("The caller does not have the required permission.");
            }
            
        }
    }
}

//Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores it in the current directory. Find in Google how to download files in C#. Be sure to catch all exceptions and to free any used resources in the finally block.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace _04.DownloadFile
{
    class Down
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            try
            {
                Console.WriteLine("Downloading..");
                client.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "logo.jpg");
                Console.WriteLine("Success!");
            }
            catch (ArgumentNullException)
            {

                Console.WriteLine("The addresss is invalid!");
            }
            catch (WebException)
            {
                Console.WriteLine("The address is invalid,or the file dows not exist!");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The metod has been called simultaneously on multiple threads!");
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}

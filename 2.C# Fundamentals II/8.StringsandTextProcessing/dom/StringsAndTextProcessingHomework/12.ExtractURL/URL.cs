//Write a program that parses an URL address
//and extracts from it the [protocol], [server] and [resource] elements. For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
//[protocol] = "http"
//[server] = "www.devbg.org"
//[resource] = "/forum/index.php"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ExtractURL
{
    class URL
    {
        static void Main(string[] args)
        {
            Console.WriteLine("URL :");
            string url = Console.ReadLine();

            try
            {
                int dotsIndex = url.IndexOf(":");
                int doubleSlashIndex = url.IndexOf("//");

                if (dotsIndex == -1 || doubleSlashIndex == -1)
                {
                    throw new FormatException();
                }

                string protocol = url.Substring(0,dotsIndex);
                string server = url.Substring(doubleSlashIndex + 2, url.IndexOf("/", doubleSlashIndex + 2) - url.IndexOf("//")-2 );
                string resource = url.Substring(protocol.Length+3+server.Length,url.Length-(protocol.Length+3+server.Length));
                Console.WriteLine("Protocol : {0}", protocol);
                Console.WriteLine("Server : {0}",server);
                Console.WriteLine("Resource : {0}",resource);
               
               
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid URL!");
            }

            
        }
    }
}

using System;
using System.Linq;
using _05.StringChecker.Client.StringCheckerService;

namespace _05.StringChecker.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new StringCheckerSvcClient();
            int count = client.CheckStrings("aa", "aaaa");
            Console.WriteLine(count);
            
        }
    }
}

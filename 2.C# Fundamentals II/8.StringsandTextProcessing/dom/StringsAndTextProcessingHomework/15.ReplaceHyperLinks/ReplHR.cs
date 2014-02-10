//Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.ReplaceHyperLinks
{
    class ReplHR
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HTML part");
            string html = Console.ReadLine();

            bool flag = false;
            html = html.Replace("<a href=\"", "[URL=");
            html = html.Replace("</a>", "[/URL]");

            for (int i = 0; i < html.Length-3; i++)
            {
                string sub=html.Substring(i,4);
                if (sub=="[URL")
                {
                    flag = true;
                }
                
                if (flag && html[i]=='"')
                {
                    html=html.Remove(i,1);
                    html=html.Remove(i,1);
                    html=html.Insert(i, "]");
                    flag = false;
                }
            }
            Console.WriteLine();
            Console.WriteLine(html);
        }
    }
}

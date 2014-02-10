//Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25.ExtractFromHTML
{
    class htmlExtract
    {
        static void Main(string[] args)
        {
            string content = "..\\..\\Content";
            string html;
            bool flag = false;
            try
            {
                StreamReader rdr = new StreamReader(content + "\\file.html");
                Console.WriteLine("Working..");
                html = rdr.ReadToEnd();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }
           
            int titleStart = html.IndexOf("<title>") + 7;
            int bodyStart = html.IndexOf("<body>") + 6;

            StringBuilder title = new StringBuilder();
            StringBuilder bodyFinal = new StringBuilder();
            if (html.IndexOf("<title>")!=-1)
            {
                int i = titleStart;
                while (html[i]!='<')
                {
                    title.Append(html[i]);
                    i++;
                }
            }
            string body = html.Substring(bodyStart, html.IndexOf("</body>") - bodyStart);
            for (int i = 0; i < body.Length; i++)
            {
                if (body[i] == '<')
                {
                    flag = true;
                }
                if (body[i] == '>' && flag)
                {
                    flag = false;
                }
                if (!flag)
                {
                    if (body[i] != '>' && body[i]!='\r' && body[i]!='\n')
                    {
                        bodyFinal.Append(body[i]);
                    }
                    else
                    {
                        bodyFinal.Append(' ');
                    }
                }
            }

            for (int i = bodyFinal.Length-2; i >= 0; i--)
            {
                char prev = bodyFinal[i + 1];
                char current = bodyFinal[i];
                if (prev == ' ' && current == ' ')
                {
                    bodyFinal.Remove(i + 1, 1);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Title : {0}",title.ToString());
            Console.WriteLine("Body :");
            Console.WriteLine(bodyFinal.ToString());
        }
    }
}

//Write a program that extracts from given XML file all the text without the tags. 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _10.ExtractTextFromXML
{
    class ExtractXML
    {
        private static string GetTextOnly(XmlNode node)
        {
            if (node == null)
            {
                return String.Empty;
            }

            if (!node.HasChildNodes)
            {
                return node.InnerText;
            }
            else
            {
                StringBuilder b = new StringBuilder();

                foreach (XmlNode n in node.ChildNodes)
                {
                    string text = GetTextOnly(n);
                    b.Append(text+"\n");
                }

                return b.ToString();
            }
        }
        static void Main(string[] args)
        {
            string content = "..\\..\\Content";
            XmlDocument xml = new XmlDocument(); ;
            xml.Load(content + "\\strings.xml");

            string text = GetTextOnly(xml.DocumentElement);

            StreamWriter wrt = new StreamWriter(content + "\\final.txt");

            wrt.WriteLine(text);
            wrt.Close();


        }
    }
}

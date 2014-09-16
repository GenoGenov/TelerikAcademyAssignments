using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikAcademyRSS
{
    using System.IO;
    using System.Net;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "rss.xml";
            WebClient client=new WebClient();
            client.DownloadFile("http://forums.academy.telerik.com/feed/qa.rss", filename);


            var xmlToJSON = JObject.Parse(JsonConvert.SerializeXNode(XDocument.Load(filename)));

            var questionTitles =
                xmlToJSON["rss"]["channel"].Select(
                    x =>
                    new
                        {
                            Channel = x.Parent["title"].ToString(),
                            Questions = x.Parent["item"].Select(i => new
                                                                         {
                                                                             Title = i["title"],
                                                                             Link=i["link"],
                                                                             Category=i["category"]
                                                                         })
                        });
            var RSSData = questionTitles.First();

            Console.WriteLine("Questions in {0}",RSSData.Channel);
            Console.WriteLine();

            var questions = new List<Question>();
            foreach (var question in RSSData.Questions)
            {
                Console.WriteLine(question.Title);
                var questionToJSON = JsonConvert.SerializeObject(question); //This is stupid, but that was the requirement...
                questions.Add(JsonConvert.DeserializeObject<Question>(questionToJSON));
            }

            var html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html>");
            html.AppendLine("<body>");
            html.AppendLine("<ul>");
            foreach (var question in questions)
            {
                html.AppendLine(
                    "<li><a href=" + question.Link + ">" + question.Title + "</a>, Category:" + question.Category
                    + "</li>");
            }
            html.AppendLine("</ul>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            using (var writer=new StreamWriter("rss.html",false,Encoding.UTF8))
            {
                writer.Write(html);
            }

        }
    }
}

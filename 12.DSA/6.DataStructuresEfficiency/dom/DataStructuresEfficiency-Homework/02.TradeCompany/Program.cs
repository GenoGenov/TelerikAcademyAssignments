using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.TradeCompany
{
    class Program
    {
        static Random rand=new Random();
        static void Main(string[] args)
        {
            var company = new TradeCompany();
            for (int i = 0; i < 1000000; i++)
            {
                company.AddArticle(new Article()
                {
                    Barcode = rand.Next(),
                    Title = "product"+i,
                    Price = i,
                    Vendor = "vendor"+i
                });
            }

            foreach (var article in company.GetArticlesInPricerange(6345,6400))
            {
                Console.WriteLine(
                    "Name: {0}, Vendor: {1}, Price: {2}",
                    article.Select(x => x.Title).First(),
                    article.Select(x => x.Vendor).First(),
                    article.Select(x => x.Price).First());
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.TradeCompany
{
    using Wintellect.PowerCollections;

    public class TradeCompany
    {
        private OrderedMultiDictionary<decimal, Article> articles;

        public TradeCompany()
        {
            this.articles=new OrderedMultiDictionary<decimal, Article>(true);
        }

        public List<ICollection<Article>> GetArticlesInPricerange(decimal lower, decimal upper)
        {
            return this.articles.Range(lower, true, upper, true).Select(x=>x.Value).ToList();
        }

        public void AddArticle(Article article)
        {
            this.articles.Add(article.Price, article);
        }
    }
}

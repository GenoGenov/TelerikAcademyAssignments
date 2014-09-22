using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Models
{
    public class Category
    {
        private ICollection<Article> articles;

        public Category()
        {
            this.articles = new HashSet<Article>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Article> Articles
        {
            get
            {
                return this.articles;
            }
            set
            {
                this.articles = value;
            }
        }
    }
}


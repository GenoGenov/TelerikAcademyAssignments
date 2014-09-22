using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Articles.Services.Models
{
    using System.Linq.Expressions;

    using Articles.Models;

    public class CategoryModel
    {
        public static Expression<Func<Category, CategoryModel>> FromCategory
        {
            get
            {
                return
                    c =>
                    new CategoryModel()
                        {
                            Title = c.Title,
                            Id = c.Id,
                            Articles = c.Articles.AsQueryable().Select(ArticleModel.FromArticle).ToList()
                        };
            }
        } 

        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<ArticleModel> Articles { get; set; } 
    }
}

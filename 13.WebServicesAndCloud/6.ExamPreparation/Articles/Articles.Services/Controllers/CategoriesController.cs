using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Articles.Services.Controllers
{
    using Articles.Data;
    using Articles.Services.Models;

    [Authorize]
    public class CategoriesController : ApiController
    {
        private IArticlesData data;

        public CategoriesController(IArticlesData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult GetAllCategories()
        {
            var categories = this.data.Categories.All().Select(CategoryModel.FromCategory);
            return this.Ok(categories);
        }

        [HttpGet]
        public IHttpActionResult GetAllArticles(int id)
        {
            var category = this.data.Categories.Find(id);
            if (category==null)
            {
                return this.BadRequest("No such category exists!");
            }

            var articles = category.Articles.AsQueryable().Select(ArticleModel.FromArticle).ToList();
                articles=articles.OrderByDescending(x => x.DateCreated).ToList();

            return this.Ok(articles);
        }
    }
}

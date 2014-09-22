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
    public class TagsController : ApiController
    {
        private IArticlesData data;

        public TagsController(IArticlesData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult GetAllTags()
        {
            return this.Ok(this.data.Tags.All().Select(TagModel.FromTag).ToList());
        }

        [HttpGet]
        public IHttpActionResult GetAllArticlesByTag(int id)
        {
            var tag = this.data.Tags.Find(id);
            if (tag==null)
            {
                return this.BadRequest("No such tag exists!");
            }
            var articles = tag.Articles.AsQueryable().Select(ArticleModel.FromArticle).ToList();
            articles = articles.OrderByDescending(x => x.DateCreated).ToList();

            return this.Ok(articles);
        }
    }
}

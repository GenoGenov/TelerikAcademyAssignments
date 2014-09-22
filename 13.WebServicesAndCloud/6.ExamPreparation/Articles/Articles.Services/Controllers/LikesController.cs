using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Articles.Services.Controllers
{
    using Articles.Data;
    using Articles.Models;
    using Articles.Services.Models;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public class LikesController : ApiController
    {
        private IArticlesData data;

        public LikesController(IArticlesData data)
        {
            this.data = data;
        }

        [HttpPost]
        public IHttpActionResult LikeArticle(int id)
        {
            var article = this.data.Articles.Find(id);
            if (article==null)
            {
                return this.BadRequest("No such article exists!");
            }

            if (article.Likes.Any(x=>x.AuthorId==User.Identity.GetUserId()))
            {
                return this.BadRequest("That user already liked that!");
            }

            var like = new Like() { AuthorId = User.Identity.GetUserId() };
            article.Likes.Add(like);
            this.data.SaveChanges();
            var model = new LikeModel(like);
            return this.Ok(model);
        }

        [HttpPut]
        public IHttpActionResult UnlikeArticle(int id)
        {
            var article = this.data.Articles.Find(id);
            if (article == null)
            {
                return this.BadRequest("No such article exists!");
            }

            if (article.Likes.All(x => x.AuthorId != User.Identity.GetUserId()))
            {
                return this.BadRequest("That user did not like that!");
            }

            article.Likes.Remove(article.Likes.First(x => x.AuthorId == User.Identity.GetUserId()));
            return this.Ok();
        }
    }
}

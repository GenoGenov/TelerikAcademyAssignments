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
    public class CommentsController : ApiController
    {
        private IArticlesData data;

        public CommentsController(IArticlesData data)
        {
            this.data = data;
        }

        [HttpPost]
        public IHttpActionResult CreateCommentByArticleId(int id, CommentModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            var article = this.data.Articles.Find(id);
            if (article==null)
            {
                return this.BadRequest("No such article exists!");
            }
            var comment = new Comment() { AuthorId = User.Identity.GetUserId(), Content = model.Content };
            article.Comments.Add(comment);
            model.Id = comment.Id;
            model.AuthorId = comment.AuthorId;
            this.data.SaveChanges();
            return this.Ok(model);
        }
    }
}

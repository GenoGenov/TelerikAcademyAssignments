namespace Articles.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Articles.Data;
    using Articles.Models;
    using Articles.Services.Models;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public class ArticlesController : ApiController
    {
        private IArticlesData data;

        public ArticlesController(IArticlesData data)
        {
            this.data = data;
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetAll()
        {
            return this.GetTop10(0, "");
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetPage(int page)
        {
            return this.GetTop10(page, "");
        }

        [HttpGet]
        public IHttpActionResult GetTop10ByCategory(string category)
        {
            return this.GetTop10(0, category);
        }

        [HttpGet]
        public IHttpActionResult GetPageByCategory(string category, int page)
        {
            return this.GetTop10(page, category);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var article = this.data.Articles.Find(id);
            if (article==null)
            {
                return this.BadRequest("No such article exists!");
            }
            return this.Ok(article);
        }

        [HttpPost]
        public IHttpActionResult CreateArticle(ArticleModel model)
        {
            if (!this.ModelState.IsValid)
            {
                //return this.BadRequest(this.ModelState);
            }

            var article = new Article()
            {
                AuthorId = this.User.Identity.GetUserId(),
                Title = model.Title,
                Content = model.Content,
                Category = this.GetCategory(model.Category),
                Tags = this.GetTags(model.Tags),
                DateCreated = DateTime.Now
            };
            this.data.Articles.Add(article);
            this.data.SaveChanges();
            model.Id = article.Id;

            //var location = new Uri(this.Url.Link("DefaultApi", new { id = model.Id }));

            //var response = this.Request.CreateResponse(HttpStatusCode.Created, article);
            //response.Headers.Location = new Uri(this.Url.Link("DefaultApi", new { id = model.Id }));
            //return response;

            return this.Ok(model);
        }

        private IHttpActionResult GetTop10(int page, string category)
        {
            var articlesSorted =
                this.data.Articles.All()
                    .Where(x => string.IsNullOrEmpty(category) || x.Category.Title == category)
                    .Select(ArticleModel.FromArticle)
                    .OrderByDescending(x => x.DateCreated)
                    .Skip(page * 10)
                    .Take(10);
            return this.Ok(articlesSorted);
        }



        private ICollection<Tag> GetTags(ICollection<string> tags)
        {
            var result = new List<Tag>();
            var alltags = this.data.Tags.All().ToList();
            foreach (var tagName in tags)
            {
                var tag = alltags.FirstOrDefault(x => x.Name == tagName);
                result.Add(tag ?? new Tag() { Name = tagName });
            }

            return result;
        }

        private Category GetCategory(string name)
        {
            var category = this.data.Categories.All().FirstOrDefault(x => x.Title == name);

            return category ?? new Category() { Title = name };
        }
    }
}
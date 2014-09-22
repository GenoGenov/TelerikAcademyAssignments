using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Articles.Services.Models
{
    using System.Linq.Expressions;

    using Articles.Models;

    public class LikeModel
    {

        public LikeModel(Like like)
        {
            this.Article = like.Article.Title;
            this.Author = like.AuthorId;
            this.Id = like.Id;
        }

        public LikeModel()
        {
            
        }

        public static Expression<Func<Like, LikeModel>> FromLike
        {
            get
            {
                return l => new LikeModel() { Id = l.Id, Article = l.Article.Title, Author = l.AuthorId };
            }
        } 

        public int Id { get; set; }

        public string Article { get; set; }

        public string Author { get; set; }
    }
}
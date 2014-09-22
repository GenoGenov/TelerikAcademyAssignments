using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Articles.Services.Models
{
    using System.Linq.Expressions;

    using Articles.Models;

    public class ArticleModel
    {
        public static Expression<Func<Article, ArticleModel>> FromArticle
        {
            get
            {
                return
                    a =>
                    new ArticleModel()
                        {
                            Id = a.Id,
                            Category = a.Category.Title,
                            Content = a.Content,
                            Title = a.Title,
                            DateCreated = a.DateCreated,
                            Likes = a.Likes.AsQueryable().Select(LikeModel.FromLike).ToList(),
                            Tags = a.Tags.AsQueryable().Select(x=>x.Name).ToList(),
                            Comments = a.Comments.AsQueryable().Select(CommentModel.FromComment).ToList()
                        };
            }
        } 

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<string> Tags { get; set; }

        public ICollection<LikeModel> Likes { get; set; } 

        public ICollection<CommentModel> Comments { get; set; } 
    }

}
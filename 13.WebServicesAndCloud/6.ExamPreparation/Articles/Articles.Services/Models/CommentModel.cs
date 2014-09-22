using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Articles.Services.Models
{
    using System.Linq.Expressions;

    using Articles.Models;

    public class CommentModel
    {
        public static Expression<Func<Comment, CommentModel>>  FromComment
        {
            get
            {
                return c => new CommentModel() { Id = c.Id, AuthorId = c.AuthorId, Content = c.Content };
            }
        } 

        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }
    }
}

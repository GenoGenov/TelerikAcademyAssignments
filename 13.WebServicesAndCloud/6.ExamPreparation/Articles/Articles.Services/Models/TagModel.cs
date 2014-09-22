using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Articles.Services.Models
{
    using System.Linq.Expressions;

    using Articles.Models;

    public class TagModel
    {
        public static Expression<Func<Tag, TagModel>>  FromTag
        {
            get
            {
                return t => new TagModel() { Id = t.Id, Name = t.Name };
            }
        } 

        public int Id { get; set; }

        public string Name { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Articles.Services.Models
{
    using System.Linq.Expressions;

    using Articles.Models;

    public class AlertModel
    {
        public static Expression<Func<Alert, AlertModel>> FromAlert
        {
            get
            {
                return a => new AlertModel() { Id = a.Id, Content = a.Content };
            }
        } 

        public int Id { get; set; }

        public string Content { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVisitors_DB.models
{
    using System.ComponentModel.DataAnnotations;

    public class VisitorsCount
    {
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }
    }
}
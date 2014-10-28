using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVisitors_DB.data
{
    using System.Data.Entity;

    using AppVisitors_DB.Migrations;
    using AppVisitors_DB.models;

    public class VisitorsDbContext:DbContext
    {
        public VisitorsDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VisitorsDbContext,Configuration>());
        }

        public IDbSet<VisitorsCount> Visitors { get; set; } 
    }
}
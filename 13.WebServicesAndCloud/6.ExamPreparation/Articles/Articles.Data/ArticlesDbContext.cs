namespace Articles.Data
{
    using System.Data.Entity;

    using Articles.Data.Migrations;
    using Articles.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ArticlesDbContext : IdentityDbContext<User>
    {
        public ArticlesDbContext()
            : base("ArticlesConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArticlesDbContext, Configuration>());
        }

        public virtual IDbSet<Article> Articles { get; set; }
 
        public virtual IDbSet<Category> Categories { get; set; }
 
        public virtual IDbSet<Comment> Comments { get; set; }
 
        public virtual IDbSet<Like> Likes { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }

        public virtual IDbSet<Alert> Alerts { get; set; }

        public static ArticlesDbContext Create()
        {
            return new ArticlesDbContext();
        }
    }
}
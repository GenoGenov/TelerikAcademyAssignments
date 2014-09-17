namespace Artists.Data
{
    using System.Data.Entity;

    using Artists.Data.Migrations;
    using Artists.Models;

    public class ArtistsDbContext : DbContext
    {
        public ArtistsDbContext()
            : base("artistsConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArtistsDbContext, Configuration>());
        }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public IDbSet<Album> Albums { get; set; }
    }
}
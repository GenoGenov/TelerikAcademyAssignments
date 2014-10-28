namespace DbFileUpload.data
{
    using System.Data.Entity;

    using DbFileUpload.Migrations;
    using DbFileUpload.models;

    public class FilesDbContext:DbContext
    {
        public FilesDbContext()
            : this("DefaultConnection")
        {
            
        }

        public FilesDbContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FilesDbContext, Configuration>());
        }

        public IDbSet<UploadedFile> Files { get; set; } 
    }
}
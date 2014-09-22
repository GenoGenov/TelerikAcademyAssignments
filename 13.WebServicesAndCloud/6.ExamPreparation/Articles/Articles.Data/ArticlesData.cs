using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Data
{
    using System.Data.Entity;

    using Articles.Data.Repositories;
    using Articles.Models;

    public class ArticlesData:IArticlesData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public ArticlesData(DbContext context)
        {
            this.repositories=new Dictionary<Type, object>();
            this.context = context;
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public IRepository<Article> Articles
        {
            get
            {
                return this.GetRepository<Article>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Like> Likes
        {
            get
            {
                return this.GetRepository<Like>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                return this.GetRepository<Tag>();
            }
        }

        public IRepository<Alert> Alerts
        {
            get
            {
                return this.GetRepository<Alert>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data
{
    using System.Data.Entity;

    using BookStore.Models;

    public class BookstoreDBContext:DbContext
    {
        public BookstoreDBContext(string connectionString)
            : base(connectionString)
        {
            
        }

        public BookstoreDBContext():base("Bookstore")
        {
            
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }
 
        public IDbSet<Review> Reviews { get; set; } 
    }
}

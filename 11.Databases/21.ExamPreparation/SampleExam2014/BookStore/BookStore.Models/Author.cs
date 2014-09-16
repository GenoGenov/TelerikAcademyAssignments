using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Author
    {

        private ICollection<Book> books;

        private ICollection<Review> reviews; 

        public Author()
        {
            this.books=new HashSet<Book>();
            this.reviews=new HashSet<Review>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Book> Books
        {
            get
            {
                return this.books;
            }
            set
            {
                this.books = value;
            }
        }

        public ICollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }
            set
            {
                this.reviews = value;
            }
        }
    }
}

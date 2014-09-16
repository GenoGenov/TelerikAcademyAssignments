using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public virtual Author Author { get; set; }

        public string Content { get; set; }

        public virtual Book Book { get; set; }
    }
}

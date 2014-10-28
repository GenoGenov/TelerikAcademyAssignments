using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2.SimpleChat.models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        public Message()
        {
            this.Created = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime Created { get; set; }
    }
}
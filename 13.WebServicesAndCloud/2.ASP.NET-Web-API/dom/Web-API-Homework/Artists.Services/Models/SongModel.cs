using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Artists.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    using Artists.Models;

    using Microsoft.Ajax.Utilities;

    public class SongModel
    {

        [Required]
        public string Title { get; set; }

        public string Genre { get; set; }

        public static SongModel FromSong(Song song)
        {
            return new SongModel() { Title = song.Title, Genre = song.Genre };
        }
    }
}
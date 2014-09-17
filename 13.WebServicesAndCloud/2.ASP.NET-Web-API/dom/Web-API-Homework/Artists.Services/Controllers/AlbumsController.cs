using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Artists.Services.Controllers
{
    using Artists.Data;
    using Artists.Models;

    public class AlbumsController : ApiController
    {
        private static ArtistsDbContext db = new ArtistsDbContext();

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(db.Albums);
        }

        public IHttpActionResult ById(int id)
        {
            var artist = db.Albums.FirstOrDefault(x => x.Id == id);

            if (artist == null)
            {
                return this.BadRequest("No such artist exists!");
            }

            return this.Ok(artist);
        }

        [HttpPost]
        public IHttpActionResult Create(Album album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            db.Albums.Add(album);
            db.SaveChanges();
            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddArtist(int albumId, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            var album = db.Albums.FirstOrDefault(x => x.Id == albumId);
            if (album==null)
            {
                return this.BadRequest("No such album exists");
            }

            album.Artists.Add(artist);
            db.SaveChanges();
            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddSong(int albumId, Song song)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            var album = db.Albums.FirstOrDefault(x => x.Id == albumId);
            if (album == null)
            {
                return this.BadRequest("No such album exists");
            }
            album.Songs.Add(song);
            db.SaveChanges();
            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(int id, string name)
        {
            var artist = db.Albums.FirstOrDefault(x => x.Id == id);

            if (artist == null)
            {
                return this.BadRequest("No such artist exists!");
            }

            artist.Title = name;
            db.SaveChanges();
            return this.Ok(artist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var album = db.Albums.FirstOrDefault(x => x.Id == id);

            if (album == null)
            {
                return this.BadRequest("No such artist exists!");
            }

            db.Albums.Remove(album);
            return this.Ok();
        }
    }
}

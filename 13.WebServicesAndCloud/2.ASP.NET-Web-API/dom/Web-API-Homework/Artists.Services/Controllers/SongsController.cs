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
    using Artists.Services.Models;

    public class SongsController : ApiController
    {
        private static ArtistsDbContext db = new ArtistsDbContext();

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(db.Songs.Select(SongModel.FromSong));
        }

        public IHttpActionResult ById(int id)
        {
            var song = db.Songs.FirstOrDefault(x => x.Id == id);

            if (song == null)
            {
                return this.BadRequest("No such artist exists!");
            }

            return this.Ok(SongModel.FromSong(song));
        }

        [HttpPost]
        public IHttpActionResult Create(Song song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            db.Songs.Add(song);
            db.SaveChanges();
            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddArtist(int songId, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            var song = db.Songs.FirstOrDefault(x => x.Id == songId);
            if (song==null)
            {
                return this.BadRequest("No such song exists!");
            }

            song.Artists.Add(artist);
            db.SaveChanges();
            return this.Ok();

        }

        [HttpPut]
        public IHttpActionResult Update(int id, string name)
        {
            var song = db.Songs.FirstOrDefault(x => x.Id == id);

            if (song == null)
            {
                return this.BadRequest("No such artist exists!");
            }

            song.Title = name;
            db.SaveChanges();
            return this.Ok(SongModel.FromSong(song));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var song = db.Songs.FirstOrDefault(x => x.Id == id);

            if (song == null)
            {
                return this.BadRequest("No such artist exists!");
            }

            db.Songs.Remove(song);
            return this.Ok();
        }
    }
}

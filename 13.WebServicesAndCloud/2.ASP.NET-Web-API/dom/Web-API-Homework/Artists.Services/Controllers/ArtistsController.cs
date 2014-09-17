namespace Artists.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Artists.Data;
    using Artists.Models;

    public class ArtistsController : ApiController
    {
        private static ArtistsDbContext db = new ArtistsDbContext();

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(db.Artists);
        }

        public IHttpActionResult ById(int id)
        {
            var artist = db.Artists.FirstOrDefault(x => x.Id == id);

            if (artist == null)
            {
                return this.BadRequest("No such artist exists!");
            }

            return this.Ok(artist);
        }

        [HttpPost]
        public IHttpActionResult Create(Artist artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            db.Artists.Add(artist);
            db.SaveChanges();
            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(int id, string name)
        {
            var artist = db.Artists.FirstOrDefault(x => x.Id == id);

            if (artist == null)
            {
                return this.BadRequest("No such artist exists!");
            }

            artist.Name = name;
            db.SaveChanges();
            return this.Ok(artist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var artist = db.Artists.FirstOrDefault(x => x.Id == id);

            if (artist == null)
            {
                return this.BadRequest("No such artist exists!");
            }

            db.Artists.Remove(artist);
            return this.Ok();
        }
    }
}
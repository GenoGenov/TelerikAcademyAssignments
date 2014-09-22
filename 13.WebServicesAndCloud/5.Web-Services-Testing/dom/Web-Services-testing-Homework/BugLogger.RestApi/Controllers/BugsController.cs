using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BugLogger.DataLayer;
using BugLogger.Repositories;

namespace BugLogger.RestApi.Controllers
{
    public class BugsController : ApiController
    {
        private IRepository<Bug> repo;

        public BugsController() : this(new DbBugsRepository(new BugLoggerDbContext()))
        {
        }

        public BugsController(IRepository<Bug> repository)
        {
            this.repo = repository;
        }

        [EnableCors("*", "*", "*")]
        public IQueryable<Bug> GetAll()
        {
            var bugs = this.repo.All();
            return bugs;
        }

        public IHttpActionResult GetAfterDate(string date)
        {
            try
            {
                var afterDate = DateTime.Parse(date);
                var bugs = this.repo.All().Where(x => x.LogDate >= afterDate);
                return this.Ok(bugs);
            }
            catch (FormatException e)
            {
                return this.BadRequest("aa");
            }
        }

        public IHttpActionResult GetWithStatus(string type)
        {
            Status status;

            if (!Enum.TryParse<Status>(type, out status))
            {
                return BadRequest();
            }
            else
            {
                var bugs = this.repo.All().Where(x => x.Status == status);
                return Ok(bugs);
            }
        }

        public IQueryable<Bug> GetCount(int count)
        {
            return this.GetAll().Take(count);
        }

        public HttpResponseMessage PostBug(Bug bug)
        {
            if (string.IsNullOrEmpty(bug.Text))
            {
                var ex = new ArgumentException();
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            bug.LogDate = DateTime.Now;
            bug.Status = Status.Pending;
            this.repo.Add(bug);
            this.repo.Save();

            var response = this.Request.CreateResponse(HttpStatusCode.Created, bug);
            response.Headers.Location = new Uri(this.Url.Link("DefaultApi", new { id = bug.Id }));
            return response;
        }
    }
}
namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class StudentsController : ApiController
    {
        private IStudentSystemData data;

        public StudentsController()
            : this(new StudentsSystemData())
        {
        }

        public StudentsController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.data.Students.All().Select(StudentModel.FromStudent));
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var student = this.data.Students.All().FirstOrDefault(x => x.StudentIdentification == id);
            if (student==null)
            {
                return this.BadRequest("No such student exists!");
            }
            return this.Ok(StudentModel.TransformStudent(student));
        }

        [HttpPost]
        public IHttpActionResult Create(StudentModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            var student = new Student()
                              {
                                  StudentIdentification = model.StudentIdentification,
                                  AdditionalInformation = model.AdditionalInformation,
                                  FirstName = model.FirstName,
                                  LastName = model.LastName,
                                  Level = model.Level
                              };
            this.data.Students.Add(student);
            this.data.SaveChanges();
            return this.Ok(StudentModel.TransformStudent(student));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var student = this.data.Students.All().FirstOrDefault(x => x.StudentIdentification == id);
            if (student==null)
            {
                return this.BadRequest("No such student exists!");
            }

            this.data.Students.Delete(student);
            this.data.SaveChanges();
            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]string firstName)
        {
            var student = this.data.Students.All().FirstOrDefault(x => x.StudentIdentification == id);
            if (student == null)
            {
                return this.BadRequest("No such student exists!");
            }

            student.FirstName = firstName;
            this.data.SaveChanges();
            return this.Ok(StudentModel.TransformStudent(student));
        }
    }
}
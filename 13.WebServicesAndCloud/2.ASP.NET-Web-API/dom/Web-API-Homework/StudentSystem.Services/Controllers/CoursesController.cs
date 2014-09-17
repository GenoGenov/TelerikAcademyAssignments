using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentSystem.Services.Controllers
{
    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class CoursesController : ApiController
    {
        private IStudentSystemData data;

        public CoursesController():this(new StudentsSystemData())
        {
            
        }

        public CoursesController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.data.Courses.All());
        }

        [HttpGet]
        public IHttpActionResult ByName(string name)
        {
            var course = this.data.Courses.All().FirstOrDefault(x => x.Name == name);
            if (course==null)
            {
                return this.BadRequest("There is no such course!");
            }

            return this.Ok(CourseModel.TransformCourse(course));
        }

        [HttpPost]
        public IHttpActionResult Create(CourseModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var course = new Course() { Description = model.Description, Name = model.Name, };
            this.data.Courses.Add(course);
            this.data.SaveChanges();
            return this.Ok(CourseModel.TransformCourse(course));
        }

        public IHttpActionResult AddStudent(string courseName, StudentModel model)
        {

            var course = this.data.Courses.All().FirstOrDefault(x => x.Name == courseName);
            if (course == null)
            {
                return this.BadRequest("There is no such course!");
            }

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
            
            course.Students.Add(student);
            this.data.SaveChanges();
            return this.Ok(CourseModel.TransformCourse(course));
        }
    }
}

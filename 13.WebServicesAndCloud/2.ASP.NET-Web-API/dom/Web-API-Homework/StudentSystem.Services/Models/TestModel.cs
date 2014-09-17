using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Services.Models
{
    using System.Linq.Expressions;

    using Microsoft.Ajax.Utilities;

    using StudentSystem.Models;

    public class TestModel
    {

        public static Expression<Func<Test, TestModel>> FromTest
        {
            get
            {
                return
                    t =>
                    new TestModel()
                        {
                            Course = CourseModel.TransformCourse(t.Course),
                            CourseId = t.CourseId,
                            Id = t.Id,
                            Students = t.Students.AsQueryable().Select(StudentModel.FromStudent).ToList()
                        };
            }
        } 

        public int Id { get; set; }

        public virtual ICollection<StudentModel> Students { get; set; }

        public virtual Guid CourseId { get; set; }

        public virtual CourseModel Course { get; set; }
    }
}
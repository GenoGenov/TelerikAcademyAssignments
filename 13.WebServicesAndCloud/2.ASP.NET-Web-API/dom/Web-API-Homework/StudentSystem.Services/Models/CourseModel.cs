using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Services.Models
{
    using System.Linq.Expressions;

    using Microsoft.Ajax.Utilities;

    using StudentSystem.Models;

    public class CourseModel
    {
        public static Expression<Func<Course, CourseModel>> FromCourse
        {
            get
            {
                return
                    c =>
                    new CourseModel()
                        {
                            Description = c.Description,
                            Id = c.Id,
                            Name = c.Name,
                            Students = c.Students.AsQueryable().Select(StudentModel.FromStudent).ToList()
                        };
            }
        }

        public static CourseModel TransformCourse(Course c)
        {
            if (c==null)
            {
                return null;
            }
            return new CourseModel()
                       {
                           Description = c.Description,
                           Id = c.Id,
                           Name = c.Name,
                           Students = c.Students.ToList().Select(StudentModel.TransformStudent).ToList()
                       };
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<StudentModel> Students { get; set; } 

        public ICollection<Homework> Homeworks { get; set; } 
    }
}
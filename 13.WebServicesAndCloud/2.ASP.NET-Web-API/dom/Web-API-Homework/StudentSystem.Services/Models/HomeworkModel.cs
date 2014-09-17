using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Services.Models
{
    using System.Linq.Expressions;

    using Microsoft.Ajax.Utilities;

    using StudentSystem.Models;

    public class HomeworkModel
    {

        public static Expression<Func<Homework, HomeworkModel>> FromHomework
        {
            get
            {
                return
                    h =>
                    new HomeworkModel()
                        {
                            Id = h.Id,
                            Course = CourseModel.TransformCourse(h.Course),
                            Student = StudentModel.TransformStudent(h.Student),
                            CourseId = h.CourseId,
                            FileUrl = h.FileUrl,
                            StudentIdentification = h.StudentIdentification,
                            TimeSent = h.TimeSent
                        };
            }
        }

        public int Id { get; set; }

        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        public int StudentIdentification { get; set; }

        public virtual StudentModel Student { get; set; }

        public Guid CourseId { get; set; }

        public virtual CourseModel Course { get; set; }
    }
}
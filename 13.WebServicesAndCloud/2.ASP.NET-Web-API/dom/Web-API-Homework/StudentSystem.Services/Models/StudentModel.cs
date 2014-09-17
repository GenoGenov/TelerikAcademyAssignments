namespace StudentSystem.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using StudentSystem.Models;

    public class StudentModel
    {
        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return
                    student =>
                    new StudentModel()
                        {
                            AdditionalInformation = student.AdditionalInformation,
                            Assistant = TransformStudent(student.Assistant),
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            Level = student.Level,
                            StudentIdentification = student.StudentIdentification
                        };
            }
        }

        public static StudentModel TransformStudent(Student student)
        {
            if (student==null)
            {
                return null;
            }
            return new StudentModel()
                       {
                           AdditionalInformation = student.AdditionalInformation,
                           Assistant = TransformStudent(student.Assistant),
                           FirstName = student.FirstName,
                           LastName = student.LastName,
                           Level = student.Level,
                           StudentIdentification = student.StudentIdentification
                       };
        }

        public int StudentIdentification { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public int Level { get; set; }

        public StudentModel Assistant { get; set; }

        public StudentInfo AdditionalInformation { get; set; }
    }
}
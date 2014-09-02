namespace StudentSystemDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystem.Model;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var db = new StudentSystemContext();
            using (db)
            {
                db.Courses.Add(
                    new Course
                        {
                            Description = "C# course",
                            Students = new List<Student>() { new Student { Name = "Pencho", Number = 13 } }
                        });
                db.SaveChanges();

                var students = db.Students.Select(x => new
                {
                    x.Name,
                    x.Courses
                });
                foreach (var student in students)
                {
                    Console.WriteLine(student.Name + " participates in " + string.Join(",", student.Courses.Select(x => x.Description)));
                }
            }

            
        }
    }
}

namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }
            context.Courses.Add(
                new Course
                    {
                        Description = "Seed course",
                        Materials = new Material[] { new Material { Description = "Video" } },
                        Homeworks =
                            new Homework[]
                                {
                                    new Homework
                                        {
                                            Contet =
                                                "Write 5000 tasks in 2 days and finish your team project on time for a chance to move to the next course.",
                                            TimeSent = DateTime.Now
                                        }
                                },
                        Students = new List<Student>() { new Student { Name = "Gencho", Number = 33, } }
                    });
            context.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data
{
    using System.Data.Entity;

    using StudentSystem.Data.Migrations;
    using StudentSystem.Model;
    public class StudentSystemContext:DbContext
    {
        public StudentSystemContext()
            : base("StudentSystemMSSQL")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
        }
        public IDbSet<Course> Courses { get; set; }
 
        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Material> Materials { get; set; }

        public IDbSet<Student> Students { get; set; }
    }
}

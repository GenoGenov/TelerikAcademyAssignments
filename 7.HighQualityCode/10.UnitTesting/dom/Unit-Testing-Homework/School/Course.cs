namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Course
    {
        private ICollection<Student> students;

        private string name;

        public Course(string name, ICollection<Student> students)
        {
            this.Name = name;
            this.Students = students;
        }

        public ICollection<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("the students list cannot be null");
                }

                this.students = new List<Student>(value);
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("the course name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public void AddStudent(School school, Student student)
        {
            if (school.Courses.Single(x => x.Equals(this)) != null)
            {
                this.students.Add(student);
            }
        }
    }
}
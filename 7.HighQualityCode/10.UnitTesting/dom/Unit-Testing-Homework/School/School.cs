namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class School
    {
        private ICollection<Course> courses;

        private string name;

        public School(string name, ICollection<Course> courses)
        {
            this.Name = name;
            this.Courses = courses;
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
                    throw new ArgumentException("the school name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public ICollection<Course> Courses
        {
            get
            {
                return new List<Course>(this.courses);
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("the students list cannot be null");
                }

                if (this.courses == null)
                {
                    this.courses = new List<Course>();
                }

                this.AddCourses(value.ToArray());
            }
        }

        public void AddCourse(Course course)
        {
            if (this.Courses.Any(x => x.Name == course.Name))
            {
                throw new ArgumentException("the school already contains a course with that name!");
            }

            foreach (var student in course.Students)
            {
                if (this.StudentExists(student.Number))
                {
                    throw new ArgumentException(string.Format("The course {0} contains a student with a number, which is already in use!", course.Name));
                }
            }

            this.courses.Add(course);
        }

        public void AddCourses(params Course[] courses)
        {
            foreach (var course in courses)
            {
                this.AddCourse(course);
            }
        }

        public bool StudentExists(int number)
        {
            foreach (var item in this.courses)
            {
                if (item.Students.Any(x => x.Number == number))
                {
                    return true;
                }
            }

            return false;
        }

        public void AddStudentToCourse(Student student, string courseName)
        {
            if (this.StudentExists(student.Number))
            {
                throw new ArgumentException("A student with the same number already exists!");
            }

            this.courses.Single(x => x.Name == courseName).AddStudent(this, student);
        }
    }
}
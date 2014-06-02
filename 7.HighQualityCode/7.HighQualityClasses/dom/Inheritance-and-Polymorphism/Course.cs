namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Course
    {
        private string name;

        private IList<string> students;

        public Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The course name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public string TeacherName { get; set; }

        public IList<string> Students
        {
            get
            { 
                return new List<string>(this.students);
            }

            set
            {
                if (value == null)
                {
                    this.students = new List<string>();
                }
                else
                {
                    this.students = new List<string>(value);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0} {{ Name = ", this.GetType().Name);
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return string.Format("{{ {0} }}", string.Join(", ", this.Students));
            }
        }
    }
}
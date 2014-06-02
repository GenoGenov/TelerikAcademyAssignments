namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        public LocalCourse(string name, string teacherName, IList<string> students) : base(name, teacherName, students)
        {
            this.Lab = null;
        }

        public LocalCourse(string name, string teacherName, IList<string> students, string lab) : base(name, teacherName, students)
        {
            this.Lab = lab;
        }

        public LocalCourse(string name) : this(name, null, null)
        {
        }

        public string Lab { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
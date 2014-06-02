namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string name, string teacherName, IList<string> students, string town) : base(name, teacherName, students)
        {
            this.Town = town;
        }

        public OffsiteCourse(string name, string teacherName, IList<string> students) : base(name, teacherName, students)
        {
            this.Town = null;
        }

        public OffsiteCourse(string name) : this(name, null, null)
        {
        }
        
        public string Town { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
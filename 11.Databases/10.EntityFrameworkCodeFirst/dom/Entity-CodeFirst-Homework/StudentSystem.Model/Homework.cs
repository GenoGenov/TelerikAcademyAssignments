using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Model
{
    public class Homework
    {
        private ICollection<Course> courses;

        private ICollection<Student> students; 
        public Homework()
        {
            this.courses=new HashSet<Course>();
            this.students=new HashSet<Student>();
        }
        public int HomeworkId { get; set; }

        public string Contet { get; set; }

        public DateTime TimeSent { get; set; }

        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }

    }
}

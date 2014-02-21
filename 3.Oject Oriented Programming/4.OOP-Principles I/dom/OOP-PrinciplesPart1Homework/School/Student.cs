using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student : Person
    {
        private int id;

        #region Constructors

        public Student(string name, List<string> comments, int id) : base(name, comments)
        {
            this.Id = id;
        }

        public Student(string name, int id) : base(name)
        {
            this.Id = id;
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Class number must be bigger than 0");
                }
                id = value;
            }
        }

        #endregion

        #region Public Methods

        public void ChangeId(int value, Class c)
        {
            this.Id = value;
            c.ValidateStudentEntries();
        }

        #endregion
    }
}
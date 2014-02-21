using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public class Student : Human
    {
        #region Fields

        private double grade;

        #endregion

        #region Constructors

        public Student(string first, string last, double grade) : base(first, last)
        {
            this.Grade = grade;
        }

        protected Student(string first, string last) : base(first, last)
        {
        }

        #endregion

        #region Properties

        public double Grade
        {
            get { return grade; }
            set
            {
                if (value < 2 || value > 6)
                {
                    Console.WriteLine("grade must be bigger or equal to 2 and less than 6");
                }
                grade = value;
            }
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentOperations
{
    public class Student
    {
        public string FirstName { get;private set; }

        public string LastName { get; private set; }

        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("the age must be bigger than zero");
                }
                age = value;
            }
        }

        public Student(string fName, string lName,int age)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Age = age;
        }
    }
}

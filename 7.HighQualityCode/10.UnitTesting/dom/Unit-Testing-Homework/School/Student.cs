namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Student
    {
        private int number;
        private string name;

        public Student(int number, string name)
        {
            this.Number = number;
            this.Name = name;
        }

        public int Number
        {
            get
            {
                return this.number;
            }

            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentException("the student number cannot be less than 10000 or more than 99999");
                }

                this.number = value;
            }
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
                    throw new ArgumentException("the student name cannot be null or empty!");
                }

                this.name = value;
            }
        }
    }
}
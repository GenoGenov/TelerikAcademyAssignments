using System;
using System.Linq;

namespace Person
{
    public class Person
    {
        private string name;
        private int? age;

        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
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
                    throw new ArgumentException("Name cannot be null");
                }
                this.name = value;
            }
        }

        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age must be bigger than 0 or null");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format("Name: {0}\nAge:{1}", this.Name, this.Age != null ? this.Age.ToString() : "Not Specified");

            return result;
        }
    }
}
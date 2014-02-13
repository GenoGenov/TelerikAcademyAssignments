using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupStudentsByGroupName
{
    internal class Student
    {
        private string groupName;
        private string name;

        public Student(string name, string grpName)
        {
            this.GroupName = grpName;
            this.Name = name;
        }

        public string GroupName
        {
            get { return groupName; }
            set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException("Group name must be atleast 4 symbols");
                }
                groupName = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException("Student name must be atleast 4 symbols");
                }
                name = value;
            }
        }
    }
}
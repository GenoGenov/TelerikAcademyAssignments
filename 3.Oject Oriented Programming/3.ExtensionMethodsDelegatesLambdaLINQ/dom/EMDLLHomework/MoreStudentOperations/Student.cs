using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreStudentOperations.DepartmentNames;

namespace MoreStudentOperations
{
    internal class Student
    {
        private string email;
        private string firstName;
        private int fn;
        private Group group;
        private int groupNumber;
        private string lastName;
        private List<int> marks;
        private string tel;

        public Student()
        {
        }

        public Student(string firstName, string lastName, int fn, string tel, string email, int groupNumber,
            List<int> marks, Group gr)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = fn;
            this.Tel = tel;
            this.Email = email;
            this.GroupNumber = groupNumber;
            this.Marks = marks;
            this.group = gr;
            EqualizeGroupNumbers();
        }

        public Group Group
        {
            get { return @group; }
            set { @group = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("the first name must be atleast 3 symbols long");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("the last name must be atleast 3 symbols long");
                }
                lastName = value;
            }
        }

        public int FN
        {
            get { return fn; }
            set
            {
                if (value < 100000 || value > 999999)
                {
                    throw new ArgumentException("the facoulty number must be exactly 6 symbols long");
                }
                fn = value;
            }
        }

        public string Tel
        {
            get { return tel; }
            set
            {
                if (value.Any(d => !char.IsDigit(d) && d != '/' && d != '+'))
                {
                    throw new ArgumentException("the telephone number must be atleast 3 symbols long");
                }
                tel = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (value.Length < 3 || !value.Contains('@'))
                {
                    throw new ArgumentException("the email must be atleast 3 symbols long and contain the \"@\" symbol");
                }
                email = value;
            }
        }

        public List<int> Marks
        {
            get
            {
                int[] list = new int[marks.Count];
                marks.CopyTo(list);
                return list.ToList();
            }
            set
            {
                if (value.Any(i => i < 2 || i > 6))
                {
                    throw new ArgumentException("a mark may not be less than 2 and bigger than 6");
                }
                marks = value.ToList();
            }
        }

        public int GroupNumber
        {
            get { return groupNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("the group number must be bigger than 0");
                }
                groupNumber = value;
            }
        }

        #region Overrides

        public override string ToString()
        {
            string str =
                string.Format("Name: " + this.FirstName + " " + this.lastName + "\nFN: " + this.FN + "\nTel: " +
                              this.Tel + "\nEmail: " + this.Email + "\nGroupNumber: " + this.GroupNumber + "\n");
            var result = new StringBuilder(str);
            result.AppendLine("Marks:");
            for (int i = 0; i < this.Marks.Count; i++)
            {
                result.Append(this.Marks[i].ToString() + " ");
            }
            result.AppendLine();
            result.AppendLine();
            return result.ToString();
        }

        #endregion

        private void EqualizeGroupNumbers()
        {
            if (!this.group.GroupNumber.HasValue)
            {
                this.group.GroupNumber = this.GroupNumber;
            }
        }
    }
}
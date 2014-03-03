using System;
using System.Linq;
using Student.Enums;

namespace Student
{
    public class Student : ICloneable, IComparable<Student>
    {
        #region Fields
        
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private int course;
        
        #endregion
        
        #region Constructors
        
        public Student(string firstName, string middleName, string lastName, string ssn, string permanentAddress, string mobilePhone, string email, int course, Speciality specialty, Facoulty facoulty, University university)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Speciality = specialty;
            this.Facoulty = facoulty;
            this.University = university;
        }
        
        #endregion
        
        #region Properties
        
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be null or empty.");
                }
                this.firstName = value;
            }
        }
        
        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Middle name cannot be null or empty.");
                }
                this.middleName = value;
            }
        }
        
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty.");
                }
                this.lastName = value;
            }
        }
        
        public string Ssn
        {
            get
            {
                return this.ssn;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("SSN cannot be null or empty.");
                }
                this.ssn = value;
            }
        }
        
        public string PermanentAddress
        {
            get
            {
                return this.permanentAddress;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Permanent address cannot be null or empty.");
                }
                this.permanentAddress = value;
            }
        }
        
        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Mobile phone cannot be null or empty.");
                }
                this.mobilePhone = value;
            }
        }
        
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Email cannot be null or empty.");
                }
                this.email = value;
            }
        }
        
        public int Course
        {
            get
            {
                return this.course;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Year must be greater than 0.");
                }
                this.course = value;
            }
        }
        
        public Speciality Speciality { get; private set; }
        
        public Facoulty Facoulty { get; private set; }
        
        public University University { get; private set; }
        
        #endregion
        
        #region Overrides
        
        public int CompareTo(Student other)
        {
            String thisName = String.Format("{0}{1}{2}",
                this.FirstName, this.MiddleName, this.LastName);
            
            String otherName = String.Format("{0}{1}{2}",
                other.FirstName, other.MiddleName, other.LastName);
            
            int result = String.Compare(thisName, otherName);
            
            if (result != 0)
            {
                return result;
            }
            else
            {
                return String.Compare(this.Ssn, other.Ssn);
            }
        }
        
        public Student Clone()
        {
            Student cloned = new Student(this.FirstName,this.MiddleName,this.LastName,this.Ssn,this.PermanentAddress,this.MobilePhone,this.Email,this.Course,this.Speciality,this.Facoulty,this.University);
            
            return cloned;
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int result = this.firstName.GetHashCode() ^
                             this.middleName.GetHashCode() ^
                             this.lastName.GetHashCode() ^
                             this.ssn.GetHashCode() ^
                             this.permanentAddress.GetHashCode() ^
                             this.mobilePhone.GetHashCode() ^
                             this.email.GetHashCode() ^
                             this.course.GetHashCode() ^
                             this.Speciality.GetHashCode() ^
                             this.Facoulty.GetHashCode() ^
                             this.University.GetHashCode();
                return result;
            }
        }
        
        public override bool Equals(object obj)
        {
            Student st = obj as Student;
            if (st == null)
            {
                return false;
            }
            
            return st.FirstName == this.FirstName &&
                   st.MiddleName == this.MiddleName &&
                   st.LastName == this.LastName &&
                   st.Ssn == this.Ssn;
        }
        
        public override string ToString()
        {
            return String.Format("Student:\r\nName: {0} {1} {2}\r\nSSN: {3}\r\nPermanent address: {4}\r\nMobile phone: {5}\r\nEmail: {6}\r\nYear: {7}\r\nSpeciality: {8}\r\nUniversity: {9}\r\nSchool: {10}", this.FirstName, this.MiddleName, this.LastName, this.Ssn, this.PermanentAddress, this.MobilePhone, this.Email, this.Course, this.Speciality, this.University, this.Facoulty);
        }
        
        object ICloneable.Clone()
        {
            return this.Clone();
        }
        
        #endregion
        
        #region Operators
        
        public static bool operator ==(Student a, Student b)
        {
            return Student.Equals(a, b);
        }
        
        public static bool operator !=(Student a, Student b)
        {
            return !(Student.Equals(a, b));
        }
    
        #endregion
    }
}
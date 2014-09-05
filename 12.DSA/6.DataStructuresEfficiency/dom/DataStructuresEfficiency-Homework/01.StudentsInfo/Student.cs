namespace _01.StudentsInfo
{
    using System;

    public class Student : IComparable<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(Student other)
        {
            var lastNameCompareResult = String.Compare(this.LastName, other.LastName, StringComparison.Ordinal);
            if (lastNameCompareResult == 0)
            {
                return String.Compare(this.FirstName, other.FirstName, StringComparison.Ordinal);
            }

            return lastNameCompareResult;
        }
    }
}
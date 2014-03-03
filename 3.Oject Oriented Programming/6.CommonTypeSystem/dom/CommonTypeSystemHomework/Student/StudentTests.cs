using System;
using System.Collections.Generic;
using System.Linq;
using Student.Enums;

namespace Student
{
    public class StudentTests
    {
        private static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student("Harry","James","Harington","12345","Sunny Ave.","023143543","Harry@ymail.com",1999,Speciality.Physics,Facoulty.Science,University.Yale),
                new Student("Alex","Penchev","Penchev","032532","Pencho Road,46,CA","0342543","penchev@abv.bg",1892,Speciality.Physics,Facoulty.Science,University.UniversityOfCalifornia),
                new Student("Ronny","James","Dio","2325","Huntington Road 1332","2352839523","Ronny@gmail.com",1991,Speciality.PoliticalScience,Facoulty.Management,University.Harvard)
            };

            foreach (var student in students)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }

            Console.WriteLine();

            foreach (var student in students)
            {
                Console.WriteLine(student.GetHashCode());
            }

            Console.WriteLine();

            students.Sort((x,y) => x.CompareTo(y));

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            var newStudent = students[1].Clone();

            newStudent.Ssn = "NewSSN";
            newStudent.Email = "newMail";
            Console.WriteLine(newStudent);
            Console.WriteLine(students[1]);
        }
    }
}

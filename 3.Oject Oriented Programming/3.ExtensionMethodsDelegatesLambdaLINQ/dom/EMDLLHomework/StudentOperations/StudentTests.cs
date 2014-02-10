using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentOperations
{
    internal class StudentTests
    {
        public static Student[] CheckNames(IEnumerable<Student> students)
        {
            return (from student in students
                    where String.Compare(student.FirstName, student.LastName, StringComparison.Ordinal) <= 0
                    select student).ToArray();
        }

        private static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student("Pesho","Minkov",22),
                new Student("Gencho","Peshev",21),
                new Student("Haralambi","Genchev",47),
                new Student("Anatoli","Kurtev",55)
            };

            //Names Query
            foreach (var student in CheckNames(students))
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }

            //Age Query
            var ageQuery = from student in students
                where student.Age >= 18 && student.Age <= 24
                select student.FirstName + " " + student.LastName;

            Console.WriteLine(string.Join(",",ageQuery));


        }
    }
}
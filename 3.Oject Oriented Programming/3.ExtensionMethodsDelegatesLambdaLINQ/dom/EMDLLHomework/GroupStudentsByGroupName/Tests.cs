using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupStudentsByGroupName
{
    internal class Tests
    {
        private static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student("Pesho", "Leon"),
                new Student("Gosho", "Marble"),
                new Student("Joro", "Blade"),
                new Student("Mincho", "Shark"),
                new Student("Valio", "Marble"),
                new Student("Kolio", "Leon"),
                new Student("Pencho", "Shark"),
                new Student("Jivko", "Blade")
            };

            var grouped = from st in students
                group st by st.GroupName
                into Groups
                select Groups;

            foreach (var x in grouped)
            {
                Console.WriteLine("Group: " + x.Key);
                foreach (var student in x)
                {
                    Console.WriteLine(student.Name);
                }
            }

            ////using extension methods

            //var grouped = students.GroupBy(x => x.GroupName);
            //foreach (var st in grouped)
            //{
            //    Console.WriteLine("Group: "+st.Key);
            //    foreach (var student in st)
            //    {
            //        Console.WriteLine(student.Name);
            //    }
            //}
        }
    }
}
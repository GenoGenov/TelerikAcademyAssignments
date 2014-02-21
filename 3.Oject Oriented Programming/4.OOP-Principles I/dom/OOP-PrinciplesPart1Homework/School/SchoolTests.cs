using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class SchoolTests
    {
        private static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student("Gosho", 1),
                new Student("Mincho", 2)
            };
            var teachers = new List<Teacher>
            {
                new Teacher("Tisho"),
                new Teacher("Misho")
            };

            var classes = new List<Class>
            {
                new Class("math", students, teachers),
            };

            var disciplines = new List<Discipline>
            {
                new Discipline("Discrete Structures", 1, 1)
            };

            School sc = new School(classes);


            Console.WriteLine(string.Join(",", sc.GetClassNames()));


            sc.AddClass(new Class("pesho", new List<Student>(), new List<Teacher>()));
            Console.WriteLine(string.Join(",", sc.GetClassNames()));
            sc.GetClassById("pesho").AddComment("V tozi klas uchim visual Pesho++");
            sc.GetClassById("pesho").PrintComments();
            classes.ElementAt(0).GetStudentByID(1).ChangeId(5, classes.ElementAt(0));
            sc.GetClassById("math").GetTeacherByName("Tisho").AddDiscipline(disciplines[0]);
            sc.GetClassById("math")
                .GetTeacherByName("Tisho")
                .GetDisciplineByName("Discrete Structures")
                .AddComment("Abandon hope all ye who enter here");
            disciplines[0].PrintComments();
        }
    }
}
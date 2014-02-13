using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MoreStudentOperations.DepartmentNames;

namespace MoreStudentOperations
{
    internal class StudentTests
    {
        private static void Main(string[] args)
        {
            Group it = new Group(DepartmentName.IT);
            Group mat = new Group(DepartmentName.Mathematics);
            Group phys = new Group(DepartmentName.Physics);

            List<Group> groups = new List<Group> {it, mat, phys};

            var students = new List<Student>
            {
                new Student("Anatoli", "Brejnev", 122317, "02/23311", "anatolkata_mega_lice@gmail.com", 2,
                    new List<int> {4, 2}, it),
                new Student("Hristo", "Markov", 356223, "033533332", "batko_vi@abv.bg", 1,
                    new List<int> {4, 2, 5, 5, 5}, mat),
                new Student("Haralambi", "Iordanov", 123433, "09884657685", "hypermanqk@gmail.com", 7,
                    new List<int> {3, 3, 5, 5}, it),
                new Student("Bat", "Venzi", 124024, "08543643433", "asdfghjk@gmail.com", 4, new List<int> {4, 5, 3, 5},
                    mat),
                new Student("Koicho", "Koichev", 655789, "02/932543", "koichoto87@abv.bg", 2,
                    new List<int> {2, 2, 2, 2}, it),
                new Student("Joro", "Mihailov", 211213, "+35962922456", "anatolkata_mega_lice@abv.bg", 5,
                    new List<int> {5, 5, 2, 2, 2}, it),
                new Student("Boiko", "Borisov", 324551, "0899999999", "bat_boiko@gmail.com", 4, new List<int> {3, 4, 5},
                    it),
                new Student("Cvetan", "Plqskov", 212440, "0935982396", "plqskov@gmail.com", 6,
                    new List<int> {5, 3, 3, 3}, mat),
                new Student("Ernesto", "Guevara", 575637, "+6218925344", "simply_CHE@abv.bg", 9,
                    new List<int> {5, 5, 5, 6, 6}, phys),
                new Student("Bob", "Marley", 344652, "+7822893522345", "smoke_every_day@abv.bg", 2,
                    new List<int> {2, 2, 2, 2, 4}, it),
                new Student("Nicolas", "Cage", 908531, "08883492734", "IAmEverywhere@gmail.com", 8,
                    new List<int> {5, 5, 5, 6, 6}, phys),
                new Student("Orlando", "Blum", 346649, "02/2345634", "IAmGay@gmal.com", 3,
                    new List<int> {2, 2, 2, 2, 2, 2}, it),
                new Student("Steve", "Jobs", 678606, "02356853434", "BowBeforeMe@gmail.com", 5,
                    new List<int> {4, 4, 6, 6, 6, 6, 6}, it),
                new Student("Steve", "Vozniak", 213653, "08283542", "the_jew@abv.bg", 6, new List<int> {5, 5, 5}, it),
                new Student("Adolf", "Hitler", 342606, "023534634334", "meine_campf@abv.bg", 7,
                    new List<int> {6, 6, 6, 2, 2}, phys),
                new Student("Napoleon", "Bonaparte", 236806, "023623353", "iAmShort@abv.bg", 1,
                    new List<int> {6, 6, 6, 6, 5}, mat),
                new Student("Slavi", "Trifonov", 457642, "02/023533", "slavishow@abv.bg", 1,
                    new List<int> {4, 2, 4, 5, 2}, it),
                new Student("Albert", "Einstein", 346806, "034654323235", "relativity@abv.bg", 9,
                    new List<int> {6, 6, 6, 6, 6, 6, 6}, phys),
                new Student("Niels", "Bohr", 234606, "02353253", "quantum@gmail.com", 8, new List<int> {6, 6, 6, 6, 6},
                    phys),
                new Student("Stephen", "Hawking", 664206, "0235235268", "black_hole@gmail.com", 2,
                    new List<int> {6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6}, phys)
            };

            //ALL QUIERIES
            //JUST UNCOMMENT THE ONE U NEED


            //Take with group=2 and sort by name

            //var filteredSorted = from student in students
            //    where student.GroupNumber == 2
            //    orderby student.FirstName
            //    select student;
            //Console.WriteLine(string.Join("", filteredSorted));


            //Take with group=2 and sort by name with lambda

            //var fSorted = students.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName);
            //Console.WriteLine(string.Join("", fSorted));


            //Extract all with emails in abv

            //var filtered = from student in students
            //    where student.Email.ToLower().EndsWith("abv.bg")
            //    select student;
            //Console.WriteLine(string.Join("", filtered));


            //extract all with phones in Sofia

            //var filtered = from x in students
            //               where x.Tel.StartsWith("02/")
            //               select x;
            //Console.WriteLine(string.Join("", filtered));


            //select all with atleast 1 mark 6

            //var filtered = from x in students
            //               where x.Marks.Contains(6)
            //               select new
            //               {
            //                   x.FirstName,
            //                   x.Marks,
            //               };
            //foreach (var student in filtered)
            //{
            //    Console.WriteLine(student.FirstName);
            //    Console.WriteLine("Marks:");
            //    Console.WriteLine(string.Join(",", student.Marks));
            //    Console.WriteLine();
            //}


            //extract all with exactly two marks 2 using lambda

            //var filtered = students.Where(x => x.Marks.Count(i => i == 2) == 2).Select(x => new { x.FirstName, x.Marks });
            //foreach (var x in filtered)
            //{
            //    Console.WriteLine("Name:");
            //    Console.WriteLine(x.FirstName);
            //    Console.WriteLine("Marks:");
            //    Console.WriteLine(string.Join(",", x.Marks));
            //    Console.WriteLine();
            //}


            //extract all enrolled in 2006

            //var filtered = students.Where(x => x.FN%10 == 6 && (x.FN/10)%10 == 0);
            //Console.WriteLine(string.Join("",filtered));


            //extract all from mathematics department using join operator

            //var extracted = from student in students
            //    join grp in groups on student.Group.Department equals grp.Department
            //    where grp.Department==DepartmentName.Mathematics
            //    select new
            //    {
            //        student.FirstName,
            //        student.Group.Department,
            //    };
            //Console.WriteLine(string.Join("\n",extracted));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentsInfo
{
    using System.IO;

    using Wintellect.PowerCollections;

    class Program
    {
        private static void ParseStudentsInfo(ref SortedDictionary<string, OrderedBag<Student>> studentsInfo, string path)
        {
            var reader = new StreamReader(path);
            using (reader)
            {
                var line = reader.ReadLine();
                while (line!=null)
                {
                    var entry = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    var course = entry[2].Trim();
                    var firstName = entry[0].Trim();
                    var lastName = entry[1].Trim();
                    if (!studentsInfo.ContainsKey(course))
                    {
                        studentsInfo[course]=new OrderedBag<Student>();
                    }
                    studentsInfo[course].Add(new Student() { FirstName = firstName, LastName = lastName });
                    line = reader.ReadLine();
                }
                
            }
        }
        static void Main(string[] args)
        {
            var studentsInfo = new SortedDictionary<string, OrderedBag<Student>>();
            ParseStudentsInfo(ref studentsInfo, "..//..//Students.txt");

            foreach (var course in studentsInfo)
            {
                var studentNames = course.Value.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToArray();
                Console.WriteLine(
                    "{0}: {1}",
                    course.Key,
                    string.Join(",", studentNames.Select(x => x.FirstName + " " + x.LastName)));
            }
        }
    }
}

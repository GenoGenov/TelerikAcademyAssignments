using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Workers
{
    public class WorkerTests
    {
        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var students = new List<Student>
            {
                new Student("Mincho", "Minchev", 4.20),
                new Student("Angel", "Angelov", 6.00),
                new Student("Albert", "Einstein", 6.00),
                new Student("Kolio", "Kolev", 3.25),
                new Student("Peio", "Hristov", 4.66),
                new Student("Jeko", "Jekov", 3.50),
                new Student("Boiko", "Boichev", 5.10),
                new Student("Poncho", "Borisov", 2.00),
                new Student("Penko", "Penchev", 2.85),
                new Student("Qnko", "Vasilev", 4.00)
            };

            var sorted = students.OrderBy(x => x.Grade);
            Console.WriteLine(string.Join("\n", sorted.Select(x => new {x.FirstName, x.Grade})));

            var workers = new List<Worker>
            {
                new Worker("Mincho", "Anchev", 432, 9),
                new Worker("Angel", "Fagelov", 263, 7),
                new Worker("Albert", "Albertov", 1846, 12),
                new Worker("Kolio", "Molev", 724, 3),
                new Worker("Peio", "Dristov", 235, 8),
                new Worker("Jeko", "Mekov", 723, 7),
                new Worker("Boiko", "Foichev", 511, 4),
                new Worker("Poncho", "Norisov", 334, 5),
                new Worker("Penko", "Senchev", 812, 10),
                new Worker("Qnko", "Kasilev", 900, 3)
            };

            var sortedMoney = workers.OrderByDescending(x => x.MoneyPerHour());
            Console.WriteLine(string.Join("\n",
                sortedMoney.Select(
                    x =>
                        new
                        {
                            x.FirstName,
                            x.WeekSalary,
                            x.WorkHoursPerDay,
                            MoneyPerHour = x.MoneyPerHour().ToString("F2")
                        })));

            var merged = sorted.Concat<Human>(sortedMoney);

            var mergedSorted = merged.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

            Console.WriteLine(string.Join("\n", mergedSorted.Select(x => new {x.FirstName, x.LastName})));
        }
    }
}
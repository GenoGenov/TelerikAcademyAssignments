using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPerformance_Homework
{
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            var db = new TelerikAcademyEntities();

            #region Task1

            //Bad Query
            //var employees = db.Employees;
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(
            //        "{0} - {1} - {2}",
            //        employee.FirstName + " " + employee.LastName,
            //        employee.Department.Name,
            //        employee.Address.Town.Name);
            //}

            //Good Queries
            //var employees =
            //    db.Employees.Select(
            //        x =>
            //        new
            //            {
            //                Name = x.FirstName + " " + x.LastName,
            //                Department = x.Department.Name,
            //                Town = x.Address.Town.Name
            //            });

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine("{0} - {1} - {2}", employee.Name, employee.Department, employee.Town);
            //}

            //Another good query
            //foreach (var employee in db.Employees.Include("Department").Include("Address.Town"))
            //{
            //    Console.WriteLine(
            //        "{0} - {1} - {2}",
            //        employee.FirstName + " " + employee.LastName,
            //        employee.Department.Name,
            //        employee.Address.Town.Name);
            //}
            #endregion

            #region Task2
            //Bad Query
            var sw = new Stopwatch();
            sw.Start();
            var employees =
                db.Employees.ToList()
                  .Select(x => x.Address)
                  .ToList()
                  .Select(x => x.Town)
                  .ToList()
                  .Where(x => x.Name == "Sofia");
            sw.Stop();
            Console.WriteLine("The bad query completed in {0}",sw.Elapsed);

            //BetterQuery
            sw.Restart();
            var betterEmployees = db.Employees.Where(x => x.Address.Town.Name == "Sofia").Select(x => x.Address.Town.Name).ToList();
            Console.WriteLine("The better query completed in {0}",sw.Elapsed);
            sw.Restart();

            //Best query
            var bestEmployeesTowns = db.Towns.Select(x => x.Name).ToList();
            Console.WriteLine("The best query completed in {0}",sw.Elapsed);
            sw.Stop();

            #endregion
        }
    }
}

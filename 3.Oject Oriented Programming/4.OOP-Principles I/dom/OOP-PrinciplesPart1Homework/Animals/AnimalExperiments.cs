using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animals.Enums;

namespace Animals
{
    public class AnimalExperiments
    {
        static void Main(string[] args)
        {
            var animals =new List<Animal>
            {
                new Dog("d1", 4, Sex.Male),
                new Cat("c1", 2, Sex.Female),
                new Frog("f1", 12, Sex.Female),
                new Kitten("k1", 1),
                new Tomcat("t1", 3),
            };

            foreach (var animal in animals)
            {
                animal.Identify();
            }

            Console.WriteLine("Average age of all animals is {0}",Animal.CalcAge(animals));

            Console.WriteLine("Using LINQ:");

            var grouped = from animal in animals
                group animal by animal.GetType().Name
                into kinds
                select new
                {
                    Kind = kinds.Key,
                    AverageAge = kinds.Average(x => x.Age),
                };

            foreach (var x in grouped)
            {
                Console.WriteLine(x);
            }
        }
    }
}

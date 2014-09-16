using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysStore.RandomGenerator
{
    using global::RandomGenerator;

    using ToyStore.Data;

    class Program
    {
        static void Main(string[] args)
        {
            var db = new ToyStoreEntities();
            db.Configuration.AutoDetectChangesEnabled = false;
            var rnd = RandomGenerator.GetInstance;
            var uniqueStrings = rnd.GenerateUniqueStringsWithRandomLength(5, 25, 50);

            int index = 0;
            foreach (var uniqueString in uniqueStrings)
            {
                db.Manufacturers.Add(
                    new Manufacturer()
                        {
                            Name = uniqueString,
                            Country = rnd.GenerateRandomStringWithRandomLength(5, 25),
                        });
                index++;

                if (index%100==0)
                {
                    db.SaveChanges();
                }
            }

            db.SaveChanges();

            index = 0;
            for (int i = 0; i < 100; i++)
            {
                db.Categories.Add(new Category() { Name = rnd.GenerateRandomStringWithRandomLength(5, 20) });

                index++;

                if (index % 100 == 0)
                {
                    db.SaveChanges();
                }
            }

            db.SaveChanges();

            index = 0;
            for (int i = 0; i < 100; i++)
            {
                int minYears = rnd.GenerateRandomNumber(1, 10);
                int maxYears = rnd.GenerateRandomNumber(minYears + 2, 25);
                db.AgeRanges.Add(
                    new AgeRange() { MinYears = minYears, MaxYears = rnd.IsInFavour(30) ? (int?)null : maxYears });

                index++;

                if (index % 100 == 0)
                {
                    db.SaveChanges();
                }
            }

            db.SaveChanges();

            index = 0;
            Console.WriteLine("Adding toys");
            for (int i = 0; i < 100000; i++)
            {
                var ageRangeIds = db.AgeRanges.Select(x => x.Id).ToList();
                var manufacturerIds = db.Manufacturers.Select(x => x.Id).ToList();
                var categoryIds = db.Categories.Select(x => x.Id).ToList();

                var categoriesCount = rnd.GenerateRandomNumber(0, 3);
                var categories = new List<Category>();
                for (int j = 0; j < categoriesCount; j++)
                {
                    categories.Add(db.Categories.Find(categoryIds[rnd.GenerateRandomNumber(0, categoryIds.Count - 1)]));
                }

                db.Toys.Add(
                    new Toy()
                        {
                            AgeRangeId = ageRangeIds[rnd.GenerateRandomNumber(0, ageRangeIds.Count - 1)],
                            Name = rnd.GenerateRandomStringWithRandomLength(5, 25),
                            Color = rnd.GenerateRandomStringWithRandomLength(5, 20),
                            ManufacturerId = manufacturerIds[rnd.GenerateRandomNumber(0, manufacturerIds.Count - 1)],
                            Price = (decimal)rnd.GenerateRandomDouble(0.3, 999.95),
                            Type = rnd.GenerateRandomStringWithRandomLength(5, 20),
                            Categories = categories
                        });
                index++;
                
                if (index%100==0)
                {
                    db.SaveChanges();
                    Console.Write(".");
                }
            }

            db.SaveChanges();
        }
    }
}

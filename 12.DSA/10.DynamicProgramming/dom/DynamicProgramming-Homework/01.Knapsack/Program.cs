using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>()
                               {
                                   new Product() { Name = "beer", Weight = 3, Cost = 2 },
                                   new Product() { Name = "vodka", Weight = 8, Cost = 12 },
                                   new Product() { Name = "cheese", Weight = 4, Cost = 5 },
                                   new Product() { Name = "nuts", Weight = 1, Cost = 4 },
                                   new Product() { Name = "ham", Weight = 2, Cost = 3 },
                                   new Product() { Name = "whiskey", Weight = 8, Cost = 13 }
                               };

            Console.Write("M=");
            int m = int.Parse(Console.ReadLine());

            var possible = new List<Product>[m + 1];
            possible[0] = new List<Product>();
            var currentmaxPricetListIndex = 0;
            foreach (var product in products)
            {
                if (product.Weight <= m)
                {
                    for (int i = possible.Length-1; i >= 0; i--)
                    {
                        if (possible[i]!=null)
                        {
                            if (i+product.Weight<=m)
                            {
                                possible[i + product.Weight] = new List<Product>(possible[i]);
                                possible[i+product.Weight].Add(product);
                                if (possible[currentmaxPricetListIndex].Sum(x=>x.Cost)<possible[i+product.Weight].Sum(x=>x.Cost))
                                {
                                    currentmaxPricetListIndex = i + product.Weight;
                                }
                            }
                            
                        }
                    }
                }
                
            }

            Console.WriteLine("The list of products with maximal price within the kg limit is:");
            Console.WriteLine(
                              string.Join(
                                          "\n",
                                          possible[currentmaxPricetListIndex].Select(
                                                                                     x =>
                                                                                     new { x.Name, x.Weight, x.Cost })));


            Console.WriteLine("Total price: {0}",possible[currentmaxPricetListIndex].Sum(x=>x.Cost));
        }
    }
}

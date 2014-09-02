namespace NorthWindTasks
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            //Uncomment the one yu want to see :)

            //Customers.AddCustomer(new Customer() { CustomerID = "ASDFG",CompanyName = "Alabala tralala"});

            //Console.WriteLine("Using LINQ:");
            //var customers = Customers.GetCustomersByOrder(1997, "Canada");
            //foreach (var customer in customers)
            //{
            //    Console.WriteLine(customer.ContactName);
            //}

            //Console.WriteLine("-------------------------------------");
            //Console.WriteLine("Using Native:");

            //customers = Customers.GetCustomersByOrderNative(1997, "Canada");
            //foreach (var customer in customers)
            //{
            //    Console.WriteLine(customer.ContactName);
            //}

            //Console.WriteLine("---------Sales in period 1980-2003 to region RJ");
            //var sales = Customers.FindSales(new DateTime(1980,1,1), new DateTime(2003,1,1), "RJ");
            //foreach (var sale in sales)
            //{
            //    Console.WriteLine(sale.ShipName+" on "+sale.ShippedDate+" to "+sale.ShipCountry);
            //}

            //using (var firstContext=new NORTHWNDEntities())
            //{
            //    using (var secondContext = new NORTHWNDEntities())
            //    {
            //        var customers2 = secondContext.Customers.Where(x => x.Address.ToLower().StartsWith("a"));
            //        customers2.FirstOrDefault().Country = "aaa";
            //        secondContext.SaveChanges();
            //        var customers1 = firstContext.Customers.Where(x => x.Address.ToLower().StartsWith("a"));
            //        customers1.FirstOrDefault().Country = "aaa";
            //        firstContext.SaveChanges();
            //    }
            //}
            //var order = new Order()
            //                {

            //                };
            //using (var c = new NORTHWNDEntities())
            //{
            //    c.Orders.Add(order);
            //    c.SaveChanges();
            //}
            //var details = new List<Order_Detail>()
            //                  {
            //                      new Order_Detail
            //                          {
            //                              Discount = 0.7f,
            //                              OrderID = order.OrderID,
            //                              ProductID = 15,
            //                              Quantity = 2,
            //                              UnitPrice = 23
            //                          }
            //                  };
            //AddOrder(order, details);

            //using (var db=new NORTHWNDEntities())
            //{
            //    var totalIncome = db.usp_FindTotalIncome(new DateTime(1990, 1, 1), new DateTime(2005, 1, 1), "Exotic Liquids");
            //    Console.WriteLine(totalIncome.First());
            //}
        }

        static void AddOrder(Order order, List<Order_Detail> details)
        {
            using (var ctx = new NORTHWNDEntities())
            {
                using (var tran = ctx.Database.BeginTransaction(IsolationLevel.Serializable))
                {
                    ctx.Orders.Add(order);
                    ctx.SaveChanges();
                    foreach (var orderDetail in details)
                    {
                        ctx.Order_Details.Add(orderDetail);
                    }
                    ctx.SaveChanges();
                    tran.Commit();
                }

            }
        }
    }
}
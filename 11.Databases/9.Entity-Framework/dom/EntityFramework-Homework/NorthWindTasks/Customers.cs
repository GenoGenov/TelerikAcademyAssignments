using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindTasks
{
    using System.Data.Entity;
    using System.Linq.Expressions;

    public static class Customers
    {
        private static NORTHWNDEntities context;

        public static void AddCustomer(Customer customer)
        {
            using (context=new NORTHWNDEntities())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public static void AddCustomer(string companyName, string contactName,string contactTitle, string address, string city, string region)
        {
            using (context=new NORTHWNDEntities())
            {
                context.Customers.Add(
                new Customer()
                    {
                        Address = address,
                        City = city,
                        CompanyName = companyName,
                        ContactName = contactName,
                        ContactTitle = contactTitle,
                        Region = region
                    });
                context.SaveChanges();
            }
            
        }

        public static Customer RemoveCustomer(int id)
        {
            using (context=new NORTHWNDEntities())
            {
                var customer = context.Customers.Find(id);
                context.Customers.Remove(customer);
                return customer;
                context.SaveChanges();
            }
        }

        public static Customer RemoveCustomer(string contactName)
        {
            using (context=new NORTHWNDEntities())
            {
                var customer = context.Customers.First(x => x.ContactName == contactName);
                context.Customers.Remove(customer);
                return customer;
                context.SaveChanges();
            }
        }

        public static void ModifyCustomer(Expression<Func<Customer, bool>> exp, Customer newData)
        {
            using (context=new NORTHWNDEntities())
            {
                var customer = context.Customers.First(exp);
                customer = newData;
                context.SaveChanges();
            }
        }

        public static ICollection<Customer> GetCustomersByOrder(int orderDate, string orderCountry)
        {
            using (context=new NORTHWNDEntities())
            {
                var customers =
                    context.Orders.Where(
                        x => x.OrderDate.Value.Year == orderDate &&
                             x.ShipCountry == orderCountry)
                           .Select(x => x.Customer);

                return customers.ToList();
            }
        }

        public static ICollection<Customer> GetCustomersByOrderNative(int orderDate, string orderCountry)
        {
            using (context=new NORTHWNDEntities())
            {
                var customers = context.Database.SqlQuery<Customer>(
                    "SELECT * FROM Customers c INNER JOIN Orders o"
                    + " ON c.CustomerID=o.CustomerID" + 
                    " WHERE DATEPART ( year , o.OrderDate )=" + orderDate + " AND o.ShipCountry=" + "'" + orderCountry + "'");
                return customers.ToList();
            }
        }

        public static ICollection<Order> FindSales(DateTime start, DateTime end, string region)
        {
            using (context=new NORTHWNDEntities())
            {
                var orders =
                    context.Orders.Where(x => x.OrderDate >= start && x.OrderDate <= end && x.ShipRegion == region);
                    
                return orders.ToList();
            }
        }
    }
}

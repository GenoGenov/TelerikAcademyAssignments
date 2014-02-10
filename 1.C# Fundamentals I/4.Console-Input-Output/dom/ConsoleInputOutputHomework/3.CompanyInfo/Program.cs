using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.CompanyInfo
{
    class Program
    {
        struct Company
        {
            static string name;
            static string address;
            static string phoneNumber;
            static string faxNumber;
            static string webSite;
            Manager manager;
            public struct Manager
            {
                static string firstName;
                static string lastName;
                static int age;
                static string phoneNumber;

                public Manager(int x)
                {
                    Console.WriteLine("Manager First Name");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Manager Last Name" );
                    lastName = Console.ReadLine();
                    Console.WriteLine("Manager age:");
                    age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Manager Phone Number");
                    phoneNumber = Console.ReadLine();

                }

                public static string ToString()
                {
                    return string.Format("Manager Info:\n{0,15} {1,-5}\n{2,15} {3,-5}\n{4,15} {5,-5}\n{6,15} {7,-5}","First Name:",firstName,"Last Name:",lastName,"Age:",age,"Phone Number:",phoneNumber);
                }
            }

            public Company(Manager man)
            {
                Console.WriteLine("Company Name:");
                name = Console.ReadLine();
                Console.WriteLine("Company Address:");
                address = Console.ReadLine();
                Console.WriteLine("Company Phone Number:");
                phoneNumber=Console.ReadLine();
                Console.WriteLine("Company Fax Number:");
                faxNumber = Console.ReadLine();
                Console.WriteLine("company Web Site:");
                webSite = Console.ReadLine();
            }

            override public string ToString()
            {

                return string.Format("Company Info:\n{0,15} {1,-5}\n{2,15} {3,-5}\n{4,15} {5,-5}\n{6,15} {7,-5}\n{8,15} {9,-5}\n\n\n{10}", "Name :", name, "Address :", address, "Phone Number :", phoneNumber, "Fax Number :", faxNumber, "WebSite :", webSite,Manager.ToString());
            }

        }
        static void Main(string[] args)
        {
          
            Company.Manager man=new Company.Manager(2);
            Company company = new Company(man);
            Console.WriteLine(company.ToString());
        }
    }
}

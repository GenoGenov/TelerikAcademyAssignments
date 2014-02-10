using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketingFirm
{
    class EmployeeInfo
    {
        struct Employees
        {
            public string firstName;
            public string familyName;
            public string gender;
            public int age;
            public String ID;
            private long employeeNumber;
            public void setNum(long x)
            {
                employeeNumber = x;
            }
            public long getNum()
            {
                return employeeNumber;
            }      
            public override string ToString() 
            {
                string info=string.Format("First Name: {0}\nFamily Name: {1}\nGender: {2}\nAge: {3}\nID: {4}\nUnique Employee Number: {5}",firstName,familyName,gender,age,ID,getNum());
                return info;
            }
        }
        static void Main(string[] args)
        {
            Employees goshko = new Employees();
            Console.Write("First Name:");
            goshko.firstName = Console.ReadLine();
            Console.Write("Family Name:");
            goshko.familyName =Console.ReadLine();
            Console.Write("Gender:");
            goshko.gender = Console.ReadLine();
            Console.Write("Age:");
            bool imput=Int32.TryParse(Console.ReadLine(), out goshko.age);
            bool imput2;
            bool imput4;
            if(!imput)
            {
                do
	                {
	                    Console.WriteLine("Incorrect Data!!! Try again:");
                        imput2=Int32.TryParse(Console.ReadLine(), out goshko.age);
	                } 
                while (!imput2);
            }
            Console.Write("ID:");
            goshko.ID = Console.ReadLine();
            Console.Write("Emplyee Number:");
            long d;
            bool imput3 = Int64.TryParse(Console.ReadLine(), out d);
            if (!imput3 || d < 27560000 || d > 27569999)
            {
                do
                {
                    Console.Write("Incorrect Data!!! Must be between 27560000 and 27569999.Try again:");
                    imput4 = Int64.TryParse(Console.ReadLine(), out d);
                }
                while (!imput4 || d < 27560000 || d > 27569999);
            }
            goshko.setNum(d);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Whole info:\n\n{0}",goshko.ToString());
        }
    }
}

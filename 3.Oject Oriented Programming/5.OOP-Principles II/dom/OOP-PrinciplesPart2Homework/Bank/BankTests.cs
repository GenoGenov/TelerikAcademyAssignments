using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Bank
{
    public class BankTests
    {
        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var individ = new Individual("a");
            var company = new Company("company");
            var mortgage1 = new Mortgage(individ,4,5);
            var mortgage2 = new Mortgage(company,4,5);
            var loan = new Loan(company,3123000,3.2m);

            Console.WriteLine(mortgage1.CalculateInterest(7));
            Console.WriteLine(mortgage2.CalculateInterest(7));
            Console.WriteLine(loan.CalculateInterest(8));
        }
    }
}
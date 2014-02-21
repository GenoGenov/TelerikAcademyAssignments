using System;
using System.Linq;

namespace Bank
{
    internal class Loan : Account, IDepositable
    {
        #region Constructors
        public Loan(Customer customer, decimal balance, decimal interestrate) : base(customer, balance, interestrate)
        {
        }
        
        #endregion

        #region Methods
        
        public void MakeDeposit(decimal ammount)
        {
            this.Balance += ammount;
        }
        
        public override decimal CalculateInterest(int months)
        {
            if (this.Customer is Company)
            {
                return base.CalculateInterest(months - 2);
            }
            else
            {
                return base.CalculateInterest(months - 3);
            }
        }
        
        #endregion
    }
}
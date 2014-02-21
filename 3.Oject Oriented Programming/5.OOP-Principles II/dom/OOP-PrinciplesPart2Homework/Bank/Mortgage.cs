using System;
using System.Linq;

namespace Bank
{
    internal class Mortgage : Account, IDepositable
    {
        #region Constructors
        public Mortgage(Customer customer, decimal balance, decimal interestrate) : base(customer, balance, interestrate)
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
                if (months >= 12)
                {
                    return base.CalculateInterest(12) / 2.0m + base.CalculateInterest(months - 12);
                }
                return base.CalculateInterest(months) / 2.0m;
            }
            else
            {
                return base.CalculateInterest(months - 6);
            }
        }
        
        #endregion
    }
}
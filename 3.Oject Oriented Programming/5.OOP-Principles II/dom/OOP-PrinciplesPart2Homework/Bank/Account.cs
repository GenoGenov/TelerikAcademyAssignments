using System;
using System.Linq;

namespace Bank
{
    public abstract class Account
    {
        #region Constructor
        protected Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }
        
        #endregion

        #region Properties
        
        public Customer Customer { get; protected set; }
        
        public decimal InterestRate { get; protected set; }
        
        protected decimal Balance { get; set; }
        
        #endregion

        #region Virtual Methods
        
        public virtual decimal CalculateInterest(int months)
        {
            if (months > 0)
            {
                return this.InterestRate * (decimal)months;
            }
            return 0;
        }
        
        #endregion
    }
}
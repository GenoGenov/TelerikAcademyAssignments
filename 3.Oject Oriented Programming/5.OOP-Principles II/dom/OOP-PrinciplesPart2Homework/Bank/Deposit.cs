using System;
using System.Linq;

namespace Bank
{
    internal class Deposit : Account, IDepositable, IWithdrawable
    {
        #region Constructors
        
        public Deposit(Customer customer, decimal balance, decimal interestrate) : base(customer, balance, interestrate)
        {
        }
        
        #endregion
        
        #region Methods
        
        public void MakeDeposit(decimal ammount)
        {
            this.Balance += ammount;
        }
        
        public bool Withdraw(decimal ammount)
        {
            this.Balance -= ammount;
            return this.Balance <= 0;
        }
        
        public override decimal CalculateInterest(int months)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            return base.CalculateInterest(months);
        }
    
        #endregion
    }
}
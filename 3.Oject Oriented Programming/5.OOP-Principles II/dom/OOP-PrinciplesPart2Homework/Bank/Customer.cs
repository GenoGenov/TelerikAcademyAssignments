using System;
using System.Linq;

namespace Bank
{
    public abstract class Customer
    { 
        #region Properties
        protected string name;
        
        protected Guid id;
        
        #endregion

        #region Constructor
        
        protected Customer(string name)
        {
            this.name = name;
        }
        
        #endregion

        #region Properties
        
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be null or empty");
                }
                this.name = value;
            }
        }
        
        #endregion
    }
}
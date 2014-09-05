namespace ATM.Data
{
    using System;
    using System.Collections.Generic;

    using ATM.Model;

    using StudentSystem.Data;
    using StudentSystem.Data.Repositories;

    public class ATMData : IATMData,IDisposable
    {
        private IATMDbContext context;
        private IDictionary<Type, object> repositories;

        public ATMData()
            : this(new ATMEntities())
        {
        }


        public IGenericRepository<WithdrawalLog> WithdrawalLogs
        {
            get
            {
                return this.GetRepository<WithdrawalLog>();
            }
        }

        public IGenericRepository<CardAccount> CardAccounts
        {
            get
            {
                return this.GetRepository<CardAccount>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public ATMData(IATMDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}

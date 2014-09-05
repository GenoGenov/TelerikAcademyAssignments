using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;

    using ATM.Data.Migrations;
    using ATM.Model;

    public class ATMEntities:DbContext,IATMDbContext
    {
        public ATMEntities():base("ATM")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATMEntities, Configuration>());

        }
        public IDbSet<CardAccount> CardAccounts { get; set; }

        public IDbSet<WithdrawalLog> WithdrawalLogs { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if (entityEntry.Entity is CardAccount)
            {
                var acc = entityEntry.Cast<CardAccount>();
                if (acc.Property(x => x.CardCash).CurrentValue < 0)
                {
                    throw new DbEntityValidationException("The card ballance cannot be less than 0");
                }
            }
            return base.ValidateEntity(entityEntry, items);
        }
    }
}

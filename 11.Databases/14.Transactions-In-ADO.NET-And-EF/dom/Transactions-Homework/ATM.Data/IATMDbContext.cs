namespace ATM.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using ATM.Model;

    public interface IATMDbContext:IDisposable
    {
        IDbSet<CardAccount> CardAccounts { get; set; }

        IDbSet<WithdrawalLog> WithdrawalLogs { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}

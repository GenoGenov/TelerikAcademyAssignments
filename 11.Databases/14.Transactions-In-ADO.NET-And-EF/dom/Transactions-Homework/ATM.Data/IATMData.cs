namespace ATM.Data
{
    using ATM.Model;

    using StudentSystem.Data.Repositories;

    public interface IATMData
    {
        IGenericRepository<WithdrawalLog> WithdrawalLogs { get; }

        IGenericRepository<CardAccount> CardAccounts { get; }
    }
}
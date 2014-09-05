namespace StudentSystem.Data.Repositories
{
    using ATM.Data;
    using ATM.Model;

using System.Linq;

    public class CardAccountsRepository : GenericRepository<CardAccount>, IGenericRepository<CardAccount>
    {
        public CardAccountsRepository(IATMDbContext context)
            : base(context)
        {

        }

        public IQueryable<CardAccount> AllAccounts(decimal balance)
        {
            return this.All().Where(x => x.CardCash == balance);
        }
    }
}

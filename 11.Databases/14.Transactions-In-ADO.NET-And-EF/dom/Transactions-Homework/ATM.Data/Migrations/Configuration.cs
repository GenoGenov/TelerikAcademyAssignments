namespace ATM.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using ATM.Model;

    public sealed class Configuration : DbMigrationsConfiguration<ATM.Data.ATMEntities>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ATMEntities context)
        {
            
                context.CardAccounts.AddOrUpdate(
                  new CardAccount { CardCash = 12345.67m,CardPIN = "1234",Cardnumber = "9235489217"},
                  new CardAccount { CardCash = 83653.45m, CardPIN = "8834", Cardnumber = "7326832693" },
                  new CardAccount { CardCash = 55468432m, CardPIN = "2222", Cardnumber = "8424678555" }
                );
            context.SaveChanges();

        }
    }
}